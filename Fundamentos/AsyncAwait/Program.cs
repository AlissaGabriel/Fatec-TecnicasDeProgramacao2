//Programação Assíncrona
//-permite que o aplicativo execute várias tarefas ao mesmo tempo;
//-utiliza - se async / await;
//-evita o bloqueio da thread principal;
//-thread se refere a uma linha de execução, onde multiplas operações podem ocorrer simultaneamente sem bloquear o fluxo principal;
//-async = indica que o método pode ser executado de forma assíncrona;
//-await = utiliza - se para esperar a conclusão de uma tarefa assíncrona;
//-na programação síncrona as tarefas são executadas de forma sequencial.
//task = não retorno
//task<T> = retorna a tarefa com o tipo definido
//T = tipo - int, float, objeto
Console.WriteLine("Café da Manhã Síncrono");
CafeDaManha();
Console.WriteLine("\nCafé da Manhã Assíncrono");
CafeDaManhaAsync();
Console.ReadKey();

//método CafeDaManha
//assincrono
static async void CafeDaManhaAsync()
{
    Console.WriteLine("Preparar o café da manhã");
    var TarefaCafe = PrepararCafeAsync();
    var TarefaPao = PrepararPaoAsync();
    var cafe = await TarefaCafe;
    var pao = await TarefaPao;
    ServirCafeManhaAsync(cafe, pao);
}

static async Task<Cafe> PrepararCafeAsync()
{
    Console.WriteLine("Fervendo a água");
    await Task.Delay(2000);
    Console.WriteLine("Coando o café");
    await Task.Delay(3000);
    Console.WriteLine("Adoçando o café");
    await Task.Delay(2000);
    return new Cafe();
}

static async Task<Pao> PrepararPaoAsync()
{
    Console.WriteLine("Cortando o pão");
    await Task.Delay(2000);
    Console.WriteLine("Passando manteiga");
    await Task.Delay(3000);
    Console.WriteLine("Tostando o pão");
    await Task.Delay(2000);
    return new Pao();
}

static async void ServirCafeManhaAsync(Cafe cafe, Pao pao)
{
    Console.WriteLine("Servindo o café da manhã");
    await Task.Delay(2000);
    Console.WriteLine("Café Servido");

}


//sincrono

static void CafeDaManha()
{
    Console.WriteLine("Preparar o café da manhã");
    var cafe = PrepararCafe();
    var pao = PrepararPao();
    ServirCafeManha(cafe, pao);
}

static Cafe PrepararCafe()
{
    Console.WriteLine("Fervendo a água");
    Thread.Sleep(2000);
    Console.WriteLine("Coando o café");
    Thread.Sleep(3000);
    Console.WriteLine("Adoçando o café");
    Thread.Sleep(2000);
    return new Cafe();
}

static Pao PrepararPao()
{
    Console.WriteLine("Cortando o pão");
    Thread.Sleep(2000);
    Console.WriteLine("Passando manteiga");
    Thread.Sleep(3000);
    Console.WriteLine("Tostando o pão");
    Thread.Sleep(2000);
    return new Pao();
}

static void ServirCafeManha(Cafe cafe, Pao pao)
{
    Console.WriteLine("Servindo o café da manhã");
    Thread.Sleep(2000);
    Console.WriteLine("Café Servido");

}

internal class Cafe
{
    public Cafe() { }
}

internal class Pao
{
    public Pao() { }
}

