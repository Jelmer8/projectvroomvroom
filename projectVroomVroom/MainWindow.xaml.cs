using System.Windows;

namespace projectVroomVroom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            this.Content = new Pages.CarSelection(); //Navigate to the CarSelection page
        }

        private void LeaderboardButtonClick(object sender, RoutedEventArgs e)
        {
            this.Content = new Pages.Leaderboard(); //Navigate to the Leaderboard page
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {
            this.Content = new Pages.Settings(); //Navigate to the Settings page
        }

        private void InfoButtonClick(object sender, RoutedEventArgs e)
        {
            this.Content = new Pages.Info(); //Navigate to the Info page
        }
    }
}