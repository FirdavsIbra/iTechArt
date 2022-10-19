namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPupilService
    {
        public List<string> ImportPupilsFile();
        public List<string> ExportPupilsFile();
    }
}
