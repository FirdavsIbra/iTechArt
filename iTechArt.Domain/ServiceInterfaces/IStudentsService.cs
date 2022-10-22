using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStudentsService
    {
        public IStudent[] ImportStudentsAsync();

        public IStudent[] ExportStudentsAsync();
    }
}
