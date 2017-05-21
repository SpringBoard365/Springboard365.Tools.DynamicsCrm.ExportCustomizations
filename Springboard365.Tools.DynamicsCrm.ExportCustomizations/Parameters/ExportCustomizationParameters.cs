namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using Springboard365.Tools.DynamicsCrm.Common;
    using Springboard365.Tools.CommandLine.Core;

    public class ExportCustomizationParameters : CrmCommandLineParameterBase
    {
        [CommandLineArgument(ArgumentType.Required, "SolutionUniqueName", Description = "Show the file name.", Shortcut = "name")]
        public string SolutionUniqueName { get; set; }

        [CommandLineArgument(ArgumentType.Required, "DestinationFolder", Description = "Show the file name.", Shortcut = "folder")]
        public string DestinationFolder { get; set; }

        [CommandLineArgument(ArgumentType.Required, "SolutionType", Description = "Show the Import job file save path.", Shortcut = "type")]
        public string SolutionType { get; set; }

        [CommandLineArgument(ArgumentType.Required, "AppendVersionToOutputFile", Description = "Show the Import job file save path.", Shortcut = "append")]
        public bool AppendVersionToOutputFile { get; set; }
    }
}