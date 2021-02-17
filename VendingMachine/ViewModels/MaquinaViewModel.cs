using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.ViewModels
{
    class MaquinaViewModel : ObjetoObs
    {
        public ObservableCollection<ProdutoViewModel> Items { get; private set; }
        public VendingTransacoesViewModel Transacoes { get; private set; }

        public MaquinaViewModel()
        {
            Transacoes = new VendingTransacoesViewModel();
            Items = new ObservableCollection<ProdutoViewModel>()
            {
                new ProdutoViewModel(1, "Água Engarrafada", 2.50),
                new ProdutoViewModel(2, "Chá Gelado", 3.50),
                new ProdutoViewModel(3, "Coca-Cola", 4.75),
                new ProdutoViewModel(4, "Pepsi", 4.25),
                new ProdutoViewModel(5, "Fanta Laranja", 3.50),
                new ProdutoViewModel(6, "Sprite", 4.00),
            };
        }

        public void Comprar(object item)
        {
            var ProdutoPedido = item as ProdutoViewModel;
            Transacoes.ValorSelecionado(ProdutoPedido.Info.Valor);

            if (Transacoes.ConfirmarPagamento())
            {
                if (ProdutoPedido.Dispensar())
                {
                    Transacoes.Pagar();
                    Console.WriteLine("Aproveite sua bebida!");
                }
            }
        }
        public void Inserir(double valor)
        {
            Transacoes.Inserir(valor);
        }
        public void SacarTotalDepositado()
        {
            Transacoes.SacarTotalDepositado();
        }
        //Reabastecer todos os itens do estoque
        public void Reabastecer() 
        {
            foreach (var item in Items)
            {
                item.Reabastecer();
            }
            Console.WriteLine("O estoque da máquina foi reabastecido.");
        }
        //Esvaziar todo o estoque
        public void Esvaziar()
        {
            foreach(var item in Items)
            {
                item.Esvaziar();
            }
            Console.WriteLine("O estoque da máquina foi esvaziado.");
        }
    }
}
