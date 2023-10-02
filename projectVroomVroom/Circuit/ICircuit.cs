using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;

namespace projectVroomVroom.Circuit
{
    public interface ICircuit
    {
        Path TrackPath { get; }
        Size GetSize();
    }
}
