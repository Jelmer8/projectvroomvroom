using System.Numerics;
using System.Windows;
using System.Windows.Input;

namespace vroom_vroom_cars
{
    public partial class MainWindow : Window
    {
        private double playerOneCarPositionX = 0;
        private double playerOneCarPositionY = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    MoveUpPlayerOneCar();
                    break;
                case Key.Left:
                    MoveLeftPlayerOneCar();
                    break;
                case Key.Down:
                    MoveDownPlayerOneCar();
                    break;
                case Key.Right:
                    MoveRightPlayerOneCar();
                    break;
            }
        }

        private void MoveUpPlayerOneCar()
        {
            playerOneCarPositionY -= 10;
            Player2.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveLeftPlayerOneCar()
        {
            playerOneCarPositionX -= 10;
            Player2.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveDownPlayerOneCar()
        {
            playerOneCarPositionY += 10;
            Player2.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveRightPlayerOneCar()
        {
            playerOneCarPositionX += 10;
            Player2.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }
    }
}
