using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CalculatorBase.Models;
using ReactiveUI;

namespace CalculatorBase.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyDataErrorInfo
{
    #region Fields

    private readonly Dictionary<string, List<ValidationResult>> _validationErrors = new();
    private readonly Calculator _calculator = new();

    private double _firstArgument;
    private double _secondArgument;
    private Operation _selectedOperation;
    private double? _result;

    #endregion


    public MainWindowViewModel()
    {
        this.WhenAnyValue(vm => vm.FirstArgument, vm => vm.SecondArgument, vm => vm.SelectedOperation)
            .Subscribe(_ => DoCalculations());
    }


    #region Events

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    #endregion


    #region Properties

    public static IEnumerable AvailableOperations => Enum.GetValues<Operation>();

    public bool HasErrors => _validationErrors.Count > 0;

    public double FirstArgument
    {
        get => _firstArgument;
        set => this.RaiseAndSetIfChanged(ref _firstArgument, value);
    }

    public double SecondArgument
    {
        get => _secondArgument;
        set => this.RaiseAndSetIfChanged(ref _secondArgument, value);
    }

    public Operation SelectedOperation
    {
        get => _selectedOperation;
        set => this.RaiseAndSetIfChanged(ref _selectedOperation, value);
    }

    public double? Result
    {
        get => _result;
        set => this.RaiseAndSetIfChanged(ref _result, value);
    }

    #endregion


    #region Methods

    public IEnumerable GetErrors(string? propertyName = null)
    {
        if (string.IsNullOrEmpty(propertyName))
            return _validationErrors.Values.SelectMany(static errors => errors);

        return _validationErrors.TryGetValue(propertyName, out var value)
            ? value
            : Enumerable.Empty<ValidationResult>();
    }

    private void DoCalculations()
    {
        ClearErrors();
        Result = null;

        if (SelectedOperation == Operation.Divide)
            ValidateDivider();

        if (HasErrors)
            return;

        Result = SelectedOperation switch
        {
            Operation.Add => _calculator.Add(FirstArgument, SecondArgument),
            Operation.Subtract => _calculator.Subtract(FirstArgument, SecondArgument),
            Operation.Multiply => _calculator.Multiply(FirstArgument, SecondArgument),
            Operation.Divide => _calculator.Divide(FirstArgument, SecondArgument),
            _ => throw new NotSupportedException($"Command {SelectedOperation} does not support.")
        };
    }

    private void AddError(string propertyName, string errorMessage)
    {
        ArgumentException.ThrowIfNullOrEmpty(propertyName);

        if (!_validationErrors.ContainsKey(propertyName))
            _validationErrors.Add(propertyName, new List<ValidationResult>());

        _validationErrors[propertyName].Add(new ValidationResult(errorMessage));

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        this.RaisePropertyChanged(nameof(HasErrors));
    }

    private void ClearErrors(string? propertyName = null)
    {
        if (string.IsNullOrEmpty(propertyName))
            _validationErrors.Clear();
        else
            _validationErrors.Remove(propertyName);

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        this.RaisePropertyChanged(nameof(HasErrors));
    }

    private void ValidateDivider()
    {
        ClearErrors(nameof(SecondArgument));

        try
        {
            _ = _calculator.Divide(FirstArgument, SecondArgument);
        }
        catch (DivideByZeroException e)
        {
            AddError(nameof(SecondArgument), e.Message);
        }
    }

    #endregion
}