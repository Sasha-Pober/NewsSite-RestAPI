using DAL.Entities;

namespace DAL.Specifications;

public class NewsWithTagsSpecification : Specification<News>
{
    public NewsWithTagsSpecification() : base(null) 
    {
        AddInclude(news => news.Tags);
    }
}
