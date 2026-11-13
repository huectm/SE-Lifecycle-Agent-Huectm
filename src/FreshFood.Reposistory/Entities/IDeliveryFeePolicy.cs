namespace FreshFood.Reposistory.Entities;

public interface IDeliveryFeePolicy
{
    VndAmount Quote(decimal distanceKm);
}
