using iTechArt.Data;
using iTechArt.Domain.Entities.Police;
using iTechArt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoliceController : ControllerBase
    {
        private readonly IPoliceService _policeService;
        public Response response { get; set; }

        public PoliceController(IPoliceService policeService)
        {
            _policeService = policeService;
            this.response = new Response();
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<List<Officer>>> GetAllOfficers()
        {
            var officers = await _policeService.GetAllOfficers();
            if (officers == null)
            {
                response.Success = false;
                response.Message = "No data found";
            }
            else
            {
                response.Data = officers;
                response.Success = true;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("getsingle/{id}")]
        public async Task<ActionResult<Response>> GetSingleOfficer(int id)
        {
            var objFromDb = await _policeService.GetOfficerById(id);
            if (objFromDb == null)
            {
                response.Success = false;
                response.Message = "Entity not found";
            }
            else
            {
                response.Success = true;
                response.Data = objFromDb;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Officer>> AddOfficer(Officer newOfficer)
        {
            return Ok(await _policeService.AddUpdateOfficer(newOfficer));
        }

        [HttpPut]
        public async Task<ActionResult<Officer>> UpdateOfficer(Officer officer)
        {
            return Ok(await _policeService.AddUpdateOfficer(officer));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteOfficer(int id)
        {
            var isDeleted = await _policeService.DeleteOfficer(id);
            if (!isDeleted)
            {
                response.Success = false;
                response.Message = "Not found";
                return NotFound(response);
            }
            else
            {
                response.Success = true;
                response.Message = "Deleted successfully";
                return Ok(response);
            }
        }
    }
}
