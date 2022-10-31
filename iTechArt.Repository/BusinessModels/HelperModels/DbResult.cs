using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;

namespace iTechArt.Repository.BusinessModels.HelperModels
{
    public class DbResult: IDbResult
    {
        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }
    }
}
