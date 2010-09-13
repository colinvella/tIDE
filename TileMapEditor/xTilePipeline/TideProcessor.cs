using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

using xTile;
using xTile.Format;
using xTile.Layers;
using xTile.Tiles;

namespace xTile.Pipeline
{
    /// <summary>
    /// Content processor class for tIDE map files
    /// </summary>
    [ContentProcessor(DisplayName = "tIDE Map Processor")]
    public class TideProcessor : ContentProcessor<Map, Map>
    {
        #region Public Methods

        /// <summary>
        /// Process a tIDE map object.
        /// </summary>
        /// <param map="input">Input map object</param>
        /// <param name="contentProcessorContext">Processor context object</param>
        /// <returns></returns>
        public override Map Process(Map map, ContentProcessorContext contentProcessorContext)
        {
            // handle invisible layer exclusion
            if (m_excludeInvisibleLayers)
            {
                List<Layer> invisibleLayers = new List<Layer>();
                foreach (Layer layer in map.Layers)
                    if (!layer.Visible)
                        invisibleLayers.Add(layer);

                if (invisibleLayers.Count == map.Layers.Count)
                    throw new Exception("At least one layer must be visible when excluding invisible layers");

                foreach (Layer invisibleLayer in invisibleLayers)
                {
                    map.RemoveLayer(invisibleLayer);
                    contentProcessorContext.Logger.LogImportantMessage(
                        "Excluded invisible layer '" + invisibleLayer.Id + "'");
                }
            }

            // handle unused tile sheet exclusion
            if (m_excludeUnusedTileSheets)
            {
                List<TileSheet> unusedTileSheets = new List<TileSheet>();
                foreach (TileSheet tileSheet in map.TileSheets)
                    if (!map.DependsOnTileSheet(tileSheet))
                        unusedTileSheets.Add(tileSheet);

                foreach (TileSheet unusedTileSheet in unusedTileSheets)
                {
                    map.RemoveTileSheet(unusedTileSheet);
                    contentProcessorContext.Logger.LogImportantMessage(
                        "Excluded unused tile sheet '" + unusedTileSheet.Id + "'");
                }
            }

            // update tilesheet image source references
            foreach (TileSheet tileSheet in map.TileSheets)
            {
                // get image source
                string imageSource = tileSheet.ImageSource;

                // build path relative to content directory (remove upward folder refs)
                string contentSourcePath = imageSource + "";
                while (contentSourcePath.StartsWith("..\\")
                    || contentSourcePath.StartsWith("../"))
                    contentSourcePath = contentSourcePath.Remove(0, 3);

                // not strictly needed, but sets asset dependency
                string absoluteImagePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + contentSourcePath;
                contentProcessorContext.AddDependency(absoluteImagePath);

                // generate asset name
                string assetName = null;
                string extension = Path.GetExtension(contentSourcePath);
                if (extension != string.Empty)
                    assetName
                        = contentSourcePath.Remove(contentSourcePath.Length - extension.Length);
                else
                    assetName = contentSourcePath;

                // force build of image source as asset
                contentProcessorContext.Logger.LogImportantMessage("Discovered dependency on asset '" + contentSourcePath + "'...");
                ExternalReference<TextureContent> imageSourceReference
                    = contentProcessorContext.BuildAsset<TextureContent, TextureContent>(
                        new ExternalReference<TextureContent>(contentSourcePath), "TextureProcessor", null, null, assetName);

                tileSheet.ImageSource = assetName;

                contentProcessorContext.Logger.LogImportantMessage(
                    "Converted image source refenrence'" + imageSource + "' to asset reference '" + assetName + "'");
            }

            return map;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Content processor parameter to control if invisible layers should
        /// be excluded or otherwise
        /// </summary>
        [DisplayName("Exclude Invisible Layers")]
        [DefaultValue(false)]
        [Description("Excludes layers that are not marked as visible")]
        public bool ExcludeInvisibleLayers
        {
            get { return m_excludeInvisibleLayers; }
            set { m_excludeInvisibleLayers = value; }
        }

        /// <summary>
        /// Content processor parameter to control if invisible layers should
        /// be excluded or otherwise
        /// </summary>
        [DisplayName("Exclude Unused TileSheets")]
        [DefaultValue(false)]
        [Description("Excludes tile sheets that are not referenced in any layer")]
        public bool ExcludeUnusedTileSheets
        {
            get { return m_excludeUnusedTileSheets; }
            set { m_excludeUnusedTileSheets = value; }
        }

        #endregion

        #region Private Variables

        private bool m_excludeInvisibleLayers;
        private bool m_excludeUnusedTileSheets;

        #endregion
    }
}