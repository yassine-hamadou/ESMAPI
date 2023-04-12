namespace ServiceManagerApi.Dtos.LubeConfigs
{
    public class LubeConfigPostDto
    {
        public string? Model { get; set; }
        public int? CompartmentId { get; set; }
        public string? ChangeOutInterval { get; set; }
        public string? Capacity { get; set; }

    }
}
