//Trabalhando Arquivos - Stream

//Liberação Recursos Alocados: Close(Manualmente) ou Using(libera automaticamente)
//Stream - Classe - abstrata (base)
//FileStream, MemoryStream, BufferedStream, PepeStream e CryptoStream
//Classes Auxiliares - StreamReader e StreamWriter
//Sintaxe: 
//FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.Read, FileShare.Read);
//FileMode(Append, Create, CreateNew, Open, OpenOrCreate, Truncate)
//FileAcces(Read, ReadWrite, Write)
//FileShare(Delete, None, Read, ReadWrite, Write)


var caminho = @"D:\Fatec\3 Semestre\Técnicas de Programação II\TrabalhandoComArquivos\ArquivoTexto.txt";

try
{
    using (FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.Read))
    {
        using (StreamReader leitor = new StreamReader(fs)) 
        {
            string? linha;
            while ((linha = leitor.ReadLine()) != null)
            {
                Console.WriteLine(linha);
            }
        }
    }  
}
catch (IOException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}