using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor.Controls
{
    class CustomToolStripSplitButton: ToolStripSplitButton
    {
        private CheckState m_checkState;

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            base.OnPaint(paintEventArgs);

            if (m_checkState == CheckState.Checked)
            {
                Graphics graphics = paintEventArgs.Graphics;
                Rectangle rectangle = paintEventArgs.ClipRectangle;
                rectangle.Width--; rectangle.Height--;
                graphics.DrawRectangle(SystemPens.Highlight, rectangle);
            }
        }

        public CustomToolStripSplitButton()
            : base()
        {
            m_checkState = CheckState.Unchecked;
        }

        public CustomToolStripSplitButton(Image image)
            : base(image)
        {
            m_checkState = CheckState.Unchecked;
        }

        public CustomToolStripSplitButton(string text)
            : base(text)
        {
            m_checkState = CheckState.Unchecked;
        }

        public CustomToolStripSplitButton(string text, Image image)
            : base(text, image)
        {
            m_checkState = CheckState.Unchecked;
        }

        public CustomToolStripSplitButton(string text, Image image, EventHandler onClick)
            : base(text, image, onClick)
        {
            m_checkState = CheckState.Unchecked;
        }

        public CustomToolStripSplitButton(string text, Image image, ToolStripItem[] dropDownItems)
            : base(text, image, dropDownItems)
        {
            m_checkState = CheckState.Unchecked;
        }

        public CustomToolStripSplitButton(string text, Image image, EventHandler onClick, string name)
            : base(text, image, onClick, name)
        {
            m_checkState = CheckState.Unchecked;
        }

        public CheckState CheckState
        {
            get { return m_checkState; }
            set
            {
                if (m_checkState != value)
                {
                    m_checkState = value;
                    Invalidate();
                }
            }
        }

        public bool Checked
        {
            get { return m_checkState == CheckState.Checked; }
            set
            {
                CheckState newCheckState = value
                    ? CheckState.Checked : CheckState.Unchecked;
                if (m_checkState != newCheckState)
                {
                    m_checkState = newCheckState;
                    Invalidate();
                }
            }
        }
    }
}
