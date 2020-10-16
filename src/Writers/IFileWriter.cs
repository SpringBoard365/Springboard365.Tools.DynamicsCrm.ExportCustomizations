namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    public interface IFileWriter
    {
        void Write(string fileName, byte[] compressedXml);
    }
}