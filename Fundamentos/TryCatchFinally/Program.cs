//Tratamento de Exceção
//exceção é uma condição de erro ou um comportamento inesperado em um código.
//ArgumentException() = argumento inválido
//NullReferenceException() = referência nula
//FormatException() = formatação inválida
//OverFlowException() = excedeu a capacidade
//FileNotFound() = arquivo não localizado
//try/catch/finally
//throw
//Personalizado = derivar Exception, ter Exception no nome, implementar 3 construtores

try
{
    Console.WriteLine("Digite um número inteiro: ");
    var dividendo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Digite um número inteiro: ");
    var divisor = Convert.ToInt32(Console.ReadLine());
    int resultado = dividendo / divisor;
    Console.WriteLine("Resultado: ");
    Console.WriteLine(resultado);
}
catch (FormatException)
{
    Console.WriteLine("Entre com um valor inteiro");
}
catch (OverflowException)
{
    Console.WriteLine("O número inteiro excedeu a capacidade");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Não pode dividir um número por zero");
}
catch (Exception ex)
{
    Console.WriteLine("Algo deu errado" + ex.Message);
}
finally
{
    Console.WriteLine("Finalizado");
}