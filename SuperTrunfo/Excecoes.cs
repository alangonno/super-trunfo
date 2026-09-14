using System;

namespace SuperTrunfo
{
    // Classe base de todos os erros de regra do jogo.
    // Ter uma base comum permite que o Program capture qualquer erro do jogo
    // com um único catch (SuperTrunfoException).
    public class SuperTrunfoException : Exception
    {
        public SuperTrunfoException(string mensagem) : base(mensagem)
        {
        }
    }

    // Lançada por Pokemon.ObterAtributo quando o atributo digitado não existe.
    public class AtributoInvalidoException : SuperTrunfoException
    {
        public AtributoInvalidoException(string atributo)
            : base($"Atributo inválido: \"{atributo}\". Escolha Ataque ou Defesa.")
        {
        }
    }

    // Lançada por Jogador.EscolherPokemon quando o baralho já está completo.
    public class BaralhoCheioException : SuperTrunfoException
    {
        public BaralhoCheioException(string nomeJogador, int maximo)
            : base($"{nomeJogador} já tem {maximo} pokémons no baralho.")
        {
        }
    }

    // Lançada por Jogador.EscolherPokemon quando a carta já está no baralho.
    public class PokemonDuplicadoException : SuperTrunfoException
    {
        public PokemonDuplicadoException(string nomePokemon)
            : base($"{nomePokemon} já está no baralho. Escolha outro pokémon.")
        {
        }
    }

    // Lançada por Jogador.ProximoPokemon quando não há mais cartas.
    public class BaralhoVazioException : SuperTrunfoException
    {
        public BaralhoVazioException(string nomeJogador)
            : base($"{nomeJogador} não tem mais pokémons no baralho.")
        {
        }
    }
}
