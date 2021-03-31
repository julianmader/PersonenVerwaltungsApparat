namespace Gamadu.PVA.Business.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Business.Models;

  public class PositionValidator : AbstractValidator<IPosition>
  {
    public PositionValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}