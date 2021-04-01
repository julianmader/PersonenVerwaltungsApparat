namespace Gamadu.PVA.Core.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Core.Models;

  public class ContractValidator : AbstractValidator<IContract>
  {
    public ContractValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}