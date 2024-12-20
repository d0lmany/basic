using System.Windows;
using System.Windows.Controls;

namespace TTTgui
{
    public partial class MainWindow : Window
    {
        private string player = "X";
        private void Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.ToString() == " ")
            {
                ((Button)sender).Content = player;
            }
            else
            {
                MessageBox.Show("You select a busy cell, try again");
            }
            if (CheckWin())
            {
                MessageBox.Show($"{player} wins!");
                Close();
            }
            else
            {
                if (isDraw())
                {
                    MessageBox.Show("Nobody wins..");
                    Close();
                }
            }
            player = (player == "X") ? "O" : "X";
            Out.Text = Out.Text.Replace(Out.Text[^1], player[0]);
        }

        private bool isDraw()
        {
            Button[] that = [aa, ab, ac, ba, bb, bc, ca, cb, cc];
            foreach (Button a in that)
            {
                if (a.Content.ToString() == " ")
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckWin()
        {
            string[,] a = {
                { aa.Content.ToString()!, ab.Content.ToString()!, ac.Content.ToString()! },
                { ba.Content.ToString()!, bb.Content.ToString()!, bc.Content.ToString()! },
                { ca.Content.ToString()!, cb.Content.ToString()!, cc.Content.ToString()! }
            };
            return (a[0, 0] == player && a[0, 1] == player && a[0, 2] == player) ||
                (a[1, 0] == player && a[1, 1] == player && a[1, 2] == player) ||
                (a[2, 0] == player && a[2, 1] == player && a[2, 2] == player) ||

                (a[0, 0] == player && a[1, 0] == player && a[2, 0] == player) ||
                (a[0, 1] == player && a[1, 1] == player && a[2, 1] == player) ||
                (a[0, 2] == player && a[1, 2] == player && a[2, 2] == player) ||

                (a[0, 0] == player && a[1, 1] == player && a[2, 2] == player) ||
                (a[0, 2] == player && a[1, 1] == player && a[2, 0] == player);
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}