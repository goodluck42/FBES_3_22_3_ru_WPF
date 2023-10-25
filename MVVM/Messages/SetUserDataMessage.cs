using MVVM.Services;

namespace MVVM.Messages;

public class SetUserDataMessage : IMessage
{
    public SetUserDataMessage(object sender)
    {
        Sender = sender;
    }
    public object Sender { get; }
    public string? Login { get; set; }
    public string? Password { get; set; }
}