using Microsoft.Win32;
using System.Diagnostics;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Flappers
{
    public partial class MainWindow : Window
    {
        private int score = 0, speed = 8, gravity = 15;
        private readonly DispatcherTimer timer = new() { Interval = TimeSpan.FromMilliseconds(20) };
        private SoundPlayer player = new()
        {
            Stream = Application.GetResourceStream(new Uri("pack://application:,,,/game-lost.wav", UriKind.RelativeOrAbsolute)).Stream
        };
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Tick;
            Start();
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Start();
        }

        private void Tick(object? sender, EventArgs e)
        {
            Canvas.SetTop(Hero, Canvas.GetTop(Hero) + gravity);
            Canvas.SetLeft(Bottom, Canvas.GetLeft(Bottom) - speed);
            Canvas.SetLeft(Top, Canvas.GetLeft(Top) - speed);
            Random r = new();
            if (Canvas.GetLeft(Bottom) < Canvas.GetLeft(Hero) - Hero.Width * 1.1)
            {
                Canvas.SetLeft(Bottom, Canvas.GetLeft(Bottom) + r.Next((int)(Canvas.GetLeft(Hero) * 2), (int)Board.ActualWidth));
                Canvas.SetTop(Bottom, r.Next((int)Bottom.Height, (int)Board.ActualHeight) + 50);
                score++;
                ScoreOut.Content = score;
            }
            if (Canvas.GetLeft(Top) < Canvas.GetLeft(Hero) - Hero.Width * 1.1)
            {
                Canvas.SetLeft(Top, Canvas.GetLeft(Top) + r.Next((int)(Canvas.GetLeft(Hero) * 2), (int)Board.ActualWidth));
                Canvas.SetTop(Top, r.Next(-(int)Top.Height, 0));
                score++;
                ScoreOut.Content = score;
            }
            Rect bbr = GetRectForImage(Bottom);
            Rect btr = GetRectForImage(Top);
            if (CheckVert() || CheckIntersection(bbr, btr))
            {
                GameOver();
            }
        }

        private bool CheckIntersection(Rect barBottomRect, Rect barTopRect)
        {
            double heroX = Canvas.GetLeft(Hero), heroY = Canvas.GetTop(Hero), heroWidth = Hero.Width, heroHeight = Hero.Height;
            EllipseGeometry heroGeometry = new(
                new Point(heroX + heroWidth / 2, heroY + heroHeight / 2),
                heroWidth / 2,
                heroHeight / 2
            );
            return (Geometry.Combine(heroGeometry, new RectangleGeometry(barBottomRect), GeometryCombineMode.Intersect, null).GetArea() > 0) ||
           (Geometry.Combine(heroGeometry, new RectangleGeometry(barTopRect), GeometryCombineMode.Intersect, null).GetArea() > 0);
        }

        private static Rect GetRectForImage(Rectangle image)
        {
            double x = Canvas.GetLeft(image), y = double.IsNaN(Canvas.GetTop(image)) ? 0 : Canvas.GetTop(image), width = image.ActualWidth, height = image.ActualHeight;
            return new Rect(x, y, width, height);
        }

        private bool CheckVert()
        {
            return (Canvas.GetTop(Hero) > Board.ActualHeight - 125) || (Canvas.GetTop(Hero) <= 0);
        }

        private void Up(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                gravity = -15;
            }
        }

        private void Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                gravity = 15;
            }
        }

        private void SelectHero(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            OpenFileDialog ofd = new() { Filter = "Image Files (*.png)|*.png" };
            if (ofd.ShowDialog() == true)
            {
                string filePath = ofd.FileName;
                if (System.IO.Path.GetExtension(filePath).Equals(".png", StringComparison.OrdinalIgnoreCase))
                {
                    BitmapImage bitmap = new(new Uri(filePath));
                    ImageBrush imageBrush = new(bitmap);
                    Hero.Fill = imageBrush;
                }
                else
                {
                    MessageBox.Show("genuis, it's not PNG");
                }
            }
            Start();
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult a = MessageBox.Show("The browser will open, are you sure?", "Warn", MessageBoxButton.YesNo);
            if (a == MessageBoxResult.Yes)
            {
                Process.Start(new ProcessStartInfo("https://d0lmany.netlify.app/")
                {
                    UseShellExecute = true
                });
            }
        }

        private void Start()
        {
            Canvas.SetLeft(Hero, 150);
            Canvas.SetTop(Hero, 180);
            Canvas.SetLeft(Top, 690);
            Canvas.SetLeft(Bottom, 330);
            Canvas.SetTop(Bottom, 345);
            score = 0; gravity = 15; speed = 8;
            ScoreOut.Content = score;
            GO.Opacity = 0;
            timer.Start();
        }

        private void GameOver()
        {
            timer.Stop();
            GO.Opacity = 1;
            player.Play();
        }
    }
}