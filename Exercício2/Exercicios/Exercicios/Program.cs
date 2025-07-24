try
{
    string caminhoArquivo = "D:\\Fatec\\3 Semestre\\Técnicas De Programação II\\Exercicios\\a.txt";
    string conteudo = File.ReadAllText(caminhoArquivo);
    Console.WriteLine(conteudo);
}
catch (FileNotFoundException)
{
    Console.WriteLine("Arquivo não existe");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Programa não tem permissão para acessar o arquivo");
}
catch (Exception ex)
{
    Console.WriteLine("Algo deu errado" + ex.Message);
}
finally
{
    Console.WriteLine("Finalizado");
}