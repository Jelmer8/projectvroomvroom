using projectVroomVroom.Circuit;
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
            InitializeCars();
            InitializeTrack();

        }

        private void InitializeTrack()
        {
            var pathData = circuit.TrackPath.Data;
            var pathGeometry = pathData.GetFlattenedPathGeometry();
            var pathFigure = pathGeometry.Figures[0];

            polyLineSegment = (PolyLineSegment)pathFigure.Segments[0];
            var p1 = polyLineSegment.Points[0];
            trackStartPoint = pathFigure.StartPoint;




        }
    }
}
