/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  LICENSE    Microsoft Public License (Ms-PL)                            //
//             http://www.opensource.org/licenses/ms-pl.html               //
//                                                                         //
//  AUTHOR     Colin Vella                                                 //
//                                                                         //
//  CODEBASE   http://tide.codeplex.com                                    //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using xTile.ObjectModel;
using xTile.Tiles;
using xTile.Layers;
using xTile.Dimensions;

namespace xTile.Format
{
    class TbinFormat : IMapFormat
    {
        #region Public Methods

        public TbinFormat()
        {
            m_compatibilityResults = new CompatibilityReport();
            m_tbinSequence = "tBIN10".ToArray().Select(x => (byte)x).ToArray();
        }

        /// <summary>
        /// Determines the map compatibility with tIDE. This is implicitly
        /// supported in full
        /// </summary>
        /// <param name="map">Map to analyse</param>
        /// <returns>Format compatibility report</returns>
        public CompatibilityReport DetermineCompatibility(Map map)
        {
            // trivially compatible
            return m_compatibilityResults;
        }

        public Map Load(Stream stream)
        {
            Map map = new Map();

            LoadSequence(stream, m_tbinSequence);
            map.Id = LoadString(stream);
            map.Description = LoadString(stream);
            LoadProperties(stream, map);
            LoadTileSheets(stream, map);
            LoadLayers(stream, map);

            return map;
        }

        public void Store(Map map, Stream stream)
        {
            StoreSequence(stream, m_tbinSequence);
            StoreString(stream, map.Id);
            StoreString(stream, map.Description);
            StoreProperties(stream, map);
            StoreTileSheets(stream, map);
            StoreLayers(stream, map);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// tIDE binary map format name
        /// </summary>
        public string Name
        {
            get { return "tIDE Binary Map File"; }
        }

        /// <summary>
        /// tIDE map format descriptor
        /// </summary>
        public string FileExtensionDescriptor
        {
            get { return "tIDE Binary Map Files (*.tbin)"; }
        }

        /// <summary>
        /// tIDE file extension (.tide)
        /// </summary>
        public string FileExtension
        {
            get { return "tbin"; }
        }

        #endregion

        #region Private Methods

        private void StoreSequence(Stream stream, byte[] sequence)
        {
            stream.Write(sequence, 0, sequence.Length);
        }

        private byte[] LoadSequence(Stream stream, int sequenceLength)
        {
            byte[] sequence = new byte[sequenceLength];
            if (stream.Read(sequence, 0, sequenceLength) != sequenceLength)
                throw new Exception(
                    "Unexpected end of file while reading sequence of length: " + sequenceLength);
            return sequence;
        }

        private void LoadSequence(Stream stream, byte[] expectedSequence)
        {
            byte[] sequence = LoadSequence(stream, expectedSequence.Length);
            for (int nIndex = 0; nIndex < sequence.Length; nIndex++)
                if (sequence[nIndex] != expectedSequence[nIndex])
                    throw new Exception(
                        "Byte sequence mismatch. Expected: " + expectedSequence + " Actual: " + sequence);
        }

        private void StoreBool(Stream stream, bool value)
        {
            stream.WriteByte((byte)(value ? 1 : 0));
        }

        private bool LoadBool(Stream stream)
        {
            return stream.ReadByte() > 0;
        }

        private void StoreInt16(Stream stream, Int16 value)
        {
            stream.WriteByte((byte)(value & 0xFF));
            stream.WriteByte((byte)((value >> 8) & 0xFF));
        }

        private Int16 LoadInt16(Stream stream)
        {
            byte[] bytes = LoadSequence(stream, 2);
            return (Int16)((bytes[1] << 8) | bytes[0]);
        }

        private void StoreInt32(Stream stream, Int32 value)
        {
            stream.WriteByte((byte)(value & 0xFF));
            stream.WriteByte((byte)((value >> 8) & 0xFF));
            stream.WriteByte((byte)((value >> 16) & 0xFF));
            stream.WriteByte((byte)((value >> 24) & 0xFF));
        }

        private Int32 LoadInt32(Stream stream)
        {
            byte[] bytes = LoadSequence(stream, 4);
            return (Int32)((bytes[3] << 24) | (bytes[2] << 16) | (bytes[1] << 8) | bytes[0]);
        }

        private void StoreFloat(Stream stream, float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            StoreSequence(stream, bytes);
        }

        private float LoadFloat(Stream stream)
        {
            byte[] bytes = LoadSequence(stream, 4);
            return BitConverter.ToSingle(bytes, 0);
        }

        private void StoreString(Stream stream, string value)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(value);
            StoreInt32(stream, (short)bytes.Length);
            stream.Write(bytes, 0, bytes.Length);
        }

        private string LoadString(Stream stream)
        {
            int length = LoadInt32(stream);
            byte[] bytes = LoadSequence(stream, length);

            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(bytes, 0, length);
        }

        private void StoreSize(Stream stream, Size size)
        {
            StoreInt32(stream, size.Width);
            StoreInt32(stream, size.Height);
        }

        private Size LoadSize(Stream stream)
        {
            Dimensions.Size size = new Size();
            size.Width = LoadInt32(stream);
            size.Height = LoadInt32(stream);
            return size;
        }

        private void StoreProperties(Stream stream, Component component)
        {
            StoreInt32(stream, component.Properties.Count);
            foreach (string key in component.Properties.Keys)
            {
                StoreString(stream, key);
                PropertyValue propertyValue = component.Properties[key];
                if (propertyValue.Type == typeof(bool))
                {
                    stream.WriteByte(PROPERTY_BOOL);
                    StoreBool(stream, (bool)propertyValue);
                }
                else if (propertyValue.Type == typeof(bool))
                {
                    stream.WriteByte(PROPERTY_INT);
                    StoreInt32(stream, (int)propertyValue);
                }
                else if (propertyValue.Type == typeof(bool))
                {
                    stream.WriteByte(PROPERTY_FLOAT);
                    StoreFloat(stream, (float)propertyValue);
                }
                else if (propertyValue.Type == typeof(bool))
                {
                    stream.WriteByte(PROPERTY_STRING);
                    StoreString(stream, (string)propertyValue);
                }
                else
                    throw new Exception("Unsupported property type: " + propertyValue.Type);
            }
        }

        private void LoadProperties(Stream stream, Component component)
        {
            int propertyCount = LoadInt32(stream);
            while (propertyCount-- > 0)
            {
                string key = LoadString(stream);
                byte propertyType = (byte)stream.ReadByte();
                switch (propertyType)
                {
                    case PROPERTY_BOOL:
                        component.Properties[key] = LoadBool(stream);
                        break;
                    case PROPERTY_INT:
                        component.Properties[key] = LoadInt32(stream);
                        break;
                    case PROPERTY_FLOAT:
                        component.Properties[key] = LoadFloat(stream);
                        break;
                    case PROPERTY_STRING:
                        component.Properties[key] = LoadString(stream);
                        break;
                }
            }
        }

        private void StoreTileSheets(Stream stream, Map map)
        {
            StoreInt32(stream, map.TileSheets.Count);
            foreach (TileSheet tileSheet in map.TileSheets)
                StoreTileSheet(stream, tileSheet);
        }

        private void LoadTileSheets(Stream stream, Map map)
        {
            int tileSheetCount = LoadInt32(stream);
            while (tileSheetCount-- > 0)
                LoadTileSheet(stream, map);
        }

        private void StoreTileSheet(Stream stream, TileSheet tileSheet)
        {
            StoreString(stream, tileSheet.Id);
            StoreString(stream, tileSheet.Description);
            StoreString(stream, tileSheet.ImageSource);
            StoreSize(stream, tileSheet.SheetSize);
            StoreSize(stream, tileSheet.TileSize);
            StoreSize(stream, tileSheet.Margin);
            StoreSize(stream, tileSheet.Spacing);
            StoreProperties(stream, tileSheet);
        }

        private void LoadTileSheet(Stream stream, Map map)
        {
            string id = LoadString(stream);
            string description = LoadString(stream);
            string imageSource = LoadString(stream);
            Size sheetSize = LoadSize(stream);
            Size tileSize = LoadSize(stream);
            Size margin = LoadSize(stream);
            Size spacing = LoadSize(stream);
            TileSheet tileSheet = new TileSheet(id, map, imageSource, sheetSize, tileSize);
            tileSheet.Margin = margin;
            tileSheet.Spacing = spacing;
            map.AddTileSheet(tileSheet);
        }

        private void StoreLayers(Stream stream, Map map)
        {
            StoreInt32(stream, map.Layers.Count);
            foreach (Layer layer in map.Layers)
                StoreLayer(stream, layer);
        }

        private void LoadLayers(Stream stream, Map map)
        {
            int layerCount = LoadInt32(stream);
            while (layerCount-- > 0)
                LoadLayer(stream, map);
        }

        private void StoreLayer(Stream stream, Layer layer)
        {
            StoreString(stream, layer.Id);
            StoreBool(stream, layer.Visible);
            StoreString(stream, layer.Description);
            StoreSize(stream, layer.LayerSize);
            StoreSize(stream, layer.TileSize);

            TileSheet previousTileSheet = null;
            int nullCount = 0;

            for (int tileY = 0; tileY < layer.LayerHeight; tileY++)
            {
                for (int tileX = 0; tileX < layer.LayerWidth; tileX++)
                {
                    Tile currentTile = layer.Tiles[tileX, tileY];

                    if (currentTile == null)
                    {
                        ++nullCount;
                        continue;
                    }
                    else if (nullCount > 0)
                    {
                        stream.WriteByte((byte)'N');
                        StoreInt32(stream, nullCount);
                        nullCount = 0;
                    }

                    TileSheet currentTileSheet = currentTile.TileSheet;

                    if (previousTileSheet != currentTileSheet)
                    {
                        stream.WriteByte((byte)'T');
                        StoreString(stream, currentTileSheet == null ? "" : currentTileSheet.Id);

                        previousTileSheet = currentTileSheet;
                    }

                    if (currentTile is StaticTile)
                    {
                        //StoreStaticTile((StaticTile)currentTile, xmlWriter);
                    }
                    else if (currentTile is AnimatedTile)
                    {
                        AnimatedTile animatedTile = (AnimatedTile)currentTile;
                        //StoreAnimatedTile(animatedTile, xmlWriter);
                    }
                }

                if (nullCount > 0)
                {
                    stream.WriteByte((byte)'N');
                    StoreInt32(stream, nullCount);
                    nullCount = 0;
                }
            }

        }

        private void LoadLayer(Stream stream, Map map)
        {
        }

        #endregion

        #region Private Constants

        const byte PROPERTY_BOOL = 0;
        const byte PROPERTY_INT = 1;
        const byte PROPERTY_FLOAT = 2;
        const byte PROPERTY_STRING = 3;

        #endregion

        #region Private Variables

        private CompatibilityReport m_compatibilityResults;
        private byte[] m_tbinSequence;

        #endregion
    }
}
