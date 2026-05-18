using ArenaDigital.Enum;
namespace ArenaDigital.Models;

public class Jogador
{
    public Jogador(string nome, string nickName, DateTime dataNascimento, string nacionalidade, FuncaoPrincipalEnum funcao, Equipe equipe)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        NickName = nickName;
        DataNascimento = dataNascimento;
        Nacionalidade = nacionalidade;
        Funcao = funcao;
        Equipe = equipe;
    }
    public Guid Id { get; }
    public string Nome { get; private set; }
    public string NickName { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Nacionalidade { get; private set; }
    public FuncaoPrincipalEnum Funcao { get; private set; }
    public Equipe Equipe { get; private set; }
    public DateTime DataTransferencia { get; private set; }

    public void TransferirJogador(Equipe equipe)
    {
        Equipe = equipe;
        DataTransferencia = DateTime.Now;

        Console.WriteLine($"{Nome} transferido para equipe {Equipe.Nome}");
    }
    public override string ToString() => $"Jogador: [{Id}] {Nome} | NickName: {NickName} | Nacionalidade: {Nacionalidade} | Função: {Funcao} | Equipe: {Equipe}";
}
