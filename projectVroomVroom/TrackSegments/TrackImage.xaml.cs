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
using System.Windows.Shapes;

namespace projectVroomVroom.TrackSegments
{
    /// <summary>
    /// Interaction logic for TrackImage.xaml
    /// </summary>
    public partial class TrackImage : UserControl, ITrackSegment
    {
        public TrackImage()
        {
            InitializeComponent();
        }

        public Point GetMidTrackPoint(double x, double y)
        {
            return new Point(x, y);
        }
    }
}
