using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Layers;
using xTile.Dimensions;
using xTile.ObjectModel;
using xTile.Tiles;

namespace TileMapEditor.Commands
{
    internal class LayerVisibilityCommand: Command
    {
        private Layer m_layer;
        private bool m_oldVisibility, m_newVisibility;

        public LayerVisibilityCommand(Layer layer, bool newVisibility)
        {
            m_layer = layer;
            m_oldVisibility = layer.Visible;
            m_newVisibility = newVisibility;
            m_description = "Make layer \"" + m_layer.Id + "\" "
                + (m_newVisibility ? "visible" : "invisibile");
        }

        public override void Do()
        {
            m_layer.Visible = m_newVisibility;
        }

        public override void Undo()
        {
            m_layer.Visible = m_oldVisibility;
        }
    }
}
