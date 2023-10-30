using MVVMLibSample.ViewModels;

namespace MVVMLibSample.Messages;

public class ChangeViewModelMessage : Message
{
    public ChangeViewModelMessage(BaseViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public BaseViewModel ViewModel { get; }
}