namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    public interface IFileNameBuilder
    {
        string Build(string destinationFolder, string solutionUniqueName, string solutionType, bool appendVersionToOutputFile);
    }
}