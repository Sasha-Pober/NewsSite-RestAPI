using DAL.Entities;

namespace DAL.Specifications;

public class NewsByRubricNameSpecification : Specification<News>
{
    public NewsByRubricNameSpecification(string name) : base(news => news.Rubric.Name == name)
    {
        AddInclude(news => news.Rubric);
    }
}
