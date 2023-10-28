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


        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Boolean VisibleCheck = false;
        private Boolean SoundMuted = false;
        private Boolean MusicMuted = false;
        public double Wheelangle = 0;

        public Zandvoort()
        {
            InitializeComponent();
            canvas.Focus();
            this.KeyDown += OnKeyDown2;
            this.KeyUp += OnKeyUp;
            DispatcherTimer gameLoopTimer = new DispatcherTimer();
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16); 
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();
            InitializeMediaPlayer();

        }

        private void InitializeMediaPlayer()
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();

            string fileName = "music.mp3";
            // Provide the path to your MP3 file
            string mp3FilePath = fileName;

            // Load and play the MP3 file
            player.URL = mp3FilePath;
            player.controls.play();
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
    }





    }







