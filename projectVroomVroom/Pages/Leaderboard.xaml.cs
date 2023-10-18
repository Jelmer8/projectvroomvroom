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
using System.IO;
using static System.Formats.Asn1.AsnWriter;

namespace projectVroomVroom.Pages
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : UserControl
    {

        private int MapNumber = 1;
        private int TotalMapNumber = 3;

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow; // Get the main window

        public Leaderboard()
        {
            InitializeComponent();
            ImportLeaderboard();
        }

        private void LeaderboardMapUpArrowButtonClick(object sender, RoutedEventArgs e)
        {   
            if (MapNumber == 1)
            {
                MapNumber = TotalMapNumber;
            }
            else
            {
                MapNumber = MapNumber -1;
            }
            UpdateMap();
        }

        private void LeaderboardMapDownArrowButtonClick(object sender, RoutedEventArgs e)
        {
            if (MapNumber == TotalMapNumber)
            {
                MapNumber = 1;
            }
            else
            {
                MapNumber = MapNumber + 1;
            }
            UpdateMap();
        }

        private void UpdateMap()
        {

            Map.Source = new BitmapImage(new Uri("pack://application:,,,/Images/map" + MapNumber + ".png")); // Update the car image
            ImportLeaderboard();
        }

        private void ImportLeaderboard()
        {

            String Scores;
            StreamReader sr = new StreamReader(@"..\..\..\DBMap" + MapNumber + ".txt");

            Scores = sr.ReadLine();
            sr.Close();
            var PlayerScores = new List<string>(); 
            PlayerScores = Scores.Split(';').ToList();

            LoadLeaderboard(PlayerScores);
        }

        private void LoadLeaderboard(List<string> Score)
        {
            try
            {
                r1Name.Text = Score[0];
                r2Name.Text = Score[1];
                r3Name.Text = Score[2];
                r4Name.Text = Score[3];
                r5Name.Text = Score[4];
                r6Name.Text = Score[5];
                r7Name.Text = Score[6];
                r8Name.Text = Score[7];
                r9Name.Text = Score[8];
                r10Name.Text = Score[9];
            }
            catch (Exception e)
            {
                
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.MainMenu(); // Navigate back to the main menu
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
