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

    public bool HasErrors => (bool)this.ErrorsCollection?.Any();

    private IDictionary<string, IEnumerable<string>> ErrorsCollection { get; set; }

    private IDictionary<string, IEnumerable<string>> PreviousErrorsCollection { get; set; }

    public ValidateableModelBase()
    {
      this.ErrorsCollection = new Dictionary<string, IEnumerable<string>>();
      this.PreviousErrorsCollection = new Dictionary<string, IEnumerable<string>>();
    }

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    /// <inheritdoc/>
    public IEnumerable GetErrors(string propertyName = null)
    {
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

    public void Validate(T instance)
    {
      if (this.Validator == null)
      {
        return;
      }

      this.PreviousErrorsCollection = this.ErrorsCollection;

      this.ErrorsCollection = new Dictionary<string, IEnumerable<string>>();

      ValidationResult validationResult = this.Validator.Validate(instance);

      IEnumerable<ValidationFailure> validationFailures = validationResult.Errors;

      if (validationFailures == null)
      {
        return;
      }

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

      this.CallOnErrorsChangedForChangedErrors();
    }

    public abstract void Validate();

    /// <summary>
    /// Calls the <see cref="OnErrorsChanged(string)"/> for each error which has really changed.
    /// </summary>
    protected void CallOnErrorsChangedForChangedErrors()
    {
      if (this.PreviousErrorsCollection.Count == 0)
      {
        foreach (string propertyName in this.ErrorsCollection.Keys)
        {
          this.OnErrorsChanged(propertyName);
        }

        return;
      }

      foreach (string propertyName in this.ErrorsCollection.Keys)
      {
        if (this.PreviousErrorsCollection.Keys.Contains(propertyName))
        {
          foreach (string errorMessage in this.ErrorsCollection[propertyName])
          {
            if (!this.PreviousErrorsCollection[propertyName].Contains(errorMessage))
            {
              this.OnErrorsChanged(propertyName);
            }
          }

          continue;
        }

        this.OnErrorsChanged(propertyName);
      }

      foreach (string propertyName in this.PreviousErrorsCollection.Keys)
      {
        if (!this.ErrorsCollection.Keys.Contains(propertyName))
        {
          this.OnErrorsChanged(propertyName);
        }
      }
    }

    /// <summary>
    /// Invokes the <see cref="ErrorsChanged"/> event.
    /// </summary>
    /// <param name="propertyName">The name of the property which changed the error.</param>
    protected void OnErrorsChanged(string propertyName)
    {
      this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
  }
}