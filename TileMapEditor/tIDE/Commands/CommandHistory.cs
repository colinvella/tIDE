using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tIDE.Commands
{
    internal class CommandHistory
    {
        private static CommandHistory s_instance = new CommandHistory();

        private Stack<Command> m_undoCommandStack;
        private Stack<Command> m_redoCommandStack;

        private CommandHistory()
        {
            m_undoCommandStack = new Stack<Command>();
            m_redoCommandStack = new Stack<Command>();
        }

        public static CommandHistory Instance
        {
            get { return s_instance; }
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

        public void Undo(Command command)
        {
            if (!m_undoCommandStack.Contains(command))
                throw new Exception("The command is not in the undo stack");

            while (m_undoCommandStack.Peek() != command)
                Undo();

            Undo();
        }

        public void Redo()
        {
            if (m_redoCommandStack.Count == 0)
                throw new Exception("No commands to redo");

            Command command = m_redoCommandStack.Pop();
            command.Do();
            m_undoCommandStack.Push(command);
        }

        public void Redo(Command command)
        {
            if (!m_redoCommandStack.Contains(command))
                throw new Exception("The command is not in the redo stack");

            while (m_redoCommandStack.Peek() != command)
                Redo();

            Redo();
        }

        public void UndoOrRedo(Command command)
        {
            if (m_undoCommandStack.Contains(command))
                Undo(command);
            else if (m_redoCommandStack.Contains(command))
                Redo(command);
            else
                throw new Exception("The command is not in the undo/redo command history");
        }

        public int Count
        {
            get { return m_undoCommandStack.Count + m_redoCommandStack.Count; }
        }

        public string UndoDescription
        {
            get
            {
                return m_undoCommandStack.Count > 0
                    ? m_undoCommandStack.Peek().Description
                    : "No action to undo";
            }
        }

        public string RedoDescription
        {
            get
            {
                return m_redoCommandStack.Count > 0
                    ? m_redoCommandStack.Peek().Description
                    : "No action to redo";
            }
        }

        public IEnumerable<Command> History
        {
            get
            {
                List<Command> commandHistory = new List<Command>();
                foreach (Command command in m_undoCommandStack)
                    commandHistory.Insert(0, command);

                //int index = commandHistory.Count;
                foreach (Command command in m_redoCommandStack)
                    commandHistory.Add(command);
                return commandHistory;
            }
        }

        public Command LastCommand
        {
            get
            {
                return m_undoCommandStack.Count == 0 ? null : m_undoCommandStack.Peek();
            }
        }
    }
}
