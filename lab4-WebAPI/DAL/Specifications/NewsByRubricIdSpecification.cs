using DAL.Entities;

namespace DAL.Specifications;

public class NewsByRubricIdSpecification : Specification<News>
{
    public NewsByRubricIdSpecification(int id) : base(news => news.Rubric.Id == id)
    {
        AddInclude(news => news.Rubric);
        AddInclude(news => news.Tags);
    }
}
