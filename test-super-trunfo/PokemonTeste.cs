using Xunit;
using SuperTrunfo;

namespace SuperTrunfo.Tests
{
    // Testa a classe Pokemon, principalmente o método ObterAtributo
    // e a exceção que ele lança.
    public class PokemonTests
    {
        private Pokemon CriarCharmander()
        {
            return new Pokemon
            {
                Nome = "Charmander",
                Ataque = 52,
                Defesa = 43,
                TipoElemento = Elementos.Fogo
            };
        }

        [Fact]
        public void ObterAtributo_WhenAttributeIsAtaque_ReturnsAtaqueValue()
        {
            // Arrange
            var pokemon = CriarCharmander();

            // Act
            var resultado = pokemon.ObterAtributo("Ataque");

            // Assert
            Assert.Equal(52, resultado);
        }

        [Fact]
        public void ObterAtributo_WhenAttributeIsDefesa_ReturnsDefesaValue()
        {
            // Arrange
            var pokemon = CriarCharmander();

            // Act
            var resultado = pokemon.ObterAtributo("Defesa");

            // Assert
            Assert.Equal(43, resultado);
        }

        [Theory]
        [InlineData("ataque")]
        [InlineData("ATAQUE")]
        [InlineData("  Ataque  ")]
        public void ObterAtributo_WhenAttributeHasDifferentCaseOrSpaces_StillReturnsAtaqueValue(string entrada)
        {
            // Arrange
            var pokemon = CriarCharmander();

            // Act
            var resultado = pokemon.ObterAtributo(entrada);

            // Assert
            Assert.Equal(52, resultado);
        }

        [Fact]
        public void ObterAtributo_WhenAttributeDoesNotExist_ThrowsAtributoInvalidoException()
        {
            // Arrange
            var pokemon = CriarCharmander();

            // Act + Assert
            Assert.Throws<AtributoInvalidoException>(() => pokemon.ObterAtributo("Velocidade"));
        }

        [Fact]
        public void ObterAtributo_WhenAttributeIsEmpty_ThrowsAtributoInvalidoException()
        {
            // Arrange
            var pokemon = CriarCharmander();

            // Act + Assert
            Assert.Throws<AtributoInvalidoException>(() => pokemon.ObterAtributo(""));
        }

        [Theory]
        [InlineData("ataque", "Ataque")]
        [InlineData("  ATAQUE  ", "Ataque")]
        [InlineData("defesa", "Defesa")]
        [InlineData("  Defesa ", "Defesa")]
        public void NormalizarAtributo_WhenAttributeIsValid_ReturnsTheCanonicalName(string entrada, string esperado)
        {
            // Act
            var resultado = Pokemon.NormalizarAtributo(entrada);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void NormalizarAtributo_WhenAttributeDoesNotExist_ThrowsAtributoInvalidoException()
        {
            // Act + Assert
            Assert.Throws<AtributoInvalidoException>(() => Pokemon.NormalizarAtributo("Velocidade"));
        }

        [Fact]
        public void AtributoInvalidoException_IsASuperTrunfoException()
        {
            // Arrange
            var pokemon = CriarCharmander();

            // Act
            var erro = Assert.Throws<AtributoInvalidoException>(() => pokemon.ObterAtributo("Velocidade"));

            // Assert — prova que o catch (SuperTrunfoException) do Program pega esta exceção.
            Assert.IsAssignableFrom<SuperTrunfoException>(erro);
        }
    }
}
