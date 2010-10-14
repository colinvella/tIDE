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
                        m_btnTop.Image = Resources.AnchorRight;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = Resources.AnchorDown;
                        m_btnCentre.Image = Resources.AnchorDownRight;
                        m_btnRight.Image = null;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = null;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.Top:
                        m_btnTopLeft.Image = Resources.AnchorLeft;
                        m_btnTop.Image = m_image;
                        m_btnTopRight.Image = Resources.AnchorRight;
                        m_btnLeft.Image = Resources.AnchorDownLeft;
                        m_btnCentre.Image = Resources.AnchorDown;
                        m_btnRight.Image = Resources.AnchorDownRight;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = null;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.TopRight:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = Resources.AnchorLeft;
                        m_btnTopRight.Image = m_image;
                        m_btnLeft.Image = null;
                        m_btnCentre.Image = Resources.AnchorDownLeft;
                        m_btnRight.Image = Resources.AnchorDown;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = null;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.Left:
                        m_btnTopLeft.Image = Resources.AnchorUp;
                        m_btnTop.Image = Resources.AnchorUpRight;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = m_image;
                        m_btnCentre.Image = Resources.AnchorRight;
                        m_btnRight.Image = null;
                        m_btnBottomLeft.Image = Resources.AnchorDown;
                        m_btnBottom.Image = Resources.AnchorDownRight;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.Centre:
                        m_btnTopLeft.Image = Resources.AnchorUpLeft;
                        m_btnTop.Image = Resources.AnchorUp;
                        m_btnTopRight.Image = Resources.AnchorUpRight;
                        m_btnLeft.Image = Resources.AnchorLeft;
                        m_btnCentre.Image = m_image;
                        m_btnRight.Image = Resources.AnchorRight;
                        m_btnBottomLeft.Image = Resources.AnchorDownLeft;
                        m_btnBottom.Image = Resources.AnchorDown;
                        m_btnBottomRight.Image = Resources.AnchorDownRight;
                        break;
                    case Alignment.Right:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = Resources.AnchorUpLeft;
                        m_btnTopRight.Image = Resources.AnchorUp;
                        m_btnLeft.Image = null;
                        m_btnCentre.Image = Resources.AnchorLeft;
                        m_btnRight.Image = m_image;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = Resources.AnchorDownLeft;
                        m_btnBottomRight.Image = Resources.AnchorDown;
                        break;
                    case Alignment.BottomLeft:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = null;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = Resources.AnchorUp;
                        m_btnCentre.Image = Resources.AnchorUpRight;
                        m_btnRight.Image = null;
                        m_btnBottomLeft.Image = m_image;
                        m_btnBottom.Image = Resources.AnchorRight;
                        m_btnBottomRight.Image = null;
                        break;
                    case Alignment.Bottom:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = null;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = Resources.AnchorUpLeft;
                        m_btnCentre.Image = Resources.AnchorUp;
                        m_btnRight.Image = Resources.AnchorUpRight;
                        m_btnBottomLeft.Image = Resources.AnchorLeft;
                        m_btnBottom.Image = m_image;
                        m_btnBottomRight.Image = Resources.AnchorRight;
                        break;
                    case Alignment.BottomRight:
                        m_btnTopLeft.Image = null;
                        m_btnTop.Image = null;
                        m_btnTopRight.Image = null;
                        m_btnLeft.Image = null;
                        m_btnCentre.Image = Resources.AnchorUpLeft;
                        m_btnRight.Image = Resources.AnchorUp;
                        m_btnBottomLeft.Image = null;
                        m_btnBottom.Image = Resources.AnchorLeft;
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
