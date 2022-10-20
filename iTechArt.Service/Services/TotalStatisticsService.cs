using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Repository.BusinessModels;

namespace iTechArt.Service.Services
{
    public class TotalStatisticsService : ITotalStatisticsService
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IGroceryRepository _groceryRepository;
        private readonly IPoliceRepository _policeRepository;
        public TotalStatisticsService(
            IPupilRepository pupilRepository,
            IAirportRepository airportRepository,
            IDoctorRepository doctorRepository,
            IStudentRepository studentRepository,
            IGroceryRepository groceryRepository,
            IPoliceRepository policeRepository)
        {
            _pupilRepository = pupilRepository;
            _airportRepository = airportRepository;
            _doctorRepository = doctorRepository;
            _studentRepository = studentRepository;
            _groceryRepository = groceryRepository;
            _policeRepository = policeRepository;
        }

        /// <summary>
        /// Get total counts of users
        /// </summary>
        /// <returns></returns>
        public IDashboardInfo GetCountOfUsers()
        {
            return new DashboardInfo()
            {
                StudentCount = _studentRepository.GetCountOfStudents(),
                AirportCount = _airportRepository.GetCountOfAirport(),
                DoctorCount = _doctorRepository.GetCountOfDoctors(),
                PoliceCount = _policeRepository.GetCountOfPolice(),
                PupilCount = _pupilRepository.GetCountOfPupils(),
                GroceryCount = _groceryRepository.GetCountOfGrocery(),
            };
        }
    }
}
