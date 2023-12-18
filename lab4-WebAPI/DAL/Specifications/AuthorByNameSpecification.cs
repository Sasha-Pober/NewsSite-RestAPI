using DAL.Entities;

namespace DAL.Specifications;

public class AuthorByNameSpecification : Specification<Author>
{
    public AuthorByNameSpecification(string name) : base(author => author.Name.Equals(name))
    {

    }
}
