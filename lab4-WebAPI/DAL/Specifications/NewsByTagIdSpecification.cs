using DAL.Entities;
using System.Linq;

namespace DAL.Specifications;

public class NewsByTagIdSpecification : Specification<News>
{
    public NewsByTagIdSpecification(int id) : 
        base(news => news.Tags.Any(t => t.Id == id))
    {
        AddInclude(news => news.Tags);
    }
}
