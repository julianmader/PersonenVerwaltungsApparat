namespace Gamadu.PVA.Core.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Core.Models;

  public class EmployeeValidator : AbstractValidator<IEmployee>
  {
    public EmployeeValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}