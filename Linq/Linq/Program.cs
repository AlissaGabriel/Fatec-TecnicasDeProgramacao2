//Linq - Language Integrated Query
//Funcionalidades que permite escrever consultas diretamente em C#;
//Trabalha com coleções de dados (list, array, banco de dados, xml, etc);
//É parecida com SQL, mas diretamente no código;
//As coleções de dados devem implementar IEnumerable ou IQueryable;
//Alguns métodos:
//Where(), Select(), OrderBy(), First(), Join(), GroupBy();

int[] numeros = { 1, 2, 3, 4, 5, 6 };
//sintaxe de query
var pares = from n in numeros 
            where n % 2 == 0 
            select n;
//sintaxe de método
var pares1 = numeros.Where(n => n % 2 == 0);

Console.WriteLine("Números divisiveis por 2: ");
foreach (var par in pares)
{
    Console.WriteLine(par);
}

List<string> nomes = new List<string>()
{
    "Ana", "Maria", "Pedro", "Lais", "Vitor"
};

var resultado = from n in nomes
                where n.Contains('o')
                select n;

var resultado1 = nomes.Where(n=>n.Contains('a'));

Console.WriteLine("Possuem a letra 'o' no nome: ");
foreach(var nome in resultado)
{
    Console.WriteLine(nome);
}
Console.ReadKey();

