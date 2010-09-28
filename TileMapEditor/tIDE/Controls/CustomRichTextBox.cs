using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor.Controls
{
    [ToolboxBitmapAttribute(typeof(RichTextBox))]
    public class CustomRichTextBox : RichTextBox
    {
        #region Privte Constants

        private const string RTF_HEADER = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";
        private const string RTF_IMAGE_POST = @"}";
        private const string FF_UNKNOWN = "UNKNOWN";
        private const int HMM_PER_INCH = 2540;
        private const int TWIPS_PER_INCH = 1440;
        private const int MM_ANISOTROPIC = 8;

		private const int WM_USER			 = 0x0400;
		private const int EM_GETCHARFORMAT	 = WM_USER+58;
		private const int EM_SETCHARFORMAT	 = WM_USER+68;

		private const int SCF_SELECTION	= 0x0001;
		private const int SCF_WORD		= 0x0002;
		private const int SCF_ALL		= 0x0004;

		private const UInt32 CFE_BOLD		= 0x0001;
		private const UInt32 CFE_ITALIC		= 0x0002;
		private const UInt32 CFE_UNDERLINE	= 0x0004;
		private const UInt32 CFE_STRIKEOUT	= 0x0008;
		private const UInt32 CFE_PROTECTED	= 0x0010;
		private const UInt32 CFE_LINK		= 0x0020;
		private const UInt32 CFE_AUTOCOLOR	= 0x40000000;
		private const UInt32 CFE_SUBSCRIPT	= 0x00010000;		
		private const UInt32 CFE_SUPERSCRIPT= 0x00020000;		

		private const int CFM_SMALLCAPS		= 0x0040;			
		private const int CFM_ALLCAPS		= 0x0080;			
		private const int CFM_HIDDEN		= 0x0100;			
		private const int CFM_OUTLINE		= 0x0200;			
		private const int CFM_SHADOW		= 0x0400;			
		private const int CFM_EMBOSS		= 0x0800;			
		private const int CFM_IMPRINT		= 0x1000;			
		private const int CFM_DISABLED		= 0x2000;
		private const int CFM_REVISED		= 0x4000;

		private const int CFM_BACKCOLOR		= 0x04000000;
		private const int CFM_LCID			= 0x02000000;
		private const int CFM_UNDERLINETYPE	= 0x00800000;		
		private const int CFM_WEIGHT		= 0x00400000;
		private const int CFM_SPACING		= 0x00200000;		
		private const int CFM_KERNING		= 0x00100000;		
		private const int CFM_STYLE			= 0x00080000;		
		private const int CFM_ANIMATION		= 0x00040000;		
		private const int CFM_REVAUTHOR		= 0x00008000;

		private const UInt32 CFM_BOLD		= 0x00000001;
		private const UInt32 CFM_ITALIC		= 0x00000002;
		private const UInt32 CFM_UNDERLINE	= 0x00000004;
		private const UInt32 CFM_STRIKEOUT	= 0x00000008;
		private const UInt32 CFM_PROTECTED	= 0x00000010;
		private const UInt32 CFM_LINK		= 0x00000020;
		private const UInt32 CFM_SIZE		= 0x80000000;
		private const UInt32 CFM_COLOR		= 0x40000000;
		private const UInt32 CFM_FACE		= 0x20000000;
		private const UInt32 CFM_OFFSET		= 0x10000000;
		private const UInt32 CFM_CHARSET	= 0x08000000;
		private const UInt32 CFM_SUBSCRIPT	= CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
		private const UInt32 CFM_SUPERSCRIPT= CFM_SUBSCRIPT;

		private const byte CFU_UNDERLINENONE		= 0x00000000;
		private const byte CFU_UNDERLINE			= 0x00000001;
		private const byte CFU_UNDERLINEWORD		= 0x00000002; 
		private const byte CFU_UNDERLINEDOUBLE		= 0x00000003; 
		private const byte CFU_UNDERLINEDOTTED		= 0x00000004;
		private const byte CFU_UNDERLINEDASH		= 0x00000005;
		private const byte CFU_UNDERLINEDASHDOT		= 0x00000006;
		private const byte CFU_UNDERLINEDASHDOTDOT	= 0x00000007;
		private const byte CFU_UNDERLINEWAVE		= 0x00000008;
		private const byte CFU_UNDERLINETHICK		= 0x00000009;
		private const byte CFU_UNDERLINEHAIRLINE	= 0x0000000A; 

		#endregion

        #region Private Enumerations

        private enum EmfToWmfBitsFlags
        {
            EmfToWmfBitsFlagsDefault = 0x00000000,
            EmfToWmfBitsFlagsEmbedEmf = 0x00000001,
            EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,
            EmfToWmfBitsFlagsNoXORClip = 0x00000004
        };

        #endregion

        #region Private Structures

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT2_STRUCT
        {
            public UInt32 cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            public Int32 yHeight;
            public Int32 yOffset;
            public Int32 crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
            public UInt16 wWeight;
            public UInt16 sSpacing;
            public int crBackColor; // Color.ToArgb() -> int
            public int lcid;
            public int dwReserved;
            public Int16 sStyle;
            public Int16 wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
            public byte bReserved1;
        }

        private struct RtfFontFamilyDef
        {
            public const string Unknown = @"\fnil";
            public const string Roman = @"\froman";
            public const string Swiss = @"\fswiss";
            public const string Modern = @"\fmodern";
            public const string Script = @"\fscript";
            public const string Decor = @"\fdecor";
            public const string Technical = @"\ftech";
            public const string BiDirect = @"\fbidi";
        }

        #endregion

        #region Private Variables

        private HybridDictionary m_rtfFontFamily;
        private float m_xDpi;
        private float m_yDpi;

        #endregion

        #region Private Static Methods

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImportAttribute("gdiplus.dll")]
        private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize,
            byte[] _buffer, int _mappingMode, EmfToWmfBitsFlags _flags);

        #endregion

        #region Private Methods

        private void SetSelectionStyle(UInt32 mask, UInt32 effect)
        {
            CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32)Marshal.SizeOf(cf);
            cf.dwMask = mask;
            cf.dwEffects = effect;

            IntPtr wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);

            IntPtr res = SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);

            Marshal.FreeCoTaskMem(lpar);
        }

        private int GetSelectionStyle(UInt32 mask, UInt32 effect)
        {
            CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32)Marshal.SizeOf(cf);
            cf.szFaceName = new char[32];

            IntPtr wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);

            IntPtr res = SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar);

            cf = (CHARFORMAT2_STRUCT)Marshal.PtrToStructure(lpar, typeof(CHARFORMAT2_STRUCT));

            int state;
            // dwMask holds the information which properties are consistent throughout the selection:
            if ((cf.dwMask & mask) == mask)
            {
                if ((cf.dwEffects & effect) == effect)
                    state = 1;
                else
                    state = 0;
            }
            else
            {
                state = -1;
            }

            Marshal.FreeCoTaskMem(lpar);
            return state;
        }

        private string GetFontTable(Font font)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(@"{\fonttbl{\f0");
            stringBuilder.Append(@"\");

            if (m_rtfFontFamily.Contains(font.FontFamily.Name))
                stringBuilder.Append(m_rtfFontFamily[font.FontFamily.Name]);
            else
                stringBuilder.Append(m_rtfFontFamily[FF_UNKNOWN]);

            // set ANSII char set
            stringBuilder.Append(@"\fcharset0 ");
            stringBuilder.Append(font.Name);
            stringBuilder.Append(@";}}");

            return stringBuilder.ToString();
        }

        private string GenerateRtfImagePrefix(Image image)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int sourceWidthMM = (int)Math.Round((image.Width / m_xDpi) * HMM_PER_INCH);
            int sourceHeightMM = (int)Math.Round((image.Height / m_yDpi) * HMM_PER_INCH);

            int destWidthTwips = (int)Math.Round((image.Width / m_xDpi) * TWIPS_PER_INCH);
            int destHeightTwips = (int)Math.Round((image.Height / m_yDpi) * TWIPS_PER_INCH);

            stringBuilder.Append(@"{\pict\wmetafile8");
            stringBuilder.Append(@"\picw");
            stringBuilder.Append(sourceWidthMM);
            stringBuilder.Append(@"\pich");
            stringBuilder.Append(sourceHeightMM);
            stringBuilder.Append(@"\picwgoal");
            stringBuilder.Append(destWidthTwips);
            stringBuilder.Append(@"\pichgoal");
            stringBuilder.Append(destHeightTwips);
            stringBuilder.Append(" ");

            return stringBuilder.ToString();
        }

        private string GenerateImageRtf(Image image)
        {
            MemoryStream metaFileStream = null;
            Graphics graphics = null;
            Metafile metaFile = null;

            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                metaFileStream = new MemoryStream();

                using (graphics = this.CreateGraphics())
                {
                    IntPtr hdc = graphics.GetHdc();
                    metaFile = new Metafile(metaFileStream, hdc);
                    graphics.ReleaseHdc(hdc);
                }

                using (graphics = Graphics.FromImage(metaFile))
                {
                    graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                }

                IntPtr hMetaFile = metaFile.GetHenhmetafile();

                // get size (buller = null)
                uint bufferSize = GdipEmfToWmfBits(hMetaFile, 0, null, MM_ANISOTROPIC,
                    EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
                byte[] buffer = new byte[bufferSize];

                // do copy (buffer != null, return ignored)
                GdipEmfToWmfBits(hMetaFile, bufferSize, buffer, MM_ANISOTROPIC,
                    EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);

                stringBuilder.Append(BitConverter.ToString(buffer).Replace("-", ""));

                return stringBuilder.ToString();
            }
            finally
            {
                if (graphics != null)
                    graphics.Dispose();
                if (metaFile != null)
                    metaFile.Dispose();
                if (metaFileStream != null)
                    metaFileStream.Close();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a new CustomRichTextBox component
        /// </summary>
        public CustomRichTextBox()
		{
            m_rtfFontFamily = new HybridDictionary();
            m_rtfFontFamily.Add(FontFamily.GenericMonospace.Name, RtfFontFamilyDef.Modern);
            m_rtfFontFamily.Add(FontFamily.GenericSansSerif, RtfFontFamilyDef.Swiss);
            m_rtfFontFamily.Add(FontFamily.GenericSerif, RtfFontFamilyDef.Roman);
            m_rtfFontFamily.Add(FF_UNKNOWN, RtfFontFamilyDef.Unknown);

            using (Graphics _graphics = this.CreateGraphics())
            {
                m_xDpi = _graphics.DpiX;
                m_yDpi = _graphics.DpiY;
            }
        }

		/// <summary>
		/// Insert a given text as a link into the RichTextBox at the current insert position.
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		public void InsertLink(string text)
		{
			InsertLink(text, this.SelectionStart);
		}

		/// <summary>
		/// Insert a given text at a given position as a link. 
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="position">Insert position</param>
		public void InsertLink(string text, int position)
		{
			if (position < 0 || position > this.Text.Length)
				throw new ArgumentOutOfRangeException("position");

			this.SelectionStart = position;
			this.SelectedText = text;
			this.Select(position, text.Length);
			this.SelectionLink = true;
			this.Select(position + text.Length, 0);
		}
		
		/// <summary>
		/// Insert a given text at at the current input position as a link.
		/// The link text is followed by a hash (#) and the given hyperlink text, both of
		/// them invisible.
		/// When clicked on, the whole link text and hyperlink string are given in the
		/// LinkClickedEventArgs.
        /// Note: Any existing text selection is replaced by this link
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
		public void InsertLink(string text, string hyperlink)
		{
            int position = this.SelectionStart;
            this.SelectedRtf = @"{\rtf1\ansi " + text + @"\v #" + hyperlink + @"\v0}";
            this.Select(position, text.Length + hyperlink.Length + 1);
            this.SelectionLink = true;
            this.Select(position + text.Length + hyperlink.Length + 1, 0);
        }

		/// <summary>
		/// Insert a given text at a given position as a link. The link text is followed by
		/// a hash (#) and the given hyperlink text, both of them invisible.
		/// When clicked on, the whole link text and hyperlink string are given in the
		/// LinkClickedEventArgs.
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
		/// <param name="position">Insert position</param>
		public void InsertLink(string text, string hyperlink, int position)
		{
			if (position < 0 || position > this.Text.Length)
				throw new ArgumentOutOfRangeException("position");

			this.SelectionStart = position;
			this.SelectedRtf = @"{\rtf1\ansi "+text+@"\v #"+hyperlink+@"\v0}";
			this.Select(position, text.Length + hyperlink.Length + 1);
            this.SelectionLink = true;
			this.Select(position + text.Length + hyperlink.Length + 1, 0);
		}

        /// <summary>
        /// Starts a new line of text
        /// </summary>
        public void AppendLine()
        {
            AppendText("\n");
        }

        /// <summary>
        /// Appends the given text followed by a new line
        /// </summary>
        /// <param name="text">Text to output</param>
        public void AppendLine(string text)
        {
            AppendText(text + "\n");
        }

        /// <summary>
        /// Inserts the given image into the current selectiosn
        /// </summary>
        /// <param name="image">Image to insert</param>
        public void InsertImage(Image image)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(RTF_HEADER);
            stringBuilder.Append(GetFontTable(this.Font));
            stringBuilder.Append(GenerateRtfImagePrefix(image));
            stringBuilder.Append(GenerateImageRtf(image));
            stringBuilder.Append(RTF_IMAGE_POST);

            this.SelectedRtf = stringBuilder.ToString();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Indicates if, or set the current selection is a link or otherwise
        /// </summary>
        public bool SelectionLink
        {
            get
            {
                return GetSelectionStyle(CFM_LINK, CFE_LINK) == 1;
            }
            set
            {
                SetSelectionStyle(CFM_LINK, value ? CFE_LINK : 0);
            }
        }

        /// <summary>
        /// Indicates if the current selection is a partial link
        /// </summary>
        public bool SelectionLinkMixed
        {
            get
            {
                return GetSelectionStyle(CFM_LINK, CFE_LINK) == -1;
            }
        }

        [DefaultValue(false)]
        public new bool DetectUrls
        {
            get { return base.DetectUrls; }
            set { base.DetectUrls = value; }
        }

        #endregion
    }
}
