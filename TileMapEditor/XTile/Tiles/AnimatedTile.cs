using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Layers;

namespace XTile.Tiles
{
    [Serializable]
    public class AnimatedTile : Tile
    {
        private StaticTile[] m_tileFrames;
        long m_frameInterval;
        long m_animationInterval;

        public AnimatedTile(Layer layer, StaticTile[] tileFrames, long frameInterval)
            : base(layer)
        {
            if (frameInterval <= 0)
                throw new Exception("Frame interval must be strictly positive");

            m_tileFrames = new StaticTile[tileFrames.Length];
            tileFrames.CopyTo(m_tileFrames, 0);

            m_frameInterval = frameInterval;
            m_animationInterval = frameInterval * tileFrames.Length;
        }

        public override bool DependsOnTileSheet(TileSheet tileSheet)
        {
            foreach (StaticTile tileFrame in m_tileFrames)
                if (tileFrame.DependsOnTileSheet(tileSheet))
                    return true;
            return false;
        }

        public override Tile Clone()
        {
            List<StaticTile> tileFrames = new List<StaticTile>(m_tileFrames.Length);
            foreach (StaticTile tileFrame in m_tileFrames)
                tileFrames.Add((StaticTile)tileFrame.Clone());
            return new AnimatedTile(this.Layer, tileFrames.ToArray(), m_frameInterval);
        }

        public override BlendMode BlendMode
        {
            get
            {
                long animationTime = Layer.Map.ElapsedTime % m_animationInterval;
                int currentIndex = (int)(animationTime / m_frameInterval);
                return m_tileFrames[currentIndex].BlendMode;
            }
            set
            {
                foreach (StaticTile tileFrame in m_tileFrames)
                    tileFrame.BlendMode = value;
            }
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
                return m_tileFrames[currentIndex].TileIndex;
            }
            set
            {
                throw new NotSupportedException(
                    "Cannot set a specific tile index for an animated tile");
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
