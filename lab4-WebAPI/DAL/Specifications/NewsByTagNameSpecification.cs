using DAL.Entities;
using System.Linq;

namespace DAL.Specifications;

public class NewsByTagNameSpecification : Specification<News>
{
    public NewsByTagNameSpecification(string name) : 
        base(news => news.Tags.Contains(news.Tags.Find(t => t.Name.Equals(name))))
    {

    }
}
