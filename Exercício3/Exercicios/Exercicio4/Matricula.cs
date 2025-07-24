using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    internal class Matricula
    {
        public Matricula(Aluno aluno, Disciplina disciplina, DateTime dataMatricula)
        {
            Aluno = aluno;
            Disciplina = disciplina;
            DataMatricula = dataMatricula;

            //associa a matrícula ao aluno e à disciplina
            aluno.Matriculas.Add(this);
            disciplina.Matriculas.Add(this);
        }

        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime DataMatricula { get; set; }

        public void ExibirMatricula()
        {
            Console.WriteLine($"Nome do Aluno: {Aluno.Nome}\nIdade do Aluno: {Aluno.Idade}\nNome da Disciplina: {Disciplina.Nome}\nDuração da Disciplina: {Disciplina.Duracao}\nProfessor Responsável pela Disciplina: {Disciplina.Professor}\nData da Matricula: {DataMatricula}");
        }
    }
}
