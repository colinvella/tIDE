using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.Commands
{
    internal class CommandHistory
    {
        private Stack<Command> m_undoCommandStack;
        private Stack<Command> m_redoCommandStack;

        internal CommandHistory()
        {
            m_undoCommandStack = new Stack<Command>();
            m_redoCommandStack = new Stack<Command>();
        }

        public bool CanUndo()
        {
            return m_undoCommandStack.Count > 0;
        }

        public bool CanRedo()
        {
            return m_redoCommandStack.Count > 0;
        }

        public void Clear()
        {
            m_undoCommandStack.Clear();
            m_redoCommandStack.Clear();
        }

        public void Do(Command command)
        {
            command.Do();
            m_undoCommandStack.Push(command);
            m_redoCommandStack.Clear();
        }

        public void Undo()
        {
            if (m_undoCommandStack.Count == 0)
                throw new Exception("No commands to undo");

            Command command = m_undoCommandStack.Pop();
            command.Undo();
            m_redoCommandStack.Push(command);
        }

        public void Redo()
        {
            if (m_redoCommandStack.Count == 0)
                throw new Exception("No commands to redo");

            Command command = m_redoCommandStack.Pop();
            command.Do();
            m_undoCommandStack.Push(command);
        }
    }
}
