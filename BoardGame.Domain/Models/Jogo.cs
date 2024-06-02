

namespace boardGame;

public class Jogo
{
    public int JogoId { get; set; }
    public List<Jogador> Jogadores { get; set; }
    public int TurnoId { get; set; }
    public List<Turno> Turnos { get; set; }
    public StatusDoJogo Status { get; set; }
    public Jogador JogadorNaVez { get; set; }

    // Context context = new Context();


    // private ServicoDeNotificacao _servicoDeNotificacao;

    // public Jogo()
    // {
    //     _servicoDeNotificacao = new ServicoDeNotificacao();
    // }

    public void SetUp(int[] jogadoresId)
    {
        var jogoId = PegarJogoId(CriarJogoNoBD());
        AdicionarJogadores(jogadoresId, jogoId);

        if (jogadoresId.Length > 4 || jogadoresId.Length < 2)
        {
            // _servicoDeNotificacao.MostrarErro("Para jogar Lorcana voce precisa de 2 a 4 jogadores.");
            return;
        }

        SortearPrimeiro(jogadoresId);

        foreach (var id in jogadoresId)
        {
            // var jogador = context.Jogadores
            // .Include(j => j.Deck)
            // .ThenInclude(d => d.Cartas)
            // .Include(c => c.CartasNaMão)
            // .FirstOrDefault(j => j.JogadorId == id);

            // jogador.ComprarCarta(7);
            // OferecerMulligan(jogador);
        }
    }

    public void Começar()
    {
        AtualizarStatus(StatusDoJogo.EmProgresso);
        InicializarTurno(true);
        // add validacao para status
        // comecar o turno

        // onde tem chamada externa add try/catch
    }

    public void AtualizarStatus(StatusDoJogo status)
    {
        Status = StatusDoJogo.EmProgresso;
        // _servicoDeNotificacao.MostrarMensagem($"O jogo agora esta em status: {Status}");
    }

    private void AdicionarJogadores(int[] jogadoresId, int jogoId)
    {
        try
        {
            foreach (var id in jogadoresId)
            {
                // var jogador = context.Jogadores.FirstOrDefault(j => j.JogadorId == id);
                // Jogadores.Add(jogador);
                // jogador.JogoId = jogoId;
                // context.SaveChanges();
            }

            // _servicoDeNotificacao.MostrarMensagem($"{jogadoresId.Length} jogadores adicionados");

        }
        catch (System.Exception)
        {
            throw;
        }
    }

    private void SortearPrimeiro(int[] jogadoresId)
    {
        Random _random = new Random();
        int indiceSorteado = _random.Next(0, jogadoresId.Length);
        // JogadorNaVez = context.Jogadores.FirstOrDefault(j => j.JogadorId == jogadoresId[indiceSorteado]);
        // 
        // _servicoDeNotificacao.MostrarMensagem($"Jogador sorteado para comecar foi {JogadorNaVez.Nome}");
    }

    private void OferecerMulligan(Jogador jogador)
    {
        // _servicoDeNotificacao.MostrarMensagem("Gostaria de trocar quantas cartas da mão inicial?");
        // _servicoDeNotificacao.MostrarMensagem("[A] - sim, iniciar Mulligan");
        // _servicoDeNotificacao.MostrarMensagem("[B] - não");
        var resposta = Console.ReadLine();
    

        if(resposta == "A"){
            jogador.ExecutarMulligan();
        }
    }

    public void InicializarTurno(bool turnoInitial)
    {
        JogadorNaVez.ExecutarAçõesDoTurno(turnoInitial);
        // contar tinta por jogador
        // contar Lore por jogador
    }

    public void AvancarParaProximoJogador()
    {

    }

    private Jogo CriarJogoNoBD()
    {
        try
        {
            Jogo jogo = new Jogo() { };
            jogo.Jogadores = [];
            // context.Jogos.Add(jogo);

            // context.SaveChanges();
            return jogo;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private int PegarJogoId(Jogo jogo)
    {

        try
        {
            // var jogoFound = context.Jogos.FirstOrDefault(c => c == jogo);
            // if (jogoFound == null)
            // {
            //     throw new JogoException("Jogo não encontrado no banco de dados.");
            // }

            // return jogoFound.JogoId;
            return 0;
        }
        catch (JogoException)
        {

            throw new JogoException("Ocorreu um erro.");
        }
    }
}
