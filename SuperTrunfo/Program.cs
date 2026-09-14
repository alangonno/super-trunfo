using SuperTrunfo;
using System;

// try/catch externo: envolve o jogo inteiro.
// Se qualquer erro escapar dos try/catch de dentro, ele é tratado aqui
// e o programa termina com uma mensagem, em vez de quebrar na cara do usuário.
try
{
    // Faz o console entender os acentos das mensagens.
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    ConsoleUI.EscreverTitulo("Super Trunfo Pokémon");

    Jogador jogador1 = new Jogador(LerNome("Jogador 1"));
    MontarBaralho(jogador1);

    Jogador jogador2 = new Jogador(LerNome("Jogador 2"));
    MontarBaralho(jogador2);

    Batalha batalha = new Batalha();
    int pontosJogador1 = 0;
    int pontosJogador2 = 0;
    int rodada = 1;

    while (jogador1.Baralho.Count > 0 && jogador2.Baralho.Count > 0)
    {
        Pokemon pokemon1 = jogador1.ProximoPokemon();
        Pokemon pokemon2 = jogador2.ProximoPokemon();

        ConsoleUI.EscreverTitulo($"Rodada {rodada}");
        ConsoleUI.MostrarDuelo(jogador1, pokemon1, jogador2, pokemon2);

        string atributo = LerAtributo();

        // A Batalha só calcula; quem mostra o resultado é o ConsoleUI.
        ResultadoBatalha resultado = batalha.IniciarBatalha(pokemon1, pokemon2, atributo);
        ConsoleUI.MostrarResultadoBatalha(jogador1, pokemon1, jogador2, pokemon2, atributo, resultado);

        if (resultado.Vencedor == ResultadoRodada.Jogador1)
        {
            pontosJogador1++;
        }
        else if (resultado.Vencedor == ResultadoRodada.Jogador2)
        {
            pontosJogador2++;
        }

        rodada++;
    }

    ConsoleUI.EscreverTitulo("Fim de jogo");
    Console.WriteLine($"Placar final: {jogador1.Nome} {pontosJogador1} x {pontosJogador2} {jogador2.Nome}");

    if (pontosJogador1 > pontosJogador2)
    {
        ConsoleUI.Escrever($"{jogador1.Nome} venceu o jogo!", ConsoleColor.Green);
    }
    else if (pontosJogador2 > pontosJogador1)
    {
        ConsoleUI.Escrever($"{jogador2.Nome} venceu o jogo!", ConsoleColor.Green);
    }
    else
    {
        ConsoleUI.Escrever("O jogo terminou empatado!", ConsoleColor.DarkYellow);
    }
}
catch (SuperTrunfoException erro)
{
    // Pega qualquer erro de regra do jogo (as quatro exceções são filhas desta).
    ConsoleUI.Escrever($"Erro de regra do jogo: {erro.Message}", ConsoleColor.Red);
}
catch (Exception erro)
{
    // Rede de segurança: qualquer outro erro inesperado cai aqui.
    ConsoleUI.Escrever($"Erro inesperado: {erro.Message}", ConsoleColor.Red);
}
finally
{
    // O finally roda sempre: com erro ou sem erro.
    Console.WriteLine();
    Console.WriteLine("Pressione ENTER para sair.");
    Console.ReadLine();
}


static string LerNome(string rotulo)
{
    Console.Write($"Nome do {rotulo}: ");

    // ReadLine() pode devolver null; o ?? troca null por texto vazio.
    string nome = Console.ReadLine() ?? string.Empty;

    return string.IsNullOrWhiteSpace(nome) ? rotulo : nome;
}

static void MontarBaralho(Jogador jogador)
{
    ConsoleUI.EscreverTitulo($"{jogador.Nome}, escolha {Jogador.MaxPokemonsNoBaralho} pokémons");

    for (int i = 0; i < Pokedex.Todos.Count; i++)
    {
        ConsoleUI.MostrarCarta(i + 1, Pokedex.Todos[i]);
    }

    while (jogador.Baralho.Count < Jogador.MaxPokemonsNoBaralho)
    {
        Console.Write($"Escolha o pokémon {jogador.Baralho.Count + 1}/{Jogador.MaxPokemonsNoBaralho}: ");

        // try/catch da escolha das cartas: avisa o erro e pergunta de novo,
        // sem encerrar o jogo.
        try
        {
            string entrada = Console.ReadLine() ?? string.Empty;

            // int.Parse lança FormatException quando a entrada não é um número.
            int escolha = int.Parse(entrada);

            // O indexador da List lança ArgumentOutOfRangeException
            // quando a posição não existe na lista.
            Pokemon escolhido = Pokedex.Todos[escolha - 1];

            // EscolherPokemon lança PokemonDuplicadoException se a carta já estiver no baralho.
            jogador.EscolherPokemon(escolhido);

            ConsoleUI.Escrever($"{escolhido.Nome} entrou no baralho.", ConsoleColor.Green);
        }
        catch (FormatException)
        {
            ConsoleUI.Escrever("Digite um número, não letras.", ConsoleColor.Red);
        }
        catch (OverflowException)
        {
            ConsoleUI.Escrever($"Número grande demais. Escolha entre 1 e {Pokedex.Todos.Count}.", ConsoleColor.Red);
        }
        catch (ArgumentOutOfRangeException)
        {
            ConsoleUI.Escrever($"Escolha um número entre 1 e {Pokedex.Todos.Count}.", ConsoleColor.Red);
        }
        catch (PokemonDuplicadoException erro)
        {
            ConsoleUI.Escrever(erro.Message, ConsoleColor.Red);
        }
    }
}

static string LerAtributo()
{
    while (true)
    {
        Console.Write("Escolha o atributo (Ataque/Defesa): ");
        string entrada = Console.ReadLine() ?? string.Empty;

        // try/catch da escolha do atributo: quem valida é a classe Pokemon.
        try
        {
            // NormalizarAtributo confere se o atributo existe e devolve o nome
            // no formato certo ("Ataque" ou "Defesa"). Se não existir, lança
            // AtributoInvalidoException.
            return Pokemon.NormalizarAtributo(entrada);
        }
        catch (AtributoInvalidoException erro)
        {
            ConsoleUI.Escrever(erro.Message, ConsoleColor.Red);
        }
    }
}
