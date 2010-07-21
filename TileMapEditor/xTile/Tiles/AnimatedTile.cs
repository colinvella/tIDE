/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  LICENSE    Microsoft Reciprocal License (Ms-RL)                        //
//             http://www.opensource.org/licenses/ms-rl.html               //
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

using XTile.Layers;

namespace XTile.Tiles
{
    /// <summary>
    /// Animated implementation of the Tile base class. The constituent
    /// animation frames are internally stored as StaticTile
    /// immplementations. The animation is cyclic and regulated by a
    /// constant frame interval
    /// </summary>
    [Serializable]
    public class AnimatedTile : Tile
    {
        #region Public Properties

        /// <summary>
        /// Tile blending mode. This may vary according to the current
        /// animation frame
        /// </summary>
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

        /// <summary>
        /// Tile sheet of the current animation frame
        /// </summary>
        public override TileSheet TileSheet
        {
            get
            {
                long animationTime = Layer.Map.ElapsedTime % m_animationInterval;
                int currentIndex = (int)(animationTime / m_frameInterval);
                return m_tileFrames[currentIndex].TileSheet;
            }
        }

        /// <summary>
        /// Tile index of the current animation frame
        /// </summary>
        public override int TileIndex
        {
            get
            {
                long animationTime = Layer.Map.ElapsedTime % m_animationInterval;
                int currentIndex = (int)(animationTime / m_frameInterval);
                return m_tileFrames[currentIndex].TileIndex;
            }
            set
            {
                throw new NotSupportedException(
                    "Cannot set a specific tile index for an animated tile");
            }
        }

        /// <summary>
        /// Animation frames
        /// </summary>
        public StaticTile[] TileFrames
        {
            get
            {
                StaticTile[] tileFrames = new StaticTile[m_tileFrames.Length];
                m_tileFrames.CopyTo(tileFrames, 0);
                return tileFrames;
            }
        }

        /// <summary>
        /// Frame interval in milliseconds
        /// </summary>
        public long FrameInterval { get { return m_frameInterval; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a new animated tile for the given layer, using the
        /// given tile frames and frame interval
        /// </summary>
        /// <param name="layer">Layer to assign the tile to</param>
        /// <param name="tileFrames">Array of StaticTile instances</param>
        /// <param name="frameInterval">Frame interval in milliseconds</param>
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

        /// <summary>
        /// Tests if this tile depends on the given tile sheet. All animation
        /// frames are tested for dependency
        /// </summary>
        /// <param name="tileSheet">Tile sheet to test</param>
        /// <returns>True if this tile depends on the sheet, False otherwise</returns>
        public override bool DependsOnTileSheet(TileSheet tileSheet)
        {
            foreach (StaticTile tileFrame in m_tileFrames)
                if (tileFrame.DependsOnTileSheet(tileSheet))
                    return true;
            return false;
        }

        /// <summary>
        /// Clones this AnimatedTile for the given Layer
        /// </summary>
        /// <param name="layer">Layer to assign the new tile to</param>
        /// <returns>Cloned AnimatedTile instance</returns>
        public override Tile Clone(Layer layer)
        {
            List<StaticTile> tileFrames = new List<StaticTile>(m_tileFrames.Length);
            foreach (StaticTile tileFrame in m_tileFrames)
                tileFrames.Add((StaticTile)tileFrame.Clone(layer));
            return new AnimatedTile(layer, tileFrames.ToArray(), m_frameInterval);
        }

        /// <summary>
        /// Generates and returns a string representation of this tile
        /// </summary>
        /// <returns>String representation of this tile</returns>
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

        #endregion

        #region Private Variables

        private StaticTile[] m_tileFrames;
        private long m_frameInterval;
        private long m_animationInterval;

        #endregion
    }
}
