
try
{
    Console.WriteLine("Insira um número: ");
    int numero = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a posição que vai inserir o número (0 a 9): ");
    int posicao = int.Parse(Console.ReadLine());

    int[] numeros = new int[10];
    numeros[posicao] = numero;
    Console.WriteLine($"Número {numero} na posição {posicao}");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("Posição inválida");
}