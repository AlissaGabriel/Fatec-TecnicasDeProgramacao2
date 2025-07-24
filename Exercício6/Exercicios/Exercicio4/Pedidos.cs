using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
     class Pedidos
    {
        public Pedidos(int quantidade, DateTime? dataPedido, List<Produto>? produto, Cliente? cliente)
        {
            Quantidade = quantidade;
            DataPedido = dataPedido;
            Produto = produto;
            Cliente = cliente;
        }

        public int Quantidade { get; set; }
        public DateTime? DataPedido {  get; set; }
        public List<Produto>? Produto { get; set; }
        public Cliente? Cliente { get; set; }



        public double CalcularTotal()
        {
            double total = 0;
            if(Produto != null)
            {
                foreach (var produto in Produto)
                {
                    total += produto.Preco * Quantidade;
                }
            }
            return total;
        }
    }
}
