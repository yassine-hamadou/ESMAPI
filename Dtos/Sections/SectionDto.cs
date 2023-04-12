using ServiceManagerApi.Dtos.Groups;

namespace ServiceManagerApi.Dtos.Sections
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ServiceId { get; set; }
        public virtual ICollection<GroupDto> Groups { get; set; }

    }
}
