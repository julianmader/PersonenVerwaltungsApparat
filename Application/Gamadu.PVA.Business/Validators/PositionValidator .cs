namespace Gamadu.PVA.Core.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Core.Models;

  public class PositionValidator : AbstractValidator<IPosition>
  {
    public PositionValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}