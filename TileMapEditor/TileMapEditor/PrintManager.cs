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

        private PrintManager()
        {
            m_printerSettings = new PrinterSettings();
            m_pageSettings = new PageSettings(m_printerSettings);
        }

        internal void ShowPageSetupDialog(IWin32Window owner)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.PrinterSettings = m_printerSettings;
            pageSetupDialog.PageSettings = m_pageSettings;
            pageSetupDialog.ShowDialog(owner);
        }

        internal void ShowPrintPreviewDialog(IWin32Window owner)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.ShowIcon = false;
            printPreviewDialog.ShowDialog(owner);
        }

        internal void ShowPrintDialog(IWin32Window owner, Image printImage)
        {
        }

        internal static PrintManager Instance { get { return s_printManager; } }
    }
}
