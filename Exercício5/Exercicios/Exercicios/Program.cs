
//soma
Operacao del1 = new Operacao(Soma); 
del1.Invoke(1, 2);

Operacao del2 = new Operacao(Subtrair);
del2.Invoke(1, 2);

Operacao del3 = new Operacao(Dividir);
del3.Invoke(1, 2);

Operacao del4 = new Operacao(Multiplicar);
del4.Invoke(1, 2);

static void Soma(double num1, double num2)
{
    double num3 = num1 + num2;
    Console.WriteLine($"O resultado da soma é: {num3}");
}

static void Subtrair(double num1, double num2)
{
    double num3 = num1 - num2;
    Console.WriteLine($"O resultado da subtração é: {num3}");
}

static void Dividir(double num1, double num2)
{
    double num3 = num1 / num2;
    Console.WriteLine($"O resultado da divisão é: {num3}");
}
static void Multiplicar(double num1, double num2)
{
    double num3 = num1 * num2;
    Console.WriteLine($"O resultado da multiplicação é: {num3}");
}

Console.ReadKey();

public delegate void Operacao(double numero1, double numero2);


