using System.IO;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVMLibSample.Models;

namespace MVVMLibSample.Services;

public class FileItemRepository : IItemRepository
{
    private const string c_Filename = "items.json";
    private ObservableCollection<Item> _items = null!;

    public FileItemRepository()
    {
        Load();
    }
    
    public void Add(Item item)
    {
       _items.Add(item);
       Save();
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
        Save();
    }

    public IEnumerable<Item> GetItems()
    {
        return _items;
    }

    private void Load()
    {
        if (File.Exists(c_Filename))
        {
            var json = File.ReadAllText(c_Filename);
            
            _items = JsonSerializer.Deserialize<ObservableCollection<Item>>(json)!;
        }
        else
        {
            using var streamWriter = new StreamWriter(File.Create(c_Filename));
            
            streamWriter.Write("{}");

            _items = new ObservableCollection<Item>();
        }
    }
    
    private void Save()
    {
        var json = JsonSerializer.Serialize(_items);
        
        File.WriteAllText(c_Filename, json);
    }
}