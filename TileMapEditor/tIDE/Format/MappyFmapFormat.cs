using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using xTile;
using xTile.Format;
using System.Windows.Forms;

namespace tIDE.Format
{
    internal class MappyFmapFormat: IMapFormat
    {
        #region Public Methods

        public CompatibilityReport DetermineCompatibility(xTile.Map map)
        {
            throw new NotImplementedException();
        }

        public Map Load(Stream stream)
        {
            ReadHeader(stream);
            foreach (Chunk chunk in ReadChunks(stream))
            {
                MessageBox.Show("Chunk ID = " + chunk.Id + ", Len = " + chunk.Data.Length);
            }

            return null;
        }

        public void Store(Map map, Stream stream)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get { return "Mappy FMP Format"; }
        }

        public string FileExtensionDescriptor
        {
            get { return "Mappy FMP Files (*.fmp)"; }
        }

        public string FileExtension
        {
            get { return "fmp"; }
        }

        #endregion

        #region Private Methods

        private string ReadSequence(Stream stream, int count)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (count-- > 0)
            {
                int byt = stream.ReadByte();
                if (byt < 0)
                    break;
                stringBuilder.Append((char)byt);
            }

            return stringBuilder.ToString();
        }

        private void ReadSequence(Stream stream, string sequence)
        {
            long position = stream.Position;
            string readSequence = ReadSequence(stream, sequence.Length);

            if (readSequence != sequence)
                throw new Exception("Expected sequence '" + sequence + "' at position " + position);
        }

        private long ReadLong(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading long at position " + position);

            long value = (longBytes[0] << 24) | (longBytes[1] << 16)
                | (longBytes[2] << 8) | longBytes[3];

            return value;
        }

        private void ReadHeader(Stream stream)
        {
            ReadSequence(stream, "FORM");
            long storedLength = ReadLong(stream);
            long actualLength = stream.Length - 8;
            if (storedLength != actualLength)
                throw new Exception(
                    "Mappy Header: File body length mismatch: stored = " + storedLength + ", actual = " + actualLength);
            ReadSequence(stream, "FMAP");
        }

        private Chunk ReadChunk(Stream stream)
        {
            string chunkId = ReadSequence(stream, 4);
            long chunkLength = ReadLong(stream);
            byte[] chunkData = new byte[chunkLength];
            if (stream.Read(chunkData, 0, (int) chunkLength) != chunkLength)
                throw new Exception("End-of-file reading data for chuck id " + chunkId);

            Chunk chunk = new Chunk();
            chunk.Id = chunkId;
            chunk.Data = chunkData;
            return chunk;
        }

        private IEnumerable<Chunk> ReadChunks(Stream stream)
        {
            List<Chunk> chunks = new List<Chunk>();
            while (stream.Position < stream.Length)
            {
                Chunk chunk = ReadChunk(stream);
                chunks.Add(chunk);
            }
            return chunks;
        }

        #endregion

        #region Private Classes

        private struct Chunk
        {
            internal string Id;
            internal byte[] Data;
        }

        #endregion
    }
}
