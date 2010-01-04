using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.ObjectModel;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class TileSheetPropertiesCommand: Command
    {
        private TileSheet m_tileSheet;
        private string m_oldId, m_newId;
        private string m_oldDescription, m_newDescription;
        private Size m_oldTileSize, m_newTileSize;
        private Size m_oldMargin, m_newMargin;
        private Size m_oldSpacing, m_newSpacing;
        private Size m_oldSheetSize, m_newSheetSize;
        private string m_oldImageSource, m_newImageSource;
        private PropertyCollection m_oldProperties, m_newProperties;

        public TileSheetPropertiesCommand(TileSheet tileSheet,
            string newId, string newDescription,
            Size newTileSize, Size newMargin, Size newSpacing,
            Size newSheetSize, string newImageSource,
            PropertyCollection newProperties)
        {
            m_tileSheet = tileSheet;

            m_oldId = tileSheet.Id;
            m_oldDescription = tileSheet.Description;
            m_oldTileSize = tileSheet.TileSize;
            m_oldMargin = tileSheet.Margin;
            m_oldSpacing = tileSheet.Spacing;
            m_oldSheetSize = tileSheet.SheetSize;
            m_oldImageSource = tileSheet.ImageSource;
            m_oldProperties = new PropertyCollection(tileSheet.Properties);

            m_newId = newId;
            m_newDescription = newDescription;
            m_newTileSize = newTileSize;
            m_newMargin = newMargin;
            m_newSpacing = newSpacing;
            m_newSheetSize = newSheetSize;
            m_newImageSource = newImageSource;
            m_newProperties = newProperties;
        }

        public override void Do()
        {
            m_tileSheet.Id = m_newId;
            m_tileSheet.Description = m_newDescription;
            m_tileSheet.TileSize = m_newTileSize;
            m_tileSheet.Margin = m_newMargin;
            m_tileSheet.Spacing = m_newSpacing;
            m_tileSheet.SheetSize = m_newSheetSize;
            m_tileSheet.ImageSource = m_newImageSource;
            m_tileSheet.Properties.Clear();
            m_tileSheet.Properties.CopyFrom(m_newProperties);

            TileImageCache.Instance.Refresh(m_tileSheet);

            m_description = "Change properties for tile sheet \"" + m_newId + "\"";
        }

        public override void Undo()
        {
            m_tileSheet.Id = m_oldId;
            m_tileSheet.Description = m_oldDescription;
            m_tileSheet.TileSize = m_oldTileSize;
            m_tileSheet.Margin = m_oldMargin;
            m_tileSheet.Spacing = m_oldSpacing;
            m_tileSheet.SheetSize = m_oldSheetSize;
            m_tileSheet.ImageSource = m_oldImageSource;
            m_tileSheet.Properties.Clear();
            m_tileSheet.Properties.CopyFrom(m_oldProperties);

            TileImageCache.Instance.Refresh(m_tileSheet);

            m_description = "Change properties for tile sheet \"" + m_oldId + "\"";
        }
    }
}
