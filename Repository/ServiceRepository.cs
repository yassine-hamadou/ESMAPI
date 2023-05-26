using ServiceManagerApi.Data;
using ServiceManagerApi.Interfaces;

namespace ServiceManagerApi.Repository
{
    public class ServiceRepository:GenericRepositoryAsync<Service>, IServiceRepository
    {
        public ServiceRepository(EnpDbContext context) : base(context) { }
    }


}
