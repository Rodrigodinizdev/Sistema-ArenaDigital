namespace ArenaDigital.Models;

public class Partida
{
    public Partida(string codigoPartida, Torneio torneio, Equipe equipeMandante, Equipe equipeVisitante, DateTime dataHoraRealizacao, int? placarMandante, int? placarVisitante)
    {
        Id = Guid.NewGuid();
        CodigoPartida = codigoPartida;
        Torneio = torneio;
        EquipeMandante = equipeMandante;
        EquipeVisitante = equipeVisitante;
        DataHoraRealizacao = dataHoraRealizacao;
        PlacarMandante = placarMandante;
        PlacarVisitante = placarVisitante;
    }
    public Guid Id { get; }
    public string CodigoPartida { get; private set; }
    public Torneio Torneio { get; private set; }
    public Equipe EquipeMandante { get; private set; }
    public Equipe EquipeVisitante { get; private set; }
    public DateTime DataHoraRealizacao { get; private set; }
    public int? PlacarMandante { get; private set; }
    public int? PlacarVisitante { get; private set; }

    public string Resultado()
    {
        if (PlacarMandante == null || PlacarVisitante == null)
            return "Sem resultado";

        if (PlacarMandante > PlacarVisitante)
            return $"{EquipeMandante.Nome} Vencedor";

        if (PlacarVisitante > PlacarMandante)
            return $"{EquipeVisitante.Nome} Vencedor";

        return "Empate";
    }

    public override string ToString() => $"Código Partida: [{CodigoPartida}] | Torneio: {Torneio.Nome} | {EquipeMandante.Nome} X {EquipeVisitante.Nome} | Data: {DataHoraRealizacao} | Resultado: {Resultado()} ";
}
