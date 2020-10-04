namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    public class FileNameBuilder : IFileNameBuilder
    {
        private readonly ISolutionReader solutionReader;

        public FileNameBuilder(ISolutionReader solutionReader)
        {
            this.solutionReader = solutionReader;
        }

        public string Build(string destinationFolder, string solutionUniqueName, string solutionType, bool appendVersionToOutputFile)
        {
            ProgressBar.DrawProgressBar(30, 100, "Building Filename start.");
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

            ProgressBar.DrawProgressBar(40, 100, "Building Filename end - " + fileName + ".");

            return fileName;
        }
    }
}