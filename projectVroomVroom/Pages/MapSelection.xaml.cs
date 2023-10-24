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
    /// Interaction logic for MapSelection.xaml
    /// </summary>
    public partial class MapSelection : UserControl
    {

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;


        public MapSelection()
        {
            InitializeComponent();
        }

        private void Zandvoort_MouseDown(object sender, MouseEventArgs e) 
        {
            mainWindow.Content = new Pages.Zandvoort();
        }

        private void Interlagos_MouseDown(object sender, MouseEventArgs e)
        {
            mainWindow.Content = new Pages.Interlagos();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.CarSelection(); // Navigate back to the main menu
        }


    }
}
