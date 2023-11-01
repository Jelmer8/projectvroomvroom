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
        double carAcceleration = 0.03;

        private MediaPlayer mediaPlayer;
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Boolean VisibleCheck = false;
        private Boolean SoundMuted = false;
        private Boolean MusicMuted = false;
        public double Wheelangle = 0;

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
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("Music/music.mp3", UriKind.RelativeOrAbsolute));
            mediaPlayer.Play();


            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
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

        }
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
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

            CheckCollisionsWithCar();
            if (isTurningLeft)
            {
                carRotationAngle -= 5;
            }
            if (isTurningRight)
            {
                carRotationAngle += 5;
            }


            
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

        private void CheckCollisionsWithCar()
        {
            Image car = Car;
            var collision = Collision.Children.OfType<Rectangle>().ToList();

            Rect carRect = new Rect(Canvas.GetLeft(car), Canvas.GetTop(car), car.Width, car.Height);

            foreach (Rectangle x in collision)
            {

                Rect imgRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                if (carRect.IntersectsWith(imgRect))
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
            }
        }

    }
}







