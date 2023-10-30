using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVMLibSample.Messages;
using MVVMLibSample.Models;
using MVVMLibSample.Services;

namespace MVVMLibSample.ViewModels;

public partial class ItemListViewModel : BaseViewModel
{
    private readonly ViewModelFactory _factory;
    private readonly IItemRepository _itemRepository;

    public ItemListViewModel(ViewModelFactory factory, IItemRepository itemRepository)
    {
        _factory = factory;
        _itemRepository = itemRepository;
        Items = itemRepository.GetItems();

        WeakReferenceMessenger.Default.Register<ItemMessage, int>(this, ItemTokens.AddItemToken, (sender, message) =>
        {
            _itemRepository.Add(message.Item);
        });
    }

    public IEnumerable<Item> Items { get; set; }

    [RelayCommand(CanExecute = "CanRemove")]
    private void RemoveItem(object? param)
    {
        MessageBox.Show(param?.ToString());
        if (param is Item item)
        {
            _itemRepository.Remove(item);
        }
    }

    public bool CanRemove => Items.Any();

    [RelayCommand]
    private void AddItem()
    {
        WeakReferenceMessenger.Default.Send(new ChangeViewModelMessage(_factory.Create(1)));
    }

    [RelayCommand]
    private void UpdateItem(object obj)
    {
        if (obj is Item item)
        {
            WeakReferenceMessenger.Default.Send(new ChangeViewModelMessage(_factory.Create(3)));
            WeakReferenceMessenger.Default.Send(new ItemMessage(item), ItemTokens.SendItemToUpdateViewToken);
        }
    }
}