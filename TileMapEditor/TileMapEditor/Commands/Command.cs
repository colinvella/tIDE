using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.Commands
{
    internal abstract class Command
    {
        protected string m_description;

        public abstract void Do();
        public abstract void Undo();

        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
    }
}
