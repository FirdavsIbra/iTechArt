using iTechArt.Domain.Entities.Police;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Interfaces
{
    public interface IPoliceService
    {
        Task<Officer> AddUpdateOfficer(Officer officer);

        Task<List<Officer>> GetAllOfficers();

        Task<Officer> GetOfficerById(int id);

        Task<bool> DeleteOfficer(int id);
    }
}
