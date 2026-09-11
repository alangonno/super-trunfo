using System;
using System.Collections.Generic;

namespace SuperTrunfo
{
    public class Jogador
    {
        private const int MaxPokemonsNoBaralho = 3;

        public string Nome { get; internal set; }
        public Queue<Pokemon> Baralho { get; } = new Queue<Pokemon>();

        public Jogador(string nome)
        {
            Nome = nome;
        }

        public bool EscolherPokemon(Pokemon pokemon)
        {
            if (Baralho.Count >= MaxPokemonsNoBaralho)
            {
                Console.WriteLine($"{Nome} já tem {MaxPokemonsNoBaralho} pokémons no baralho.");
                return false;
            }

            Baralho.Enqueue(pokemon);
            return true;
        }

        public Pokemon ProximoPokemon()
        {
            if (Baralho.Count == 0)
            {
                Console.WriteLine($"{Nome} não tem mais pokémons no baralho!");
                return null;
            }

            return Baralho.Dequeue();
        }
    }
}