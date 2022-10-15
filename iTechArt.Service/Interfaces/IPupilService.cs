namespace iTechArt.Service.Interfaces
{
    public interface IPupilService
    {
        IEnumerable<string> ImportPupilsFile();
        IEnumerable<string> ExportPupilsFile();
    }
}
