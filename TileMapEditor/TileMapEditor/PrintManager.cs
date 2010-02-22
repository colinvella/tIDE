using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor
{
    internal class PrintManager
    {
        private static PrintManager s_printManager = new PrintManager();

        private PrinterSettings m_printerSettings;
        private PageSettings m_pageSettings;
        private PrintDocument m_printDocument;
        private Image m_printContent;
        private Rectangle m_sourceBounds;
        private int m_currentPage;
        private Font m_captionFont;

        private PrintManager()
        {
            m_printerSettings = new PrinterSettings();
            m_pageSettings = new PageSettings(m_printerSettings);
            m_printDocument = new PrintDocument();
            m_printDocument.BeginPrint += new PrintEventHandler(OnBeginPrint);
            m_printDocument.PrintPage += new PrintPageEventHandler(OnPrintPage);
            m_printContent = null;
            m_sourceBounds = Rectangle.Empty;
            m_currentPage = 0;
            m_captionFont = new Font(SystemFonts.CaptionFont, FontStyle.Regular);
        }

        private void OnBeginPrint(object sender, PrintEventArgs printEventArgs)
        {
            // handle portrait / landscape settings
            if (m_pageSettings.Landscape)
                m_printContent.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // colour settings
            if (!m_pageSettings.Color)
            {
                Bitmap grayscaleBitmap = new Bitmap(m_printContent.Width, m_printContent.Height);
                Graphics graphics = Graphics.FromImage(grayscaleBitmap);
                float fWeight = 1.0f / 3.0f;
                ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                    new float[] {fWeight, fWeight, fWeight, 0.0f, 0.0f },
                    new float[] {fWeight, fWeight, fWeight, 0.0f, 0.0f },
                    new float[] {fWeight, fWeight, fWeight, 0.0f, 0.0f },
                    new float[] {   0.0f,    0.0f,    0.0f, 1.0f, 0.0f },
                    new float[] {   0.0f,    0.0f,    0.0f, 0.0f, 1.0f }});
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix);
                int width = m_printContent.Width;
                int height = m_printContent.Height;
                Rectangle destRect = new Rectangle(Point.Empty, m_printContent.Size);
                graphics.DrawImage(m_printContent,
                    new Point[] {Point.Empty, new Point(width, 0), new Point(0, height)},
                    destRect, GraphicsUnit.Pixel, imageAttributes);
                m_printContent = grayscaleBitmap;
            }

            m_sourceBounds = Rectangle.Empty;
            m_currentPage = 1;
        }

        private void OnPrintPage(object sender, PrintPageEventArgs printPageEventArgs)
        {
            Graphics graphics = printPageEventArgs.Graphics;
            Rectangle marginBounds = printPageEventArgs.MarginBounds;
            int leftMargin = marginBounds.Left;
            int topMargin = marginBounds.Top;

            if (m_sourceBounds == Rectangle.Empty)
            {
                m_sourceBounds.Size = marginBounds.Size;
                m_sourceBounds.Inflate(0, -16);
            }

            int pagesAcross = (m_printContent.Width + m_sourceBounds.Width - 1) / m_sourceBounds.Width;
            int pagesDown = (m_printContent.Height + m_sourceBounds.Height - 1) / m_sourceBounds.Height;
            int pageCount = pagesAcross * pagesDown;

            graphics.DrawImage(m_printContent, marginBounds, m_sourceBounds, GraphicsUnit.Pixel);
            graphics.DrawString("Page " + m_currentPage + " of " + pageCount,
                m_captionFont, Brushes.Black, leftMargin, m_sourceBounds.Height + 4.0f);

            // handle paging
            ++m_currentPage;
            m_sourceBounds.Offset(marginBounds.Width, 0);
            if (m_sourceBounds.Left >= m_printContent.Width)
                m_sourceBounds.Offset(-m_sourceBounds.Left, marginBounds.Height);

            printPageEventArgs.HasMorePages = m_sourceBounds.Top <= m_printContent.Height;
        }

        internal void ShowPageSetupDialog(IWin32Window owner)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.PrinterSettings = m_printerSettings;
            pageSetupDialog.PageSettings = m_pageSettings;
            pageSetupDialog.AllowMargins
                = pageSetupDialog.AllowOrientation
                = pageSetupDialog.AllowPaper
                = pageSetupDialog.AllowPrinter = true;
            pageSetupDialog.Document = m_printDocument;

            // handle .NET measurement bug
            Margins originalMargins = m_printDocument.DefaultPageSettings.Margins;
            if(System.Globalization.RegionInfo.CurrentRegion.IsMetric)
            {
                m_printDocument.DefaultPageSettings.Margins = PrinterUnitConvert.Convert(
                    m_printDocument.DefaultPageSettings.Margins, PrinterUnit.Display,
                    PrinterUnit.TenthsOfAMillimeter);
            }

            if (pageSetupDialog.ShowDialog(owner) != DialogResult.OK)
                m_printDocument.DefaultPageSettings.Margins = originalMargins;
        }

        internal void ShowPrintPreviewDialog(IWin32Window owner, Image printContent)
        {
            m_printContent = printContent;
            m_sourceBounds = Rectangle.Empty;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.ShowIcon = false;
            printPreviewDialog.Document = m_printDocument;
            printPreviewDialog.ShowDialog(owner);
        }

        internal void Print(IWin32Window owner, Image printContent)
        {
            m_printContent = printContent;
            m_sourceBounds = Rectangle.Empty;

            PrintDialog printDialog = new PrintDialog();
            printDialog.UseEXDialog = true;
            printDialog.AllowCurrentPage
                = printDialog.AllowPrintToFile
                = printDialog.AllowSelection
                = printDialog.AllowSomePages
                = true;
            printDialog.Document = m_printDocument;
            if (printDialog.ShowDialog(owner) == DialogResult.OK)
                m_printDocument.Print();
        }

        internal static PrintManager Instance { get { return s_printManager; } }
    }
}
