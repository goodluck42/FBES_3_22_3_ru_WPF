using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        var value = e.NewValue / 100;

        CatImage.Opacity = value;
        SliderValue.Text = Math.Round(value, 2).ToString();
    }

    private void ButtonBase_Increase_OnClick(object sender, RoutedEventArgs e)
    {
        var randomValue = (double)Random.Shared.Next(1, 10 + 1);

        if (randomValue + TestProgressBar.Value >= TestProgressBar.Maximum)
        {
            TestProgressBar.Value = TestProgressBar.Maximum;

            return;
        }

        TestProgressBar.Value += randomValue;
    }

    private void ButtonBase_Reset_OnClick(object sender, RoutedEventArgs e)
    {
        TestProgressBar.Value = default;
    }

    private void ButtonBase_ShowPassword_OnClick(object sender, RoutedEventArgs e)
    {
        PasswordTextBlock.Text = MyPasswordBox.Password;
    }

    private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
    {
        
    }
}