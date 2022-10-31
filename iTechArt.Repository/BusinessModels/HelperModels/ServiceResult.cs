using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;

namespace iTechArt.Repository.BusinessModels.HelperModels
{
    public class ServiceResult: IServiceResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
