using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XTile.Format
{
    public interface IMapFormat
    {
        CompatibilityReport DetermineCompatibility(Map map);

        Map Load(Stream stream);

        void Store(Map map, Stream stream);

        string Name { get; }

        string FileExtensionDescriptor { get; }

        string FileExtension { get; }
    }
}
