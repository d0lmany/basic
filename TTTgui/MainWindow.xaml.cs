using System.Windows;
using System.Windows.Controls;

namespace TTTgui
{
    public partial class MainWindow : Window
    {
        string player = "X";
        private void Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.ToString() == " ")
            {
                ((Button)sender).Content = player;
                Out.Text = Out.Text.Replace(Out.Text[^1], player[0]);
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
            if (isDraw())
            {
                MessageBox.Show("Nobody wins..");
                Close();
            }
            player = (player == "X") ? "O" : "X";

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
             return aa.Content.ToString() == player && ab.Content.ToString() == player && ac.Content.ToString() == player ||
                    ba.Content.ToString() == player && bb.Content.ToString() == player && bc.Content.ToString() == player ||
                    ca.Content.ToString() == player && cb.Content.ToString() == player && cc.Content.ToString() == player ||
                    aa.Content.ToString() == player && ba.Content.ToString() == player && ca.Content.ToString() == player ||
                    ab.Content.ToString() == player && bb.Content.ToString() == player && bc.Content.ToString() == player ||
                    ac.Content.ToString() == player && cb.Content.ToString() == player && cc.Content.ToString() == player ||
                    aa.Content.ToString() == player && bb.Content.ToString() == player && cc.Content.ToString() == player ||
                    ac.Content.ToString() == player && bb.Content.ToString() == player && ca.Content.ToString() == player;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}