double[,] notas = new double[3, 3];

for(int i = 0; i < 3; i++)
{
    Console.WriteLine($"\nDigite as notas do aluno {i+1}: ");
    for(int j = 0; j < 3; j++)
    {
        Console.WriteLine($"Nota da matéria {j+1}: ");
        notas[i, j] = Convert.ToDouble(Console.ReadLine() );
    }
}

Console.WriteLine("Notas dos alunos: ");
for(int i = 0;i < 3; i++)
{
    Console.WriteLine($"\nAluno {i+1}: ");
    for (int j = 0; j < 3; j++)
    {
        Console.WriteLine($"Matéria {j+1}: {notas[i,j]}");
    }
}

for(int i = 0; i < 3 ; i++)
{
    double soma = 0;
    for (int j = 0;j < 3; j++)
    {
        soma += notas[i, j];
    }
    double media = soma / 3;
    Console.WriteLine($"\nA média do aluno {i+1} é: {media:F2}");
}