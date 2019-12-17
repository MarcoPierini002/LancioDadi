using System;
using System.Collections.Generic;
using System.Linq;
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

namespace LancioDadiWpf
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        

        private void Btn_LancioDadi_Click(object sender, RoutedEventArgs e)
        {
            var PrimoDado = Task.Factory.StartNew(Lancio);
            var SecondoDado = Task.Factory.StartNew(Lancio);
            var somma = Dispatcher.Invoke(() => Somma(PrimoDado.Result, SecondoDado.Result));

            Lbl_risultato.Content = $"la somma è {somma}";
        }

        public int Lancio()
        {
            int dado = rnd.Next(1, 7);
            return dado;
        }

        private static int Somma(int PrimoDado, int SecondoDado)
        {
            return PrimoDado + SecondoDado;
        }
    }
}
