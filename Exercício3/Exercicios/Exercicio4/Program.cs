using Exercicio4;

Aluno aluno1 = new("João", 19);
Aluno aluno2 = new("Maria", 20);

Disciplina disciplina1 = new("Técnicas de Programação", "Flavia", "6 meses");
Disciplina disciplina2 = new("Desenvolvimento Web", "Pedro", "6 meses");

Matricula matricula1 = new(aluno1, disciplina1, new DateTime(2024, 3, 16, 7, 30, 0));
Matricula matricula2 = new(aluno2, disciplina2, new DateTime(2025, 3, 20, 16, 30, 0));
Matricula matricula3 = new(aluno1, disciplina2, DateTime.Now);

Console.WriteLine("Exibindo a matricula 1: ");
matricula1.ExibirMatricula();
Console.WriteLine("\nExibindo a matricula 2: ");
matricula2.ExibirMatricula();
Console.WriteLine("\nExibindo a matricula 3: ");
matricula3.ExibirMatricula();

Console.WriteLine("\nExibindo todas as disciplinas de João:\n");
aluno1.ListarDisciplinas();

Console.WriteLine("\nExibindo todos os alunos da disciplina Desenvolvimento Web:\n");
disciplina2.ListarAlunos();
