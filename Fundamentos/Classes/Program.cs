//classe que pode ser utilizada somente dentro do projeto (internal)
//classe que pode ser utilizada fora do projeto (public)
//void = sem retorno
//sem referência = faz uma cópia e não muda o valor
//com referência = modifica a variável

int x = 10;
int y = 20;

int w = 30;
int z = 20;

//var conta = new Matematica();
//Matematica conta = new Matematica();
Matematica conta = new ();

Console.WriteLine($"valor de x: {x}\nvalor de y: {y}\n");
conta.soma(x, y);

Console.WriteLine($"valor de w: {w}\nvalor de z: {z}\n");
conta.subtracao(ref w, ref z);

Console.WriteLine($"valor de w com ref: {w}\nvalor de z com ref: {z}\n");

Console.WriteLine("Nova subtração com os novos valores: ");
conta.subtracao(ref w, ref z);

public class Matematica 
{
    //métodos
    public void soma(int numero1, int numero2)
    {
        Console.WriteLine($"Soma = {numero1 + numero2}\n");
        numero1 = 100;
        numero2 = 50;
    }

    public void soma(int numero1, int numero2, int numero3)
    {
        Console.WriteLine($"soma = {numero1 + numero2 + numero3}");
    }

    public void soma(double numero1, int numero2)
    {
        Console.WriteLine($"soma = {numero1 + numero2}");
    }

    public void soma(int numero1, double numero2)
    {
        Console.WriteLine($"soma = {numero1 + numero2}");
    }

    public void subtracao(ref int numero1, ref int numero2)
    {
       Console.WriteLine($"Subtração = {numero1 - numero2}\n");
        numero1 = 100;
        numero2 = 50;
    }
}