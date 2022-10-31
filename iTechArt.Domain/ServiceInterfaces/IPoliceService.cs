using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to import data to the database
        /// </summary>
        /// <param name="formFile"></param>
        public Task ImportPoliceData(IFormFile formFile);

        /// <summary>
        /// function to export data from the database
        /// </summary>
        public Task<IPolice[]> ExportPoliceData();
    }
}
