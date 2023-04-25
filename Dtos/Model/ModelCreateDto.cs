namespace ServiceManagerApi.Dtos.Model
{
    public class ModelCreateDto
    {
        public int? ManufacturerId { get; set; }
        public int? ModelClassId { get; set; }
        public string? Name { get; set; }
        public string Code { get; set; } = null!;
        public string? PictureLink { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
