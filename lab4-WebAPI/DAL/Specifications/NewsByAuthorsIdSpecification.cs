using DAL.Entities;

namespace DAL.Specifications;

public class NewsByAuthorsIdSpecification : Specification<News>
{
    public NewsByAuthorsIdSpecification(int id) : base(news => news.AuthorId == id)
    {
        AddInclude(news => news.Author);
        AddInclude(news => news.Tags);
    }
}
