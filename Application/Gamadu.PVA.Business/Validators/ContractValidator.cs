namespace Gamadu.PVA.Business.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Business.Models;

  public class ContractValidator : AbstractValidator<IContract>
  {
    public ContractValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}