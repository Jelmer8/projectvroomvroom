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
        Circuit circuit = new Circuit();  // Instantiate your Circuit UserControl
        Size circuitSize = circuit.GetSize();  // Get the size of the Circuit UserControl

        // You can add your circuit to the main window's content or another container as needed
        Content = circuit;
        Width = circuitSize.Width;
        Height = circuitSize.Height;
    }
}
