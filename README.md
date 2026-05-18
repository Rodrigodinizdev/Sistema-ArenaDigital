# Sistema-ArenaDigital
Aqui está uma nova especificação de prova — mesmo escopo (4 entidades, CRUD, console C#), mas com regras de negócio bem mais ricas e complexas:

Prova – Programação Orientada a Objetos: Sistema de Gestão de Torneios de E-Sports Arena Digital
Regra de Negócio: Plataforma Arena Digital
A Arena Digital é uma plataforma nacional de organização de torneios de e-sports, responsável por gerenciar competições, equipes, jogadores e partidas de forma estruturada e profissional.

Equipes
Cada equipe possui um tag único de até 5 caracteres em maiúsculas (ex.: "FURIA", "LOUD"), um nome completo, o país de origem e uma data de fundação. Uma equipe pode participar de vários torneios ao longo do tempo, mas não pode estar inscrita duas vezes no mesmo torneio.

Jogadores
Os jogadores são cadastrados com nome real, nickname único no sistema (ex.: "fallen"), data de nascimento, nacionalidade e a função principal que desempenha, que pode ser: Fragger, Suporte, IGL (In-Game Leader), AWPer ou Lurker.
Todo jogador pertence a exatamente uma equipe — sem equipe, o jogador não pode ser cadastrado. Um jogador pode ser transferido para outra equipe, mas o sistema deve registrar a data da transferência e garantir que ele só pertença a uma equipe por vez.

A idade mínima para competição é 16 anos. O sistema deve impedir o cadastro de jogadores mais novos.


Torneios
Cada torneio possui um código único (ex.: "BR-2025-01"), um nome, o jogo disputado (campo livre de texto), a modalidade — Liga ou Mata-Mata —, uma data de início, uma data de término e uma premiação total em reais.

Torneios na modalidade Liga aceitam qualquer número de equipes inscritas.
Torneios na modalidade Mata-Mata aceitam no máximo 64 equipes.
Um torneio só pode ter seu status alterado para Encerrado se tiver ao menos duas equipes inscritas e ao menos uma partida registrada.
O status do torneio pode ser: Planejado, Em Andamento ou Encerrado.


Partidas
A partida é a entidade que conecta duas equipes dentro de um torneio. Cada partida possui um código único, o torneio ao qual pertence, a equipe mandante, a equipe visitante, a data e hora de realização, e o resultado — composto pelo placar da equipe mandante e da equipe visitante (ambos inteiros não-negativos).
Regras de integridade:

Uma equipe não pode jogar contra si mesma.
Ambas as equipes devem estar inscritas no torneio da partida.
Não é permitido cadastrar duas partidas entre as mesmas duas equipes no mesmo torneio (independente de quem é mandante ou visitante).
Uma partida só pode ter resultado registrado se o torneio estiver Em Andamento.


Funcionalidades Obrigatórias
1. Busca de Jogadores

Busca por nickname (parcial, case-insensitive).
Busca por função (ex.: listar todos os IGLs cadastrados).

2. Tabela de Classificação de um Torneio
Dado o código de um torneio, exibir a classificação das equipes inscritas considerando apenas as partidas com resultado registrado, ordenada pelos seguintes critérios — nesta ordem de prioridade:

Pontos (vitória = 3 pts, empate = 1 pt, derrota = 0 pts) — decrescente
Saldo de placar (soma dos placares marcados menos os sofridos) — decrescente
Total de gols/pontos marcados — decrescente
Nome da equipe — alfabético crescente (critério de desempate final)

3. Histórico de Partidas de uma Equipe
Dado o tag de uma equipe, listar todas as partidas em que ela participou (como mandante ou visitante), exibindo: código da partida, nome do torneio, adversário, placar, resultado para a equipe (Vitória, Derrota ou Empate) e data. Ordenar por data crescente.
4. Elenco Atual de uma Equipe
Dado o tag de uma equipe, listar todos os jogadores atualmente vinculados a ela, exibindo nome real, nickname, função e data da última transferência (ou data de cadastro, se nunca foi transferido). Ordenar por função e depois por nickname alfabeticamente.
5. Artilharia de um Torneio
Dado o código de um torneio, calcular a média de gols/pontos por partida de cada equipe participante (total de pontos marcados ÷ número de partidas jogadas), exibindo as equipes em ordem decrescente. Em caso de empate na média, ordenar pelo nome da equipe. Equipes sem nenhuma partida registrada devem aparecer ao final com média 0,00.
6. Filtro de Partidas por Torneio e Intervalo de Datas
Dado o código de um torneio, uma data inicial e uma data final, listar todas as partidas realizadas naquele intervalo, ordenadas por data crescente.

Interface

Menu interativo no console, com submenus organizados por entidade.
O sistema deve continuar rodando até o usuário escolher a opção de encerramento.
Navegação clara, sem travar ou quebrar o fluxo em entradas inválidas.


Entrega

Código-fonte completo em C#.
O sistema deve compilar e executar corretamente.
Dados podem ser mantidos em memória (sem banco de dados).
