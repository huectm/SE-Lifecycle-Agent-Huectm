namespace FreshFood.Reposistory.Entities;

public partial class DeliveryFailure
{
    public string FailureId { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string FailureCause { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public int ReportedByStaffId { get; set; }
    public DateTimeOffset ReportedAt { get; set; }
    public int CauseConfirmedByStaffId { get; set; }
    public DateTimeOffset CauseConfirmedAt { get; set; }
    public string CauseEvidence { get; set; } = string.Empty;
}
