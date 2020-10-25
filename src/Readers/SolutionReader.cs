namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Documents;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Springboard365.Tools.CommandLine.Core;

    public class SolutionReader : ISolutionReader
    {
        private readonly IOrganizationService organizationService;

        public SolutionReader(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        public string GetSolutionVersion(string solutionUniqueName)
        {
            var querySolution = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet("version"),
                Criteria = new FilterExpression(),
            };

            querySolution.Criteria.AddCondition("uniquename", ConditionOperator.Equal, solutionUniqueName);

            ConsoleLogger.LogProgress("Retrieve solution entity start.", new ProgressBarOptions { Progress = 33, Total = 100 });
            var solutionEntity = organizationService.RetrieveMultiple(querySolution).Entities.First();
            ConsoleLogger.LogProgress("Retrieve solution entity end.", new ProgressBarOptions { Progress = 36, Total = 100 });

            var solutionVersion = solutionEntity["version"].ToString();

            ConsoleLogger.LogProgress($"Solution Version: {solutionVersion}", new ProgressBarOptions { Progress = 39, Total = 100 });

            return FormatSolutionVersion(solutionVersion);
        }

        private static string FormatSolutionVersion(string solutionVersion)
        {
            return solutionVersion.Replace('.', '_');
        }
    }
}