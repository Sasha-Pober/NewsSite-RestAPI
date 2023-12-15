using DAL.Entities;

namespace DAL.Specifications;

public class RubricByIdWithNewsSpecification : Specification<Rubric>
{
    public RubricByIdWithNewsSpecification(int id) : base(rubric => rubric.Id == id)
    {
        AddInclude(rubric => rubric.News);
    }
}
