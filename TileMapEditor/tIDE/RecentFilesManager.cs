using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace TileMapEditor
{
    class RecentFilesManager
    {
        private static RecentFilesManager s_instance = new RecentFilesManager();
        private const int MAX_FILES = 10;

        private RecentFilesManager()
        {
        }

        public static RecentFilesManager Instance { get { return s_instance; } }

        public StringCollection Filenames
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

        public void StoreFilename(string filename)
        {
            RemoveFilename(filename);

            StringCollection filenames = Filenames;
            filenames.Insert(0, filename);

            while (filenames.Count > MAX_FILES)
                filenames.RemoveAt(filenames.Count - 1);

            Properties.Settings.Default.Save();
        }

        public void RemoveFilename(string filename)
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
    }
}
