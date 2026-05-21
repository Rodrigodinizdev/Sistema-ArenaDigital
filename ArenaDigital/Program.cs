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

        case "3":
            CadastrarTorneio();
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

    string tag = Console.ReadLine().ToUpper();
    while (string.IsNullOrWhiteSpace(tag) || tag.Length > 5 || Equipes.Any(e => e.Tag == tag))
    {
        Console.WriteLine(tag.Length > 5
            ? "Tag deve ter no máximo 5 caracteres"
            : Equipes.Any(e => e.Tag == tag)
                ? "Tag já existe, digite outra"
                : "Tag não pode ser vazia");
        tag = Console.ReadLine().ToUpper();
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
    while (string.IsNullOrWhiteSpace(nickName) || Jogadores.Any(j => j.NickName == nickName))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(nickName)
            ? "NickName não pode ser vazio"
            : "NickName já existe, digite outro");
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

void CadastrarTorneio()
{
    Console.WriteLine("Digite o Código do torneio (EX: BR-2025-01): ");

    string codigoTorneio = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(codigoTorneio) || Torneios.Any(t => t.CodigoUnico == codigoTorneio))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(codigoTorneio)
            ? "Código não pode ser vazio"
            : "Código já existe, digite outro código");

        codigoTorneio = Console.ReadLine();
    }

    Console.WriteLine("Digite o nome do Torneio: ");

    string nomeTorneio = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nomeTorneio))
    {
        Console.WriteLine("Nome não pode ser vazio");
        nomeTorneio = Console.ReadLine();
    }

    Console.WriteLine("Digite o nome do Jogo: ");

    string nomeJogo = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nomeJogo))
    {
        Console.WriteLine("Nome não pode ser vazio");
        nomeJogo = Console.ReadLine();
    }

    Console.WriteLine("=== MODALIDADE DO TORNEIO ===");
    Console.WriteLine("1 - Liga");
    Console.WriteLine("2 - Mata-Mata");

    Console.WriteLine("Escolha uma modalidade: ");
    int opcao;

    while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 2)
        Console.WriteLine("Escolha a opção 1 ou 2");

    ModalidadeEnum modalidadeEscolhida = (ModalidadeEnum)opcao;

    int maxEquipes = int.MaxValue;

    if (modalidadeEscolhida == ModalidadeEnum.MataMata)
    {
        Console.WriteLine("Digite o número máximo de equipes (máx 64): ");
        while (!int.TryParse(Console.ReadLine(), out maxEquipes) || maxEquipes < 2 || maxEquipes > 64)
            Console.WriteLine("Mata-Mata aceita no máximo 64 equipes (mínimo 2)");
    }

    Console.WriteLine("Digite a data de início do torneio: ");

    DateTime dataInicio;
    while (!DateTime.TryParse(Console.ReadLine(), out dataInicio) || dataInicio < DateTime.Now.AddDays(7))
        Console.WriteLine("Data Inválida! data deve ser no mínimo 7 dias após data de hoje");

    Console.WriteLine("Digite a data de término do torneio: ");

    DateTime dataTermino;
    while (!DateTime.TryParse(Console.ReadLine(), out dataTermino) || dataTermino < dataInicio)
        Console.WriteLine("Data Inválida! data deve ser no mínimo no mesmo dia que o inicio do torneio");

    Console.WriteLine("Digite o valor da premiação: ");

    decimal premiacao;
    while (!decimal.TryParse(Console.ReadLine(), out premiacao) || premiacao <= 0)
        Console.WriteLine("Premiação deve ser maior que 0");

    var torneio = new Torneio(codigoTorneio, nomeTorneio, nomeJogo, modalidadeEscolhida, maxEquipes, dataInicio, dataTermino, premiacao);
    Torneios.Add(torneio);
    Console.WriteLine($"{torneio} | Torneio criado com sucesso!");
}
