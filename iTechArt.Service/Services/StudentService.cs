using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Services
{
    public class StudentService : IStudentService
    {
        public IFormFile ExportStudent()
        {
            return new object() as IFormFile;
        }

        public void ImportStudent(IFormFile formFile)
        {

        }
    }
}
