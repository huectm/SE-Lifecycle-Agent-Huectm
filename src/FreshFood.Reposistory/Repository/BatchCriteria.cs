namespace FreshFood.Reposistory.Repository;

public class BatchCriteria
{
    public bool ActiveProductsOnly { get; set; }
    public DateTimeOffset AsOf { get; set; }
    public int MinimumAvailable { get; set; }
    public List<string> SortKeys { get; set; } = [];
    public bool LockForUpdate { get; set; }
}
