namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using System;
    using System.IO;

    public class FileWriter : IFileWriter
    {
        public void Write(string fileName, byte[] compressedXml)
        {
            Console.WriteLine("Filename: " + fileName);
            CreateIfNotExists(fileName);

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                Console.WriteLine("Writing file.");
                fileStream.Write(compressedXml, 0, compressedXml.Length);
            }
        }

        private void CreateIfNotExists(string fileName)
        {
            var path = Path.GetDirectoryName(fileName);

            if (path == null || Directory.Exists(path))
            {
                return;
            }

            Console.WriteLine("Creating Directory: " + path);
            Directory.CreateDirectory(path);
        }
    }
}