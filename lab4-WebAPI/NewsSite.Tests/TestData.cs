using BLL.DTO;
using DAL.Entities;

namespace NewsSite.Tests;

public static class TestData
{
    private static Random random = new Random();
    public static List<AuthorDTO> AuthorsDTO => new List<AuthorDTO>
        {
            new AuthorDTO(){Id = 1, Name = "John Brown", Email = "brown@gmail.com", Password = "12345678"},
            new AuthorDTO(){Id = 2, Name = "Jack Back", Email = "back11@gmail.com", Password = "fds8ds98"},
            new AuthorDTO(){Id = 3, Name = "Tim Burton", Email = "burton99@gmail.com", Password = "fjtuvnq3"},
            new AuthorDTO(){Id = 4, Name = "Bob Sponge", Email = "squarepants@gmail.com", Password = "pvntydq4"},
            new AuthorDTO(){Id = 5, Name = "Tim Lee", Email = "leelo@gmail.com", Password = "74mnty98"},
        };
    public static List<NewsDTO> NewsDTO => new()
        {
            new NewsDTO
            {
                Id = 1,
                Title = "Wanted dead or alive",
                Body = "Etiam eu lacus vitae eros.",
                AuthorName = AuthorsDTO[random.Next(0,4)].Name,
                Date = DateTime.Now.AddDays(random.Next(0,4)),
                RubricName = Rubrics[random.Next(0,4)].Name,
                Tags = Tags.Skip(random.Next(0,2)).Take(2).Select(x => x.Name).ToList()
            },

            new NewsDTO
            {
                Id = 2,
                Title = "Integer et.",
                Body = "Quisque eget est condimentum, tincidunt.",
                AuthorName = AuthorsDTO[random.Next(0,4)].Name,
                Date = DateTime.Now.AddDays(random.Next(0,4)),
                RubricName = Rubrics[random.Next(0,4)].Name,
                Tags = Tags.Skip(random.Next(0,2)).Take(2).Select(x => x.Name).ToList()
            },

            new NewsDTO
            {
                Id = 3,
                Title = "Aenean euismod.",
                Body = "Praesent pellentesque posuere scelerisque. Morbi.",
                AuthorName = AuthorsDTO[random.Next(0,4)].Name,
                Date = DateTime.Now.AddDays(1),
                RubricName = Rubrics[random.Next(0,4)].Name,
                Tags = Tags.Skip(random.Next(0,2)).Take(2).Select(x => x.Name).ToList()
            },

            new NewsDTO
            {
                Id = 4,
                Title = "Morbi velit.",
                Body = "Aenean et facilisis est. Suspendisse.",
                AuthorName = AuthorsDTO[random.Next(0,4)].Name,
                Date = DateTime.Now.AddDays(1),
                RubricName = Rubrics[random.Next(0,4)].Name,
                Tags = Tags.Skip(random.Next(0,2)).Take(2).Select(x => x.Name).ToList()
            },

            new NewsDTO
            {
                Id = 5,
                Title = "Proin non.",
                Body = "Nam tristique non ipsum egestas.",
                AuthorName = AuthorsDTO[random.Next(0,4)].Name,
                Date = DateTime.Now.AddDays(1),
                RubricName = Rubrics[random.Next(0,4)].Name,
                Tags = Tags.Skip(random.Next(0,2)).Take(2).Select(x => x.Name).ToList()
            },
        };
    public static List<TagDTO> TagsDTO => new List<TagDTO>()
        {
            new TagDTO(){ Id = 1, Name = "Covid-19"},
            new TagDTO(){ Id = 2, Name = "Cars"},
            new TagDTO(){ Id = 3, Name = "Batman"},
            new TagDTO(){ Id = 4, Name = "Red"},
            new TagDTO(){ Id = 5, Name = "Plane"},
        };
    public static List<RubricDTO> RubricsDTO => new List<RubricDTO>()
        {
            new RubricDTO(){Id = 1, Name = "Health"},
            new RubricDTO(){Id = 2, Name = "Sport"},
            new RubricDTO(){Id = 3, Name = "Politics"},
            new RubricDTO(){Id = 4, Name = "Art"},
            new RubricDTO(){Id = 5, Name = "Hunt"},
        };
    public static List<Author> Authors => new List<Author>()
        {
            new Author(){Id = 1, Name = "John Brown", Email = "brown@gmail.com", Password = "12345678"},
            new Author(){Id = 2, Name = "Jack Back", Email = "back11@gmail.com", Password = "fds8ds98"},
            new Author(){Id = 3, Name = "Tim Burton", Email = "burton99@gmail.com", Password = "fjtuvnq3"},
            new Author(){Id = 4, Name = "Bob Sponge", Email = "squarepants@gmail.com", Password = "pvntydq4"},
            new Author(){Id = 5, Name = "Tim Lee", Email = "leelo@gmail.com", Password = "74mnty98"},
        };
    public static List<News> News => new List<News>()
        {
            new News
            {
                Id = 1,
                Title = "Wanted dead or alive",
                Body = "Etiam eu lacus vitae eros.",
                Author = Authors[random.Next(0,4)],
                Date = DateTime.Now.AddDays(random.Next(0,4)),
                Rubric = Rubrics[random.Next(0, 4)],
                Tags = Tags.Skip(random.Next(0,2)).Take(2).ToList()
            },

            new News
            {
                Id = 2,
                Title = "Integer et.",
                Body = "Quisque eget est condimentum, tincidunt.",
                Author = Authors[random.Next(0, 4)],
                Date = DateTime.Now.AddDays(random.Next(0,4)),
                Rubric = Rubrics[random.Next(0, 4)],
                Tags = Tags.Skip(random.Next(0, 2)).Take(2).ToList()
            },

            new News
            {
                Id = 3,
                Title = "Aenean euismod.",
                Body = "Praesent pellentesque posuere scelerisque. Morbi.",
                Author = Authors[random.Next(0, 4)],
                Date = DateTime.Now.AddDays(1),
                Rubric = Rubrics[random.Next(0, 4)],
                Tags = Tags.Skip(random.Next(0, 2)).Take(2).ToList()
            },

            new News
            {
                Id = 4,
                Title = "Morbi velit.",
                Body = "Aenean et facilisis est. Suspendisse.",
                Author = Authors[random.Next(0,4)],
                Date = DateTime.Now.AddDays(1),
                Rubric = Rubrics[random.Next(0, 4)],
                Tags = Tags.Skip(random.Next(0,2)).Take(2).ToList()
            },

            new News
            {
                Id = 5,
                Title = "Proin non.",
                Body = "Nam tristique non ipsum egestas.",
                Author = Authors[random.Next(0,4)],
                Date = DateTime.Now.AddDays(1),
                Rubric = Rubrics[random.Next(0,4)],
                Tags = Tags.Skip(random.Next(0,2)).Take(2).ToList()
            },
        };
    public static List<Tag> Tags => new List<Tag>()
        {
            new Tag(){ Id = 1, Name = "Covid-19", },
            new Tag(){ Id = 2, Name = "Cars"},
            new Tag(){ Id = 3, Name = "Batman"},
            new Tag(){ Id = 4, Name = "Red"},
            new Tag(){ Id = 5, Name = "Plane"},
        };
    public static List<Rubric> Rubrics => new List<Rubric>()
        {
            new Rubric(){Id = 1, Name = "Health"},
            new Rubric(){Id = 2, Name = "Sport"},
            new Rubric(){Id = 3, Name = "Politics"},
            new Rubric(){Id = 4, Name = "Art"},
            new Rubric(){Id = 5, Name = "Hunt"},
        };
}
