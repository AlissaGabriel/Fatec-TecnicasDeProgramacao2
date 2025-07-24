
using System.Globalization;

while (true)
{
    try
    {
     
        Console.WriteLine("Insira uma data no formato 'dd/MM/yyyy': ");
        var data = Convert.ToString(Console.ReadLine());
        DateTime dataConvertida;
        string formato = "dd/MM/yyyy";
        dataConvertida = DateTime.ParseExact(data, formato, CultureInfo.InvariantCulture);
        Console.WriteLine($"A data que você digitou foi: {data}");
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("Formato de data inválido");
    }
    finally
    {
        Console.WriteLine("Finalizado");
    }
}
