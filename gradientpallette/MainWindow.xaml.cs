using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gradientpallette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for(byte i = 0; i < byte.MaxValue; i++)
            {
                for(byte j = i ; j < byte.MaxValue; j++)
                {
                    Rectangle p = new()
                    {
                        Width = 3, Height = 3, Fill = new SolidColorBrush(Color.FromRgb(j,0,0))
                    };
                    Board.Children.Add(p);
                }
            }
        }
    }
}