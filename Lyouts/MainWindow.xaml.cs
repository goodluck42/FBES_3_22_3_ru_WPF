﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lyouts;

public partial class MainWindow : Window
{
    private int _counter;
    
    public MainWindow()
    {
        InitializeComponent();
        _counter = 0;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        this.TextBlock.Text = _counter.ToString();

        _counter++;
    }
}