using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConvertToMp3
{
    public static class FileFinder
    {
        private static readonly List<string> Extensions = new List<string> { ".ape", ".flac", ".mp4" };

        public static IEnumerable<string> GetSupportedFiles(string path)
        {
            return Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(file => Extensions.Contains(Path.GetExtension(file) ?? string.Empty, StringComparer.OrdinalIgnoreCase));
        }
    }
}
