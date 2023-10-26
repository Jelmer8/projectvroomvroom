using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace projectVroomVroom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new Pages.MainMenu(); // Navigate to the main menu
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            /// hoi 
        }
        ///                 Om de auto te versnellen en de snelheid te bepalen gebruik zo'n code
        ///                 if (car.Speed + car.Acceleration < car.MaxSpeed)
        ///                 car.Speed = car.Speed + car.Acceleration* groundFactor;
    }
}
