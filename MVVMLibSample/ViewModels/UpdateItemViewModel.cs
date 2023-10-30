using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVMLibSample.Messages;
using MVVMLibSample.Models;
using MVVMLibSample.Services;

namespace MVVMLibSample.ViewModels;

[INotifyPropertyChanged]
public partial class UpdateItemViewModel : BaseViewModel
{
    private readonly ViewModelFactory _factory;

    public UpdateItemViewModel(ViewModelFactory factory)
    {
        _factory = factory;
        WeakReferenceMessenger.Default.Register<ItemMessage, int>(this, ItemTokens.SendItemToUpdateViewToken, (sender, message) =>
        {
            ItemToUpdate = message.Item;
        });
    }


    [ObservableProperty] 
    private Item _itemToUpdate = null!;

    [RelayCommand]
    private void Back()
    {
        WeakReferenceMessenger.Default.Send(new ChangeViewModelMessage(_factory.Create(2)));
    }

    [RelayCommand]
    private void Update()
    {
        Back();
    }
}