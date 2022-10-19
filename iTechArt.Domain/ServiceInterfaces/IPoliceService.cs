namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// PoliceInterface import function
        /// </summary>
        public List<string> ImportPolice();

        public List<string> ExportPolice();
    }
}
