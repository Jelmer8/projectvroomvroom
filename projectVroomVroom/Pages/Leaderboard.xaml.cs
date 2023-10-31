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
using System.Windows.Controls.Primitives;
using System.Windows.Media.TextFormatting;

namespace projectVroomVroom.Pages
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : UserControl
    {

        private int MapNumber = 1;
        private int TotalMapNumber = 2;

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow; // Get the main window

        public Leaderboard()
        {
            InitializeComponent();
            ImportLeaderboard();
            UpdateMap();

            MainWindow.LANGUAGE lang = mainWindow.GetLanguage();
            switch (lang)
            {
                case MainWindow.LANGUAGE.Nederlands:
                    TextRank.Text = "Rank";
                    TextName.Text = "Naam";
                    TextTime.Text = "Tijd";
                    ButtonBack.Content = "TERUG";
                    break;

                case MainWindow.LANGUAGE.Fries:
                    TextRank.Text = "Rang";
                    TextName.Text = "Namme";
                    TextTime.Text = "Tiid";
                    ButtonBack.Content = "WEROM";
                    break;

                case MainWindow.LANGUAGE.Engels:
                    TextRank.Text = "Rank";
                    TextName.Text = "Name";
                    TextTime.Text = "Time";
                    ButtonBack.Content = "BACK";
                    break;
            }
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
            if (MapNumber == 1)
            {  
                MapName.Text = "Interlagos"; 
            }
            else if (MapNumber == 2)
            {
                MapName.Text = "Zandvoort";
            }
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
