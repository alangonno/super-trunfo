using Xunit;
using SuperTrunfo;

namespace SuperTrunfo.Tests
{
    // Testa a tabela de efetividade: Fogo > Planta > Água > Fogo.
    public class EfetivoTests
    {
        private readonly Batalha _batalha = new Batalha();

        // [Theory] + [InlineData] roda o MESMO teste com vários dados diferentes.
        [Theory]
        [InlineData(Elementos.Fogo, Elementos.Planta, 2.0)]
        [InlineData(Elementos.Planta, Elementos.Fogo, 0.5)]
        [InlineData(Elementos.Agua, Elementos.Fogo, 2.0)]
        [InlineData(Elementos.Fogo, Elementos.Agua, 0.5)]
        [InlineData(Elementos.Planta, Elementos.Agua, 2.0)]
        [InlineData(Elementos.Agua, Elementos.Planta, 0.5)]
        [InlineData(Elementos.Fogo, Elementos.Fogo, 1.0)]
        [InlineData(Elementos.Planta, Elementos.Planta, 1.0)]
        [InlineData(Elementos.Agua, Elementos.Agua, 1.0)]
        public void Efetivo_WhenGivenAttackerAndDefenderTypes_ReturnsExpectedMultiplier(
            Elementos tipoAtacante, Elementos tipoDefensor, decimal multiplicadorEsperado)
        {
            // Arrange
            var atacante = new Pokemon { Nome = "Atacante", TipoElemento = tipoAtacante };
            var defensor = new Pokemon { Nome = "Defensor", TipoElemento = tipoDefensor };

            // Act
            var resultado = _batalha.Efetivo(atacante, defensor);

            // Assert
            Assert.Equal(multiplicadorEsperado, resultado);
        }
    }
}
