using CommunityToolkit.Mvvm.Messaging;

namespace MVVMLibSample.Messages;

public abstract class Message
{
    public Message(object sender)
    {
        Sender = sender;
    }
    
    public object Sender { get; set; }
}