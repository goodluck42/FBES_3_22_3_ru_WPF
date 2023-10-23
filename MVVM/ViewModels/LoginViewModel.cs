using System.Collections.ObjectModel;
using System.Windows;
using MVVM.Commands;
using MVVM.Models;

namespace MVVM.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private RelayCommand? _loginCommand;

    public LoginViewModel()
    {
        Users = new ObservableCollection<User>();
    }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public RelayCommand LoginCommand =>
        _loginCommand ??= new RelayCommand(o =>
        {
            if (Login != string.Empty && Password != string.Empty)
            {
                Users.Add(new User()
                {
                    Password = Password,
                    Login = Login
                });
            }
        });
    
    public ObservableCollection<User> Users { get; set; }
}