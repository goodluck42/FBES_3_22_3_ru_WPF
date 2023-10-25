using System;
using System.Windows.Input;

namespace MVVM.Commands;

public class RelayCommand : ICommand
{
    public RelayCommand(Action<object?> action)
    {
        _action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
        {
            _action(parameter);
        }
    }

    public event EventHandler? CanExecuteChanged;

    private Action<object?> _action;
}