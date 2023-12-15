namespace BLL.DTO;

public class NewsDTO
{
    public string Title { get; set; } = null!;
    public string Body { get; set; } = null!;
    public int AuthorId{ get; set; }
    public int RubricId { get; set; }

}
