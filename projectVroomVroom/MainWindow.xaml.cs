using System.Windows;
using projectVroomVroom.Circuit;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        
        InitializeTrack();
    }

    private void InitializeTrack()
    {
        Circuit circuit = new Circuit();  
        Size circuitSize = circuit.GetSize();  

       
        Content = circuit;
        Width = circuitSize.Width;
        Height = circuitSize.Height;
    }
}
