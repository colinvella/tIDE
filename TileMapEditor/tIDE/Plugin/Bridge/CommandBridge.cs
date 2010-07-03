using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TileMapEditor.Plugin.Interface;

using TileMapEditor.Commands;

namespace TileMapEditor.Plugin.Bridge
{
    internal class CommandBridge: Command
    {
        private ICommand m_pluginCommand;

        public CommandBridge(ICommand pluginCommand)
        {
            m_pluginCommand = pluginCommand;
        }

        public override void Do()
        {
            m_pluginCommand.Do();
        }

        public override void Undo()
        {
            m_pluginCommand.Undo();
        }

        public override string Description
        {
            get { return m_pluginCommand.Description; }
        }
    }
}
