using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using xTile;
using xTile.Format;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using xTile.Tiles;
using xTile.Layers;

namespace tIDE.Format
{
    internal class MappyFmapFormat: IMapFormat
    {
        #region Public Methods

        public CompatibilityReport DetermineCompatibility(xTile.Map map)
        {
            List<CompatibilityNote> compatibilityNotes = new List<CompatibilityNote>();

            if (map.TileSheets.Count != 1)
                compatibilityNotes.Add(
                    new CompatibilityNote(CompatibilityLevel.None, "Map must use exactly one tile sheet"));

            if (map.Layers.Count == 0)
                compatibilityNotes.Add(
                    new CompatibilityNote(CompatibilityLevel.None, "Map must have at least one layer"));

            if (map.Layers.Count > 8)
                compatibilityNotes.Add(
                    new CompatibilityNote(CompatibilityLevel.None, "Map must have no more than 8 layers"));

            xTile.Dimensions.Size layerSize = map.Layers[0].LayerSize;

            foreach (Layer layer in map.Layers)
                if (layer.LayerSize != layerSize)
                {
                    compatibilityNotes.Add(
                        new CompatibilityNote(CompatibilityLevel.None, "All layers must be of the same size"));
                    break;
                }

            xTile.Dimensions.Size tileSize = map.Layers[0].TileSize;
            foreach (Layer layer in map.Layers)
                if (layer.TileSize != tileSize)
                {
                    compatibilityNotes.Add
                        (new CompatibilityNote(CompatibilityLevel.None,
                            "All layers must share a common tile size dictated by the tile sheet"));
                    break;
                }

            if (map.Description.Split(new char[] { '\r', 'n' }, StringSplitOptions.RemoveEmptyEntries).Length > 4)
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.None, "Map description should not exceed 4 paragraphs"));

            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial, "Tile, layer and map attributes will not be stored"));

            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial, "Auto-tiling definitions will not be stored"));

            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial, "Brush definitions will not be stored"));

            CompatibilityReport compatibilityReport = new CompatibilityReport(compatibilityNotes);
            return compatibilityReport;
        }

        public Map Load(Stream stream)
        {
            ReadHeader(stream);

            MphdRecord mphdRecord = null;
            string[] authorLines = null;
            Color[] colourMap = null;
            BlockRecord[] blockRecords = null;
            AnimationRecord[] animationRecords = null;
            Image imageSource = null;
            short[][] layers = new short[8][];

            Dictionary<string, Chunk> chunks = MapChunks(stream);

            if (!chunks.ContainsKey("MPHD"))
                throw new Exception("Header chunk MPHD missing");
            Chunk mphdChunk = chunks["MPHD"];
            mphdRecord = ReadChunkMPHD(stream, mphdChunk);

            if (mphdRecord.BlockDepth == 8)
            {
                if (!chunks.ContainsKey("CMAP"))
                    throw new Exception("Colour map chuck CMAP is required for 8bit graphics blocks");
                Chunk cmapChunk = chunks["CMAP"];
                colourMap = ReadChunkCMAP(stream, cmapChunk);
            }

            if (chunks.ContainsKey("ATHR"))
                authorLines = ReadChunkATHR(stream, chunks["ATHR"]);

            if (!chunks.ContainsKey("BKDT"))
                throw new Exception("Block data chunk BKDT missing");
            Chunk bkdtChunk = chunks["BKDT"];
            blockRecords = ReadChunkBKDT(stream, bkdtChunk, mphdRecord);

            // optional ?
            if (chunks.ContainsKey("ANDT"))
            {
                Chunk andtChunk = chunks["ANDT"];
                animationRecords = ReadChunkANDT(stream, andtChunk, mphdRecord);
            }

            if (!chunks.ContainsKey("BGFX"))
                throw new Exception("Block graphics chunk BGFX missing");
            Chunk bgfxChunk = chunks["BGFX"];
            imageSource = ReadChuckBGFX(stream, bgfxChunk, mphdRecord, colourMap);

            if (!chunks.ContainsKey("BODY"))
                throw new Exception("Body chunk BODY missing");
            Chunk bodyChunk = chunks["BODY"];
            layers[0] = ReadChunkLayer(stream, bodyChunk, mphdRecord);

            // additional layers
            for (int layer = 1; layer <= 7; layer++)
            {
                string chunkId = "LYR" + layer;
                if (chunks.ContainsKey(chunkId))
                {
                    Chunk layerChuck = chunks[chunkId];
                    layers[layer] = ReadChunkLayer(stream, layerChuck, mphdRecord);
                }
            }

            // new map
            Map map = new Map();

            // attach ATHR lines as description
            if (authorLines != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string authorLine in authorLines)
                    stringBuilder.AppendLine(authorLine);
                map.Description = stringBuilder.ToString();
            }

            // prompt user to save tilesheet image source
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = "Portable Network Geaphics (*.png)|*.png";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Title = "Save tile sheet image source as";
            saveFileDialog.ValidateNames = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                throw new Exception("Mappy FMAP file import aborted");

            string tileSheetImageSource = saveFileDialog.FileName;

            imageSource.Save(tileSheetImageSource, ImageFormat.Png);

            // determine global tile size
            xTile.Dimensions.Size tileSize = new xTile.Dimensions.Size(mphdRecord.BlockWidth, mphdRecord.BlockHeight);

            // add tilesheet
            TileSheet tileSheet = new TileSheet(map, tileSheetImageSource,
                new xTile.Dimensions.Size(1, mphdRecord.NumBlockGfx), tileSize);
            map.AddTileSheet(tileSheet);

            // determine global map size
            xTile.Dimensions.Size mapSize = new xTile.Dimensions.Size(mphdRecord.MapWidth, mphdRecord.MapHeight);

            // create layers
            for (int layerIndex = 0; layerIndex < 8; layerIndex++)
            {
                if (layers[layerIndex] == null)
                    continue;

                string layerId = layerIndex == 0 ? "BODY" : "LYR" + layerIndex;
                Layer layer = new Layer(layerId, map, mapSize, tileSize);
                map.AddLayer(layer);
                for (int tileY = 0; tileY < mapSize.Height; tileY++)
                {
                    for (int tileX = 0; tileX < mapSize.Width; tileX++)
                    {
                        int layerOffset = tileY * mapSize.Width + tileX;
                        int tileIndex = layers[layerIndex][layerOffset];
                        if (tileIndex >= 0)
                        {
                            layer.Tiles[tileX, tileY] = new StaticTile(layer, tileSheet, BlendMode.Alpha, tileIndex);
                        }
                        else
                        {
                            AnimationRecord animationRecord = animationRecords[-tileIndex - 1];
                            StaticTile[] tileFrames = new StaticTile[animationRecord.Frames.Length];
                            for (int frameIndex = 0; frameIndex < animationRecord.Frames.Length; frameIndex++)
                            {
                                tileFrames[frameIndex] = new StaticTile(layer, tileSheet, BlendMode.Alpha, animationRecord.Frames[frameIndex]);
                            }
                            AnimatedTile animatedTile = new AnimatedTile(layer, tileFrames, (long)animationRecord.Delay * 20);
                            layer.Tiles[tileX, tileY] = animatedTile;
                        }
                    }
                }
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

        private byte ReadUnsignedByte(Stream stream)
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

        private ushort ReadUnsignedShortMsb(Stream stream)
        {
            byte[] shortBytes = new byte[2];

            long position = stream.Position;
            if (stream.Read(shortBytes, 0, 2) != 2)
                throw new Exception("Error reading MSB short int at position " + position);

            ushort value = (ushort)((shortBytes[0] << 8) | shortBytes[1]);

            return value;
        }

        private ushort ReadUnsignedShortLsb(Stream stream)
        {
            byte[] shortBytes = new byte[2];

            long position = stream.Position;
            if (stream.Read(shortBytes, 0, 2) != 2)
                throw new Exception("Error reading MSB short int at position " + position);

            ushort value = (ushort)((shortBytes[1] << 8) | shortBytes[0]);

            return value;
        }

        private ushort ReadUnsignedShort(Stream stream, bool lsb)
        {
            return lsb ? ReadUnsignedShortLsb(stream) : ReadUnsignedShortMsb(stream);
        }

        private ulong ReadUnsignedLongMsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading MSB long at position " + position);

            ulong value = (ulong)((longBytes[0] << 24) | (longBytes[1] << 16)
                | (longBytes[2] << 8) | longBytes[3]);

            return value;
        }

        private ulong ReadUnsignedLongLsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading LSB long at position " + position);

            ulong value = (ulong)((longBytes[3] << 24) | (longBytes[2] << 16)
                | (longBytes[1] << 8) | longBytes[0]);

            return value;
        }

        private ulong ReadUnsignedLong(Stream stream, bool lsb)
        {
            return lsb ? ReadUnsignedLongLsb(stream) : ReadUnsignedLongMsb(stream);
        }

        private long ReadSignedLongMsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading MSB long at position " + position);

            long value = (longBytes[0] << 24) | (longBytes[1] << 16)
                | (longBytes[2] << 8) | longBytes[3];

            return value;
        }

        private long ReadSignedLongLsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading LSB long at position " + position);

            long value = (longBytes[3] << 24) | (longBytes[2] << 16)
                | (longBytes[1] << 8) | longBytes[0];

            return value;
        }

        private long ReadSignedLong(Stream stream, bool lsb)
        {
            return lsb ? ReadSignedLongLsb(stream) : ReadSignedLongMsb(stream);
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
            long storedLength = ReadSignedLongMsb(stream);
            long actualLength = stream.Length - 8;
            if (storedLength != actualLength)
                throw new Exception(
                    "Mappy Header: File body length mismatch: stored = " + storedLength + ", actual = " + actualLength);
            ReadSequence(stream, "FMAP");
        }

        private Chunk MapChunk(Stream stream)
        {
            string chunkId = ReadSequence(stream, 4);
            long chunkLength = ReadSignedLongMsb(stream);
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

        private Dictionary<string, Chunk> MapChunks(Stream stream)
        {
            Dictionary<string, Chunk> chunks = new Dictionary<string, Chunk>();
            while (stream.Position < stream.Length)
            {
                Chunk chunk = MapChunk(stream);
                chunks[chunk.Id] = chunk;
            }
            return chunks;
        }

        private string[] ReadChunkATHR(Stream stream, Chunk chunk)
        {
            stream.Position = chunk.FilePosition;
            byte[] chunkData = new byte[chunk.Length];
            stream.Read(chunkData, 0, chunk.Length);
            string authors = ASCIIEncoding.ASCII.GetString(chunkData);
            string[] authorLines = authors.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            return authorLines;
        }

        private MphdRecord ReadChunkMPHD(Stream stream, Chunk chunk)
        {
            MphdRecord mphdRecord = new MphdRecord();

            stream.Position = chunk.FilePosition;
            mphdRecord.VersionHigh = ReadSignedByte(stream);
            mphdRecord.VersionLow = ReadSignedByte(stream);
            mphdRecord.LSB = ReadSignedByte(stream) != 0;
            mphdRecord.MapType = ReadSignedByte(stream);

            if (mphdRecord.MapType != 0)
                throw new Exception("Only MapType = 0 is supported");

            mphdRecord.MapWidth = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.MapHeight = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.Reserved1 = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.Reserved2 = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.BlockWidth = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.BlockHeight = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.BlockDepth = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.BlockStructSize = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.NumBlockStruct = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.NumBlockGfx = ReadShort(stream, mphdRecord.LSB);

            if (chunk.Length > 24)
            {
                mphdRecord.ColourKeyIndex = ReadUnsignedByte(stream);
                mphdRecord.ColourKeyRed = ReadUnsignedByte(stream);
                mphdRecord.ColourKeyGreen = ReadUnsignedByte(stream);
                mphdRecord.ColourKeyBlue = ReadUnsignedByte(stream);

                if (chunk.Length > 28)
                {
                    mphdRecord.BlockGapX = ReadShort(stream, mphdRecord.LSB);
                    mphdRecord.BlockGapY = ReadShort(stream, mphdRecord.LSB);
                    mphdRecord.BlockStaggerX = ReadShort(stream, mphdRecord.LSB);
                    mphdRecord.BlockStaggerY = ReadShort(stream, mphdRecord.LSB);

                    if (chunk.Length > 36)
                    {
                        mphdRecord.ClickMask = ReadShort(stream, mphdRecord.LSB);
                        mphdRecord.Pillars = ReadShort(stream, mphdRecord.LSB);
                    }
                }
            }

            return mphdRecord;
        }

        private Color[] ReadChunkCMAP(Stream stream, Chunk chunk)
        {
            stream.Position = chunk.FilePosition;
            int colourCount = chunk.Length / 3;
            Color[] colourMap = new Color[colourCount];
            for (int index = 0; index < colourCount; index++)
            {
                byte red = ReadUnsignedByte(stream);
                byte green = ReadUnsignedByte(stream);
                byte blue = ReadUnsignedByte(stream);
                Color colour = Color.FromArgb(red, green, blue);
                colourMap[index] = colour;
            }

            return colourMap;
        }

        private BlockRecord[] ReadChunkBKDT(Stream stream, Chunk chunk, MphdRecord mphdRecord)
        {
            BlockRecord[] blockRecords = new BlockRecord[mphdRecord.NumBlockStruct];
            bool lsb = mphdRecord.LSB;
            for(int index = 0; index < mphdRecord.NumBlockStruct; index++)
            {
                stream.Position = chunk.FilePosition + mphdRecord.BlockStructSize * index;

                BlockRecord blockRecord = new BlockRecord();
                blockRecord.BackgroundOffset = ReadSignedLong(stream, lsb);
                blockRecord.ForegroundOffset = ReadSignedLong(stream, lsb);
                blockRecord.BackgroundOffset2 = ReadSignedLong(stream, lsb);
                blockRecord.ForegroundOffset2 = ReadSignedLong(stream, lsb);
                blockRecord.User1 = ReadUnsignedLong(stream, lsb);
                blockRecord.User2 = ReadUnsignedLong(stream, lsb);
                blockRecord.User3 = ReadUnsignedShort(stream, lsb);
                blockRecord.User4 = ReadUnsignedShort(stream, lsb);
                blockRecord.User5 = ReadUnsignedByte(stream);
                blockRecord.User6 = ReadUnsignedByte(stream);
                blockRecord.User7 = ReadUnsignedByte(stream);
                blockRecord.Flags = ReadUnsignedByte(stream);
                blockRecords[index] = blockRecord;
            }

            return blockRecords;
        }

        private AnimationRecord[] ReadChunkANDT(Stream stream, Chunk chunk, MphdRecord mphdRecord)
        {
            bool lsb = mphdRecord.LSB;

            // temp
            stream.Position = chunk.FilePosition;
            byte[] buffer = new byte[chunk.Length];
            stream.Read(buffer, 0, chunk.Length);

            // count structures backwards
            stream.Position = chunk.FilePosition + chunk.Length - AnimationRecord.SIZE;
            int animationCount = 0;
            while (ReadSignedByte(stream) != -1)
            {
                ++animationCount;
                stream.Position -= (AnimationRecord.SIZE + 1);
            }

            AnimationRecord[] animationRecords = new AnimationRecord[animationCount];

            stream.Position = chunk.FilePosition + chunk.Length - AnimationRecord.SIZE;
            int animationIndex = 0;
            while (true)
            {
                long recordPosition = stream.Position;
                AnimationRecord animationRecord = new AnimationRecord();

                animationRecord.Type = ReadSignedByte(stream);
                if (animationRecord.Type == -1)
                    break;

                animationRecord.Delay = ReadSignedByte(stream);
                animationRecord.Counter = ReadSignedByte(stream);
                animationRecord.UserInfo = ReadSignedByte(stream);
                animationRecord.CurrentOffset = ReadSignedLong(stream, lsb);
                animationRecord.StartOffset = ReadSignedLong(stream, lsb);
                animationRecord.EndOffset = ReadSignedLong(stream, lsb);

                // offsets are negative offsets into a list of frame indices (32bit) at the beginning of the chunk
                int frameCount = (int)((animationRecord.EndOffset - animationRecord.StartOffset) / 4);

                // move (backwards) to frame indices at beginning of chunk
                animationRecord.Frames = new int[frameCount];
                stream.Position += animationRecord.StartOffset;
                for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                {
                    animationRecord.Frames[frameIndex] = (int)ReadSignedLong(stream, lsb);
                    if (mphdRecord.VersionHigh < 1)
                         animationRecord.Frames[frameIndex] /= mphdRecord.BlockStructSize;
                }

                animationRecords[animationIndex++] = animationRecord;

                stream.Position = recordPosition - AnimationRecord.SIZE;
            }

            return animationRecords;
        }

        private Image ReadChuckBGFX(Stream stream, Chunk chunk, MphdRecord mphdRecord, Color[] colourMap)
        {
            int tileCount = mphdRecord.NumBlockStruct;
            int imageWidth = mphdRecord.BlockWidth;
            int imageHeight = mphdRecord.BlockHeight * tileCount;

            byte[] imageData = new byte[chunk.Length];
            stream.Position = chunk.FilePosition;
            stream.Read(imageData, 0, chunk.Length);

            bool applyColourKeying = false;
            if (mphdRecord.BlockDepth < 32)
            {
                applyColourKeying = MessageBox.Show(
                    "Apply colour keying?", "Mappy BGFX Chunk",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }

            Bitmap imageSource = new Bitmap(imageWidth, imageHeight, PixelFormat.Format32bppArgb);
            int pixelIndex = 0;
            if (mphdRecord.BlockDepth == 8)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        byte colourIndex = imageData[pixelIndex++];
                        if (!applyColourKeying || colourIndex != mphdRecord.ColourKeyIndex)
                            imageSource.SetPixel(pixelX, pixelY, colourMap[colourIndex]);
                    }
                }
            }
            else if (mphdRecord.BlockDepth == 15)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        ushort colourValue = (ushort)(imageData[pixelIndex++] | (imageData[pixelIndex++] << 8));
                        byte alpha = 255;
                        byte red = (byte)(colourValue & 31);
                        byte green = (byte)((colourValue >> 5) & 31);
                        byte blue = (byte)((colourValue >> 10) & 31);
                        red *= 4;
                        green *= 4;
                        blue *= 4;
                        if (applyColourKeying
                            && red == mphdRecord.ColourKeyRed
                            && green == mphdRecord.ColourKeyGreen
                            && blue == mphdRecord.ColourKeyBlue)
                            alpha = 0;
                        Color colour = Color.FromArgb(alpha, red, green, blue);
                        imageSource.SetPixel(pixelX, pixelY, colour);
                    }
                }
            }
            else if (mphdRecord.BlockDepth == 16)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        ushort colourValue = (ushort)(imageData[pixelIndex++] | (imageData[pixelIndex++] << 8));
                        byte alpha = 255;
                        byte red = (byte)(colourValue & 31);
                        byte green = (byte)((colourValue >> 5) & 63);
                        byte blue = (byte)((colourValue >> 11) & 31);
                        red *= 8;
                        green *= 4;
                        blue *= 8;
                        if (applyColourKeying
                            && red == mphdRecord.ColourKeyRed
                            && green == mphdRecord.ColourKeyGreen
                            && blue == mphdRecord.ColourKeyBlue)
                            alpha = 0;
                        Color colour = Color.FromArgb(alpha, red, green, blue);
                        imageSource.SetPixel(pixelX, pixelY, colour);
                    }
                }
            }
            else if (mphdRecord.BlockDepth == 24)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        byte alpha = 255;
                        byte red   = imageData[pixelIndex++];
                        byte green = imageData[pixelIndex++];
                        byte blue  = imageData[pixelIndex++];
                        if (applyColourKeying
                            && red == mphdRecord.ColourKeyRed
                            && green == mphdRecord.ColourKeyGreen
                            && blue == mphdRecord.ColourKeyBlue)
                            alpha = 0;
                        Color colour = Color.FromArgb(alpha, red, green, blue);
                        imageSource.SetPixel(pixelX, pixelY, colour);
                    }
                }
            }
            else if (mphdRecord.BlockDepth == 32)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        byte alpha = imageData[pixelIndex++];
                        byte red = imageData[pixelIndex++];
                        byte green = imageData[pixelIndex++];
                        byte blue = imageData[pixelIndex++];
                        Color colour = Color.FromArgb(alpha, red, green, blue);
                        imageSource.SetPixel(pixelX, pixelY, colour);
                    }
                }
            }

            return imageSource;
        }

        private short[] ReadChunkLayer(Stream stream, Chunk chunk, MphdRecord mphdRecord)
        {
            bool lsb = mphdRecord.LSB;
            short[] offsets = new short[chunk.Length / 2];
            stream.Position = chunk.FilePosition;
            for (int index = 0; index < offsets.Length; index++)
            {
                short offset = ReadShort(stream, lsb);
                if (mphdRecord.VersionHigh < 1)
                {
                    if (offset >= 0)
                        offset /= mphdRecord.BlockStructSize;
                    else
                        offset /= AnimationRecord.SIZE;
                }
                offsets[index] = offset;
            }
            return offsets;
        }

        #endregion

        #region Private Classes

        private struct Chunk
        {
            internal string Id;
            internal long FilePosition;
            internal int Length;
        }

        private class MphdRecord
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

        private class BlockRecord
        {
            internal long BackgroundOffset, ForegroundOffset;
            internal long BackgroundOffset2, ForegroundOffset2;
            internal ulong User1, User2;
            internal ushort User3, User4;
            internal byte User5, User6, User7;
            internal byte Flags;
        }

        private class AnimationRecord
        {
            internal const int SIZE = 16;
            internal sbyte Type;
            internal sbyte Delay;
            internal sbyte Counter;
            internal sbyte UserInfo;
            internal long  CurrentOffset;
            internal long  StartOffset;
            internal long  EndOffset;
            internal int[] Frames;
        }

        #endregion
    }
}
