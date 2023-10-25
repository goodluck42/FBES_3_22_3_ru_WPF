using System.Collections.ObjectModel;
using System.Windows;
using MVVM.Commands;
using MVVM.Messages;
using MVVM.Models;

namespace MVVM.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private RelayCommand? _loginCommand;

    public LoginViewModel()
    {
        Messenger.Register<SetUserDataMessage>(this, message =>
        {
            if (message is SetUserDataMessage currentMessage && message.Sender is RegisterViewModel)
            {
                Login = currentMessage.Login;
                Password = currentMessage.Password;
            }
        });
    }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public RelayCommand LoginCommand =>
        _loginCommand ??= new RelayCommand(o =>
        {
            //Messenger.Send<ChangeViewModelMessage>(new ChangeViewModelMessage(this, new RegisterViewModel()));
        });
}