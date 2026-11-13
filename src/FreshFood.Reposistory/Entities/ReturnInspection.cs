namespace FreshFood.Reposistory.Entities;

public partial class ReturnInspection
{
    public string InspectionId { get; set; } = string.Empty;
    public string ReturnReceiptItemId { get; set; } = string.Empty;
    public int InspectedByStaffId { get; set; }
    public DateTimeOffset InspectedAt { get; set; }
    public int Quantity { get; set; }
    public string Disposition { get; set; } = string.Empty;
    public string ConditionNotes { get; set; } = string.Empty;
    public DateTimeOffset InventoryAppliedAt { get; set; }
}
