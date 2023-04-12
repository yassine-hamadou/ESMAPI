namespace ServiceManagerApi.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGroupRepository Groups { get; }
        IItemsRepository Items { get; }
        ISectionRepository Sections { get; }
        IServiceRepository Services { get; }

        Task<int> Commit();
    }
}
