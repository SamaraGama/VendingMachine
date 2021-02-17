using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.ViewModels
{
    class VendingTransacoesViewModel : ObjetoObs
    {
        //Info apresentada ao cliente
        private double _total;
        private double _inserido;
        private double _troco;

        //Info da máquina
        private double _totalDepositado;

        public double Total 
        { 
            get 
            {
                return _total;
            } 
            set 
            {
                _total = value;
                OnPropertyChanged("Total");
            } 
        }
        public double Inserido
        {
            get
            {
                return _inserido;
            }
            set
            {
                _inserido = value;
                OnPropertyChanged("Inserido");
            }
        }
        public double Troco
        {
            get
            {
                return _troco;
            }
            set
            {
                _troco = value;
                OnPropertyChanged("Troco");
            }
        }
        public double TotalDepositado
        {
            get
            {
                return _totalDepositado;
            }
            set
            {
                _totalDepositado = value;
                OnPropertyChanged("TotalDepositado");
            }
        }
        public VendingTransacoesViewModel()
        {
            Total = 0;
            Inserido = 0;
            Troco = 0;
            TotalDepositado = 0;
        }

        //Inserir dinheiro
        public void Inserir(double valor)
        {
            Inserido += valor;
        }
        //Setar valor total do item pedido
        public void ValorSelecionado(double valor)
        {
            Total = valor;
        }
        //Confirmar pagamento
        public bool ConfirmarPagamento()
        {
            if (Inserido >= Total)
            {
                return true;
            }
            return false;
        }
        //Finalizar pagamento
        public void Pagar()
        {
            Troco = Total - Inserido;
            TotalDepositado += Total;
            Inserido = 0;
            Total = 0;
        }
        public void SacarTotalDepositado()
        {
            Console.WriteLine($"Saque de {TotalDepositado} feito com sucesso.");
            TotalDepositado = 0;
        }
    }
}
