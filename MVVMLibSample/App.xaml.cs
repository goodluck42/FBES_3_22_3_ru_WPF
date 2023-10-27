using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MVVMLibSample.ViewModels;
using MVVMLibSample.Views;

namespace MVVMLibSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceCollection ServiceCollection = null!;
        public static ServiceProvider ServiceProvider = null!;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceCollection = new ServiceCollection();
            ServiceCollection.AddSingleton<ItemListViewModel>();
            ServiceCollection.AddSingleton<ItemListViewModel>();
            ServiceCollection.AddSingleton<MainViewModel>();
            ServiceCollection.AddSingleton<MainView>();

            ServiceProvider = ServiceCollection.BuildServiceProvider();

            var view = ServiceProvider.GetService<MainView>()!;
            
            view.Show();
        }
    }
}