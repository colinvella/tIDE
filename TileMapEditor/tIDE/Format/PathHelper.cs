using System;
using System.IO;

namespace TileMapEditor.Format
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

            int levels = basePath.Split(new char[] { Path.DirectorySeparatorChar }).Length;
            while (levels-- > 0)
                absolutePath = ".." + Path.DirectorySeparatorChar + absolutePath;

            return absolutePath;
        }

        public static string GetAbsolutePath(string basePath, string relativePath)
        {
            basePath = basePath.Trim();
            relativePath = relativePath.Trim();

            if (!Path.IsPathRooted(basePath) || Path.IsPathRooted(relativePath))
                return relativePath;

            while (relativePath.StartsWith(".." + Path.DirectorySeparatorChar))
            {
                relativePath = relativePath.Remove(0, 3);
                int index = basePath.LastIndexOf(Path.DirectorySeparatorChar);
                if (index <= 2)
                    break;
                else
                    basePath = basePath.Remove(index + 1);
            }

            if (basePath.Length > 0 && !basePath.EndsWith(Path.DirectorySeparatorChar + ""))
                basePath += Path.DirectorySeparatorChar;

            return basePath + relativePath;
        }
    }
}
