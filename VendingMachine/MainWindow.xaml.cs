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
using VendingMachine.ViewModels;

namespace VendingMachine
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private MaquinaViewModel _maquina = new MaquinaViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _maquina;
        }
        private void Comprar_Clicado(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _maquina.Comprar(button.DataContext);
        }
        private void Inserir_025_Clicked(object sender, RoutedEventArgs e)
        {
            _maquina.Inserir(0.25);
        }
        private void Inserir_050_Clicked(object sender, RoutedEventArgs e)
        {
            _maquina.Inserir(0.50);
        }
        private void Inserir_100_Clicked(object sender, RoutedEventArgs e)
        {
            _maquina.Inserir(1.00);
        }
        private void Reabastecer_Clicado(object sender, RoutedEventArgs e)
        {
            _maquina.Reabastecer();
        }
        private void Esvaziar_Clicado(object sender, RoutedEventArgs e)
        {
            _maquina.Esvaziar();
        }
        private void Sacar_Clicado(object sender, RoutedEventArgs e)
        {
            _maquina.SacarTotalDepositado();
        }
    }
}
