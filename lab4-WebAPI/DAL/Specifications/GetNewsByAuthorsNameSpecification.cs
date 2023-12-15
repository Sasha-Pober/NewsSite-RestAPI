using DAL.Entities;

namespace DAL.Specifications;

public class GetNewsByAuthorsNameSpecification : Specification<News>
{
    public GetNewsByAuthorsNameSpecification(string name) 
        : base(news => news.Author.Name.Equals(name))
    {

    }
}
