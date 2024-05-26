using EFExemplo;

namespace boardGame;

public class Jogo
{
    public int JogoId { get; set; }
    public List<Jogador> Jogadores { get; set; }
    public int TurnoId { get; set; }
    public List<Turno> Turnos { get; set; }
    public StatusDoJogo Status { get; set; }
    public Jogador JogadorNaVez { get; set; }

    Context context = new Context();


    private ServicoDeNotificacao _servicoDeNotificacao;

    public Jogo()
    {
        _servicoDeNotificacao = new ServicoDeNotificacao();
    }

    public void SetUp(List<Jogador> jogadores)
    {
        var jogoId = CriarJogo();
        AdicionarJogadores(jogadores, jogoId);

        if (jogadores.Count > 4 || jogadores.Count < 2)
        {
            _servicoDeNotificacao.MostrarErro("Para jogar Lorcana voce precisa de 2 a 4 jogadores.");
            return;
        }

        SortearPrimeiro(jogadores);
        foreach (var jogador in jogadores)
        {
            jogador.ComprarCarta(7);
            OferecerMulligan(jogador);
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
        _servicoDeNotificacao.MostrarMensagem($"O jogo agora esta em status: {Status}");
    }

    private void AdicionarJogadores(List<Jogador> jogadores, int jogoId)
    {
        Jogadores = jogadores;
        
        foreach (var jogador in jogadores)
        {
            var pessoa = context.Jogadores.FirstOrDefault(j => j == jogador);
            pessoa.JogoId = jogoId;
            context.SaveChanges();
        }

        _servicoDeNotificacao.MostrarMensagem($"{jogadores.Count} jogadores adicionados");
    }

    private void SortearPrimeiro(List<Jogador> jogadores)
    {
        Random _random = new Random();
        if (jogadores.Count == 0)
        {
            _servicoDeNotificacao.MostrarErro("Não há jogadores para sortear.");
            return;
        }

        int indiceSorteado = _random.Next(0, jogadores.Count);
        JogadorNaVez = jogadores[indiceSorteado];
        _servicoDeNotificacao.MostrarMensagem($"Jogador sorteado para comecar foi {JogadorNaVez.Nome}");
    }

    private void OferecerMulligan(Jogador jogador)
    {
        _servicoDeNotificacao.MostrarMensagem("Gostaria de trocar quantas cartas da mão inicial?");
        // informar nome das cartas?

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

    private int CriarJogo()
    {
        Jogo jogo = new Jogo(){};
        context.Jogos.Add(jogo);
        context.SaveChanges();
        return context.Jogos.FirstOrDefault(c => c == jogo).JogoId;
    }







}
