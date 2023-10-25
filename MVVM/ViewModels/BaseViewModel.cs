using MVVM.Services;

namespace MVVM.ViewModels;

public abstract class BaseViewModel
{
    public Messenger Messenger => Messenger.Instance;
}