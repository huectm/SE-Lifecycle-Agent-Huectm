namespace FreshFood.Reposistory.Repository;

public interface IFefoBatchSpecification
{
    BatchCriteria Criteria(DateTimeOffset asOf);
}
