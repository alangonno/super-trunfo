using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTrunfo
{
    public class Pokemon
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public int vida { get; set; }

    
        public decimal Efetivo(Pokemon pokemon1, Pokemon pokemon2)
        {
            return (pokemon1.Tipo, pokemon2.Tipo) switch
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
