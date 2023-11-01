using projectVroomVroom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
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
using System.Windows.Threading;
using WMPLib;

namespace projectVroomVroom.Pages
{

    public partial class Zandvoort : UserControl
    {
        private bool isTurningLeft = false;
        private bool isTurningRight = false;
        private double carRotationAngle = 0;
        private double carX = 100; 
        private double carY = 100; 
        private double carVelocityForward = 0; 
        private double carVelocityBackward = 0; 
        private bool isAccelerating = false;
        private bool isReversing = false;

        private MediaPlayer mediaPlayer;
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Boolean VisibleCheck = false;
        private Boolean SoundMuted = false;
        private Boolean MusicMuted = false;
        private Boolean KeyIsDown = false;
        public double Wheelangle = 0;

        public Zandvoort()
        {

            InitializeComponent();
            //InitializeMediaPlayer();
            canvas.Focus();
            this.KeyDown += OnKeyDown2;
            this.KeyUp += OnKeyUp;
            DispatcherTimer gameLoopTimer = new DispatcherTimer();
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16); 
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();

     }

        

        private void InitializeMediaPlayer()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("music.mp3", UriKind.RelativeOrAbsolute));
            mediaPlayer.Play();

            
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            
            mediaPlayer.Position = TimeSpan.Zero; 
        }




        private void OnKeyDown2(object sender, KeyEventArgs e)
        {
            if (!KeyIsDown)
            {
                KeyIsDown = true;
                
                if (e.Key == Key.Left)
                {
                    isTurningLeft = true;
                }
                else if (e.Key == Key.Right)
                {
                    isTurningRight = true;
                }
                else if (e.Key == Key.Up)
                {
                    isAccelerating = true;
                }
                else if (e.Key == Key.Down)
                {
                    isReversing = true;
                }

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

        }
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            KeyIsDown = false;
            if (e.Key == Key.Left)
            {
                isTurningLeft = false;
            }
            else if (e.Key == Key.Right)
            {
                isTurningRight = false;
            }
            else if (e.Key == Key.Up)
            {
                isAccelerating = false;
            }
            else if (e.Key == Key.Down)
            {
                isReversing = false;
            }
        }

        private void GameLoop(object sender, EventArgs e)
        {

            
            if (isTurningLeft)
            {
                carRotationAngle -= 5; 
            }
            if (isTurningRight)
            {
                carRotationAngle += 5; 
            }

            
            double carAcceleration = 0.1; 
            if (isAccelerating)
            {
                carVelocityForward += carAcceleration;
            }
            else if (isReversing)
            {
                carVelocityBackward += carAcceleration;
            }
            else
            {
                
                carVelocityForward *= 0.95;
                carVelocityBackward *= 0.95;
            }

            
            double maxVelocity = 5.0; 
            carVelocityForward = Math.Min(maxVelocity, carVelocityForward);
            carVelocityBackward = Math.Min(maxVelocity, carVelocityBackward);

            
            double totalVelocity = carVelocityForward - carVelocityBackward;

            
            double carRotationRadians = carRotationAngle * Math.PI / 180;

            
            carX += totalVelocity * Math.Cos(carRotationRadians);
            carY += totalVelocity * Math.Sin(carRotationRadians);

            
            Canvas.SetLeft(Car, carX);
            Canvas.SetTop(Car, carY);

            
            ((RotateTransform)Car.RenderTransform).Angle = carRotationAngle;
        }

        private void MainMenuButton(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.MainMenu(); // Navigate back to the main menu
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

    }





    }







