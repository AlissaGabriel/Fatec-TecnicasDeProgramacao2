using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_5
{
    internal class Curso
    {
        public Curso(string nome, string duracao, Professor professorResponsavel)
        {
            Nome = nome;
            Duracao = duracao;
            Professor = professorResponsavel;
        }
            public string Nome { get; set; }
            public string Duracao { get; set; }
            public Professor Professor { get; set; }
        
    }
}
