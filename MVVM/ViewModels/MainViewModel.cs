namespace MVVM.ViewModels;

public class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        CurrentViewModel = new LoginViewModel();
    }
    public BaseViewModel CurrentViewModel { get; set; }
}