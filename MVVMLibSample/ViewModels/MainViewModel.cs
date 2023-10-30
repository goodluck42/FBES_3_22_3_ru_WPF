using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MVVMLibSample.Messages;
using Microsoft.Extensions.DependencyInjection;
using MVVMLibSample.Services;

namespace MVVMLibSample.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel : BaseViewModel
{
    private readonly ViewModelFactory _factory;

    public MainViewModel(ViewModelFactory factory)
    {
        _factory = factory;
        WeakReferenceMessenger.Default.Register<ChangeViewModelMessage>(this, (sender, message) =>
        {
            CurrentViewModel = message.ViewModel;
        });
        var viewModel = _factory.Create(2);
        var changeViewModelMessage = new ChangeViewModelMessage(viewModel);
        
        WeakReferenceMessenger.Default.Send(changeViewModelMessage);
    }

    [ObservableProperty]
    private BaseViewModel? _currentViewModel;
}