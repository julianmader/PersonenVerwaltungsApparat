namespace Gamadu.PVA.Business.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Business.Models;

  public class DepartmentValidator : AbstractValidator<IDepartment>
  {
    public DepartmentValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}