using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    internal class Disciplina
    {
        public Disciplina(string nome, string professor, string duracao) 
        {
            Nome = nome;
            Professor = professor;
            Duracao = duracao;
            Matriculas = new List<Matricula>();
        }
        public string Nome { get; set; }
        public string Professor { get; set; }
        public string Duracao { get; set; }
        public List<Matricula> Matriculas { get; set; }

        public void ListarAlunos()
        {
            Console.WriteLine($"Alunos na Disciplina {Nome}");
            foreach (var matricula in Matriculas)
            {
                Console.WriteLine($"Nome do aluno: {matricula.Aluno.Nome}\nIdade do Aluno: {matricula.Aluno.Idade}\nData da Matrícula: {matricula.DataMatricula}\n");
            }
        }
    }
}
