using System;
using System.IO;
using Xunit;
using SuperTrunfo;

namespace SuperTrunfo.Tests
{
    public class IniciarBatalhaTests : IDisposable
    {
        private const string ATRIBUTO_ATAQUE = "Ataque";

        private readonly Batalha _batalha = new Batalha();
        private readonly TextWriter _consoleOriginal;

        public IniciarBatalhaTests()
        {
            // Isola o teste da saída de Console (a impressão é apresentação, não a regra testada)
            _consoleOriginal = Console.Out;
            Console.SetOut(TextWriter.Null);
        }

        public void Dispose()
        {
            Console.SetOut(_consoleOriginal);
        }

        [Fact]
        public void IniciarBatalha_WhenPokemon1HasHigherEffectiveValue_ReturnsOne()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Bulbasaur", TipoElemento = Elementos.Planta, Ataque = 50 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_ATAQUE);

            // Assert
            Assert.Equal(1, resultado);
        }

        [Fact]
        public void IniciarBatalha_WhenPokemon2HasHigherEffectiveValue_ReturnsTwo()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Bulbasaur", TipoElemento = Elementos.Planta, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_ATAQUE);

            // Assert
            Assert.Equal(2, resultado);
        }

        [Fact]
        public void IniciarBatalha_WhenBothHaveEqualEffectiveValue_ReturnsZero()
        {
            // Arrange
            var pokemon1 = new Pokemon { Nome = "Charmander", TipoElemento = Elementos.Fogo, Ataque = 50 };
            var pokemon2 = new Pokemon { Nome = "Growlithe", TipoElemento = Elementos.Fogo, Ataque = 50 };

            // Act
            var resultado = _batalha.IniciarBatalha(pokemon1, pokemon2, ATRIBUTO_ATAQUE);

            // Assert
            Assert.Equal(0, resultado);
        }
    }
}