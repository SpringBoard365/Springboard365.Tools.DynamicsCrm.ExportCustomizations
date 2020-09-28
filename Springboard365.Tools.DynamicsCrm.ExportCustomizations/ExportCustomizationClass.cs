namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using System;
    using Springboard365.Tools.DynamicsCrm.Common;

    public class ExportCustomizationClass : CrmToolBase
    {
        private const int MaxNumberOfRetries = 3;
        private IFileNameBuilder fileNameBuilder;
        private IFileWriter fileWriter;
        private ISolutionExporter solutionExporter;
        private ExportCustomizationParameters parameters;

        public ExportCustomizationClass(string[] args)
            : base(new ExportCustomizationParameters(), args)
        {
        }

        public override void Initialize()
        {
            fileNameBuilder = new FileNameBuilder(new SolutionReader(OrganizationService));
            fileWriter = new FileWriter();
            solutionExporter = new SolutionExporter(OrganizationService);
            parameters = (ExportCustomizationParameters)CommandLineParameterBase;
        }

        public override void Run()
        {
            var retries = 0;

            while (retries < MaxNumberOfRetries)
            {
                retries++;

                try
                {
                    var compressedXml = solutionExporter.ExportSolutionFile(parameters.SolutionUniqueName, parameters.SolutionType.ToLower().Equals("managed"));

                    var fileName = fileNameBuilder.Build(parameters.DestinationFolder, parameters.SolutionUniqueName, parameters.SolutionType, parameters.AppendVersionToOutputFile);

                    fileWriter.Write(fileName, compressedXml);
                    break;
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("Caught TimeoutException. Continuing...");
                }
            }
        }
    }
}