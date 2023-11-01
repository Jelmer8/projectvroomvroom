using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projectVroomVroom.Pages
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : UserControl
    {

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow; // Get the main window

        public Info()
        {
            InitializeComponent();

            MainWindow.LANGUAGE lang = mainWindow.GetLanguage();
            switch (lang)
            {
                case MainWindow.LANGUAGE.Nederlands:
                    TextPlayer1.Text = "Speler 1";
                    TextPlayer2.Text = "Speler 2";
                    TextForward1.Text = "Vooruit";
                    TextForward2.Text = "Vooruit";
                    TextLeft1.Text = "Links";
                    TextLeft2.Text = "Links";
                    TextRight1.Text = "Rechts";
                    TextRight2.Text = "Rechts";
                    TextBackward1.Text = "Achteruit";
                    TextBackward2.Text = "Achteruit";
                    break;

                case MainWindow.LANGUAGE.Fries:
                    TextPlayer1.Text = "Spiler 1";
                    TextPlayer2.Text = "Spiler 2";
                    TextForward1.Text = "Foarút";
                    TextForward2.Text = "Foarút";
                    TextLeft1.Text = "Links";
                    TextLeft2.Text = "Links";
                    TextRight1.Text = "rjochts";
                    TextRight2.Text = "rjochts";
                    TextBackward1.Text = "efterút";
                    TextBackward2.Text = "efterút";
                    break;

                case MainWindow.LANGUAGE.Engels:
                    TextPlayer1.Text = "Player 1";
                    TextPlayer2.Text = "Player 2";
                    TextForward1.Text = "Forwards";
                    TextForward2.Text = "Forwards";
                    TextLeft1.Text = "Left";
                    TextLeft2.Text = "Left";
                    TextRight1.Text = "Right";
                    TextRight2.Text = "Right";
                    TextBackward1.Text = "Backwards";
                    TextBackward2.Text = "Backwards";
                    break;
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.MainMenu(); // Navigate back to the main menu
        }
    }
}
