using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVMLibSample.Messages;
using MVVMLibSample.Models;
using Microsoft.Extensions.DependencyInjection;


namespace MVVMLibSample.ViewModels;

public partial class AddItemViewModel : BaseViewModel
{
    public AddItemViewModel()
    {
        CurrentItem = new Item();
    }

    public Item CurrentItem { get; }

    [RelayCommand]
    private void Back()
    {
        WeakReferenceMessenger.Default.Send(new ChangeViewModelMessage(this, App.ServiceProvider.GetService<ItemListViewModel>()!));
    }
    
    [RelayCommand]
    private void Add()
    {
        WeakReferenceMessenger.Default.Send(new AddItemMessage(this, CurrentItem));
        
        Back();
    }

    //public bool CanAdd => CurrentItem.Quantity > 0 && CurrentItem.Name != string.Empty;
}