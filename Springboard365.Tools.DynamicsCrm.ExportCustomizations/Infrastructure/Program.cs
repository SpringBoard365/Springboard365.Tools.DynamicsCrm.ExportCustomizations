﻿namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var exportClass = new ExportCustomizationClass(args);
            exportClass.Initialize();
            exportClass.Run();
        }
    }
}
