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

        public async Task<Officer> AddUpdateOfficer(Officer officer)
        {
            var objFromDb = await  _unitOfWork.Police.GetAsync(c => c.OfficerId == officer.OfficerId);
            if (objFromDb.OfficerId > 0)
            {
                _unitOfWork.Police.Update(officer);
                await _unitOfWork.Police.SaveChangesAsync();
            }
            else
            {
                await _unitOfWork.Police.AddAsync(officer);
                await _unitOfWork.Police.SaveChangesAsync();
            }
            return officer;
        }

        public async Task<bool> DeleteOfficer(int id)
        {
            var objFromDb = await _unitOfWork.Police.GetAsync(c => c.OfficerId == id);
            if (objFromDb != null)
            {
                _unitOfWork.Police.Delete(objFromDb);
                return true;
            }
            return false;
        }

        public async Task<List<Officer>> GetAllOfficers()
        {
            var query = _unitOfWork.Police.GetAll();
            return query.ToList();
        }

        public async Task<Officer> GetOfficerById(int id)
        {
            return await _unitOfWork.Police.GetAsync(c => c.OfficerId == id);
        }
    }
}
