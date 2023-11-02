using projectVroomVroom;
using System;
//using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;



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
        private double maxVelocity = 3.0;
        double maxVelocity2 = 3.0;
        double carAcceleration = 0.03;
        double carAcceleration2 = 0.03;
        private bool isTurningLeft2 = false;
        private bool isTurningRight2 = false;
        private double carRotationAngle2 = 0;
        private double carX2 = 100;
        private double carY2 = 100;
        private double carVelocityForward2 = 0;
        private double carVelocityBackward2 = 0;
        private bool isAccelerating2 = false;
        private bool isReversing2 = false;
        private MediaPlayer mediaPlayer;
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Boolean VisibleCheck = false;
        private Boolean SoundMuted = false;
        private Boolean MusicMuted = false;
        private Boolean KeyIsDown = false;
        public double Wheelangle = 0;
        public double rounds = 0;
        public double checkpointDone = 0;

        public Zandvoort()
        {

            InitializeComponent();
            InitializeMediaPlayer();
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

            if (!MusicMuted)
            {
                mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(new Uri("music.mp3", UriKind.RelativeOrAbsolute));
                mediaPlayer.Play();
                mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            }
            else
            {
                mediaPlayer.Stop();
            }

            
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            
            mediaPlayer.Position = TimeSpan.Zero; 
        }




        private void OnKeyDown2(object sender, KeyEventArgs e)
        {                
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
            else if (e.Key == Key.A)
            {
                isTurningLeft2 = true;
            }
            else if (e.Key == Key.D)
            {
                isTurningRight2 = true;
            }
            else if (e.Key == Key.W)
            {
                isAccelerating2 = true;
            }
            else if (e.Key == Key.S)
            {
                isReversing2 = true;
            }

            if (!KeyIsDown)
                {
                    KeyIsDown = true;

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
            else if (e.Key == Key.A)
            {
                isTurningLeft2 = false;
            }
            else if (e.Key == Key.D)
            {
                isTurningRight2 = false;
            }
            else if (e.Key == Key.W)
            {
                isAccelerating2 = false;
            }
            else if (e.Key == Key.S)
            {
                isReversing2 = false;
            }
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
        }

            private void GameLoop(object sender, EventArgs e)
        {
            CheckCollisionsWithCar();
            if (isTurningLeft)
            {
                carRotationAngle -= 5;
            }
            if (isTurningRight)
            {
                carRotationAngle += 5;
            }

            if (isTurningLeft2)
            {
                carRotationAngle2 -= 5;
            }
            if (isTurningRight2)
            {
                carRotationAngle2 += 5;
            }

            if (isAccelerating2)
            {
                carVelocityForward2 += carAcceleration2;
            }
            else if (isReversing2)
            {
                carVelocityBackward2 += carAcceleration2;
            }
            else
            {

                carVelocityForward2 *= 0.95;
                carVelocityBackward2 *= 0.95;

            }

            carVelocityForward2 = Math.Min(maxVelocity2, carVelocityForward2);
            carVelocityBackward2 = Math.Min(maxVelocity2, carVelocityBackward2);

            double totalVelocity2 = carVelocityForward2 - carVelocityBackward2;
            double carRotationRadians2 = carRotationAngle2 * Math.PI / 180;

            carX2 += totalVelocity2 * Math.Cos(carRotationRadians2);
            carY2 += totalVelocity2 * Math.Sin(carRotationRadians2);

            Canvas.SetLeft(Car2, carX2);
            Canvas.SetTop(Car2, carY2);

            ((RotateTransform)Car2.RenderTransform).Angle = carRotationAngle2;

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
        private void MusicCheckboxHandleChecked(object sender, RoutedEventArgs e)
        {
            MusicImage.Visibility = Visibility.Hidden;
            MuteMusicImage.Visibility = Visibility.Visible;
            MusicMuted = true;
            InitializeMediaPlayer();
        }

        private void MusicCheckboxHandleUnchecked(object sender, RoutedEventArgs e)
        {
            MusicImage.Visibility = Visibility.Visible;
            MuteMusicImage.Visibility = Visibility.Hidden;
            MusicMuted = false;
            InitializeMediaPlayer();
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

        private void CheckCollisionsWithCar()
        {
            Image car = Car;
            Image car2 = Car2;
            var collision = Collision.Children.OfType<Rectangle>().ToList();
            Rect carRect2 = new Rect(Canvas.GetLeft(car2), Canvas.GetTop(car2), car2.Width, car2.Height);
            Rect carRect = new Rect(Canvas.GetLeft(car), Canvas.GetTop(car), car.Width, car.Height);

            foreach (Rectangle x in collision)
            {


                Rect imgRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                if (carRect.IntersectsWith(imgRect))
                {

                    carVelocityForward = 0;
                    
                }
                if (carRect2.IntersectsWith(imgRect))
                {

                    carVelocityForward = 0;

                }
            }

            var speed = trackRectanglePath.Children.OfType<Rectangle>().ToList();

            foreach (Rectangle a in speed) { 
            
                Rect speedRect = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                if (carRect.IntersectsWith(speedRect))
                {
                    carAcceleration = 0.5;
                    maxVelocity = 3;
                    break;
                }
                else {
                    carAcceleration = 0.015;
                    maxVelocity = 1;
                }
                if (carRect2.IntersectsWith(speedRect))
                {
                    carAcceleration = 0.5;
                    maxVelocity = 3;
                    break;
                }
                else
                {
                    carAcceleration = 0.015;
                    maxVelocity = 1;
                }
            }

            var checkpointset = checkpoint.Children.OfType<Rectangle>().ToList();

            foreach (Rectangle c in checkpointset) {
                Rect checkpointSetted = new Rect(Canvas.GetLeft(c), Canvas.GetTop(c), c.Width, c.Height);
                if (carRect.IntersectsWith(checkpointSetted)) {
                    checkpointDone = 1;
                }
            }


            var finish = CanvasFinishline.Children.OfType<Rectangle>().ToList();

            foreach (Rectangle b in finish) {
                Rect finito = new Rect(Canvas.GetLeft(b), Canvas.GetTop(b), b.Width, b.Height);
                if (carRect.IntersectsWith(finito)) {
                    if (checkpointDone == 1) {
                        rounds += 1;
                        labelTest.Content = "Round " + rounds + 1;
                        checkpointDone = 0;
                        if (rounds >= 3)
                        {
                            Environment.Exit(1);
                        }
                    }
                }
            }
        }

    }
}







