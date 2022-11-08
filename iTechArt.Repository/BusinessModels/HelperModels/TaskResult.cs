using iTechArt.Domain.ModelInterfaces.HelperModelInterfaces;

namespace iTechArt.Repository.BusinessModels.HelperModels
{
    public class TaskResult: ITaskResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
