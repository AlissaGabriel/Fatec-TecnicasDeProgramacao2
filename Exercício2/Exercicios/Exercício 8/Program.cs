Console.WriteLine("\nBaixando arquivos assíncrono");
ArquivosAsync();
Console.ReadKey();

static async void ArquivosAsync()
{
    Console.WriteLine("\nBaixando Arquivos e Escovando o Dente");
    var TarefaDownload = BaixarArquivoAsync();
    var TarefaEscovar = EscovarDenteAsync();
    var baixar = await TarefaDownload;
    var escovar = await TarefaEscovar;
    DownloadArquivosAsync(baixar, escovar);
}

static async Task<Baixar> BaixarArquivoAsync()
{
    Console.WriteLine("Procurando o arquivo");
    await Task.Delay(2000);
    Console.WriteLine("Iniciando o download do arquivo");
    await Task.Delay(3000);
    Console.WriteLine("Download quase terminado");
    await Task.Delay(2000);
    return new Baixar();
}

static async Task<EscovarDente> EscovarDenteAsync()
{
    Console.WriteLine("Colocando a pasta na escova");
    await Task.Delay(2000);
    Console.WriteLine("Escovando o dente");
    await Task.Delay(3000);
    Console.WriteLine("Enxaguando a boca");
    await Task.Delay(2000);
    return new EscovarDente();
}

static async void DownloadArquivosAsync(Baixar baixar, EscovarDente escovar)
{
    Console.WriteLine("Download finalizado");
    await Task.Delay(2000);
    Console.WriteLine("Abrindo o arquivo");

}
internal class Baixar
{
    public Baixar() { }
}

internal class EscovarDente
{
    public EscovarDente() { }
}

