using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MVVMLibSample.Messages;

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
    }

    [ObservableProperty]
    private BaseViewModel? _currentViewModel;
}