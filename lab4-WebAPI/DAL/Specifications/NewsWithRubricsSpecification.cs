using DAL.Entities;

namespace DAL.Specifications;

public class NewsWithRubricsSpecification : Specification<News>
{
    public NewsWithRubricsSpecification() : base(null)
    {
        AddInclude(news => news.Rubric);
        AddInclude(news => news.Tags);
        AddInclude(news => news.Author);
        AddOrderBy(news => news.Rubric.Id);
    }
}
