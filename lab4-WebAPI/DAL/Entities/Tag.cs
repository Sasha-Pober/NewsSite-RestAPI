namespace DAL.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<NewsWithTag> NewsWithTags { get; } = [];
    public List<News> News { get; } = [];
}
