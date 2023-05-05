using System;
using System.Collections;
using CalculatorBase.Models;
using ReactiveUI;

namespace CalculatorBase.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region Fields

    private string _firstArgument = string.Empty;
    private string _secondArgument = string.Empty;
    private Operation _selectedOperation;
    private string _result = string.Empty;

    #endregion

    public MainWindowViewModel()
    {
        
    }

    #region Properties

    public IEnumerable AvailableOperations => Enum.GetValues<Operation>();

    public string FirstArgument
    {
        get => _firstArgument;
        set => this.RaiseAndSetIfChanged(ref _firstArgument, value);
    }

    public string SecondArgument
    {
        get => _secondArgument;
        set => this.RaiseAndSetIfChanged(ref _secondArgument, value);
    }

    public Operation SelectedOperation
    {
        get => _selectedOperation;
        set => this.RaiseAndSetIfChanged(ref _selectedOperation, value);
    }

    public string Result
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