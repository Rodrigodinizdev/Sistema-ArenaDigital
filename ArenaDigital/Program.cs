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
    Console.WriteLine("4 - Inscrever Equipe");
    Console.WriteLine("5 - Cadastrar Partida");
    Console.WriteLine("6 - Listar Equipes");
    Console.WriteLine("7 - Listar Jogadores");
    Console.WriteLine("8 - Listar Torneios");
    Console.WriteLine("9 - Listar Partidas");
    Console.WriteLine("10 - Alterar Status do torneio");
    Console.WriteLine("11 - Buscar jogador pelo nome");
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

        case "4":
            InscreverEquipe();
            break;

        case "5":
            RealizarPartida();
            break;

        case "6":
            ListarEquipes();
            break;

        case "7":
            ListarJogadores();
            break;

        case "8":
            ListarTorneios();
            break;

        case "9":
            ListarPartidas();
            break;

        case "10":
            AlterarStatusPartida();
            break;

        case "11":
            BuscarJogadorPorNome();
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
    {
        Console.WriteLine("Não existem jogadores cadastrados!");
        return;
    }

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

void ListarTorneios()
{
    if (Torneios.Count == 0)
    {
        Console.WriteLine("Não existem Torneios criados!");
        return;
    }

    Torneios.ForEach(t => Console.WriteLine(t));
}

void InscreverEquipe()
{
    if (Torneios.Count == 0)
    {
        Console.WriteLine("Não existem Torneios criados!");
        return;
    }

    if (Equipes.Count == 0)
    {
        Console.WriteLine("Não existem Equipes cadastradas!");
        return;
    }

    ListarTorneios();

    Console.WriteLine("Digite o código do Torneio que deseja inscrever a equipe: ");

    string torneioEscolhido = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(torneioEscolhido) || !Torneios.Any(t => t.CodigoUnico == torneioEscolhido))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(torneioEscolhido)
            ? "Código obrigatório"
            : "Torneio não encontrado");
        torneioEscolhido = Console.ReadLine();
    }

    var torneio = Torneios.FirstOrDefault(t => t.CodigoUnico == torneioEscolhido);

    ListarEquipes();

    Console.WriteLine("Digite a TAG da Equipe que Deseja Inscrever: ");

    string equipeEscolhida = Console.ReadLine().ToUpper();
    while (string.IsNullOrWhiteSpace(equipeEscolhida) || !Equipes.Any(e => e.Tag == equipeEscolhida))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(equipeEscolhida)
            ? "A TAG não pode ser vazia"
            : "Equipe não encontrada");

        equipeEscolhida = Console.ReadLine().ToUpper();
    }

    var equipe = Equipes.FirstOrDefault(e => e.Tag == equipeEscolhida);

    if (torneio.Equipes.Any(e => e.Tag == equipe.Tag))
    {
        Console.WriteLine("Equipe já inscrita neste torneio!");
        return;
    }

    if (torneio.Equipes.Count >= torneio.MaxEquipes)
    {
        Console.WriteLine("Torneio já atingiu o limite de equipes!");
        return;
    }

    torneio.Equipes.Add(equipe);
}

void RealizarPartida()
{
    if (Torneios.Count == 0)
    {
        Console.WriteLine("Não existem Torneios criados!");
        return;
    }

    if (Equipes.Count == 0)
    {
        Console.WriteLine("Não existem Equipes cadastradas!");
        return;
    }

    Console.WriteLine("Digite o código da Partida: ");

    string codigoPartida = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(codigoPartida) || Partidas.Any(p => p.CodigoPartida == codigoPartida))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(codigoPartida)
            ? "Código não pode ser vazio"
            : "Código já existe, digite outro código");

        codigoPartida = Console.ReadLine();
    }

    ListarTorneios();

    Console.WriteLine("Digite o código do torneio no qual a partida será realizada: ");

    string torneioEscolhido = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(torneioEscolhido) || !Torneios.Any(t => t.CodigoUnico == torneioEscolhido))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(torneioEscolhido)
            ? "Código obrigatório"
            : "Torneio não encontrado");
        torneioEscolhido = Console.ReadLine();
    }

    var torneio = Torneios.FirstOrDefault(t => t.CodigoUnico == torneioEscolhido);

    ListarEquipes();

    Console.WriteLine("Digite a TAG da equipe Mandante: ");

    string tagMandante = Console.ReadLine().ToUpper();
    while (string.IsNullOrWhiteSpace(tagMandante) || !torneio.Equipes.Any(e => e.Tag == tagMandante))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(tagMandante)
            ? "TAG não pode ser vazia"
            : "Equipe não encontrada");

        tagMandante = Console.ReadLine().ToUpper();
    }

    var equipeMandante = torneio.Equipes.FirstOrDefault(e => e.Tag == tagMandante);

    Console.WriteLine("Digite a TAG da equipe Visitante: ");

    string tagVisitante = Console.ReadLine().ToUpper();
    while (string.IsNullOrWhiteSpace(tagVisitante) || !torneio.Equipes.Any(e => e.Tag == tagVisitante) || tagMandante == tagVisitante)
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(tagVisitante)
            ? "TAG não pode ser vazia"
            : tagMandante == tagVisitante
                ? "Equipe visitante não pode ser igual à mandante"
                : "Equipe não encontrada no torneio");

        tagVisitante = Console.ReadLine().ToUpper();
    }

    var equipeVisitante = torneio.Equipes.FirstOrDefault(e => e.Tag == tagVisitante);

    if (torneio.Partidas.Any(p => (p.EquipeMandante.Tag == equipeMandante.Tag && p.EquipeVisitante.Tag == equipeVisitante.Tag) ||
                                  (p.EquipeMandante.Tag == equipeVisitante.Tag && p.EquipeVisitante.Tag == equipeMandante.Tag)))
    {
        Console.WriteLine("Já existe uma partida entre essas duas equipes neste torneio!");
        return;
    }

    Console.WriteLine("Digite a data e hora da partida (dd/MM/yyyy HH:mm): ");

    DateTime dataHoraPartida;
    while (!DateTime.TryParse(Console.ReadLine(), out dataHoraPartida) || dataHoraPartida < torneio.DataInicio || dataHoraPartida > torneio.DataTermino)
        Console.WriteLine("Data Inválida! Partida deve ser realizada no período em que ocorre o torneio");

    if (torneio.Status != StatusTorneioEnum.EmAndamento)
    {
        Console.WriteLine("O torneio precisa estar Em Andamento para registrar resultado!");
        return;
    }

    Console.WriteLine("Qual o placar da equipe Mandante? ");

    int placarMandante;
    while (!int.TryParse(Console.ReadLine(), out placarMandante) || placarMandante < 0)
        Console.WriteLine("Placar não pode ser negativo!");

    Console.WriteLine("Qual o placar da equipe Visitante? ");

    int placarVisitante;
    while (!int.TryParse(Console.ReadLine(), out placarVisitante) || placarVisitante < 0)
        Console.WriteLine("Placar não pode ser negativo!");

    var partida = new Partida(codigoPartida, torneio, equipeMandante, equipeVisitante, dataHoraPartida, placarMandante, placarVisitante);
    Partidas.Add(partida);
    torneio.Partidas.Add(partida);

    Console.WriteLine($"{partida}");
}

void ListarPartidas()
{
    if (Partidas.Count == 0)
    {
        Console.WriteLine("Não existem partidas cadastradas");
        return;
    }

    Partidas.ForEach(p => Console.WriteLine(p));
}

void AlterarStatusPartida()
{
    if (Torneios.Count == 0)
    {
        Console.WriteLine("Nenhum torneio cadastrado!");
        return;
    }

    ListarTorneios();

    Console.WriteLine("Digite o código do torneio: ");
    string codigoTorneio = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(codigoTorneio) || !Torneios.Any(t => t.CodigoUnico == codigoTorneio))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(codigoTorneio)
            ? "Código obrigatório"
            : "Torneio não encontrado");
        codigoTorneio = Console.ReadLine();
    }

    var torneio = Torneios.FirstOrDefault(t => t.CodigoUnico == codigoTorneio);

    Console.WriteLine($"Status atual: {torneio.Status}");
    Console.WriteLine("=== NOVO STATUS ===");
    Console.WriteLine("1 - Planejado");
    Console.WriteLine("2 - Em Andamento");
    Console.WriteLine("3 - Encerrado");

    int opcao;
    while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 3)
        Console.WriteLine("Escolha a opção 1, 2 ou 3");

    StatusTorneioEnum novoStatus = (StatusTorneioEnum)opcao;

    if (novoStatus == torneio.Status)
    {
        Console.WriteLine("O torneio já está com esse status!");
        return;
    }

    if (novoStatus < torneio.Status)
    {
        Console.WriteLine("Não é permitido retroceder o status do torneio!");
        return;
    }

    if (novoStatus == StatusTorneioEnum.Encerrado)
    {
        if (torneio.Equipes.Count < 2)
        {
            Console.WriteLine("Torneio precisa de ao menos 2 equipes inscritas para ser encerrado!");
            return;
        }

        if (torneio.Partidas.Count == 0)
        {
            Console.WriteLine("Torneio precisa de ao menos 1 partida registrada para ser encerrado!");
            return;
        }
    }

    torneio.AlterarStatusTorneio(novoStatus);
    Console.WriteLine($"Status alterado para {novoStatus} com sucesso!");
}

void BuscarJogadorPorNome()
{
    if (Jogadores.Count == 0)
    {
        Console.WriteLine("Não existe jogadores cadastrados");
        return;
    }

    Console.WriteLine("Digite parte do NickName do jogador: ");

    string parteNome = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(parteNome))
    {
        Console.WriteLine("NickName não pode ser vazio");
        parteNome = Console.ReadLine();
    }

    var busca = Jogadores.Where(j => j.NickName.Contains(parteNome, StringComparison.OrdinalIgnoreCase)).ToList();

    if(busca.Count == 0)
    {
        Console.WriteLine("Jogador não encontrado");
        return;
    }

    busca.ForEach(j => Console.WriteLine(j));
   
}

