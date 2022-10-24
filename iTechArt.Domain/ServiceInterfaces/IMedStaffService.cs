using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IMedStaffService
    {
        /// <summary>
        /// Uploads a file of data 
        /// </summary>
        public IDoctor[] ImportMedStaffFile();


        /// <summary>
        /// Gets all info from database
        /// </summary>
        public IDoctor[] ExportMedStaffFile();
    }
}
