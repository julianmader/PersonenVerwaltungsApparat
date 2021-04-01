namespace Gamadu.PVA.Core.Models.Bases
{
  using FluentValidation;
  using FluentValidation.Results;
  using Prism.Mvvm;
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;

  /// <summary>
  /// Contains the base methods for data validation and inherits from the <see cref="BindableBase"/>.
  /// </summary>
  /// <typeparam name="T">The type of the inherited class.</typeparam>
  public abstract class ValidateableModelBase<T> : ModelBase, IValidateable<T>
  {
    public IValidator<T> Validator { get; set; }

    public bool HasErrors => this.ErrorsCollection?.Any() == true;

    private IDictionary<string, IEnumerable<string>> ErrorsCollection { get; set; }

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    /// <inheritdoc/>
    public IEnumerable GetErrors(string propertyName = null)
    {
      if (this.ErrorsCollection == null)
      {
        return new List<string>();
      }

      if (propertyName != null)
      {
        this.ErrorsCollection.TryGetValue(propertyName, out IEnumerable<string> errors);

        return errors ?? new List<string>();
      }
      else
      {
        return this.ErrorsCollection.Values;
      }
    }

    /// <summary>
    /// Validates the passed instance
    /// </summary>
    /// <param name="instance"></param>
    public void Validate(T instance)
    {
      if (this.Validator == null)
      {
        return;
      }

      IEnumerable<ValidationFailure> validationFailures = this.Validator.Validate(instance).Errors;

      if (validationFailures == null)
      {
        return;
      }

      this.FillErrorsCollection(validationFailures);

      this.OnErrorsChanged(this.ErrorsCollection.Keys);
    }

    private void FillErrorsCollection(IEnumerable<ValidationFailure> validationFailures)
    {
      this.ErrorsCollection = new Dictionary<string, IEnumerable<string>>();

      foreach (ValidationFailure failure in validationFailures)
      {
        if (this.ErrorsCollection.ContainsKey(failure.PropertyName))
        {
          if (!this.ErrorsCollection[failure.PropertyName].Contains(failure.ErrorMessage))
          {
            IList<string> errorMessages = this.ErrorsCollection[failure.PropertyName].ToList();
            errorMessages.Add(failure.ErrorMessage);
            this.ErrorsCollection[failure.PropertyName] = errorMessages;
          }

          continue;
        }

        this.ErrorsCollection.Add(failure.PropertyName, new List<string>() { failure.ErrorMessage });
      }
    }

    public abstract void Validate();

    /// <summary>
    /// Calls the <see cref="OnErrorsChanged(string)"/> for each error which has really changed.
    /// </summary>
    /// <param name="propertyNames">The property names.</param>
    protected void OnErrorsChanged(IEnumerable<string> propertyNames)
    {
      foreach (string propertyName in propertyNames)
      {
        this.OnErrorsChanged(propertyName);
      }
    }

    /// <summary>
    /// Invokes the <see cref="ErrorsChanged"/> event.
    /// </summary>
    /// <param name="propertyName">The name of the property which changed the error.</param>
    protected void OnErrorsChanged(string propertyName) => this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
  }
}