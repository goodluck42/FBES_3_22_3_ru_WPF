using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MVVMLibSample.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace MVVMLibSample.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        WeakReferenceMessenger.Default.Register<ChangeViewModelMessage>(this, (sender, message) =>
        {
            CurrentViewModel = message.ViewModel;
        });
        var viewModel = App.ServiceProvider.GetService<ItemListViewModel>()!;
        var changeViewModelMessage = new ChangeViewModelMessage(this, viewModel);
        
        WeakReferenceMessenger.Default.Send(changeViewModelMessage);
    }

    [ObservableProperty]
    private BaseViewModel? _currentViewModel;
}