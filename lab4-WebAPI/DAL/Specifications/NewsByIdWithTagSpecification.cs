using DAL.Entities;

namespace DAL.Specifications;

public class NewsByIdWithTagSpecification : Specification<News>
{
    public NewsByIdWithTagSpecification(int id) : base(news => news.Id == id)
    {
        AddInclude(news => news.Tags);
    }
}
