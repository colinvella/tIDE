using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace TileMapEditor
{
    class RecentFilesManager
    {
        public static byte MaxFilenameCount
        {
            get { return Properties.Settings.Default.RecentFilesMaxCount; }
            set
            {
                Properties.Settings.Default.RecentFilesMaxCount = value;
                Properties.Settings.Default.Save();
            }
        }

        public static StringCollection Filenames
        {
            get
            {
                StringCollection filenames = Properties.Settings.Default.RecentFiles;
                if (filenames == null)
                {
                    filenames = new StringCollection();
                    Properties.Settings.Default.RecentFiles = filenames;
                    Properties.Settings.Default.Save();
                }
                return filenames;
            }
        }

        public static void StoreFilename(string filename)
        {
            RemoveFilename(filename);

            StringCollection filenames = Filenames;
            filenames.Insert(0, filename);

            while (filenames.Count > MaxFilenameCount)
                filenames.RemoveAt(filenames.Count - 1);

            Properties.Settings.Default.Save();
        }

        public static void RemoveFilename(string filename)
        {
            StringCollection filenames = Filenames;
            string filenameToRemove = null;
            foreach (string containedFilename in filenames)
                if (filename.Equals(containedFilename, StringComparison.InvariantCultureIgnoreCase))
                {
                    filenameToRemove = containedFilename;
                    break;
                }

            if (filenameToRemove != null)
            {
                filenames.Remove(filenameToRemove);
                Properties.Settings.Default.Save();
            }
        }

        public static void ClearHistory()
        {
            StringCollection filenames = Filenames;
            filenames.Clear();
            Properties.Settings.Default.Save();
        }
    }
}
