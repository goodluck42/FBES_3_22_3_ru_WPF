using MVVMLibSample.Models;

namespace MVVMLibSample.Services;

public interface IItemRepository
{
    void Add(Item item);
    void Remove(Item item);
    IEnumerable<Item> GetItems();
}