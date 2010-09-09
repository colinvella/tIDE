using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile;

using TileMapEditor.TileBrushes;

namespace TileMapEditor.Commands
{
    internal class EditTileBrushesCommand: Command
    {
        private Map m_map;
        private TileBrushCollection m_currentTileBrushCollection;
        private TileBrushCollection m_newTileBrushCollection;
        private TileBrushCollection m_oldTileBrushCollection;

        public EditTileBrushesCommand(
            Map map,
            TileBrushCollection currentTileBrushCollection,
            TileBrush newTileBrush)
        {
            m_map = map;
            m_currentTileBrushCollection = currentTileBrushCollection;
            m_oldTileBrushCollection = new TileBrushCollection(currentTileBrushCollection);
            m_newTileBrushCollection = new TileBrushCollection(currentTileBrushCollection);
            m_newTileBrushCollection.TileBrushes.Add(newTileBrush);

            m_description = "Make new tile brush";
        }

        public EditTileBrushesCommand(
            Map map,
            TileBrushCollection currentTileBrushCollection,
            TileBrushCollection newTileBrushCollection)
        {
            m_map = map;
            m_currentTileBrushCollection = currentTileBrushCollection;
            m_oldTileBrushCollection = new TileBrushCollection(currentTileBrushCollection);
            m_newTileBrushCollection = new TileBrushCollection(newTileBrushCollection);

            m_description = "Manage tile brushes";
        }

        public override void Do()
        {
            m_currentTileBrushCollection.TileBrushes.Clear();
            foreach (TileBrush tileBrush in m_newTileBrushCollection.TileBrushes)
                m_currentTileBrushCollection.TileBrushes.Add(new TileBrush(tileBrush));

            m_currentTileBrushCollection.StoreInMap(m_map);
        }

        public override void Undo()
        {
            m_currentTileBrushCollection.TileBrushes.Clear();
            foreach (TileBrush tileBrush in m_oldTileBrushCollection.TileBrushes)
                m_currentTileBrushCollection.TileBrushes.Add(new TileBrush(tileBrush));

            m_currentTileBrushCollection.StoreInMap(m_map);
        }
    }
}
