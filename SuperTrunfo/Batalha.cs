using System;

namespace SuperTrunfo
{
    public class Batalha
    {
        public int IniciarBatalha(Pokemon pokemon1, Pokemon pokemon2, string atributoEscolhido)
        {
            ConsoleUI.EscreverSeparador();

            Console.Write("Batalha entre ");
            ConsoleUI.EscreverInline(pokemon1.Nome, ConsoleUI.CorDoTipo(pokemon1.TipoElemento));
            Console.Write(" e ");
            ConsoleUI.EscreverInline(pokemon2.Nome, ConsoleUI.CorDoTipo(pokemon2.TipoElemento));
            Console.WriteLine($"! Atributo: {atributoEscolhido}");

            decimal valor1 = pokemon1.ObterAtributo(atributoEscolhido) * Efetivo(pokemon1, pokemon2);
            decimal valor2 = pokemon2.ObterAtributo(atributoEscolhido) * Efetivo(pokemon2, pokemon1);

            Console.WriteLine($"{pokemon1.Nome}: {atributoEscolhido} efetivo = {valor1}");
            Console.WriteLine($"{pokemon2.Nome}: {atributoEscolhido} efetivo = {valor2}");

            if (valor1 > valor2)
            {
                ConsoleUI.Escrever($"{pokemon1.Nome} venceu a rodada!", ConsoleColor.Green);
                return 1;
            }

            if (valor2 > valor1)
            {
                ConsoleUI.Escrever($"{pokemon2.Nome} venceu a rodada!", ConsoleColor.Green);
                return 2;
            }

            ConsoleUI.Escrever("A rodada terminou em empate!", ConsoleColor.DarkYellow);
            return 0;
        }

        private decimal Efetivo(Pokemon atacante, Pokemon defensor)
        {
            return (atacante.TipoElemento, defensor.TipoElemento) switch
            {
                (Elementos.Fogo, Elementos.Planta) => 2m,
                (Elementos.Planta, Elementos.Fogo) => 0.5m,
                (Elementos.Agua, Elementos.Fogo) => 2m,
                (Elementos.Fogo, Elementos.Agua) => 0.5m,
                (Elementos.Agua, Elementos.Planta) => 0.5m,
                (Elementos.Planta, Elementos.Agua) => 2m,
                _ => 1m
            };
        }
    }
}