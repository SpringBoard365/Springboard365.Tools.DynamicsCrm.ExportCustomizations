namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using Springboard365.Tools.CommandLine.Core;

    public class FileNameBuilder : IFileNameBuilder
    {
        private readonly ISolutionReader solutionReader;

        public FileNameBuilder(ISolutionReader solutionReader)
        {
            this.solutionReader = solutionReader;
        }

        public string Build(string destinationFolder, string solutionUniqueName, string solutionType, bool appendVersionToOutputFile)
        {
            ConsoleLogger.LogProgress("Building Filename start.", new ProgressBarOptions { Progress = 30, Total = 100 });

            var path = string.IsNullOrEmpty(destinationFolder) ? "." : destinationFolder;

            var versionNumber = appendVersionToOutputFile ? $"_{solutionReader.GetSolutionVersion(solutionUniqueName)}" : string.Empty;

            var packagetype = solutionType.ToLowerInvariant().Equals("managed") ? $"_{solutionType.ToLowerInvariant()}" : string.Empty;

            var fileName = $"{path}\\{solutionUniqueName}{versionNumber}{packagetype}.zip";

            ConsoleLogger.LogProgress($"Building Filename end - {fileName}.", new ProgressBarOptions { Progress = 40, Total = 100 });
            return fileName;
        }
    }
}