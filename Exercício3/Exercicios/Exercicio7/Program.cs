Console.WriteLine("Cálculo de Duas Notas");


try
{
    Console.WriteLine("Digite a primeira nota: ");
    double nota1 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Digite a segunda nota: ");
    double nota2 = Convert.ToDouble(Console.ReadLine());

    //int quantidadeProvas = 0;
    int quantidadeProvas = 2;

    if (quantidadeProvas == 0)
    {
        throw new DivideByZeroException("A quantidade de provas não pode ser zero.");
    }

    double media = (nota1 + nota2) / quantidadeProvas;
    Console.WriteLine($"A média do aluno é {media:F2}");
}
catch (FormatException)
{
    Console.WriteLine("Erro: Você deve digitar um número válido.");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
}
 

