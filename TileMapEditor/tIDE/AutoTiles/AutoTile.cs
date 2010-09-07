using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.Layers;
using XTile.Tiles;

namespace TileMapEditor.AutoTiles
{
    internal class AutoTile
    {
        private string m_id;
        private TileSheet m_tileSheet;
        private int[] m_indexSet;

        public AutoTile(string id, TileSheet tileSheet, int[] indexSet)
        {
            m_id = id;
            m_tileSheet = tileSheet;
            if (indexSet.Length != 16)
                throw new Exception("AutoTile index set must contain exactly 16 indices");
            m_indexSet = new int[16];
            indexSet.CopyTo(m_indexSet, 0);
        }

        public bool IsAffected(int tileIndex)
        {
            foreach (int setTileIndex in m_indexSet)
                if (tileIndex == setTileIndex)
                    return true;

            return false;
        }

        public Dictionary<Location, Tile> DetermineTileAssignments(Layer layer, Location tileLocation, int tileIndex)
        {
            // prepare blank assignment lists
            Dictionary<Location, Tile> autoTileAssignments = new Dictionary<Location, Tile>();

            // validate centre tile location
            if (!layer.IsValidTileLocation(tileLocation))
                return autoTileAssignments;

            // get and validate set index within auto tile definition
            int centreIndex = GetSetIndex(tileIndex);
            if (centreIndex == -1)
                return autoTileAssignments;

            // add centre tile
            Tile oldCentreTile = layer.Tiles[tileLocation];
            if (oldCentreTile == null || oldCentreTile.TileSheet != m_tileSheet || oldCentreTile.TileIndex != tileIndex)
            {
                Tile centreTile = new StaticTile(layer, m_tileSheet, BlendMode.Alpha, tileIndex);
                autoTileAssignments[tileLocation] = centreTile;
            }

            // determine and add adjacent tiles where applicable

            // top left
            Location topLeft = tileLocation.AboveLeft;
            Tile topLeftTile = DetermineAdjacentTile(layer, centreIndex,
                topLeft, new int[] { 0 }, new int[] { 3 });
            if (topLeftTile != null)
                autoTileAssignments[topLeft]= topLeftTile;

            // top
            Location top = tileLocation.Above;
            Tile topTile = DetermineAdjacentTile(layer, centreIndex,
                top, new int[] { 0, 1 }, new int[] { 2, 3 });
            if (topTile != null)
                autoTileAssignments[top]= topTile;

            // top right
            Location topRight = tileLocation.AboveRight;
            Tile topRightTile = DetermineAdjacentTile(layer, centreIndex,
                topRight, new int[] { 1 }, new int[] { 2 });
            if (topRightTile != null)
                autoTileAssignments[topRight] = topRightTile;

            // left
            Location left = tileLocation.Left;
            Tile leftTile = DetermineAdjacentTile(layer, centreIndex,
                left, new int[] { 0, 2 }, new int[] { 1, 3 });
            if (leftTile != null)
                autoTileAssignments[left] = leftTile;

            // right
            Location right = tileLocation.Right;
            Tile rightTile = DetermineAdjacentTile(layer, centreIndex,
                right, new int[] { 1, 3 }, new int[] { 0, 2 });
            if (rightTile != null)
                autoTileAssignments[right] = rightTile;

            // bottom left
            Location bottomLeft = tileLocation.BelowLeft;
            Tile bottomLeftTile = DetermineAdjacentTile(layer, centreIndex,
                bottomLeft, new int[] { 2 }, new int[] { 1 });
            if (bottomLeftTile != null)
                autoTileAssignments[bottomLeft] = bottomLeftTile;

            // bottom
            Location bottom = tileLocation.Below;
            Tile bottomTile = DetermineAdjacentTile(layer, centreIndex,
                bottom, new int[] { 2, 3 }, new int[] { 0, 1 });
            if (bottomTile != null)
                autoTileAssignments[bottom] = bottomTile;

            // bottom right
            Location bottomRight = tileLocation.BelowRight;
            Tile bottomRightTile = DetermineAdjacentTile(layer, centreIndex,
                bottomRight, new int[] { 3 }, new int[] { 0 });
            if (bottomRightTile != null)
                autoTileAssignments[bottomRight] = bottomRightTile;

            return autoTileAssignments;
        }

        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public TileSheet TileSheet { get { return m_tileSheet; } }

        public int[] IndexSet { get { return m_indexSet; } }

        private Tile DetermineAdjacentTile(Layer layer, int centreSetIndex,
            Location adjacentLocation,
            int[] centreConstrainedCorners, int[] adjacentConstrainedCorners)
        {
            // validate constraint array sizes
            if (centreConstrainedCorners.Length != adjacentConstrainedCorners.Length)
                throw new Exception("Constrained corner arrays must match in size");

            // validate adjacent location
            if (!layer.IsValidTileLocation(adjacentLocation))
                return null;

            // get and validate adjacent tile
            Tile adjacentTile = layer.Tiles[adjacentLocation];

            // must be non-null
            if (adjacentTile == null)
                return null;

            // must be a static tile
            if (!(adjacentTile is StaticTile))
                return null;

            // must share the same tile sheet
            if (adjacentTile.TileSheet != m_tileSheet)
                return null;

            // must belong to the same auto-tile definition
            int adjacentSetIndex = GetSetIndex(adjacentTile);
            if (adjacentSetIndex == -1)
                return null;

            // get centre and adjacent corners
            bool[] centreCorners = GetCorners(centreSetIndex);
            bool[] adjacentCorners = GetCorners(adjacentSetIndex);

            // update adjacent corners with given constraints
            for (int index = 0; index < centreConstrainedCorners.Length; index++)
                adjacentCorners[adjacentConstrainedCorners[index]] = centreCorners[centreConstrainedCorners[index]];

            // make new index
            int newSetIndex = MakeSetIndex(adjacentCorners);

            // compute new tile if different, or null if same
            int newTileIndex = m_indexSet[newSetIndex];
            if (newTileIndex != adjacentTile.TileIndex)
                return new StaticTile(layer, m_tileSheet, BlendMode.Alpha, newTileIndex);
            else
                return null;
        }

        private int GetSetIndex(int tileIndex)
        {
            for (int setIndex = 0; setIndex < 16; setIndex++)
                if (m_indexSet[setIndex] == tileIndex)
                    return setIndex;

            return -1;
        }

        private int GetSetIndex(Tile tile)
        {
            if (tile == null)
                return -1;
            if (!(tile is StaticTile))
                return -1;
            if (tile.TileSheet != m_tileSheet)
                return -1;

            return GetSetIndex(tile.TileIndex);
        }

        private bool[] GetCorners(int setIndex)
        {
            bool[] corners = new bool[4];
            corners[0] = (setIndex & 0x01) != 0;
            corners[1] = (setIndex & 0x02) != 0;
            corners[2] = (setIndex & 0x04) != 0;
            corners[3] = (setIndex & 0x08) != 0;
            return corners;
        }

        private int MakeSetIndex(bool[] corners)
        {
            if (corners.Length != 4)
                throw new Exception("Corner array must contain exactly four elements");
            int setIndex = 0;

            if (corners[0])
                setIndex |= 0x01;
            if (corners[1])
                setIndex |= 0x02;
            if (corners[2])
                setIndex |= 0x04;
            if (corners[3])
                setIndex |= 0x08;

            return setIndex;
        }
    }
}
