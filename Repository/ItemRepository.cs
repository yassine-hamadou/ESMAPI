using ServiceManagerApi.Data;
using ServiceManagerApi.Interfaces;

namespace ServiceManagerApi.Repository
{
    public class ItemRepository:GenericRepositoryAsync<Item>,IItemsRepository
    {
        public ItemRepository(EnpDbContext context) : base(context) { }
    }
}
