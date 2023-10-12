using System;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow; // Get the main window

        public MainMenu()
        {
            InitializeComponent();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.CarSelection(); // Navigate to the CarSelection page
        }

        private void LeaderboardButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.Leaderboard(); //Navigate to the Leaderboard page
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.Settings(); //Navigate to the Settings page
        }

        private void InfoButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.Info(); //Navigate to the Info page
        }
    }
}