namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to imports data to the database
        /// </summary>
        public List<string> ImportPolice();

        /// <summary>
        /// function to exports data from the database
        /// </summary>
        public List<string> ExportPolice();
    }
}
