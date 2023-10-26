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

namespace projectVroomVroom.Pages
{
    /// <summary>
    /// Interaction logic for Zandvoort.xaml
    /// </summary>
    public partial class Zandvoort : UserControl
    {

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Boolean VisibleCheck = false;

        public Zandvoort()
        {
            InitializeComponent();
            MenuCanvas.Focus();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        { 
            if (e.Key == Key.Escape)
            {
                if (!VisibleCheck)
                {
                    Menu.Visibility = Visibility.Visible;
                    MenuGoMain.Visibility = Visibility.Visible;
                    VisibleCheck = true;
                }
                else
                {
                    Menu.Visibility = Visibility.Hidden;
                    MenuGoMain.Visibility = Visibility.Hidden;
                    VisibleCheck = false;
                }
            }
        }
        private void MainMenuButton(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.MainMenu(); // Navigate back to the main menu
        }
    }
}