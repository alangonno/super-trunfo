using System;
using Xunit;
using SuperTrunfo;

namespace SuperTrunfo.Tests
{
    // Testa o baralho do jogador: limite de 3 cartas, cartas repetidas
    // e a ordem de saída (fila FIFO).
    public class JogadorTests
    {
        private Pokemon CriarPokemon(string nome)
        {
            return new Pokemon
            {
                Nome = nome,
                Ataque = 50,
                Defesa = 50,
                TipoElemento = Elementos.Fogo
            };
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_WhenNameIsEmpty_ThrowsArgumentException(string nome)
        {
            // Act + Assert
            Assert.Throws<ArgumentException>(() => new Jogador(nome));
        }

        [Fact]
        public void EscolherPokemon_WhenDeckHasSpace_AddsPokemonToDeck()
        {
            // Arrange
            var jogador = new Jogador("Ash");
            var pikachu = CriarPokemon("Pikachu");

            // Act
            jogador.EscolherPokemon(pikachu);

            // Assert
            Assert.Single(jogador.Baralho);
        }

        [Fact]
        public void EscolherPokemon_WhenDeckIsFull_ThrowsBaralhoCheioException()
        {
            // Arrange
            var jogador = new Jogador("Ash");
            jogador.EscolherPokemon(CriarPokemon("Charmander"));
            jogador.EscolherPokemon(CriarPokemon("Bulbasaur"));
            jogador.EscolherPokemon(CriarPokemon("Squirtle"));

            // Act + Assert — a quarta carta não entra.
            Assert.Throws<BaralhoCheioException>(() => jogador.EscolherPokemon(CriarPokemon("Pikachu")));
        }

        [Fact]
        public void EscolherPokemon_WhenPokemonIsAlreadyInDeck_ThrowsPokemonDuplicadoException()
        {
            // Arrange
            var jogador = new Jogador("Ash");
            var charmander = CriarPokemon("Charmander");
            jogador.EscolherPokemon(charmander);

            // Act + Assert
            Assert.Throws<PokemonDuplicadoException>(() => jogador.EscolherPokemon(charmander));
        }

        [Fact]
        public void ProximoPokemon_ReturnsPokemonsInTheOrderTheyWereChosen()
        {
            // Arrange
            var jogador = new Jogador("Ash");
            var primeiro = CriarPokemon("Charmander");
            var segundo = CriarPokemon("Bulbasaur");
            var terceiro = CriarPokemon("Squirtle");
            jogador.EscolherPokemon(primeiro);
            jogador.EscolherPokemon(segundo);
            jogador.EscolherPokemon(terceiro);

            // Act
            var carta1 = jogador.ProximoPokemon();
            var carta2 = jogador.ProximoPokemon();
            var carta3 = jogador.ProximoPokemon();

            // Assert
            Assert.Equal("Charmander", carta1.Nome);
            Assert.Equal("Bulbasaur", carta2.Nome);
            Assert.Equal("Squirtle", carta3.Nome);
        }

        [Fact]
        public void ProximoPokemon_RemovesThePokemonFromTheDeck()
        {
            // Arrange
            var jogador = new Jogador("Ash");
            jogador.EscolherPokemon(CriarPokemon("Charmander"));
            jogador.EscolherPokemon(CriarPokemon("Bulbasaur"));

            // Act
            jogador.ProximoPokemon();

            // Assert
            Assert.Single(jogador.Baralho);
        }

        [Fact]
        public void ProximoPokemon_WhenDeckIsEmpty_ThrowsBaralhoVazioException()
        {
            // Arrange
            var jogador = new Jogador("Ash");

            // Act + Assert
            Assert.Throws<BaralhoVazioException>(() => jogador.ProximoPokemon());
        }
    }
}
