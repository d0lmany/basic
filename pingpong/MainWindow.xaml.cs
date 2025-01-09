using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace pingpong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer = new() { Interval = TimeSpan.FromMilliseconds(20) };
        private Ellipse? ball;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Move(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    Canvas.SetTop(L, Canvas.GetTop(L) - 5);
                    break;
                case Key.S:
                    Canvas.SetTop(L, Canvas.GetTop(L) + 5);
                    break;
                case Key.Up:
                    Canvas.SetTop(R, Canvas.GetTop(R) - 5);
                    break;
                case Key.Down:
                    Canvas.SetTop(R, Canvas.GetTop(R) + 5);
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Line line = new()
            {
                Stroke = Brushes.White,
                X1 = Board.ActualWidth / 2,
                X2 = Board.ActualWidth / 2,
                Y1 = 0,
                Y2 = Board.ActualHeight,
                StrokeThickness = 1
            };
            Board.Children.Add(line);
            ball = new Ellipse()
            {
                Fill = Brushes.White,
                Width = 12.5,
                Height = 12.5
            };
            Board.Children.Add(ball);
            Canvas.SetTop(ball, Board.ActualHeight / 2);
            Canvas.SetLeft(ball, Board.ActualWidth / 2 - 6.25);
            timer.Tick += Game;
            timer.Start();
        }

        private void Game(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}