using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        /// <summary>
        /// игрок ходит ноликами иначе крестиками
        /// </summary>
        private bool player = true;

        /// <summary>
        /// бот ходит крестиками иначе ноликами
        /// </summary>
        private bool botSym = false;
        int ii;
        private Random rnd = new Random();
        static string debug = "0";
        List<Button> btns = new List<Button>();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            btns.Add(b1);
            btns.Add(b2);
            btns.Add(b3);
            btns.Add(b4);
            btns.Add(b5);
            btns.Add(b6);
            btns.Add(b7);
            btns.Add(b8);
            btns.Add(b9);

            switch (player)
            {
                case true:
                    sender.GetType().GetProperty("Content").SetValue(sender, "X");
                    label.Content = "Текущий ход O";
                    checkWin();
                    break;
                case false:
                    sender.GetType().GetProperty("Content").SetValue(sender, "O");
                    label.Content = "Текущий ход X";
                    checkWin();
                    break;
            }
            bot(sender, e);
            checkWin();
            if (label.Content == "Победил X" || label.Content == "Победил O" || label.Content == "Ничья")
            {
                player = !player;
                botSym = !botSym;
                checkWin();
            }
            sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
        }

        private int bot(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int c = rand.Next(0, btns.Count);
            if (b1.Content == "" || b2.Content == "" || b3.Content == "" || b4.Content == "" || b5.Content == "" || b6.Content == "" || b7.Content == "" || b8.Content == "" || b9.Content == "")
            {
                try
                {
                    while (btns[c].Content == "O" || btns[c].Content == "X")
                    {
                        c = rand.Next(0, btns.Count);
                    }
                    if (botSym)
                    {
                        //btns[c].GetType().GetProperty("Content").SetValue(btns[c], "X");
                        btns[c].Content = "X";
                        btns[c].IsEnabled = false;
                    }
                    else
                    {
                        // btns[c].GetType().GetProperty("Content").SetValue(btns[c], "O");
                        btns[c].Content = "O";
                        btns[c].IsEnabled = false;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show($"{x}");
                    throw;
                }
            }
            debug = $"{c}";

            if (btns[c].Content == "")
            {
                label.Content = "Ничья";
                btns[c].IsEnabled = false;
            }
            else
            if (btns[c].Content == "X" || btns[c].Content == "O")
            {
                btns[c].IsEnabled = false;
            }
            return c;
        }
        private void checkWin()
        {
            if ((b7.Content == "X" && b8.Content == "X" && b9.Content == "X"))
            {
                label.Content = "Победил X";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b6.Content == "X" && b5.Content == "X" && b4.Content == "X")
            {
                label.Content = "Победил X";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b1.Content == "X" && b2.Content == "X" && b3.Content == "X")
            {
                label.Content = "Победил X";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b1.Content == "X" && b4.Content == "X" && b7.Content == "X")
            {
                label.Content = "Победил X";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b2.Content == "X" && b5.Content == "X" && b8.Content == "X")
            {
                label.Content = "Победил X";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b3.Content == "X" && b6.Content == "X" && b9.Content == "X")
            {
                label.Content = "Победил X";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }

            else
            if (b7.Content == "O" && b8.Content == "O" && b9.Content == "O")
            {
                label.Content = "Победил O";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b6.Content == "O" && b5.Content == "O" && b4.Content == "O")
            {
                label.Content = "Победил O";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b1.Content == "O" && b2.Content == "O" && b3.Content == "O")
            {
                label.Content = "Победил O";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b1.Content == "O" && b4.Content == "O" && b7.Content == "O")
            {
                label.Content = "Победил O";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b2.Content == "O" && b5.Content == "O" && b8.Content == "O")
            {
                label.Content = "Победил O";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b3.Content == "O" && b6.Content == "O" && b9.Content == "O")
            {
                label.Content = "Победил O";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            //Накрест
            if (b1.Content == "O" && b5.Content == "O" && b9.Content == "O")
            {
                label.Content = "Победил O";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b3.Content == "O" && b5.Content == "O" && b7.Content == "O")
            {
                label.Content = "Победил O";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b1.Content == "X" && b5.Content == "X" && b9.Content == "X")
            {
                label.Content = "Победил X";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }
            else if (b3.Content == "X" && b5.Content == "X" && b7.Content == "X")
            {
                label.Content = "Победил X";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }


            else if (b1.Content != "" && b2.Content != "" && b3.Content != "" && b4.Content != "" && b5.Content != "" && b6.Content != "" && b7.Content != "" && b8.Content != "" && b9.Content != "")
            {
                label.Content = "Ничья";
                b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            }

        }

        private void Re_Start_Click(object sender, RoutedEventArgs e)
        {
            b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = false;
            b1.Content = b2.Content = b3.Content = b4.Content = b5.Content = b6.Content = b7.Content = b8.Content = b9.Content = "";
            b1.IsEnabled = b2.IsEnabled = b3.IsEnabled = b4.IsEnabled = b5.IsEnabled = b6.IsEnabled = b7.IsEnabled = b8.IsEnabled = b9.IsEnabled = true;
        }
    }
}