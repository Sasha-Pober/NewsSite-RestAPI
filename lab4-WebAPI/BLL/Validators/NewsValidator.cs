using BLL.DTO;
using FluentValidation;

namespace BLL.Validators;

public class NewsValidator : AbstractValidator<NewsDTO>
{
    public NewsValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty(); 
        RuleFor(x => x.Body).NotNull().NotEmpty();
        RuleFor(x => x.AuthorId).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(x => x.RubricId).NotNull().NotEmpty().GreaterThan(0);
    }
}
