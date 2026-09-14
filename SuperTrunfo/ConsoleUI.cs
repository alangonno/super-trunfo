using System;

namespace SuperTrunfo
{
    // Toda a escrita na tela fica concentrada aqui.
    public static class ConsoleUI
    {
        // Formato dos valores: mostra as casas decimais só quando existirem.
        // Assim aparece 104 e 24,5 em vez de 104 e 24,50.
        private const string FORMATO_VALOR = "0.##";

        public static void EscreverTitulo(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n=== {texto} ===");
            Console.ResetColor();
        }

        public static void EscreverSeparador()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('-', 44));
            Console.ResetColor();
        }

        public static void Escrever(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static void EscreverInline(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(texto);
            Console.ResetColor();
        }

        public static ConsoleColor CorDoTipo(Elementos tipo)
        {
            return tipo switch
            {
                Elementos.Fogo => ConsoleColor.Red,
                Elementos.Planta => ConsoleColor.Green,
                Elementos.Agua => ConsoleColor.Cyan,
                _ => ConsoleColor.White
            };
        }

        // O enum não aceita acento no nome (Agua), mas a tela aceita (Água).
        public static string NomeDoTipo(Elementos tipo)
        {
            return tipo switch
            {
                Elementos.Fogo => "Fogo",
                Elementos.Planta => "Planta",
                Elementos.Agua => "Água",
                _ => tipo.ToString()
            };
        }

        // Mostra a carta com nome colorido pelo tipo e os atributos.
        public static void MostrarCarta(int numero, Pokemon pokemon)
        {
            Console.Write($"{numero} - ");
            EscreverInline(pokemon.Nome, CorDoTipo(pokemon.TipoElemento));
            Console.WriteLine($" (Ataque: {pokemon.Ataque}, Defesa: {pokemon.Defesa}, Tipo: {NomeDoTipo(pokemon.TipoElemento)})");
        }

        // Mostra quem cada jogador colocou na mesa nesta rodada.
        public static void MostrarDuelo(Jogador jogador1, Pokemon pokemon1, Jogador jogador2, Pokemon pokemon2)
        {
            Console.Write($"{jogador1.Nome}: ");
            EscreverInline(pokemon1.Nome, CorDoTipo(pokemon1.TipoElemento));
            Console.Write($"   |   {jogador2.Nome}: ");
            EscreverInline(pokemon2.Nome, CorDoTipo(pokemon2.TipoElemento));
            Console.WriteLine();
        }

        // Mostra o resultado que a classe Batalha calculou.
        // O nome do jogador aparece em cada linha para o caso de os dois
        // estarem jogando a mesma carta.
        public static void MostrarResultadoBatalha(
            Jogador jogador1, Pokemon pokemon1,
            Jogador jogador2, Pokemon pokemon2,
            string atributo, ResultadoBatalha resultado)
        {
            EscreverSeparador();

            Console.Write("Batalha entre ");
            EscreverInline(pokemon1.Nome, CorDoTipo(pokemon1.TipoElemento));
            Console.Write(" e ");
            EscreverInline(pokemon2.Nome, CorDoTipo(pokemon2.TipoElemento));
            Console.WriteLine($"! Atributo: {atributo}");

            Console.WriteLine($"{jogador1.Nome} - {pokemon1.Nome}: {atributo} efetivo = {resultado.ValorJogador1.ToString(FORMATO_VALOR)}");
            Console.WriteLine($"{jogador2.Nome} - {pokemon2.Nome}: {atributo} efetivo = {resultado.ValorJogador2.ToString(FORMATO_VALOR)}");

            switch (resultado.Vencedor)
            {
                case ResultadoRodada.Jogador1:
                    Escrever($"{jogador1.Nome} venceu a rodada com {pokemon1.Nome}!", ConsoleColor.Green);
                    break;

                case ResultadoRodada.Jogador2:
                    Escrever($"{jogador2.Nome} venceu a rodada com {pokemon2.Nome}!", ConsoleColor.Green);
                    break;

                default:
                    Escrever("A rodada terminou em empate!", ConsoleColor.DarkYellow);
                    break;
            }
        }
    }
}
