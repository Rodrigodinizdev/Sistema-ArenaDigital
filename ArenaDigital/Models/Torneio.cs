using ArenaDigital.Enum;

namespace ArenaDigital.Models;

public class Torneio
{
    public Torneio(string nome, string jogo, ModalidadeEnum modalidade, DateTime dataInicio, DateTime dataTermino, decimal premiacao, StatusTorneioEnum status)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Jogo = jogo;
        Modalidade = modalidade;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        Premiacao = premiacao;
        Status = status;
    }
    public Guid Id { get; }
    public string Nome { get; private set; }
    public string Jogo { get; private set; }
    public ModalidadeEnum Modalidade { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataTermino { get; private set; }
    public decimal Premiacao { get; private set; }
    public StatusTorneioEnum Status { get; private set; }
    public Equipe Equipe { get; private set; }

    public void AlterarStatusTorneio(StatusTorneioEnum status)
    {
        Status = status;

        if(status == StatusTorneioEnum.Encerrado && )
    }
    public override string ToString() => $"Torneio: [{Id}] {Nome} | Jogo: {Jogo} | Modalidade: {Modalidade} | Início: {DataInicio} | Término: {DataTermino} | Premiação: {Premiacao:C} | Status: {Status}";

}
