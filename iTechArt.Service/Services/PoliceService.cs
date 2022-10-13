using iTechArt.Data.IRepositories;
using iTechArt.Domain.Entities.Police;
using iTechArt.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Services
{
    public class PoliceService : IPoliceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PoliceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> ExportOfficers()
        {
            return new List<string>();
        }

        public List<string> ImportOfficers()
        {
            return new List<string>();
        }
    }
}
