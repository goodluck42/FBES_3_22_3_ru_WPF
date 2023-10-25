using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MVVM.Messages;
using MVVM.Services;

namespace MVVM.ViewModels;

public class MainViewModel : BaseViewModel, INotifyPropertyChanged
{
    private BaseViewModel? _baseViewModel;

    public MainViewModel()
    {
        Messenger.Register<ChangeViewModelMessage>(this, message =>
        {
            if (message is ChangeViewModelMessage currentMessage)
            {
                CurrentViewModel = currentMessage.ViewModel;
            }
        });

        Messenger.Send<ChangeViewModelMessage>(new ChangeViewModelMessage(this, new RegisterViewModel()));
    }
    
    public BaseViewModel? CurrentViewModel
    {
        get => _baseViewModel;
        set => SetField(ref _baseViewModel, value);
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}