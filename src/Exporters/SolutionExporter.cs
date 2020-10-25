namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Tools.CommandLine.Core;

    public class SolutionExporter : ISolutionExporter
    {
        private readonly IOrganizationService organizationService;

        public SolutionExporter(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        public byte[] ExportSolutionFile(string solutionName, bool exportManagedSolution)
        {
            var exportSolutionRequest = new ExportSolutionRequest
            {
                Managed = exportManagedSolution,
                SolutionName = solutionName,
            };

            ConsoleLogger.LogProgress("Solution export start.", new ProgressBarOptions { Progress = 0, Total = 100 });
            var exportSolutionResponse = (ExportSolutionResponse)organizationService.Execute(exportSolutionRequest);
            ConsoleLogger.LogProgress("Solution export end.", new ProgressBarOptions { Progress = 20, Total = 100 });

            return exportSolutionResponse.ExportSolutionFile;
        }
    }
}