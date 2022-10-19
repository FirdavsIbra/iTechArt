namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IUnitofWork
    {
        IPoliceRepository Police { get; }
    }
}
