namespace Gamadu.PVA.Business.Models
{
  using FluentValidation;
  using System.ComponentModel;

  public interface IValidateable<T> : INotifyDataErrorInfo
  {
    /// <summary>
    /// Gets or sets the validator used for object validation
    /// </summary>
    IValidator<T> Validator { get; set; }

    /// <summary>
    /// Validates the object
    /// </summary>
    void Validate();
  }
}
