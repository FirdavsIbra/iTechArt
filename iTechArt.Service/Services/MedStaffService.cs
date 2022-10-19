using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public class MedStaffService : IMedStaffService
    {
        /// <summary>
        /// Takes filestream
        /// </summary>
        /// <returns> List of strings </returns>
        public async ValueTask<List<string>> ExportMedStaffFile()
        {
            return new List<string>();
        }

        /// <summary>
        /// Takes no input so far
        /// </summary>
        /// <returns> Empty List of string </returns>
        public async ValueTask<List<string>> ImportMedStaffFile()
        {
            return new List<string>();
        }
    }
}
