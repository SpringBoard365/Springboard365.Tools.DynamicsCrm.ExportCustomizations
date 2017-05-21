namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

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
                SolutionName = solutionName
            };

            Console.WriteLine("Solution export start.");
            var exportSolutionResponse = (ExportSolutionResponse)organizationService.Execute(exportSolutionRequest);
            Console.WriteLine("Solution export end.");

            return exportSolutionResponse.ExportSolutionFile;
        }
    }
}