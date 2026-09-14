using System;
using System.Collections.Generic;

namespace SuperTrunfo
{
    public class Jogador
    {
        // public para o Program usar a constante em vez de escrever 3 na mão.
        public const int MaxPokemonsNoBaralho = 3;

        public string Nome { get; }

        // Queue = fila (FIFO): a primeira carta escolhida é a primeira a jogar.
        public Queue<Pokemon> Baralho { get; } = new Queue<Pokemon>();

        public Jogador(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do jogador não pode ser vazio.", nameof(nome));
            }

            Nome = nome.Trim();
        }

        // Adiciona uma carta ao baralho. Em vez de imprimir na tela e devolver
        // false, avisa o erro lançando uma exceção — quem chamou decide o que fazer.
        public void EscolherPokemon(Pokemon pokemon)
        {
            if (Baralho.Count >= MaxPokemonsNoBaralho)
            {
                throw new BaralhoCheioException(Nome, MaxPokemonsNoBaralho);
            }

            if (Baralho.Contains(pokemon))
            {
                throw new PokemonDuplicadoException(pokemon.Nome);
            }

            Baralho.Enqueue(pokemon);
        }

        // Tira a próxima carta da fila. Dequeue já remove do baralho.
        public Pokemon ProximoPokemon()
        {
            if (Baralho.Count == 0)
            {
                throw new BaralhoVazioException(Nome);
            }

            return Baralho.Dequeue();
        }
    }
}
