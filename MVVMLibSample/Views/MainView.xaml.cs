using System.Linq;
using System.Windows;
using System.Windows.Documents;
using MVVMLibSample.ViewModels;

namespace MVVMLibSample.Views;

public partial class MainView : Window
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}