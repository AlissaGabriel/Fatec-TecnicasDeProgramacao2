//declaração
//tipo[,] nomes;
//tipo[, ,] nomes;
//int[3,3] numeros;
//int[,] numeros = new int[3,3];
//int[,] numeros = new int[2,2]{{1,2}, {3,4}};
//int[,] numeros = {{1,2}, {3,4}}
//nome_matriz.GetLength(0) -> número de linhas
//nome_matriz.GetLength(1) -> número de linhas

int[,] numeros = new int[2, 2] { { 1, 2 }, { 3, 4 } };

foreach (var numero in numeros)
{
    Console.WriteLine(numero);
}
Console.WriteLine();

for(var linha=0; linha<numeros.GetLength(0); linha++)
{
    for(var coluna=0;  coluna<numeros.GetLength(1); coluna++)
    {
        Console.WriteLine(numeros[linha,coluna]);
    }
}