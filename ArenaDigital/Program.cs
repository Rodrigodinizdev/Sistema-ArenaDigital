using ArenaDigital.Enum;
using ArenaDigital.Models;

List<Equipe> Equipes = [];
List<Jogador> Jogadores = [];
List<Partida> Partidas = [];
List<Torneio> Torneios = [];

while (true)
{
    Console.Clear();
    Console.WriteLine("======== ARENA DIGITAL ========");
    Console.WriteLine("1 - Cadastrar Equipe");
    Console.WriteLine("2 - Cadastrar Jogador");
    Console.WriteLine("3 - Cadastrar Torneio");
    Console.WriteLine("4 - Cadastrar Partida");
    Console.WriteLine("5 - Listar Equipes");
    Console.WriteLine("6 - Listar Jogadores");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("===============================");

    Console.WriteLine("Escolha a opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarEquipe();
            break;

        case "2":
            CadastrarJogador();
            break;

        case "5":
            ListarEquipes();
            break;

        case "6":
            ListarJogadores();
            break;

        case "0":
            Console.WriteLine("Saindo...");
            return;

        default:
            Console.WriteLine("Opção inválida! Tente novamente");
            break;
    }

    Console.WriteLine("Pressione qualquer tecla: ");
    Console.ReadKey();
}

void CadastrarEquipe()
{
    Console.WriteLine("Digite a TAG da equipe (5 caracteres Maiúsculos no máximo): ");

    string tag = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(tag.ToUpper()) || tag.Length > 5)
    {
        Console.WriteLine("Tag não pode ser vazia e deve ter 5 caracteres");
        tag = Console.ReadLine();
    }

    Console.WriteLine("Digite o nome da equipe: ");

    string nome = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("Nome não pode ser vazio");
        nome = Console.ReadLine();
    }

    Console.WriteLine("Digite o País de origem da equipe: ");

    string pais = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(pais))
    {
        Console.WriteLine("País não pode ser vazio");
        pais = Console.ReadLine();
    }

    Console.WriteLine("Digite a data de fundação da equipe: ");

    DateTime dataFundacao;
    while (!DateTime.TryParse(Console.ReadLine(), out dataFundacao) || dataFundacao > DateTime.Now)
        Console.WriteLine("Data Inválida");

    var equipe = new Equipe(tag, nome, pais, dataFundacao);
    Equipes.Add(equipe);
    Console.WriteLine($"{equipe} criada com sucesso!");
}

void ListarEquipes()
{
    if (Equipes.Count == 0)
        Console.WriteLine("Não existem equipes cadastradas");

    Equipes.ForEach(e => Console.WriteLine(e));
}


void CadastrarJogador()
{
    Console.WriteLine("Digite o nome do jogador: ");

    string nome = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("Nome não pode ser vazio");
        nome = Console.ReadLine();
    }

    Console.WriteLine("Digite o nickName do jogador: ");

    string nickName = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nickName))
    {
        Console.WriteLine("nickName não pode ser vazio");
        nickName = Console.ReadLine();
    }

    while (Jogadores.Any(j => j.NickName == nickName))
    {
        Console.WriteLine("Já existe este nickName cadastrado. Digite outro: ");
        nickName = Console.ReadLine();
    }

    Console.WriteLine("Digite a data de nascimento do jogador: ");

    DateTime dataNascimento;
    while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento) || dataNascimento > DateTime.Now)
        Console.WriteLine("Data Inválida");

    var idade = DateTime.Now.Year - dataNascimento.Year;

    if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
        idade--;

    if (idade < 16)
    {
        Console.WriteLine("Idade mínima deve ser 16 anos");
        return;
    }

    Console.WriteLine("Digite a nacionalidade do jogador: ");

    string nacionalidade = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nacionalidade))
    {
        Console.WriteLine("Nacionalidade não pode ser vazia");
        nacionalidade = Console.ReadLine();
    }

    Console.WriteLine("=== Funções ===");
    Console.WriteLine("1 - Fragger");
    Console.WriteLine("2 - Suporte");
    Console.WriteLine("3 - IGL");
    Console.WriteLine("4 - AWPer");
    Console.WriteLine("5 - Lurker");

    Console.WriteLine("Escolha a Função do jogador: ");
    int opcao;

    while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 5)
        Console.WriteLine("Digite as opções de 1 a 5");

    FuncaoPrincipalEnum funcaoEscolhida = (FuncaoPrincipalEnum)opcao;

    ListarEquipes();

    Equipe equipe = null;
    while (equipe == null)
    {
        Console.WriteLine("Escolha uma equipe para o jogador, Digite o Id: ");

        Guid id;
        while (!Guid.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id Incorreto");

        equipe = Equipes.FirstOrDefault(e => e.Id == id);

        if (equipe == null)
            Console.WriteLine("Equipe não encontrada, tente novamente");
    }

    var jogador = new Jogador(nome, nickName, dataNascimento, nacionalidade, funcaoEscolhida, equipe);
    Jogadores.Add(jogador);
    Console.WriteLine($"{jogador} Jogador cadastrado com sucesso!");
}

void ListarJogadores()
{
    if (Jogadores.Count == 0)
        Console.WriteLine("Não existem jogadores cadastrados!");

    Jogadores.ForEach(j => Console.WriteLine(j));
}

