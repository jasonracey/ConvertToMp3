using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConvertToMp3
{
    public class Converter
    {
        public int ProcessedSourceFiles { get; private set; }

        public int TotalSourceFiles { get; private set; }

        public string State { get; private set; }

        public void ConvertFiles(List<string> sourceFilePaths, bool deleteSourceFile)
        {
            TotalSourceFiles = sourceFilePaths.Count;
            foreach (var sourceFilePath in sourceFilePaths)
            {
                ConvertFile(sourceFilePath, deleteSourceFile);
                ProcessedSourceFiles++;
            }
        }

        private void ConvertFile(string sourceFilePath, bool deleteSourceFile)
        {
            var fixedPath = sourceFilePath.Replace("", "/");
            var sourceFileInfo = new FileInfo(fixedPath);

            var destFileName = sourceFileInfo.Name.Replace(sourceFileInfo.Extension, ".mp3");
            var destFilePath = $"{sourceFileInfo.DirectoryName}\\{destFileName}";

            if (File.Exists(destFilePath))
            {
                File.Delete(destFilePath);
            }

            var processStartInfo = new ProcessStartInfo
            {
                Arguments = $"-i \"{sourceFilePath}\" -ab 320k \"{destFilePath}\"",
                CreateNoWindow = true,
                FileName = @"C:\Program Files\ffmpeg-20151211-git-df2ce13-win64-static\bin\ffmpeg.exe",
                RedirectStandardError = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            State = $"Converting {sourceFileInfo.Name} ...";
            
            string standardError;
            using (var process = Process.Start(processStartInfo))
            {
                standardError = process?.StandardError.ReadToEnd();
                process?.WaitForExit();
            }

            if (standardError != null && standardError.Contains("No such file or directory"))
            {
                throw new ApplicationException(standardError);
            } 

            if (deleteSourceFile && File.Exists(destFilePath))
            {
                File.Delete(sourceFilePath);
            }
        }
    }
}