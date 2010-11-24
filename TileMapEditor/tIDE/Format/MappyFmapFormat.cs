using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using xTile;
using xTile.Format;
using System.Windows.Forms;
using System.Drawing;

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

            MphdHeader mphdHeader = null;
            Color[] colourMap = null;

            Map map = new Map();

            foreach (Chunk chunk in MapChunks(stream))
            {
                //MessageBox.Show("Chunk ID = " + chunk.Id + ", Len = " + chunk.Data.Length);

                if (chunk.Id == "ATHR")
                    ReadChunkATHR(stream, chunk, map);
                else if (chunk.Id == "MPHD")
                    mphdHeader = ReadChunkMPHD(stream, chunk);
                else if (chunk.Id == "CMAP")
                    colourMap = ReadChunkCMAP(stream, chunk);

            }

            return map;
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

        private byte ReadByte(Stream stream)
        {
            int byt = stream.ReadByte();
            if (byt < 0)
                throw new Exception("Unexpected end of file while reading unsigned byte");
            return (byte)byt;
        }

        private sbyte ReadSignedByte(Stream stream)
        {
            int byt = stream.ReadByte();
            if (byt < 0)
                throw new Exception("Unexpected end of file while reading signed byte");
            return (sbyte)byt;
        }

        private short ReadShortMsb(Stream stream)
        {
            byte[] shortBytes = new byte[2];

            long position = stream.Position;
            if (stream.Read(shortBytes, 0, 2) != 2)
                throw new Exception("Error reading MSB short int at position " + position);

            short value = (short)((shortBytes[0] << 8) | shortBytes[1]);

            return value;
        }

        private short ReadShortLsb(Stream stream)
        {
            byte[] shortBytes = new byte[2];

            long position = stream.Position;
            if (stream.Read(shortBytes, 0, 2) != 2)
                throw new Exception("Error reading MSB short int at position " + position);

            short value = (short)((shortBytes[1] << 8) | shortBytes[0]);

            return value;
        }

        private short ReadShort(Stream stream, bool lsb)
        {
            return lsb ? ReadShortLsb(stream) : ReadShortMsb(stream);
        }

        private long ReadLongMsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading MSB long at position " + position);

            long value = (longBytes[0] << 24) | (longBytes[1] << 16)
                | (longBytes[2] << 8) | longBytes[3];

            return value;
        }

        private long ReadLongLsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading LSB long at position " + position);

            long value = (longBytes[3] << 24) | (longBytes[2] << 16)
                | (longBytes[1] << 8) | longBytes[0];

            return value;
        }

        private long ReadLong(Stream stream, bool lsb)
        {
            return lsb ? ReadLongLsb(stream) : ReadLongMsb(stream);
        }

        private string ReadSequence(Stream stream, int count)
        {
            try
            {
                byte[] byteSequence = new byte[count];

                long position = stream.Position;
                if (stream.Read(byteSequence, 0, count) != count)
                    throw new Exception("Unexpected end of file while reading sequence of " + count + " bytes at position " + position);

                return ASCIIEncoding.ASCII.GetString(byteSequence);
            }
            catch (Exception exception)
            {
                throw new Exception("Error while reading char sequence of lengh " + count, exception);
            }
        }

        private void ReadSequence(Stream stream, string sequence)
        {
            try
            {
                long position = stream.Position;
                string readSequence = ReadSequence(stream, sequence.Length);

                if (readSequence != sequence)
                    throw new Exception("Expected sequence '" + sequence + "' at position " + position);
            }
            catch (Exception exception)
            {
                throw new Exception("Error wile matching char sequence '" + sequence + "'", exception);
            }
        }

        private void ReadHeader(Stream stream)
        {
            ReadSequence(stream, "FORM");
            long storedLength = ReadLongMsb(stream);
            long actualLength = stream.Length - 8;
            if (storedLength != actualLength)
                throw new Exception(
                    "Mappy Header: File body length mismatch: stored = " + storedLength + ", actual = " + actualLength);
            ReadSequence(stream, "FMAP");
        }

        private Chunk MapChunk(Stream stream)
        {
            string chunkId = ReadSequence(stream, 4);
            long chunkLength = ReadLongMsb(stream);
            if (chunkLength > int.MaxValue)
                throw new Exception("Chunk sizes greater than " + int.MaxValue + " not supported");
            if (stream.Position + chunkLength > stream.Length)
                throw new Exception("Lenght of chunk '" + chunkId + "' exceeds end of file");

            Chunk chunk = new Chunk();
            chunk.Id = chunkId;
            chunk.FilePosition = stream.Position;
            chunk.Length = (int) chunkLength;

            stream.Position += chunkLength;

            return chunk;
        }

        private IEnumerable<Chunk> MapChunks(Stream stream)
        {
            List<Chunk> chunks = new List<Chunk>();
            while (stream.Position < stream.Length)
            {
                Chunk chunk = MapChunk(stream);
                chunks.Add(chunk);
            }
            return chunks;
        }

        private void ReadChunkATHR(Stream stream, Chunk chunk, Map map)
        {
            stream.Position = chunk.FilePosition;
            byte[] chunkData = new byte[chunk.Length];
            stream.Read(chunkData, 0, chunk.Length);
            string authors = ASCIIEncoding.ASCII.GetString(chunkData);
            string[] authorLines = authors.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string authorLine in authorLines)
                stringBuilder.AppendLine(authorLine);
            map.Description = stringBuilder.ToString();
        }

        private MphdHeader ReadChunkMPHD(Stream stream, Chunk chunk)
        {
            MphdHeader mphdHeader = new MphdHeader();

            stream.Position = chunk.FilePosition;
            mphdHeader.VersionHigh = ReadSignedByte(stream);
            mphdHeader.VersionLow = ReadSignedByte(stream);
            mphdHeader.LSB = ReadSignedByte(stream) != 0;
            mphdHeader.MapType = ReadSignedByte(stream);
            mphdHeader.MapWidth = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.MapHeight = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.Reserved1 = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.Reserved2 = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.BlockWidth = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.BlockHeight = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.BlockDepth = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.BlockStructSize = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.NumBlockStruct = ReadShort(stream, mphdHeader.LSB);
            mphdHeader.NumBlockGfx = ReadShort(stream, mphdHeader.LSB);

            if (chunk.Length > 24)
            {
                mphdHeader.ColourKeyIndex = ReadByte(stream);
                mphdHeader.ColourKeyRed = ReadByte(stream);
                mphdHeader.ColourKeyGreen = ReadByte(stream);
                mphdHeader.ColourKeyBlue = ReadByte(stream);

                if (chunk.Length > 28)
                {
                    mphdHeader.BlockGapX = ReadShort(stream, mphdHeader.LSB);
                    mphdHeader.BlockGapY = ReadShort(stream, mphdHeader.LSB);
                    mphdHeader.BlockStaggerX = ReadShort(stream, mphdHeader.LSB);
                    mphdHeader.BlockStaggerY = ReadShort(stream, mphdHeader.LSB);

                    if (chunk.Length > 36)
                    {
                        mphdHeader.ClickMask = ReadShort(stream, mphdHeader.LSB);
                        mphdHeader.Pillars = ReadShort(stream, mphdHeader.LSB);
                    }
                }
            }

            return mphdHeader;
        }

        private Color[] ReadChunkCMAP(Stream stream, Chunk chunk)
        {
            stream.Position = chunk.FilePosition;
            int colourCount = chunk.Length / 3;
            Color[] colourMap = new Color[colourCount];
            for (int index = 0; index < colourCount; index++)
            {
                byte red = ReadByte(stream);
                byte green = ReadByte(stream);
                byte blue = ReadByte(stream);
                Color colour = Color.FromArgb(red, green, blue);
                colourMap[index] = colour;
            }

            return colourMap;
        }

        #endregion

        #region Private Classes

        private struct Chunk
        {
            internal string Id;
            internal long FilePosition;
            internal int Length;
        }

        private class MphdHeader
        {
            internal sbyte VersionHigh;
            internal sbyte VersionLow;
            internal bool LSB;
            internal sbyte MapType;
            internal short MapWidth;
            internal short MapHeight;
            internal short Reserved1;
            internal short Reserved2;
            internal short BlockWidth;
            internal short BlockHeight;
            internal short BlockDepth;
            internal short BlockStructSize;
            internal short NumBlockStruct;
            internal short NumBlockGfx;
            internal byte ColourKeyIndex;
            internal byte ColourKeyRed;
            internal byte ColourKeyGreen;
            internal byte ColourKeyBlue;
            internal short BlockGapX;
            internal short BlockGapY;
            internal short BlockStaggerX;
            internal short BlockStaggerY;
            internal short ClickMask;
            internal short Pillars;
        }

        #endregion
    }
}
