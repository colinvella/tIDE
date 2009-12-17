using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Layers;

namespace Tiling.Tiles
{
    [Serializable]
    public class AnimatedTile : Tile
    {
        private int[] m_tileIndices;
        long m_frameInterval;
        long m_animationInterval;

        public AnimatedTile(Layer layer, TileSheet tileSheet, BlendMode blendMode, int[] tileIndices, long frameInterval)
            : base(layer, tileSheet, blendMode)
        {
            if (frameInterval <= 0)
                throw new Exception("Frame interval must be strictly positive");

            foreach (int tileIndex in tileIndices)
                if (tileIndex < 0 || tileIndex >= tileSheet.TileCount)
                    throw new Exception("The specified Tile Index is out of range");

            m_tileIndices = new int[tileIndices.Length];
            Array.Copy(tileIndices, m_tileIndices, tileIndices.Length);

            m_frameInterval = frameInterval;
            m_animationInterval = frameInterval * tileIndices.Length;
        }

        public override Tile Clone()
        {
            return new AnimatedTile(this.Layer, this.TileSheet, this.BlendMode, m_tileIndices, m_frameInterval);
        }

        public override int TileIndex
        {
            get
            {
                int animationTime = (int) (Layer.Map.ElapsedTime % m_animationInterval);
                int currentIndex = animationTime / m_tileIndices.Length;
                return currentIndex;
            } 
        }
    }
}
