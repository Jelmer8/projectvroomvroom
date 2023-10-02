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
using System.Windows.Threading;

namespace projectVroomVroom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region attributes
        static double MAX_ANGLE = 30;
        static double MAX_REAL_SPEED = 280;
        const int TRACK_ARRAY_WIDTH = 36;
        const int TRACK_ARRAY_HEIGHT = 22;
        const int TRACK_VIEW_WIDTH = 5;
        const int TRACK_VIEW_HEIGHT = 5;
        const double TRACK_WIDTH = 200;
        const double METERS_PER_TRACK_SEGMENT = 10.3;
        double max_track_point_X = 0.0;
        double max_track_point_Y = 0.0;
        DispatcherTimer gameLoopTimer;
        double friction = 0.01;
        double frictionOnTrack = 0.01;
        double frictionOnLightGrass = 0.85;
        double frictionOnHeavyGrass = 0.85;
        int[,] trackArray = new int[5, 5];
        double lastTrackAngle = 0;
       /// ITrackSegment lastSegment = null;
        DateTime startTime;
        DateTime currentTime;
        ICircuit circuit = new Circuit.Circuit();
        Canvas cnvImage = new Canvas();
        Path trackWhiteLine;
        Path trackRedLine;
        Path trackGrayTrackLine;
        Path trackCenterLine;
        Path mapWhiteLine;
        Path mapBlackLine;
       /// List<TrackLineSegment> trackLineList = new List<TrackLineSegment>();
        PolyLineSegment polyLineSegment;
        const double MAX_TRACK_FRICTION_RANGE = 110.0;
        const double MAX_LIGHTGRASS_FRICTION_RANGE = 120.0;
        const double MAX_LIGHTGRASS_SPEED_REDUCTION = 1.5;
        const double MAX_HEAVYGRASS_SPEED_REDUCTION = 1.5;
       /// List<Kart> kartList = new List<Kart>();
        double circuitLength = 0.0;
        Point trackStartPoint;
        const int TOTAL_LAPS = 5;
        Image checkeredLine;
        List<Ellipse> mapCarPositionMarkerList = new List<Ellipse>();
        bool gameOver = true;
        const double BACKGROUND_RESOLUTION = 0.2;
        Ellipse trackEllipse;
        #endregion attributes

        public MainWindow()
        {
            InitializeComponent();
         ///   InitializeCars();
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

            trackWhiteLine = new Path()
            {
                Stroke = new SolidColorBrush(Color.FromRgb(0xE0, 0xE0, 0xE0)),
                StrokeThickness = 200,
                StrokeDashArray = new DoubleCollection(new double[] { 0.1, 0.1 }),
                StrokeDashOffset = 0.0,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top
            };
            trackRedLine = new Path()
            {
                Stroke = new SolidColorBrush(Color.FromRgb(0xFF, 0x00, 0x00)),
                StrokeThickness = 200,
                StrokeDashArray = new DoubleCollection(new double[] { 0.1, 0.1 }),
                StrokeDashOffset = 0.1,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top
            };
            trackGrayTrackLine = new Path()
            {
                Stroke = new SolidColorBrush(Color.FromRgb(0x80, 0x80, 0x80)),
                StrokeThickness = 180,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top
            };
            trackCenterLine = new Path()
            {
                Stroke = new SolidColorBrush(Color.FromRgb(0xC0, 0xC0, 0x80)),
                StrokeThickness = 4,
                StrokeDashArray = new DoubleCollection(new double[] { 3, 2 }),
                StrokeDashOffset = 0.0,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top
            };

            var drawingBrush = new DrawingBrush()
            {
                Stretch = Stretch.None,
                TileMode = TileMode.Tile,
                Viewport = new Rect(0, 0, 0.1, 0.1)
            };

            mapWhiteLine = new Path()
            {
                Stroke = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0x00)),
                StrokeThickness = 8,
                Margin = new Thickness(-11, -11, 0, 0),
                Opacity = 0.5
            };

            mapBlackLine = new Path()
            {
                Stroke = new SolidColorBrush(Color.FromRgb(0x00, 0x00, 0x00)),
                StrokeThickness = 8,
                Margin = new Thickness(-10, -10, 0, 0),
                Opacity = 0.0
            };

            var strPoints = new StringBuilder();
            var strMapPoints = new StringBuilder();
            strPoints.AppendFormat("M {0},{1}", trackStartPoint.X * 8 + 200, trackStartPoint.Y * 8 + 200);
            strMapPoints.AppendFormat("M {0},{1}", trackStartPoint.X, trackStartPoint.Y);
            max_track_point_X = trackStartPoint.X;
            max_track_point_Y = trackStartPoint.Y;
            int pointCount = 0;
            var lastPoint = trackStartPoint;
            var index = 0;
            foreach (var point in polyLineSegment.Points)
            {
                if (point.X > max_track_point_X)
                    max_track_point_X = point.X;

                if (point.Y > max_track_point_Y)
                    max_track_point_Y = point.Y;



                index++;






            }
    }
}
