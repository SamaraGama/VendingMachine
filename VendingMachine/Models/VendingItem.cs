using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    class VendingItem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public VendingItem(int id, string nome, double valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }
    }
}
