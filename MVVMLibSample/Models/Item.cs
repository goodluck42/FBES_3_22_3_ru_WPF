using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVMLibSample.Models;
using System;

public partial class Item : ObservableObject
{
    [ObservableProperty]
    private int _id;
    
    [ObservableProperty]
    private string? _name;
    
    [ObservableProperty]
    private int _quantity;
    
    [ObservableProperty]
    private DateTime _created;
}