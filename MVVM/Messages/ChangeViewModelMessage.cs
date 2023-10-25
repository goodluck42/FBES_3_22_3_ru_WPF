using MVVM.Services;
using MVVM.ViewModels;

namespace MVVM.Messages;

public class ChangeViewModelMessage : IMessage
{
    public ChangeViewModelMessage(object sender, BaseViewModel viewModel)
    {
        Sender = sender;
        ViewModel = viewModel;
    }
    
    public object Sender { get; }
    public BaseViewModel ViewModel { get; }
}