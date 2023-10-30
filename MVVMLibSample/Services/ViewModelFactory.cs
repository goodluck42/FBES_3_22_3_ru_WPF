using System.Diagnostics;
using System.Linq;
using MVVMLibSample.ViewModels;
using MVVMLibSample.Views;

namespace MVVMLibSample.Services;


public class ViewModelFactory
{
    public BaseViewModel Create(int index)
    {
        return index switch
        {
            0 => App.ServiceProvider.GetService<MainViewModel>(),
            1 => App.ServiceProvider.GetService<AddItemViewModel>(),
            2 => App.ServiceProvider.GetService<ItemListViewModel>(),
            3 => App.ServiceProvider.GetService<UpdateItemViewModel>()
        };
    }
}