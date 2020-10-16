namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using System;
    using System.IO;
    using System.Linq;

    public class FileWriter : IFileWriter
    {
        public void Write(string fileName, byte[] compressedXml)
        {
            CreateIfNotExists(fileName);

            var progressMesssage = string.Format("Writing file to FileName: {0}", fileName);
            int fileTotal = compressedXml.Count();
            int lastFileProgress = fileTotal;
            int currentStage = -1;
            int stageTotal = 50;

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                var currentProgress = 0;
                foreach (var byteValue in compressedXml)
                {
                    fileStream.WriteByte(byteValue);
                    if (lastFileProgress > 1)
                    {
                        int fileProgress = fileTotal / --lastFileProgress;
                        var a = stageTotal - fileProgress;
                        if (a > 0)
                        {
                            currentProgress = stageTotal / a;
                        }
                    }

                    if (currentProgress != currentStage)
                    {
                        currentStage = currentProgress;
                        ProgressBar.DrawProgressBar(currentProgress + 40, 100, progressMesssage);
                    }
                }
            }
        }

        private void CreateIfNotExists(string fileName)
        {
            var path = Path.GetDirectoryName(fileName);

            if (string.IsNullOrEmpty(path) || Directory.Exists(path))
            {
                return;
            }

            Console.WriteLine("Creating Directory: {0}", path);
            Directory.CreateDirectory(path);
        }
    }
}