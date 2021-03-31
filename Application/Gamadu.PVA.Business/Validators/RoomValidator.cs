namespace Gamadu.PVA.Business.Validators
{
  using FluentValidation;
  using Gamadu.PVA.Business.Models;

  public class RoomValidator : AbstractValidator<IRoom>
  {
    public RoomValidator()
    {
      this.RuleFor(x => x.Matchcode)
        .NotEmpty();
    }
  }
}