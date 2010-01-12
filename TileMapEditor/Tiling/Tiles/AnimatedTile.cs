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
        private StaticTile[] m_tileFrames;
        long m_frameInterval;
        long m_animationInterval;

        public AnimatedTile(Layer layer, BlendMode blendMode, StaticTile[] tileFrames, long frameInterval)
            : base(layer, blendMode)
        {
            if (frameInterval <= 0)
                throw new Exception("Frame interval must be strictly positive");

            m_tileFrames = new StaticTile[tileFrames.Length];
            tileFrames.CopyTo(m_tileFrames, 0);

            m_frameInterval = frameInterval;
            m_animationInterval = frameInterval * tileFrames.Length;
        }

        public override Tile Clone()
        {
            return new AnimatedTile(this.Layer, this.BlendMode, m_tileFrames, m_frameInterval);
        }

        public override TileSheet TileSheet
        {
            get
            {
                long animationTime = Layer.Map.ElapsedTime % m_animationInterval;
                int currentIndex = (int)(animationTime / m_frameInterval);
                return m_tileFrames[currentIndex].TileSheet;
            }
        }

        public override int TileIndex
        {
            get
            {
                long animationTime = Layer.Map.ElapsedTime % m_animationInterval;
                int currentIndex = (int) (animationTime / m_frameInterval);
                return currentIndex;
            } 
        }

        public StaticTile[] TileFrames
        {
            get
            {
                StaticTile[] tileFrames = new StaticTile[m_tileFrames.Length];
                m_tileFrames.CopyTo(tileFrames, 0);
                return tileFrames;
            }
        }

        public long FrameInterval { get { return m_frameInterval; } }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Animated Frames=");
            foreach (StaticTile tileFrame in m_tileFrames)
            {
                stringBuilder.Append(tileFrame.ToString());
                stringBuilder.Append(' ');
            }
            stringBuilder.Append(" Interval=");
            stringBuilder.Append(m_frameInterval);
            stringBuilder.Append(" BlendMode=");
            stringBuilder.Append(BlendMode);

            return stringBuilder.ToString();    
        }
    }
}
