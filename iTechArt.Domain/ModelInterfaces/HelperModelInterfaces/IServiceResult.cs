namespace iTechArt.Domain.ModelInterfaces.HelperModelInterfaces
{
    public interface IServiceResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
