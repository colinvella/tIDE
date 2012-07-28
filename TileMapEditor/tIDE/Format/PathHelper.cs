using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace tIDE.Format
{
    internal class PathHelper
    {
        public static string GetRelativePath(string basePath, string absolutePath)
        {
            basePath = basePath.Trim();
            if (basePath.Length > 0 && !basePath.EndsWith(Path.DirectorySeparatorChar + ""))
                basePath += Path.DirectorySeparatorChar;

            absolutePath = absolutePath.Trim();

            if (!Path.IsPathRooted(basePath) || !Path.IsPathRooted(absolutePath))
                return absolutePath;

            // absolute path within base
            if (absolutePath.StartsWith(basePath))
                return absolutePath.Remove(0, basePath.Length);

            // remove common root
            while (basePath.Length > 0 && absolutePath.Length > 0)
            {
                if (char.ToLower(basePath[0]) == char.ToLower(absolutePath[0]))
                {
                    basePath = basePath.Remove(0, 1);
                    absolutePath = absolutePath.Remove(0, 1);
                }
                else
                    break;
            }

            int levels = basePath.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Length;
            while (levels-- > 0)
                absolutePath = ".." + Path.DirectorySeparatorChar + absolutePath;

            return absolutePath;
        }

        public static string GetAbsolutePath(string basePath, string relativePath)
        {
            // trim paths from spaces
            basePath = basePath.Trim();
            relativePath = relativePath.Trim();

            // validate path parameters
            if (!Path.IsPathRooted(basePath))
                throw new ArgumentException("Path must be rooted", "basePath");
            if (Path.IsPathRooted(relativePath))
                throw new ArgumentException("Path must be relative", "relativePath");

            // ensure base path has an ending separator
            if (!basePath.EndsWith("" + Path.DirectorySeparatorChar))
                basePath += Path.DirectorySeparatorChar;

            // combine base and relative paths with unprocessed parent directory references
            string absolutePath = basePath + relativePath;

            // consume every instance a directory - parent reference pair e.g. a\b\..\c -> a\c
            Regex regex = new Regex(@"\\[^\\]+\\\.\.");
            while (absolutePath.Contains(".."))
                absolutePath = regex.Replace(absolutePath, @"");

            return absolutePath;
        }
    }
}
