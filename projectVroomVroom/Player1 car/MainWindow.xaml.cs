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
                case Key.W:
                    MoveUpPlayerOneCar();
                    break;
                case Key.A:
                    MoveLeftPlayerOneCar();
                    break;
                case Key.S:
                    MoveDownPlayerOneCar();
                    break;
                case Key.D:
                    MoveRightPlayerOneCar();
                    break;
            }
        }

        private void MoveUpPlayerOneCar()
        {
            playerOneCarPositionY -= 10;
            Player1.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveLeftPlayerOneCar()
        {
            playerOneCarPositionX -= 10;
            Player1.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveDownPlayerOneCar()
        {
            playerOneCarPositionY += 10;
            Player1.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }

        private void MoveRightPlayerOneCar()
        {
            playerOneCarPositionX += 10;
            Player1.Margin = new Thickness(playerOneCarPositionX, playerOneCarPositionY, 0, 0);
        }
    }
}
