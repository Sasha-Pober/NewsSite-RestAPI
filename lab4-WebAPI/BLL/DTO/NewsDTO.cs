namespace BLL.DTO;

public class NewsDTO : BaseDTO
{
    public string Title { get; set; } = null!;
    public string Body { get; set; } = null!;
    public DateTime Date {  get; set; }
    public int AuthorId{ get; set; }
    public int RubricId { get; set; }
    public List<string> Tags { get; set; } = [];

}
