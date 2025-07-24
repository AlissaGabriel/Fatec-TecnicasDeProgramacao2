using Exercício_5;

Aluno aluno1 = new(18);
Aluno aluno2 = new(20);
Aluno aluno3 = new(25);

Professor professor1 = new("João", "Engenharia de Software");
Professor professor2 = new("Maria", "Administração de Banco de Dados");
Professor professor3 = new("Pedro", "Desenvolvimento Mobile");

Curso curso1 = new("DSM", "36 Meses", professor1);
Curso curso2 = new("ADS", "12 Meses", professor2);
Curso curso3 = new("Jogos Digitais", "24 Meses", professor3);

Matricula matricula1 = new(aluno1, curso1, new DateTime(2024, 3, 24, 15, 30, 0));
Matricula matricula2 = new(aluno2, curso2, new DateTime(2024, 2, 12, 14, 20, 0));
Matricula matricula3 = new(aluno3, curso3, new DateTime(2024, 5, 24, 10, 40, 0));

Console.WriteLine("Exibindo a matricula 1: ");
matricula1.ExibirMatricula();
Console.WriteLine("\nExibindo a matricula 2: ");
matricula2.ExibirMatricula();
Console.WriteLine("\nExibindo a matricula 3: ");
matricula3.ExibirMatricula();