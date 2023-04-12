namespace ServiceManagerApi.ViewModels
{
    public class InventoryItemsViewModel
    {
        public string ItemNumber { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string ItemDescription { get; set; } = null!;
        public string AuditUser { get; set; } = null!;
    }
}
