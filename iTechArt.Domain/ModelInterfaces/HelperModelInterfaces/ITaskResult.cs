namespace iTechArt.Domain.ModelInterfaces.HelperModelInterfaces
{
    public interface ITaskResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public Exception Exception { get;}
    }
}
