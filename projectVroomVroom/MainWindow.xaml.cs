<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
=======
﻿using System.Windows;
using projectVroomVroom.Circuit;
>>>>>>> Youri
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
public partial class MainWindow : Window
{
    public MainWindow()
    {
<<<<<<< HEAD
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new Pages.MainMenu(); // Navigate to the main menu
        }
=======
        
        InitializeTrack();
    }

    private void InitializeTrack()
    {
        Circuit circuit = new Circuit();  
        Size circuitSize = circuit.GetSize();  

       
        Content = circuit;
        Width = circuitSize.Width;
        Height = circuitSize.Height;
>>>>>>> Youri
    }
}
