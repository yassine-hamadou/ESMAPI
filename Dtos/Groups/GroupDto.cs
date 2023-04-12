using ServiceManagerApi.Dtos.Items;
using ServiceManagerApi.Dtos.Sections;

namespace ServiceManagerApi.Dtos.Groups
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SectionId { get; set; }
        public virtual ICollection<ItemsDto> Items { get; set; }
    }
}
