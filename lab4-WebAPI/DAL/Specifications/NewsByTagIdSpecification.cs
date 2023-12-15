using DAL.Entities;
using System.Linq;

namespace DAL.Specifications;

public class NewsByTagIdSpecification : Specification<News>
{
    public NewsByTagIdSpecification(int id) : 
        base(news => news.Tags.Contains(news.Tags.Find(t => t.Id.Equals(id))))
    {
        AddInclude(news => news.Tags);
    }
}
