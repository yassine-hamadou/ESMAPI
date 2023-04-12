using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Sections;

namespace ServiceManagerApi.Dtos.Services
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
     
        public  virtual ICollection<SectionDto> Sections { get; set; }
    }
}
