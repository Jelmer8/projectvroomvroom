﻿using projectVroomVroom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
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

    public partial class Interlagos : UserControl
    {
        // constants
        private double carAcceleration = 0.1;
        private double maxVelocity = 5.0;

        // rest of the variables
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
        public double Wheelangle = 0;

        private System.Threading.Timer _timer;


        public Interlagos()
        {
            InitializeComponent();
            InitializeMediaPlayer();
            canvasMain.Focus();
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
            CheckCollisionsWithCar();
        }

        private void CheckCollisionsWithCar()
        {
            var otherImages = canvasMain.Children.OfType<Image>().ToList();

            foreach (var img in otherImages)
            {
                Rect carRect = new Rect(Canvas.GetLeft(Car), Canvas.GetTop(Car), Car.Width, Car.Height);
                Rect imgRect = new Rect(Canvas.GetLeft(img), Canvas.GetTop(img), img.Width, img.Height);
                if (carRect.IntersectsWith(imgRect))
                {
                    if (isAccelerating)
                    {
                        carVelocityForward = 1;
                        carVelocityBackward = 0;
                    } else if (isReversing)
                    {
                        carVelocityForward = 0;
                        carVelocityBackward = 1;
                    } else
                    {
                        carVelocityForward *= 0.5;
                        carVelocityBackward *= 0.5;
                    }
                    return;
                }

            }

        }

    }
}