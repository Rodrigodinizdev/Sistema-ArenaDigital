namespace ArenaDigital.Models;

public class Equipe
{
    public Equipe(string tag, string nome, string paisOrigem, DateTime dataFundacao)
    {
        Id = Guid.NewGuid();
        Tag = tag;
        Nome = nome;
        PaisOrigem = paisOrigem;
        DataFundacao = dataFundacao;
    }

    public Guid Id { get; }
    public string Tag { get; private set; }
    public string Nome { get; private set; }
    public string PaisOrigem { get; private set; }
    public DateTime DataFundacao { get; private set; }

    public void EditarEquipe(string tag, string nome, string paisOrigem, DateTime dataFundacao)
    {
        Tag = tag;
        Nome = nome;
        PaisOrigem = paisOrigem;
        DataFundacao = dataFundacao;
    }
    public override string ToString() => $"Id: [{Id}] | Tag: {Tag} | Equipe: {Nome} | País: {PaisOrigem} | Data Fundação: {DataFundacao}";
}
