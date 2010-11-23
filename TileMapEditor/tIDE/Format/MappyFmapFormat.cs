using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using xTile;
using xTile.Format;

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
            throw new NotImplementedException();
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
            return 0;
        }

        private void LoadHeader(Stream stream)
        {
            byte[] headerForm = new byte[4];
            if (stream.Read(headerForm, 0, 4) != 4)
                throw new Exception("Mappy Header: Unexpected end of file at position " + stream.Position);
            ReadSequence(stream, "FORM");
        }

        #endregion

        #region Private Classes

        private class Chunk
        {
            private string m_strHeader;
            private byte[] m_data;
        }

        #endregion
    }
}
