using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using xTile;
using xTile.Format;

namespace tIDE.Format
{
    internal class MappyFmapFormat: IMapFormat
    {
        #region Public Methods

        public CompatibilityReport DetermineCompatibility(xTile.Map map)
        {
            throw new NotImplementedException();
        }

        public Map Load(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        public void Store(Map map, Stream stream)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get { return "Mappy FMP Format"; }
        }

        public string FileExtensionDescriptor
        {
            get { return "Mappy FMP Files (*.fmp)"; }
        }

        public string FileExtension
        {
            get { return "fmp"; }
        }

        #endregion
    }
}
