using System;
using System.Collections.Generic;
using System.Windows;

namespace MVVM.Services;

public class Messenger
{
    private Dictionary<Type, Action<IMessage>> _actions;

    private Messenger()
    {
        _actions = new();
    }

    public bool Register<TMessage>(object sender, Action<IMessage> action)
    where TMessage : IMessage
    {
        var type = typeof(TMessage);

        if (_actions.ContainsKey(type))
        {
            return false;
        }

        _actions[type] = action;

        return true;
    }

    public bool Send<TMessage>(IMessage message)
    {
        var type = typeof(TMessage);
        
        if (_actions.TryGetValue(type, out var action))
        {
            action(message);

            return true;
        }
        
        return false;
    }

    public static Messenger Instance => s_instance ??= new Messenger();
    private static Messenger? s_instance;
}