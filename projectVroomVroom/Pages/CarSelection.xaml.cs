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
    /// Interaction logic for CarSelection.xaml
    /// </summary>
    public partial class CarSelection : UserControl
    {

        private bool _isReady1 = false; // Ready state for both players
        private bool _isReady2 = false;

        public CarSelection()
        {
            InitializeComponent();
        }

        private void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox; // Get the textbox that is clicked
            if (textBox.Text == "Naam") // If the textbox contains the placeholder text
            {
                textBox.Text = ""; // Remove the placeholder text
            }
        }

        private void AddPlaceholder(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox; // Get the textbox that is clicked
            if (string.IsNullOrWhiteSpace(textBox.Text)) // If the textbox is empty
            {
                textBox.Text = "Naam"; // Add the placeholder text
            }
        }

        private void ReadyButton1Click(object sender, RoutedEventArgs e)
        {
            _isReady1 = !_isReady1; // Toggle the ready state

            CheckIfBothPlayersReady();

            ReadyButton1.Background = _isReady1 ? 
                new SolidColorBrush(Color.FromRgb(35, 225, 32)) : 
                new SolidColorBrush(Color.FromRgb(177, 177, 177)); // Change the background color of the button to show if player is ready
        }

        private void ReadyButton2Click(object sender, RoutedEventArgs e)
        {
            _isReady2 = !_isReady2; // Toggle the ready state

            CheckIfBothPlayersReady();

            ReadyButton2.Background = _isReady2 ? 
                new SolidColorBrush(Color.FromRgb(35, 225, 32)) : 
                new SolidColorBrush(Color.FromRgb(177, 177, 177)); // Change the background color of the button to show if player is ready
        }

        private void CheckIfBothPlayersReady()
        {
            if (_isReady1 && _isReady2) // If both players are ready
            {
                this.Content = new Circuit.Circuit(); // Navigate to the Circuit page
            }
        }
    }
}