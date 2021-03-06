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
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Media.Animation;

namespace Something
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Completely made by github.com/U-C-S
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GameNavigationFrame.Navigate(new OpeningAnim());
        }
        private void GameNavigationFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            DoubleAnimation OpaVal = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.4),
                From = 0.0,
                To = 1.0,
            };
            (e.Content as Page).BeginAnimation(OpacityProperty, OpaVal);
        }
    }
}
