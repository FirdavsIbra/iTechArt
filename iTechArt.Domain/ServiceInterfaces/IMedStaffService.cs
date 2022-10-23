using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IMedStaffService
    {
        /// <summary>
        /// Uploads a file of data 
        /// </summary>
        /// <returns></returns>
        public IDoctor[] ImportMedStaffFile();


        /// <summary>
        /// Gets all info from database
        /// </summary>
        /// <returns></returns>
        public IDoctor[] ExportMedStaffFile();
    }
}
