﻿using projectVroomVroom;
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

        private bool isTurningLeft2 = false;
        private bool isTurningRight2 = false;

        private double carRotationAngle = 0;
        private double carX = 100; 
        private double carY = 100;

        private double carRotationAngle2 = 0;
        private double carX2 = 100;
        private double carY2 = 100;

        private double carVelocityForward = 0; 
        private double carVelocityBackward = 0;
        private double carVelocityForward2 = 0;
        private double carVelocityBackward2 = 0;

        private bool isAccelerating = false;
        private bool isReversing = false;

        private bool isAccelerating2 = false;
        private bool isReversing2 = false;



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



            if (isTurningLeft2)
            {
                carRotationAngle2 -= 5;
            }
            if (isTurningRight2)
            {
                carRotationAngle2 += 5;
            }


            double carAcceleration = 0.1; 
             double carAcceleration2 = 0.1;

            if (isAccelerating)
            {
                carVelocityForward += carAcceleration;
            }
            else if (isReversing)
            {
                carVelocityBackward += carAcceleration + 0.05;
            }
            else
            {
            


                    carVelocityForward *= 0.95;
                carVelocityBackward *= 0.95;
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
                double maxVelocity = 5.0; 
            carVelocityForward = Math.Min(maxVelocity, carVelocityForward);
            carVelocityBackward = Math.Min(maxVelocity, carVelocityBackward);


            double maxVelocity2 = 5.0;
            carVelocityForward2 = Math.Min(maxVelocity2, carVelocityForward2);
            carVelocityBackward2 = Math.Min(maxVelocity2, carVelocityBackward2);

            double totalVelocity = carVelocityForward - carVelocityBackward;

            double totalVelocity2 = carVelocityForward2 - carVelocityBackward2;


            double carRotationRadians = carRotationAngle * Math.PI / 180;

            double carRotationRadians2 = carRotationAngle2 * Math.PI / 180;


            carX += totalVelocity * Math.Cos(carRotationRadians);
            carY += totalVelocity * Math.Sin(carRotationRadians);

            
            Canvas.SetLeft(Car, carX);
            Canvas.SetTop(Car, carY);


            carX2 += totalVelocity2 * Math.Cos(carRotationRadians2);
            carY2 += totalVelocity2 * Math.Sin(carRotationRadians2);


            Canvas.SetLeft(Car2, carX2);
            Canvas.SetTop(Car2, carY2);


            ((RotateTransform)Car.RenderTransform).Angle = carRotationAngle;

            ((RotateTransform)Car2.RenderTransform).Angle = carRotationAngle2;
        }
    }





    }







