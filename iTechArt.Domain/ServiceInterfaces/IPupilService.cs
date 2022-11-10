using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPupilService
    {
        /// <summary>
        /// Upload pupil's file.
        /// </summary>
        public Task ImportPupilsFileAsync(IFormFile file);

        /// <summary>
        /// Get all pupils.
        /// </summary>
        public Task<IPupil[]> GetAllAsync();

        /// <summary>
        /// Parse pupil's file from excel.
        /// </summary>
        public Task ImportExcelAsync(IFormFile file);

        /// <summary>
        /// Parse pupil's file from csv.
        /// </summary>
        public Task ImportCsvAsync(IFormFile file);

        /// <summary>
        /// Parse pupil's file from xml.
        /// </summary>
        public Task ImportXmlAsync(IFormFile file);
    }
}
