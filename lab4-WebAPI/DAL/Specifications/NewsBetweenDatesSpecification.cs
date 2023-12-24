using DAL.Entities;

namespace DAL.Specifications;

public class NewsBetweenDatesSpecification : Specification<News>
{
    public NewsBetweenDatesSpecification(DateTime datefrom, DateTime dateTo) 
        : base(news => news.Date >= datefrom && news.Date <= dateTo)
    {
        AddInclude(news => news.Author);
        AddInclude(news => news.Rubric);
        AddInclude(news => news.Tags);
    }
}
