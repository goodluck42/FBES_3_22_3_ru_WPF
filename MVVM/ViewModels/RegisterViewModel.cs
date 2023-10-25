using MVVM.Commands;
using MVVM.Messages;

namespace MVVM.ViewModels;

public class RegisterViewModel : BaseViewModel
{
    private RelayCommand? _register;
    

    public string? Login { get; set; }
    public string? Password { get; set; }

    public RelayCommand RegisterCommand => _register ??= new RelayCommand(o =>
    {
        Messenger.Send<ChangeViewModelMessage>(new ChangeViewModelMessage(this, new LoginViewModel()));
        Messenger.Send<SetUserDataMessage>(new SetUserDataMessage(this)
        {
            Login = Login,
            Password = Password
        });
    });
}