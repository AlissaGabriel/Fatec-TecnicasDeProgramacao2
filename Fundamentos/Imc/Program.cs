//string? nome = ? : pode ser nulo
//int a ; int? x = null : a = x ?? 0; se x não for (??) null atribui o valor, se for null atribui 0
//string nome = "João"; string nome1; nome1 = nome ?? " ";

Console.WriteLine("Cálculo IMC");

Console.WriteLine("Digite o seu nome: ");
string? nome = Console.ReadLine();

Console.WriteLine("Digite o seu peso: ");
double peso = Convert.ToDouble(Console.ReadLine()); //implicitamente = próprio console

Console.WriteLine("Digite a sua altura: ");
double altura = double.Parse(Console.ReadLine());

double imc = peso / Math.Pow(altura, 2);

Console.WriteLine($"{nome} o seu imc é igual a: {imc}");

if (imc < 18.5)
{
    Console.WriteLine("Baixo Peso");
}
else if (imc > 18.5 && imc <= 24.9)
{
    Console.WriteLine("Peso Normal");
}
else if (imc > 25 && imc <= 29.9)
{
    Console.WriteLine("Excesso de peso");
}
else if (imc > 30 && imc <= 34.9)
{
    Console.WriteLine("Obesidade Classe 1");
}
else if (imc > 35 && imc <= 39.9)
{
    Console.WriteLine("Obesidade Classe 2");
}
else if (imc >= 40)
{
    Console.WriteLine("Obesidade Classe 3");
}