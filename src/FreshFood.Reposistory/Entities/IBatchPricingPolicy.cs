namespace FreshFood.Reposistory.Entities;

public interface IBatchPricingPolicy
{
    VndAmount Quote(BatchInventory batch, DateTimeOffset asOf);
}
