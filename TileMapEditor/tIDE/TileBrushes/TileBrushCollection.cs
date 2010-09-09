using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile;
using XTile.Dimensions;
using XTile.Layers;
using XTile.Tiles;

namespace TileMapEditor.TileBrushes
{
    internal class TileBrushCollection
    {
        #region Internal Methods

        internal TileBrushCollection()
        {
            m_tileBrushes = new List<TileBrush>();
        }

        internal TileBrushCollection(TileBrushCollection tileBrushCollection)
        {
            m_tileBrushes = new List<TileBrush>();
            foreach (TileBrush tileBrush in tileBrushCollection.TileBrushes)
                m_tileBrushes.Add(new TileBrush(tileBrush));
        }

        internal string GenerateId()
        {
            List<string> currentIds = new List<string>();
            foreach (TileBrush tileBrush in m_tileBrushes)
                currentIds.Add(tileBrush.Id);

            int newIdIndex = 1;
            string newId = "Tile Brush " + newIdIndex;
            while (currentIds.Contains(newId))
            {
                ++newIdIndex;
                newId = "Tile Brush " + newIdIndex;
            }

            return newId;
        }

        internal void LoadFromMap(Map map)
        {
            m_tileBrushes.Clear();

            foreach (string propertyKey in map.Properties.Keys)
            {
                if (!propertyKey.StartsWith("@TileBrush@"))
                    continue;

                string[] keyTokens = propertyKey.Split(new char[] {'@'}, StringSplitOptions.RemoveEmptyEntries);
                if (keyTokens.Length != 2)
                    continue;

                string tileBrushId = keyTokens[1];

                // get property value containing tile brush definition
                string propertyValue = map.Properties[propertyKey];

                // parse definition using the pipe character
                string[] tileAssignments = propertyValue.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                // must have at least 2 - fist is layer id, next is tile assignment(s)
                if (tileAssignments.Length < 2)
                    continue;

                // verify layer id
                string layerId = tileAssignments[0];
                Layer layer = null;
                foreach (Layer containedLayer in map.Layers)
                    if (containedLayer.Id == layerId)
                    {
                        layer = containedLayer;
                        break;
                    }
                if (layer == null)
                    continue;

                // parse inidividual assignments
                List<TileBrushElement> tileBrushElements = new List<TileBrushElement>();
                Location tileLocation = new Location();
                string lastTileSheetId = "";
                for (int assignmentIndex = 1; assignmentIndex < tileAssignments.Length; assignmentIndex++)
                {
                    string tileAssignment = tileAssignments[assignmentIndex];

                    // parse assignment into comma-separated element
                    string[] elements = tileAssignment.Split(new char[] { ',' });
                    // ensure exactly 4 elements (posx,posy,[sheet id],[tile index])
                    if (elements.Length != 4)
                        continue;

                    // parse tile location or skip assignment if invalid
                    if (!int.TryParse(elements[0], out tileLocation.X))
                        continue;
                    if (!int.TryParse(elements[1], out tileLocation.Y))
                        continue;

                    // determine tile sheet id (if null ,reuse last
                    string tileSheetId = elements[2];
                    if (tileSheetId.Length == 0)
                        tileSheetId = lastTileSheetId;
                    else
                        lastTileSheetId = tileSheetId;

                    // if both sheet id and tile index empty, assume null tile
                    if (tileSheetId == "" && elements[3] == "")
                    {
                        tileBrushElements.Add(new TileBrushElement(null, tileLocation));
                        continue;
                    }

                    // otherwise, validate tile sheet id
                    TileSheet tileSheet = null;
                    foreach (TileSheet containedTileSheet in map.TileSheets)
                        if (containedTileSheet.Id == tileSheetId)
                        {
                            tileSheet = containedTileSheet;
                            break;
                        }
                    if (tileSheet == null)
                        continue;

                    // validate tile index (format and range)
                    int tileIndex = -1;
                    if (!int.TryParse(elements[3], out tileIndex))
                        continue;
                    if (tileIndex < 0 || tileIndex >= tileSheet.TileCount)
                        continue;

                    // all ok, assign
                    tileBrushElements.Add(
                        new TileBrushElement(
                            new StaticTile(
                                layer, tileSheet,
                                BlendMode.Alpha, tileIndex), tileLocation));
                }

                m_tileBrushes.Add(new TileBrush(tileBrushId, tileBrushElements));
            }
        }

        internal void StoreInMap(Map map)
        {
            // clear old properties related to tile brushes
            List<string> tileBrushKeys = new List<string>();
            foreach (string propertyKey in map.Properties.Keys)
            {
                if (propertyKey.StartsWith("@TileBrush@"))
                    tileBrushKeys.Add(propertyKey);
            }
            foreach (string tileBrushKey in tileBrushKeys)
                map.Properties.Remove(tileBrushKey);

            // store tilebrushes
            foreach (TileBrush tileBrush in m_tileBrushes)
                tileBrush.StoreInMap(map);
        }

        #endregion

        #region Internal Properties

        internal List<TileBrush> TileBrushes
        {
            get { return m_tileBrushes; }
        }

        #endregion

        #region Private Variables

        private List<TileBrush> m_tileBrushes;

        #endregion
    }
}
