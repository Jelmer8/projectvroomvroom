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

        private int TOTAL_CARS = 2; // Total amount of cars

        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow; // Get the main window

        private bool _isReady1 = false; // Ready state for both players
        private bool _isReady2 = false;

        private int _player1Car = 1; // Car selection for both players
        private int _player2Car = 1;

        public CarSelection()
        {
            InitializeComponent();
        }

        private void CheckIfBothPlayersReady()
        {
            if (_isReady1 && _isReady2) // If both players are ready
            {
                mainWindow.Content = new Pages.MapSelection(); // Navigate to the Circuit page
            }
        }

        private void UpdateCarImage(Image carImage, int newCar)
        {
            carImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/car" + newCar + ".png")); // Update the car image
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Pages.MainMenu(); // Navigate back to the main menu
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

        private void Player1ReadyButtonClick(object sender, RoutedEventArgs e)
        {
            _isReady1 = !_isReady1; // Toggle the ready state

            CheckIfBothPlayersReady();

            ReadyButton1.Background = _isReady1 ? 
                new SolidColorBrush(Color.FromRgb(35, 225, 32)) : 
                new SolidColorBrush(Color.FromRgb(177, 177, 177)); // Change the background color of the button to show if player is ready
        }

        private void Player2ReadyButtonClick(object sender, RoutedEventArgs e)
        {
            _isReady2 = !_isReady2; // Toggle the ready state

            CheckIfBothPlayersReady();

            ReadyButton2.Background = _isReady2 ?
                new SolidColorBrush(Color.FromRgb(35, 225, 32)) :
                new SolidColorBrush(Color.FromRgb(177, 177, 177)); // Change the background color of the button to show if player is ready
        }
        
        private void Player1LeftArrowButtonClick(object sender, RoutedEventArgs e)
        {
            _player1Car--; // Decrease the selected car
            if (_player1Car < 1) // If the selected car is lower than 1
            {
                _player1Car = TOTAL_CARS; // Set the selected car to the highest value
            }

            UpdateCarImage(Car1, _player1Car);
        }

        private void Player1RightArrowButtonClick(object sender, RoutedEventArgs e)
        {
            _player1Car++; // Increase the selected car
            if (_player1Car > TOTAL_CARS) // If the selected car is higher than the highest value
            {
                _player1Car = 1; // Set the selected car to 1
            }

            UpdateCarImage(Car1, _player1Car);
        }

        private void Player2LeftArrowButtonClick(object sender, RoutedEventArgs e)
        {
            _player2Car--; // Decrease the selected car
            if (_player2Car < 1) // If the selected car is lower than 1
            {
                _player2Car = TOTAL_CARS; // Set the selected car to the highest value
            }

            UpdateCarImage(Car2, _player2Car);
        }

        private void Player2RightArrowButtonClick(object sender, RoutedEventArgs e)
        {
            _player2Car++; // Increase the selected car
            if (_player2Car > TOTAL_CARS) // If the selected car is higher than the highest value
            {
                _player2Car = 1; // Set the selected car to 1
            }

            UpdateCarImage(Car2, _player2Car);
        }
    }
}