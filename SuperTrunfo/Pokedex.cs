using System.Collections.Generic;

namespace SuperTrunfo
{
    // Lista de cartas disponíveis para os dois jogadores: 3 de cada tipo.
    public static class Pokedex
    {
        public static List<Pokemon> Todos { get; } = new List<Pokemon>
        {
            new Pokemon { Nome = "Charmander", Ataque = 52, Defesa = 43, TipoElemento = Elementos.Fogo },
            new Pokemon { Nome = "Magmar",     Ataque = 55, Defesa = 40, TipoElemento = Elementos.Fogo },
            new Pokemon { Nome = "Growlithe",  Ataque = 70, Defesa = 45, TipoElemento = Elementos.Fogo },
            new Pokemon { Nome = "Bulbasaur",  Ataque = 49, Defesa = 49, TipoElemento = Elementos.Planta },
            new Pokemon { Nome = "Ivysaur",    Ataque = 62, Defesa = 63, TipoElemento = Elementos.Planta },
            new Pokemon { Nome = "Oddish",     Ataque = 50, Defesa = 55, TipoElemento = Elementos.Planta },
            new Pokemon { Nome = "Squirtle",   Ataque = 48, Defesa = 65, TipoElemento = Elementos.Agua },
            new Pokemon { Nome = "Wartortle",  Ataque = 63, Defesa = 80, TipoElemento = Elementos.Agua },
            new Pokemon { Nome = "Psyduck",    Ataque = 52, Defesa = 48, TipoElemento = Elementos.Agua }
        };
    }
}
