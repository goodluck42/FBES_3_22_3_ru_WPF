using MVVMLibSample.Models;

namespace MVVMLibSample.Messages;

public class ItemMessage : Message
{
    public ItemMessage(Item item)
    {
        Item = item;
    }

    public Item Item { get; }
}

