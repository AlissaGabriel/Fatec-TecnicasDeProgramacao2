//Trabalhando Arquivos

//Classe File -> Leitura e Gravação (métodos estáticos)
//Métodos: Create, Delete, Exists, Copy e Move
//ReadAllText - Abre e Lê todo conteúdo arquivo de texto
//ReadAllBytes - Lê conteúdo arquivo binário e retorna array bytes
//WriteAllText - Cria o arquivo e grava uma string em um arquivo texto e fecha o arquivo
//WriteAllBytes - Grava arquivo bytes em um arquivo binário
//AppendAllText - Abre o arquivo e anexa uma string e fecha o arquivo (se não existir, cria o arquivo)

//DirectoryNotFoundException - Caminho para "diretório não existe"
//EndOfStreamException - Final fluxo é alcançado prematuramente
//FileNotFound - Arquivo não encontrado
//PathTooLongException - Caminho excede o máximo permitido S.O
//UnauthorizedException - Acesso negado ao arquivo

var caminho = @"D:\Fatec\3 Semestre\Técnicas de Programação II\TrabalhandoComArquivos\ArquivoTexto.txt";
if (!File.Exists(caminho))
{
    try
    {
        //criou o arquivo e gravou o texto
        File.WriteAllText(caminho, "Autor Desconhecido\r\n");
        var texto = "Quem canta seus males espanta" + Environment.NewLine + "Água mole em pedra dura tanto bate até que fura";
        //abriu o arquivo e colocou o texto no final
        File.AppendAllText(caminho, texto);
        //ler o conteúdo do arquivo
        Console.WriteLine("\nConteúdo de Arquivo");
        string conteudo = File.ReadAllText(caminho);
        Console.WriteLine(conteudo);
        //outros métodos
        Console.WriteLine($"Última Modificação: {File.GetLastWriteTime(caminho)}");
        Console.WriteLine($"Último Acesso: {File.GetLastAccessTime(caminho)}");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}