﻿namespace MVVM.Models;

public class User
{
    public string? Login { get; set; }
    public string? Password { get; set; }

    public string? Display => $"{Login} {Password}";

}