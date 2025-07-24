using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_5
{
    internal class Professor
    {
        public Professor(string nome, string especializacao) {
            Nome = nome;
            Especializacao = especializacao;
        }

        public string Nome { get; set; }
        public string Especializacao { get; set; }
    }
}
