Aluno aluno1 = new(new DateTime(2024, 3, 16, 7, 30, 0), "João", 19);
Aluno aluno2 = new(new DateTime(2025, 4, 20, 16, 40, 0), "Maria", 20);
Aluno aluno3 = new(new DateTime(2023, 5, 07, 15, 20, 0), "Márcia", 23);

Professor professor1 = new("Técnicas de Programação", "Lúcio", 40);
professor1.Aluno[0] = aluno1;
professor1.Aluno[1] = aluno2;
professor1.Aluno[2] = aluno3;

Console.WriteLine("Detalhes: ");
professor1.mostrar();

public class Pessoa
{
    public Pessoa(string? nome, int? idade)
    {
        Nome = nome;
        Idade = idade;
    }
    public string? Nome { get; set; }
    public int? Idade { get; set; }
}

public class Aluno : Pessoa
{
    public Aluno(DateTime dataMatricula, string? nome, int? idade) : base(nome, idade)
    {
        DataMatricula = dataMatricula;
    }
    public DateTime DataMatricula { get; set; }
}
public class Professor : Pessoa
{
    public Professor(string disciplina, string? nome, int? idade) : base(nome, idade)
    {
        Disciplina = disciplina;
        Aluno = new Aluno[3];
    }
    public string Disciplina { get; set; }
    public Aluno[] Aluno { get; set; }

    public void mostrar()
    {
        Console.WriteLine($"Professor: {Nome}\nIdade: {Idade}\nDisciplina: {Disciplina}\n");
        Console.WriteLine("Alunos");
        for (int i = 0; i < Aluno.Length; i++)
        {
            if (Aluno[i] != null)
            {
                Console.WriteLine($"Nome: {Aluno[i].Nome}\nIdade: {Aluno[i].Idade}\nMatrícula: {Aluno[i].DataMatricula}\n");
            }
            else
            {
                Console.WriteLine("Faltam alunos!");
            }
        }
    }
}
