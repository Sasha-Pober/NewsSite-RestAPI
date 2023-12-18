using DAL.Entities;

namespace DAL.Specifications;

public class NewsWithTagByIds : Specification<NewsWithTag>
{
    public NewsWithTagByIds(int newsId, int tagId) : base(nwt => nwt.NewsId == newsId && nwt.TagId == tagId)
    {

    }
}
