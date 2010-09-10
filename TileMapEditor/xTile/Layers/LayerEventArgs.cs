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

using xTile.Dimensions;

namespace xTile.Layers
{
    /// <summary>
    /// Argument structure for Layer-related events
    /// </summary>
    public class LayerEventArgs
    {
        #region Public Properties

        /// <summary>
        /// Layer associated with the event
        /// </summary>
        public Layer Layer { get { return m_layer; } }

        /// <summary>
        /// Viewport at the time of the event
        /// </summary>
        public Rectangle Viewport { get { return m_viewport; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a new Layer arguments structure
        /// </summary>
        /// <param name="layer">Layer associated with the event</param>
        /// <param name="viewport">Viewport associated with the event</param>
        public LayerEventArgs(Layer layer, Rectangle viewport)
        {
            m_layer = layer;
            m_viewport = viewport;
        }

        #endregion

        #region Private Variables

        private Layer m_layer;
        private Rectangle m_viewport;

        #endregion
    }
}
