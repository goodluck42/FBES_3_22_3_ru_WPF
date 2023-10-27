using MVVMLibSample.Models;

namespace MVVMLibSample.Messages;

public class AddItemMessage : Message
{
    public AddItemMessage(object sender, Item item) : base(sender)
    {
        Item = item;
    }

    public Item Item { get; }
}