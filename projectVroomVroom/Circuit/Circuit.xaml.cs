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

namespace projectVroomVroom.Circuit
{
    /// <summary>
    /// Interaction logic for Circuit.xaml
    /// </summary>
    public partial class Circuit : UserControl, ICircuit
    {
        public Circuit()
        {
            InitializeComponent();
        }
        public Path TrackPath
        {
            get { return trackPath; }
        }

        public Size GetSize()
        {
            return new Size(grdMain.Width, grdMain.Height);
        }
    }
}
