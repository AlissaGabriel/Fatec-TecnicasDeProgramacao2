using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_6
{
    public class Hospital
    {
        public class Pessoa
        {
            public Pessoa(string nome, int idade)
            {
                Nome = nome;
                Idade = idade;
            }

            public string Nome { get; set; }
            public int Idade { get; set; }
        }
        public class Medico : Pessoa
        {
            public Medico(string Nome, int Idade, string especialidade, int crm) : base(Nome, Idade)
            {
                Especialidade = especialidade;
                Crm = crm;
            }
            public string Especialidade { get; set; }
            public int Crm { get; set; }
        }

        public class Paciente : Pessoa
        {
            public Paciente(string Nome, int Idade, string historico) : base(Nome, Idade)
            {
                Historico = historico;
            }
            public string Historico { get; set; }
        }
    }
}
