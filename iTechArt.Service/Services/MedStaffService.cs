using iTechArt.Service.Interfaces;

namespace iTechArt.Service.Services
{
    public class MedStaffService : IMedStaffService
    {
        /// <summary>
        /// Takes filestream
        /// </summary>
        /// <returns> List of strings </returns>
        public List<string> ExportMedStaffFile()
        {
            return new List<string>();
        }

        /// <summary>
        /// Takes no input so far
        /// </summary>
        /// <returns> Empty List of string </returns>
        public List<string> ImportMedStaffFile()
        {
            return new List<string>();
        }
    }
}
