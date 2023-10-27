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
    /// Interaction logic for Zandvoort.xaml
    /// </summary>
    public partial class Zandvoort : UserControl
    {

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Boolean VisibleCheck = false;
        private Boolean SoundMuted = false;
        private Boolean MusicMuted = false;

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
                    ButtonMenuGoMain.Visibility = Visibility.Visible;
                    ButtonMenuOptions.Visibility = Visibility.Visible;
                    ButtonMenuResume.Visibility = Visibility.Visible;
                    MenuImage.Visibility = Visibility.Visible;
                    MenuLabel.Visibility = Visibility.Visible;
                    ButtonOptionsBack.Visibility = Visibility.Hidden;
                    VisibleCheck = true;
                }
                else
                {
                    Menu.Visibility = Visibility.Hidden;
                    ButtonMenuGoMain.Visibility = Visibility.Hidden;
                    ButtonMenuOptions.Visibility = Visibility.Hidden;
                    ButtonMenuResume.Visibility = Visibility.Hidden;
                    MenuImage.Visibility = Visibility.Hidden;
                    MenuLabel.Visibility = Visibility.Hidden;
                    ButtonOptionsBack.Visibility = Visibility.Hidden;
                    CheckboxSoundToggle.Visibility = Visibility.Hidden;
                    CheckboxMusictoggle.Visibility = Visibility.Hidden;
                    SoundImage.Visibility = Visibility.Hidden;
                    MuteSoundImage.Visibility = Visibility.Hidden;
                    MusicImage.Visibility = Visibility.Hidden;
                    MuteMusicImage.Visibility = Visibility.Hidden;
                    VisibleCheck = false;
                }
            }
        }
        private void MainMenuButton(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.MainMenu();
        }
        private void MenuOptionsButton(object sender, RoutedEventArgs e)
        {
            ButtonMenuGoMain.Visibility = Visibility.Hidden;
            ButtonMenuOptions.Visibility = Visibility.Hidden;
            ButtonMenuResume.Visibility = Visibility.Hidden;
            ButtonOptionsBack.Visibility = Visibility.Visible;
            CheckboxSoundToggle.Visibility = Visibility.Visible;
            CheckboxMusictoggle.Visibility = Visibility.Visible;
            if (SoundMuted)
            {
                SoundImage.Visibility = Visibility.Hidden;
                MuteSoundImage.Visibility = Visibility.Visible;
            }
            else
            {
                SoundImage.Visibility = Visibility.Visible;
                MuteSoundImage.Visibility = Visibility.Hidden;
            }

            if (MusicMuted)
            {
                MusicImage.Visibility = Visibility.Hidden;
                MuteMusicImage.Visibility = Visibility.Visible;
            }
            else
            {
                MusicImage.Visibility = Visibility.Visible;
                MuteMusicImage.Visibility = Visibility.Hidden;
            }
        }

        private void OptionsBackButton(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Visible;
            ButtonMenuGoMain.Visibility = Visibility.Visible;
            ButtonMenuOptions.Visibility = Visibility.Visible;
            ButtonMenuResume.Visibility = Visibility.Visible;
            ButtonOptionsBack.Visibility = Visibility.Hidden;
            CheckboxSoundToggle.Visibility = Visibility.Hidden;
            CheckboxMusictoggle.Visibility = Visibility.Hidden;
            SoundImage.Visibility = Visibility.Hidden;
            MuteSoundImage.Visibility = Visibility.Hidden;
            MusicImage.Visibility = Visibility.Hidden;
            MuteMusicImage.Visibility = Visibility.Hidden;
        }

        private void SoundCheckboxHandleChecked(object sender, RoutedEventArgs e)
        {
            SoundImage.Visibility = Visibility.Hidden;
            MuteSoundImage.Visibility = Visibility.Visible;
            SoundMuted = true;
        }

        private void SoundCheckboxHandleUnchecked(object sender, RoutedEventArgs e)
        {
            SoundImage.Visibility = Visibility.Visible;
            MuteSoundImage.Visibility = Visibility.Hidden;
            SoundMuted = false;
        }

        private void MusicCheckboxHandleChecked(object sender, RoutedEventArgs e)
        {
            MusicImage.Visibility = Visibility.Hidden;
            MuteMusicImage.Visibility = Visibility.Visible;
            MusicMuted = true;
        }

        private void MusicCheckboxHandleUnchecked(object sender, RoutedEventArgs e)
        {
            MusicImage.Visibility = Visibility.Visible;
            MuteMusicImage.Visibility = Visibility.Hidden;
            MusicMuted = false;
        }

        private void MenuResumeButton(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Hidden;
            ButtonMenuGoMain.Visibility = Visibility.Hidden;
            ButtonMenuOptions.Visibility = Visibility.Hidden;
            ButtonMenuResume.Visibility = Visibility.Hidden;
            MenuImage.Visibility = Visibility.Hidden;
            MenuLabel.Visibility = Visibility.Hidden;
            VisibleCheck = false;
        }

        /// <summary>
        ///     Hieronder volgt de code voor auto, even gescheiden want het moet wss naar boven verplaatsd worden
        /// </summary>
        /// 



        private double playerOneCarPositionX = 0;
        private double playerOneCarPositionY = 0;


        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    MoveUpPlayerOneCar();
                    break;
                case Key.A:
                    MoveLeftPlayerOneCar();
                    break;
                case Key.S:
                    MoveDownPlayerOneCar();
                    break;
                case Key.D:
                    MoveRightPlayerOneCar();
                    break;
            }
        }

        private void MoveUpPlayerOneCar()
        {
            playerOneCarPositionY -= 10;
            Player1.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveLeftPlayerOneCar()
        {
            playerOneCarPositionX -= 10;
            Player1.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveDownPlayerOneCar()
        {
            playerOneCarPositionY += 10;
            Player1.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveRightPlayerOneCar()
        {
            playerOneCarPositionX += 10;
            Player1.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }
    }
}



    }
}
