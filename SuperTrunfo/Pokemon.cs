using System;

namespace SuperTrunfo
{
    public class Pokemon
    {
        public string Nome { get; set; } = string.Empty;
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public Elementos TipoElemento { get; set; }

        // Confere se o atributo existe e devolve o nome no formato certo
        // ("Ataque" ou "Defesa"). Se não existir, lança AtributoInvalidoException.
        // É static porque a regra vale para qualquer pokémon, não para um em especial.
        public static string NormalizarAtributo(string nomeAtributo)
        {
            // Trim() tira os espaços das pontas e ToLower() deixa tudo minúsculo,
            // então "  ATAQUE " e "ataque" funcionam igual.
            string atributo = (nomeAtributo ?? string.Empty).Trim().ToLower();

            switch (atributo)
            {
                case "ataque":
                    return "Ataque";

                case "defesa":
                    return "Defesa";

                default:
                    throw new AtributoInvalidoException(nomeAtributo ?? string.Empty);
            }
        }

        // Devolve o valor do atributo pedido.
        public int ObterAtributo(string nomeAtributo)
        {
            string atributo = NormalizarAtributo(nomeAtributo);

            if (atributo == "Ataque")
            {
                return Ataque;
            }

            return Defesa;
        }
    }
}
