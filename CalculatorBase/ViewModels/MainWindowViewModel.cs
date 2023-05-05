using System;
using System.Collections;
using CalculatorBase.Models;
using ReactiveUI;

namespace CalculatorBase.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region Fields

    private double _firstArgument;
    private double _secondArgument;
    private Operation _selectedOperation;
    private double _result;

    #endregion

    public MainWindowViewModel()
    {
        
    }

    #region Properties

    public IEnumerable AvailableOperations => Enum.GetValues<Operation>();

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

    public double Result
    {
        get => _result;
        set => this.RaiseAndSetIfChanged(ref _result, value);
    }

    #endregion


    #region Methods

    private void DoCalculations()
    {
        throw new NotImplementedException();
    }

    #endregion
}