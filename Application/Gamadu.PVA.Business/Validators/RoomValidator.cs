namespace Gamadu.PVA.Core.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Core.Models;

  public class RoomValidator : AbstractValidator<IRoom>
  {
    public RoomValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}