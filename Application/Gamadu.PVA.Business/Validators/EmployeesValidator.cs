namespace Gamadu.PVA.Business.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Business.Models;

  public class EmployeeValidator : AbstractValidator<Employee>
  {
    public EmployeeValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}
