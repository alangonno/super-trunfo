using System.Collections.Generic;

namespace SuperTrunfo
{
    public static class Pokedex
    {
        public static List<Pokemon> Todos { get; } = new List<Pokemon>
        {
            new Pokemon { Nome = "Charmander", Ataque = 52, Defesa = 43, TipoElemento = Elementos.Fogo },
            new Pokemon { Nome = "Bulbasaur",  Ataque = 49, Defesa = 49, TipoElemento = Elementos.Planta },
            new Pokemon { Nome = "Squirtle",   Ataque = 48, Defesa = 65, TipoElemento = Elementos.Agua },
            new Pokemon { Nome = "Magmar",     Ataque = 55, Defesa = 40, TipoElemento = Elementos.Fogo },
            new Pokemon { Nome = "Ivysaur",    Ataque = 62, Defesa = 63, TipoElemento = Elementos.Planta },
            new Pokemon { Nome = "Wartortle",  Ataque = 63, Defesa = 80, TipoElemento = Elementos.Agua },
            // adicione o resto do seu time aqui
        };
    }
}