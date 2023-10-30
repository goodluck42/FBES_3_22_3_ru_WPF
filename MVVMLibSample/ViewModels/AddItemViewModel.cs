using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVMLibSample.Messages;
using MVVMLibSample.Models;
using Microsoft.Extensions.DependencyInjection;
using MVVMLibSample.Services;


namespace MVVMLibSample.ViewModels;

[INotifyPropertyChanged]
public partial class AddItemViewModel : BaseViewModel
{
    private readonly ViewModelFactory _factory;

    public AddItemViewModel(ViewModelFactory factory)
    {
        _factory = factory;
        CurrentItem = new Item();
    }

    [ObservableProperty]
    private Item _currentItem;

    [RelayCommand]
    private void Back()
    {
        WeakReferenceMessenger.Default.Send(new ChangeViewModelMessage(_factory.Create(2)));
    }
    
    [RelayCommand]
    private void Add()
    {
        WeakReferenceMessenger.Default.Send(new ItemMessage(CurrentItem), ItemTokens.AddItemToken);
        
        Back();
    }

    //public bool CanAdd => CurrentItem.Quantity > 0 && CurrentItem.Name != string.Empty;
}