using FluentValidation;

namespace DinnerHostingApp.Application.Menus.Create;
public class CreateMenuCommandValidator :AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Sections).NotEmpty();
    }
}
