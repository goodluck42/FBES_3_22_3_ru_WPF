using System.Windows;
using MVVM.ViewModels;

namespace MVVM.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}