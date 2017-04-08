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

namespace Tic_tac_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public byte step = 0;
        public MainWindow()
        {
            InitializeComponent();
            NulableCell();
        }

        void NulableCell()
        {
            cell1.Content = null;
            cell2.Content = null;
            cell3.Content = null;
            cell4.Content = null;
            cell5.Content = null;
            cell6.Content = null;
            cell7.Content = null;
            cell8.Content = null;
            cell9.Content = null;
            current_s.Content = "X";
            step = 0;
        }

         void GameLogic()
        {
            if (cell1.Content == cell2.Content && cell2.Content == cell3.Content && cell3.Content != null ||
                cell4.Content == cell5.Content && cell5.Content == cell6.Content && cell6.Content != null ||
                cell7.Content == cell8.Content && cell8.Content == cell9.Content && cell9.Content != null ||

                cell1.Content == cell5.Content && cell5.Content == cell9.Content && cell9.Content != null ||
                cell7.Content == cell5.Content && cell5.Content == cell3.Content && cell3.Content != null ||

                cell1.Content == cell4.Content && cell4.Content == cell7.Content && cell7.Content != null ||
                cell2.Content == cell5.Content && cell5.Content == cell8.Content && cell8.Content != null ||
                cell3.Content == cell6.Content && cell6.Content == cell9.Content && cell9.Content != null
            )
            {
                var win = current_s.Content = current_s.Content.ToString() == "O" ? "X" : "O";
                var a =  MessageBox.Show($"Победитель: {win}, Продолжить?", "Поздравляем, победа, продолжить?", MessageBoxButton.OKCancel,MessageBoxImage.Information);
                if (a == MessageBoxResult.Cancel)
                {
                    this.Close();
                }
                else
                {
                    NulableCell();
                }
            }
            else if (step >= 9)
            {
                var a = MessageBox.Show("Ничья, Продолжить?", "Ничья, продолжить?", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (a == MessageBoxResult.Cancel)
                {
                    this.Close();
                }
                else
                {
                    NulableCell();
                }
            }
            
            
        }

        private void Cell1_OnClick(object sender, RoutedEventArgs e)
        {
            var s = sender as Button;
            
            if (s.Content == null)
            {
                if (current_s.Content.ToString() == "O")
                {
                    s.Content = current_s.Content;
                    current_s.Content = "X";
                }
                else
                {
                    s.Content = current_s.Content;
                    current_s.Content = "O";
                }
                step++;
               
            }

            GameLogic();

        }

        private void BtnRestart_OnClick(object sender, RoutedEventArgs e)
        {
            NulableCell();
        }

        private void Current_s_OnClick(object sender, RoutedEventArgs e)
        {
            if (step == 0)
            {
                current_s.Content = current_s.Content.ToString() == "O" ? "X" : "O";
            }
            
        }
    }
}
