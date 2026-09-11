using SuperTrunfo;
using System;

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
    Console.Write($"{jogador1.Nome}: ");
    ConsoleUI.EscreverInline(pokemon1.Nome, ConsoleUI.CorDoTipo(pokemon1.TipoElemento));
    Console.Write($"   |   {jogador2.Nome}: ");
    ConsoleUI.EscreverInline(pokemon2.Nome, ConsoleUI.CorDoTipo(pokemon2.TipoElemento));
    Console.WriteLine();

    string atributo = LerAtributo();

    int resultado = batalha.IniciarBatalha(pokemon1, pokemon2, atributo);
    if (resultado == 1) pontosJogador1++;
    else if (resultado == 2) pontosJogador2++;

    rodada++;
}

ConsoleUI.EscreverTitulo("Fim de jogo");
Console.WriteLine($"Placar final: {jogador1.Nome} {pontosJogador1} x {pontosJogador2} {jogador2.Nome}");

if (pontosJogador1 > pontosJogador2)
    ConsoleUI.Escrever($"{jogador1.Nome} venceu o jogo!", ConsoleColor.Green);
else if (pontosJogador2 > pontosJogador1)
    ConsoleUI.Escrever($"{jogador2.Nome} venceu o jogo!", ConsoleColor.Green);
else
    ConsoleUI.Escrever("O jogo terminou empatado!", ConsoleColor.DarkYellow);


static string LerNome(string rotulo)
{
    Console.Write($"Nome do {rotulo}: ");
    string nome = Console.ReadLine();
    return string.IsNullOrWhiteSpace(nome) ? rotulo : nome;
}

static void MontarBaralho(Jogador jogador)
{
    ConsoleUI.EscreverTitulo($"{jogador.Nome}, escolha 3 pokémons");

    for (int i = 0; i < Pokedex.Todos.Count; i++)
    {
        Pokemon p = Pokedex.Todos[i];
        Console.Write($"{i + 1} - ");
        ConsoleUI.EscreverInline(p.Nome, ConsoleUI.CorDoTipo(p.TipoElemento));
        Console.WriteLine($" (Ataque: {p.Ataque}, Defesa: {p.Defesa}, Tipo: {p.TipoElemento})");
    }

    while (jogador.Baralho.Count < 3)
    {
        Console.Write($"Escolha o pokémon {jogador.Baralho.Count + 1}/3: ");
        string entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int escolha) || escolha < 1 || escolha > Pokedex.Todos.Count)
        {
            ConsoleUI.Escrever("Número inválido, tente de novo.", ConsoleColor.Red);
            continue;
        }

        jogador.EscolherPokemon(Pokedex.Todos[escolha - 1]);
    }
}

static string LerAtributo()
{
    while (true)
    {
        Console.Write("Escolha o atributo (Ataque/Defesa): ");
        string entrada = Console.ReadLine()?.Trim();

        if (string.Equals(entrada, "Ataque", StringComparison.OrdinalIgnoreCase))
            return "Ataque";
        if (string.Equals(entrada, "Defesa", StringComparison.OrdinalIgnoreCase))
            return "Defesa";

        ConsoleUI.Escrever("Atributo inválido. Digite Ataque ou Defesa.", ConsoleColor.Red);
    }
}