namespace Gamadu.PVA.Core.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Core.Models;

  public class DepartmentValidator : AbstractValidator<IDepartment>
  {
    public DepartmentValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}