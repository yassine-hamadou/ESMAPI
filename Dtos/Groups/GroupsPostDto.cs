namespace ServiceManagerApi.Dtos.Groups
{
    public record GroupsPostDto
    {
        public string? Name { get; set; }
        public int SectionId { get; set; }
    }
}
