using MVVMLibSample.ViewModels;

namespace MVVMLibSample.Messages;

public class ChangeViewModelMessage : Message
{
    public ChangeViewModelMessage(object sender, BaseViewModel viewModel) : base(sender)
    {
        ViewModel = viewModel;
    }

    public BaseViewModel ViewModel { get; }
}