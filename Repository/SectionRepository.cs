using ServiceManagerApi.Data;
using ServiceManagerApi.Interfaces;

namespace ServiceManagerApi.Repository
{
       public class SectionRepository : GenericRepositoryAsync<Section>, ISectionRepository
    {
        public SectionRepository(EnpDbContext context) : base(context) { }
    }
}
