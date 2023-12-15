﻿using BLL.DTO;
using FluentValidation;

namespace BLL.Validators;

public class TagValidator : AbstractValidator<TagDTO>
{
    public TagValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
    }
}
