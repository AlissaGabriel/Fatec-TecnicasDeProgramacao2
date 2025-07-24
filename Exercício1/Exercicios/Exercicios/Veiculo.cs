using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Veiculo
    {
        public Veiculo(string placa)
        {
            Placa = placa;
        }

        private string marca = "Chevrolet";
        public string Marca
        {
            get { return marca; }

        }

        protected string? pla;
        public string Placa
        {
            set { pla = value; }
        }

        public static void ExibirInformacoes(Veiculo veiculo)
        {
            Console.WriteLine($"Marca: {veiculo.marca}\nPlaca: {veiculo.pla}");
        }
    }
    public class Carro : Veiculo
    {
        public Carro(string Placa, int portas) : base(Placa)
        {
            Portas = portas;
        }

        public int Portas { get; set; }

        // public void Exibir() //sem ser estático = chama pelo objeto
        //{
        //    Console.WriteLine($"Marca: {Marca}\nPlaca: {pla}\nNro de Portas: {Portas}");
        //}

        public static void Exibir(Carro carro1) //estático = chama pelo nome da classe
        {
            Console.WriteLine($"Marca: {carro1.Marca}\nPlaca: {carro1.pla}\nNro de Portas: {carro1.Portas}");
        }
    }

    public class Moto : Veiculo
    {
        public Moto(string Placa, string partida) : base(Placa)
        {
            Partida = partida;
        }

        public string Partida { get; set; }

        // public void Exibir() //sem ser estático = chama pelo objeto
        //{
        //    Console.WriteLine($"Marca: {Marca}\nPlaca: {pla}\nNro de Portas: {Portas}");
        //}

        public static void ExibirMoto(Moto moto1) //estático = chama pelo nome da classe
        {
            Console.WriteLine($"Marca: {moto1.Marca}\nPlaca: {moto1.pla}\nPartida Elétrica: {moto1.Partida}");
        }
    }

}
