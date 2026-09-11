using System;

namespace SuperTrunfo
{
    public class Pokemon
    {
        public string Nome { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public Elementos TipoElemento { get; set; }

        public int ObterAtributo(string nomeAtributo)
        {
            return nomeAtributo switch
            {
                "Ataque" => Ataque,
                "Defesa" => Defesa,
                _ => throw new ArgumentException("Atributo inválido")
            };
        }
    }
}