using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using tIDE.Plugin.Interface;

using tIDE.Commands;

namespace tIDE.Plugin.Bridge
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
