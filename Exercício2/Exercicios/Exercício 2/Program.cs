
while (true) {
    try
    {
        Console.WriteLine("Digite um número inteiro: ");
        var numero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"O número que você digitou foi: {numero}");
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("Entre com um valor inteiro");
    }
    finally
    {
        Console.WriteLine("Finalizado");
    }
}
