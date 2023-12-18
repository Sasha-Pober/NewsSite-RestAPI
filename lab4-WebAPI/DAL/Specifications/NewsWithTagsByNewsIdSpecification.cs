using DAL.Entities;

namespace DAL.Specifications;

public class NewsWithTagsByNewsIdSpecification : Specification<NewsWithTag>
{
    public NewsWithTagsByNewsIdSpecification(int id) : base(nwt => nwt.NewsId == id)
    {

    }
}
