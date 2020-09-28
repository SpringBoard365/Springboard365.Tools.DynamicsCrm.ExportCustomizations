namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using System;

    public class FileNameBuilder : IFileNameBuilder
    {
        private readonly ISolutionReader solutionReader;

        public FileNameBuilder(ISolutionReader solutionReader)
        {
            this.solutionReader = solutionReader;
        }

        public string Build(string destinationFolder, string solutionUniqueName, string solutionType, bool appendVersionToOutputFile)
        {
            Console.WriteLine("Building Filename.");
            var fileName = string.Empty;

            if (!string.IsNullOrEmpty(destinationFolder))
            {
                fileName = destinationFolder + "\\" + solutionUniqueName;
            }

            fileName += solutionUniqueName;

            if (appendVersionToOutputFile)
            {
                fileName += "_" + solutionReader.GetSolutionVersion(solutionUniqueName);
            }

            if (solutionType.ToLowerInvariant().Equals("managed"))
            {
                fileName += "_" + solutionType;
            }

            fileName += ".zip";

            Console.WriteLine("FileName: {0}", fileName);

            return fileName;
        }
    }
}