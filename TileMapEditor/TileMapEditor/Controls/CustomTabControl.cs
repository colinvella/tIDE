using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TileMapEditor.Controls
{
    public class CustomTabControl: TabControl
    {
        private void OnDrawItem(object sender, DrawItemEventArgs drawItemEventArgs)
        {
            Graphics graphics = drawItemEventArgs.Graphics;

            TabPage currentTab = TabPages[drawItemEventArgs.Index];
            Rectangle tabRectangle = GetTabRect(drawItemEventArgs.Index);

            Brush tabBrush = null;
            Brush textBrush = System.Drawing.SystemBrushes.ControlText;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;

            if ((drawItemEventArgs.State & DrawItemState.Selected) != 0)
            {
                tabBrush = new LinearGradientBrush(tabRectangle,
                    SystemColors.GradientActiveCaption, SystemColors.Control, 90.0f);
                tabRectangle.Inflate(2, 1);
            }
            else
            {
                tabBrush = new LinearGradientBrush(
                    tabRectangle, SystemColors.ControlLight, SystemColors.Control, 90.0f);
            }

            // set up rotation for left and right aligned tabs
            if (Alignment == TabAlignment.Left || Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (Alignment == TabAlignment.Left)
                    RotateAngle = 270;
                PointF cp = new PointF(tabRectangle.Left + (tabRectangle.Width / 2), tabRectangle.Top + (tabRectangle.Height / 2));
                graphics.TranslateTransform(cp.X, cp.Y);
                graphics.RotateTransform(RotateAngle);
                tabRectangle = new Rectangle(-(tabRectangle.Height / 2), -(tabRectangle.Width / 2), tabRectangle.Height, tabRectangle.Width);
            }

            // paint the tab item
            graphics.FillRectangle(tabBrush, tabRectangle);

            // tab caption
            graphics.DrawString(currentTab.Text, drawItemEventArgs.Font, textBrush,
                new RectangleF(tabRectangle.X, tabRectangle.Y, tabRectangle.Width, tabRectangle.Height), stringFormat);

            // reset any Graphics rotation
            graphics.ResetTransform();

            // dispose
            tabBrush.Dispose();
        }

        private void OnControlAdded(object sender, ControlEventArgs controlEventArgs)
        {
            controlEventArgs.Control.BackColor = SystemColors.Control;
        }

        public CustomTabControl()
            : base()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;

            DrawItem += new DrawItemEventHandler(this.OnDrawItem);

            ControlAdded += new ControlEventHandler(this.OnControlAdded);
        }
    }

}
