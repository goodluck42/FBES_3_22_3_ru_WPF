using System.Windows;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVMLibSample.Messages;
using MVVMLibSample.Models;

namespace MVVMLibSample.ViewModels;

public partial class ItemListViewModel : BaseViewModel
{
    public ItemListViewModel()
    {
        Items = new ObservableCollection<Item>();
        
        WeakReferenceMessenger.Default.Register<AddItemMessage>(this,(sender, message) =>
        {
            Items.Add(message.Item);
        });
    }

    public ObservableCollection<Item> Items { get; set; }

    [RelayCommand(CanExecute = "CanRemove")]
    private void RemoveItem(object? param)
    {
        if (param is Item item)
        {
            Items.Remove(item);
        }
    }

    public bool CanRemove => Items.Count > 0;

    [RelayCommand]
    private void AddItem()
    {
        WeakReferenceMessenger.Default.Send(new ChangeViewModelMessage(this, new AddItemViewModel()));
    }
}