using DAL.Entities;

namespace DAL.Specifications;

public class RubricByNameSpecification : Specification<Rubric>
{
    public RubricByNameSpecification(string name) : base(rubric => rubric.Name.Equals(name))
    {

    }
}
