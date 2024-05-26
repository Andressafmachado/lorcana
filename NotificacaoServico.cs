namespace boardGame;

public class ServicoDeNotificacao
{
    public void MostrarMensagem(string mensagem)
    {
        Console.WriteLine($"Mensagem: {mensagem}");
    }

    public void MostrarErro(string mensagem)
    {
        Console.WriteLine($"Erro: {mensagem}");
    }
}