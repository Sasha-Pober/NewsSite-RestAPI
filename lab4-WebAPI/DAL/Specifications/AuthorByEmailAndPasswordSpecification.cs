using DAL.Entities;

namespace DAL.Specifications;

public class AuthorByEmailAndPasswordSpecification : Specification<Author>
{
    public AuthorByEmailAndPasswordSpecification(string email, string password)
        : base(author => author.Email.Equals(email) && author.Password.Equals(password))
    {

    }
}
