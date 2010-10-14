using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Properties;

namespace TileMapEditor.Controls
{
    public partial class AlignmentButton : UserControl
    {
        public AlignmentButton()
        {
            InitializeComponent();

            m_alignment = Alignment.Centre;
            m_image = Resources.DefaultButtonImage;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Representation of the entity being anchored")]
        public Image Image
        {
            get { return m_image; }
            set
            {
                m_image = value;
                Alignment = Alignment;
            }
        }

        [Browsable(true)]
        [Category("Data")]
        [Description("The value of this alignment button")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Alignment Alignment
        {
            get { return m_alignment;  }
            set
            {
                m_alignment = value;
                switch (m_alignment)
                {
                    case Alignment.TopLeft:
                        m_btnTopLeft.Image = m_image;
                        m_btnTop.Image = Resources.AlignmentRight;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = Resources.AlignmentDown;
                        m_btnCentre.Image = Resources.AlignmentDownRight;
                        m_btnRight.Image = null;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = null;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.Top:
                        m_btnTopLeft.Image = Resources.AlignmentLeft;
                        m_btnTop.Image = m_image;
                        m_btnTopRight.Image = Resources.AlignmentRight;
                        m_btnLeft.Image = Resources.AlignmentDownLeft;
                        m_btnCentre.Image = Resources.AlignmentDown;
                        m_btnRight.Image = Resources.AlignmentDownRight;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = null;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.TopRight:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = Resources.AlignmentLeft;
                        m_btnTopRight.Image = m_image;
                        m_btnLeft.Image = null;
                        m_btnCentre.Image = Resources.AlignmentDownLeft;
                        m_btnRight.Image = Resources.AlignmentDown;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = null;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.Left:
                        m_btnTopLeft.Image = Resources.AlignmentUp;
                        m_btnTop.Image = Resources.AlignmentUpRight;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = m_image;
                        m_btnCentre.Image = Resources.AlignmentRight;
                        m_btnRight.Image = null;
                        m_btnBottomLeft.Image = Resources.AlignmentDown;
                        m_btnBottom.Image = Resources.AlignmentDownRight;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.Centre:
                        m_btnTopLeft.Image = Resources.AlignmentUpLeft;
                        m_btnTop.Image = Resources.AlignmentUp;
                        m_btnTopRight.Image = Resources.AlignmentUpRight;
                        m_btnLeft.Image = Resources.AlignmentLeft;
                        m_btnCentre.Image = m_image;
                        m_btnRight.Image = Resources.AlignmentRight;
                        m_btnBottomLeft.Image = Resources.AlignmentDownLeft;
                        m_btnBottom.Image = Resources.AlignmentDown;
                        m_btnBottomRight.Image = Resources.AlignmentDownRight;
                        break;
                    case Alignment.Right:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = Resources.AlignmentUpLeft;
                        m_btnTopRight.Image = Resources.AlignmentUp;
                        m_btnLeft.Image = null;
                        m_btnCentre.Image = Resources.AlignmentLeft;
                        m_btnRight.Image = m_image;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = Resources.AlignmentDownLeft;
                        m_btnBottomRight.Image = Resources.AlignmentDown;
                        break;
                    case Alignment.BottomLeft:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = null;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = Resources.AlignmentUp;
                        m_btnCentre.Image = Resources.AlignmentUpRight;
                        m_btnRight.Image = null;
                        m_btnBottomLeft.Image = m_image;
                        m_btnBottom.Image = Resources.AlignmentRight;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.Bottom:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = null;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = Resources.AlignmentUpLeft;
                        m_btnCentre.Image = Resources.AlignmentUp;
                        m_btnRight.Image = Resources.AlignmentUpRight;
                        m_btnBottomLeft.Image = Resources.AlignmentLeft;
                        m_btnBottom.Image = m_image;
                        m_btnBottomRight.Image = Resources.AlignmentRight;
                        break;
                    case Alignment.BottomRight:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = null;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = null;
                        m_btnCentre.Image = Resources.AlignmentUpLeft;
                        m_btnRight.Image = Resources.AlignmentUp;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = Resources.AlignmentLeft;
                        m_btnBottomRight.Image = m_image;
                        break;
                }
            }

        }

        private void OnLoadControl(object sender, EventArgs eventArgs)
        {
            Alignment = Alignment;
        }

        private void OnAnchorButtonClicked(object sender, EventArgs eventArgs)
        {
            if (sender == m_btnTopLeft)
                Alignment = Alignment.TopLeft;
            else if (sender == m_btnTop)
                Alignment = Alignment.Top;
            else if (sender == m_btnTopRight)
                Alignment = Alignment.TopRight;
            else if (sender == m_btnLeft)
                Alignment = Alignment.Left;
            else if (sender == m_btnCentre)
                Alignment = Alignment.Centre;
            else if (sender == m_btnRight)
                Alignment = Alignment.Right;
            else if (sender == m_btnBottomLeft)
                Alignment = Alignment.BottomLeft;
            else if (sender == m_btnBottom)
                Alignment = Alignment.Bottom;
            else if (sender == m_btnBottomRight)
                Alignment = Alignment.BottomRight;
        }

        private Image m_image;
        private Alignment m_alignment;

    }

    public enum Alignment
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Centre,
        Right,
        BottomLeft,
        Bottom,
        BottomRight
    }
}
