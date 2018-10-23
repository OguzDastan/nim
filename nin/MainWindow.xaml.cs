using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace nin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool myTurn;
        private bool hasRemoved;
        public MainWindow()
        {
            InitializeComponent();
            L1.Content = "1";
            L2.Content = "111";
            L3.Content = "11111";
            L4.Content = "1111111";

            Row1r.Content = "remove 1 stick";
            Row2r.Content = "remove 1 stick";
            Row3r.Content = "remove 1 stick";
            Row4r.Content = "remove 1 stick";

            PlayerTurn.Content = "Det er player 1's Tur.";
            myTurn = true;
            Next.Content = "Skift spiller";
            Winner.Content = "";
            newGame.Content = "New Game";
            hasRemoved = false;
        }

        private void Row1r_Click(object sender, RoutedEventArgs e)
        {
            EnableOnly(Row1r);
            removeStick(L1);
        }
        private void Row2r_Click(object sender, RoutedEventArgs e)
        {
            EnableOnly(Row2r);
            removeStick(L2);
        }
        private void Row3r_Click(object sender, RoutedEventArgs e)
        {
            EnableOnly(Row3r);
            removeStick(L3);
        }
        private void Row4r_Click(object sender, RoutedEventArgs e)
        {
            EnableOnly(Row4r);
            removeStick(L4);
        }

        private void removeStick(Label l)
        {
            string a = l.Content.ToString();
            if (a.Length > 0)
            {
                l.Content = a.Remove(0, 1);
                hasRemoved = true;
            }
            else
            {
                Next_Click(Next, null);
            }
        }

        private void EnableOnly(object notToDisable)
        {
            Row1r.IsEnabled = false;
            Row2r.IsEnabled = false;
            Row3r.IsEnabled = false;
            Row4r.IsEnabled = false;

            Button b = (Button)notToDisable;
            b.IsEnabled = true;
        }

        private void DisableEmpty()
        {
            if (!(L1.Content.ToString() == ""))
                Row1r.IsEnabled = true;
            else
                Row1r.IsEnabled = false;

            if (!(L2.Content.ToString() == ""))
                Row2r.IsEnabled = true;
            else
                Row2r.IsEnabled = false;

            if (!(L3.Content.ToString() == ""))
                Row3r.IsEnabled = true;
            else
                Row3r.IsEnabled = false;

            if (!(L4.Content.ToString() == ""))
                Row4r.IsEnabled = true;
            else
                Row4r.IsEnabled = false;
        }

        private void enableAll()
        {
            Row1r.IsEnabled = true;
            Row2r.IsEnabled = true;
            Row3r.IsEnabled = true;
            Row4r.IsEnabled = true;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (hasRemoved)
            {
                enableAll();

                DisableEmpty();

                myTurn = !myTurn;

                if (myTurn)
                {
                    PlayerTurn.Content = "Det er spiller 1's tur";
                }
                else
                {
                    PlayerTurn.Content = "Det er spiller 2's tur";
                }

                string a = L1.Content.ToString() + L2.Content.ToString() + L3.Content.ToString() +
                           L4.Content.ToString();
                if (a == "")
                {
                    if (myTurn)
                    {
                        Winner.Content = "Spiller 1 Vinder!";
                    }
                    else
                    {
                        Winner.Content = "Spiller 2 Vinder!";
                    }
                }

                hasRemoved = false;
            }
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            L1.Content = "1";
            L2.Content = "111";
            L3.Content = "11111";
            L4.Content = "1111111";

            Winner.Content = "";
            PlayerTurn.Content = "Det er player 1's Tur.";
            myTurn = true;
            Next.Content = "Skift spiller";

            enableAll();
            hasRemoved = false;
        }
    }
}
