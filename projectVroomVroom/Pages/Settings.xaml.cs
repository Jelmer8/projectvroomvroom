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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow; // Get the main window

        public Settings()
        {
            InitializeComponent();

            MainWindow.LANGUAGE lang = mainWindow.GetLanguage();
            switch (lang)
            {
                case MainWindow.LANGUAGE.Nederlands:
                    ButtonDutch.BorderThickness = new Thickness(5, 5, 5, 5);
                    ButtonDutch.BorderBrush = Brushes.Orange;
                    TextLanguage.Text = "TAAL";
                    TextMusic.Text = "MUZIEK";
                    TextSound.Text = "GELUID";
                    ButtonBack.Content = "TERUG";
                    break;

                case MainWindow.LANGUAGE.Fries:
                    ButtonFrisian.BorderThickness = new Thickness(5, 5, 5, 5);
                    ButtonFrisian.BorderBrush = Brushes.Orange;
                    TextLanguage.Text = "TAAL";
                    TextMusic.Text = "MUZYK";
                    TextSound.Text = "LÛD";
                    ButtonBack.Content = "WEROM";
                    break;

                case MainWindow.LANGUAGE.Engels:
                    ButtonEnglish.BorderThickness = new Thickness(5, 5, 5, 5);
                    ButtonEnglish.BorderBrush = Brushes.Orange;
                    TextLanguage.Text = "LANGUAGES";
                    TextMusic.Text = "MUSIC";
                    TextSound.Text = "SOUND";
                    ButtonBack.Content = "BACK";
                    break;
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.MainMenu(); // Navigate back to the main menu
        }

        private void ButtonLanguageNL(object sender, RoutedEventArgs e)
        {
            mainWindow.ChangeLanguage(MainWindow.LANGUAGE.Nederlands);
            mainWindow.Content = new Pages.Settings();

        }
        private void ButtonLanguageFR(object sender, RoutedEventArgs e)
        {
            mainWindow.ChangeLanguage(MainWindow.LANGUAGE.Fries);
            mainWindow.Content = new Pages.Settings();

        }
        private void ButtonLanguageEN(object sender, RoutedEventArgs e)
        {

            mainWindow.ChangeLanguage(MainWindow.LANGUAGE.Engels);
            mainWindow.Content = new Pages.Settings();
        }

    }
}
