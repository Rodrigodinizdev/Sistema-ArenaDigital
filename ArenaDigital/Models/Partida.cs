namespace ArenaDigital.Models;

public class Partida
{
    public Guid Id { get; }
    public Torneio Torneio { get; private set; }
    public Equipe EquipeMandante { get; private set; }
    public Equipe EquipeVisitante { get; private set; }
    public DateTime DataHoraRealizacao { get; private set; }
    public int? PlacarMandante { get; private set; }
    public int? PlacarVisitante { get; private set; }

    public string Resultado()
    {
        if(PlacarMandante > PlacarVisitante)
            return $"{EquipeMandante.Nome} Vencedor";

        return $"{EquipeVisitante.Nome} Vencedor";  
    }

    public override string ToString() => $"Partida: [{Id}] | Torneio: {Torneio.Nome} | {EquipeMandante.Nome} X {EquipeVisitante.Nome} | Data: {DataHoraRealizacao} | Resultado: {Resultado()} ";
}
