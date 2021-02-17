using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    class ProdutoViewModel : ObjetoObs
    {
        //modelo representado pelo view model
        private VendingItem _model;
        //qunatidade máx de itens permitidos nesse view model
        private const int _maxQtd = 10;
        //quantidade atual de itens nesse view model
        private int _qtd;

        public int Id 
        {
            get 
            {
                return _model.Id;
            }
        }
        public int Qtd
        {
            get
            {
                return _qtd;
            }
            private set 
            {
                _qtd = value;
                OnPropertyChanged("MsgForaDeEstoque");
                OnPropertyChanged("EstoqueDisplay");
                OnPropertyChanged("Qtd");
            }
        }
        //msg formatada para display de nome e quantidade de itens
        //ex.: "Água Engarrafada: 10"
        public string EstoqueDisplay 
        { get 
            {
                return $"{_model.Nome}: {_qtd}";
            }
        }
        //retorna uma cópia dos valores desse modelo
        public VendingItem Info 
        { 
            get
            {
                return _model;
            }
        }
        //Determina se há necessidade de exibir msg "Fora de Estoque."
        public Visibility MsgForaDeEstoque 
        { 
            get 
            {
                if (Qtd > 0)
                {
                    return Visibility.Hidden;
                }
                return Visibility.Visible;
            } 
        }
        public ProdutoViewModel(int id, string nome, double valor)
        {
            _model = new VendingItem(id, nome, valor);
            Qtd = 0;
        }
        public int Reabastecer()
        {
            var totalAbastecer = _maxQtd - Qtd;
            Qtd += totalAbastecer;
            return totalAbastecer;
        }
        public int Esvaziar()
        {
            var totalEsvaziar = Qtd;
            Qtd = 0;
            return totalEsvaziar;
        }
        public bool Dispensar()
        {
            if (Qtd > 0) 
            {
                Qtd-= 1;
                return true;
            }
            return false;
        }

    }
}
