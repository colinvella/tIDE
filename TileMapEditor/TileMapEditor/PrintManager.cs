using System;
using System.Collections.Generic;
using System.Drawing;
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

        private PrintManager()
        {
            m_printerSettings = new PrinterSettings();
            m_pageSettings = new PageSettings(m_printerSettings);
            m_printDocument = new PrintDocument();
            m_printDocument.PrintPage += new PrintPageEventHandler(OnPrintPage);
            m_printContent = null;
            m_sourceBounds = Rectangle.Empty;
        }

        private void OnPrintPage(object sender, PrintPageEventArgs printPageEventArgs)
        {
            Graphics graphics = printPageEventArgs.Graphics;
            Rectangle marginBounds = printPageEventArgs.MarginBounds;
            int leftMargin = marginBounds.Left;
            int topMargin = marginBounds.Top;

            if (m_sourceBounds == Rectangle.Empty)
                m_sourceBounds.Size = marginBounds.Size;

            graphics.DrawImage(m_printContent, marginBounds, m_sourceBounds, GraphicsUnit.Pixel);

            // handle paging
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
            pageSetupDialog.ShowDialog(owner);
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
