namespace SuperTrunfo
{
    public class Batalha
    {
        // Esta classe só calcula. Ela não escreve nada na tela.
        // Por isso dá para testá-la sem precisar redirecionar o Console.
        public ResultadoBatalha IniciarBatalha(Pokemon pokemon1, Pokemon pokemon2, string atributoEscolhido)
        {
            // Se o atributo não existir, ObterAtributo lança AtributoInvalidoException
            // e ela sobe (propaga) para quem chamou IniciarBatalha.
            decimal valor1 = pokemon1.ObterAtributo(atributoEscolhido) * Efetivo(pokemon1, pokemon2);
            decimal valor2 = pokemon2.ObterAtributo(atributoEscolhido) * Efetivo(pokemon2, pokemon1);

            ResultadoBatalha resultado = new ResultadoBatalha();
            resultado.ValorJogador1 = valor1;
            resultado.ValorJogador2 = valor2;

            if (valor1 > valor2)
            {
                resultado.Vencedor = ResultadoRodada.Jogador1;
            }
            else if (valor2 > valor1)
            {
                resultado.Vencedor = ResultadoRodada.Jogador2;
            }
            else
            {
                resultado.Vencedor = ResultadoRodada.Empate;
            }

            return resultado;
        }

        // Tabela de efetividade: Fogo > Planta > Água > Fogo.
        // 2 = vantagem, 0,5 = desvantagem, 1 = neutro.
        public decimal Efetivo(Pokemon atacante, Pokemon defensor) => (atacante.TipoElemento, defensor.TipoElemento) switch
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
