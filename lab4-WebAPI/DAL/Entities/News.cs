
namespace DAL.Entities;

public class News : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Body { get; set; } = null!;
    public DateTime Date { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public List<NewsWithTag> NewsWithTags { get; set; } = [];
    public List<Tag> Tags { get; set; } = [];
    public int RubricId { get; set; }
    public Rubric Rubric { get; set; } = null!;

}
