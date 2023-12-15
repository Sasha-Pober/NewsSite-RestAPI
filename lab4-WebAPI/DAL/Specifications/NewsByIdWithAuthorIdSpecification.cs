using DAL.Entities;

namespace DAL.Specifications;

public class NewsByIdWithAuthorIdSpecification : Specification<News>
{
    public NewsByIdWithAuthorIdSpecification(int newsId, int authorId) 
        : base(news => news.Id.Equals(newsId) && news.AuthorId.Equals(authorId))
    {

    }
}
