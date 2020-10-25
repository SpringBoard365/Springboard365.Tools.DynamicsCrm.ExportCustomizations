namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using Springboard365.Tools.CommandLine.Core;
    using Springboard365.Tools.DynamicsCrm.Common;

    public class ExportCustomizationParameters : CrmCommandLineParameterBase
    {
        [CommandLineArgument(ArgumentType.Required, "SolutionUniqueName", Description = "The solution unique name to be exported.", Shortcut = "name")]
        public string SolutionUniqueName { get; set; }

        [CommandLineArgument(ArgumentType.Optional, "DestinationFolder", Description = "The folder for the exported solution to be saved. Defaulted to the current folder.", Shortcut = "folder")]
        public string DestinationFolder { get; set; }

        [CommandLineArgument(ArgumentType.Required, "SolutionType", Description = "The type of solution to be exported. Unmanaged or Managed.", Shortcut = "type")]
        public string SolutionType { get; set; }

        [CommandLineArgument(ArgumentType.Required, "AppendVersionToOutputFile", Description = "Boolean to show whether the version should be appended to output file.", Shortcut = "append")]
        public bool AppendVersionToOutputFile { get; set; }
    }
}