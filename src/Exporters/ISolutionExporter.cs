namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    public interface ISolutionExporter
    {
        byte[] ExportSolutionFile(string solutionName, bool exportManagedSolution);
    }
}