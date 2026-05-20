using ArenaDigital.Enum;

namespace ArenaDigital.Models;

public class Torneio
{
    public Torneio(string codigoUnico, string nome, string jogo, ModalidadeEnum modalidade, int maxEquipes, DateTime dataInicio, DateTime dataTermino, decimal premiacao)
    {
        Id = Guid.NewGuid();
        CodigoUnico = codigoUnico;
        Nome = nome;
        Jogo = jogo;
        Modalidade = modalidade;
        MaxEquipes = maxEquipes;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        Premiacao = premiacao;
        Status = StatusTorneioEnum.Planejado;
        Equipes = [];
        Partidas = [];
    }
    public Guid Id { get; }
    public string CodigoUnico { get; private set; }
    public string Nome { get; private set; }
    public string Jogo { get; private set; }
    public ModalidadeEnum Modalidade { get; private set; }
    public int MaxEquipes { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataTermino { get; private set; }
    public decimal Premiacao { get; private set; }
    public StatusTorneioEnum Status { get; private set; }
    public readonly List<Equipe> Equipes;
    public readonly List<Partida> Partidas;

    public void AlterarStatusTorneio(StatusTorneioEnum status)
    {
        Status = status;
    }
    public override string ToString() => $" Código Torneio: {CodigoUnico} | Torneio: {Nome} | Jogo: {Jogo} | Modalidade: {Modalidade} | Início: {DataInicio} | Término: {DataTermino} | Premiação: {Premiacao:C} | Status: {Status}";

}
