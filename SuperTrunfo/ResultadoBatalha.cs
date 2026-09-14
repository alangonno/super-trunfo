namespace SuperTrunfo
{
    // Só guarda o resultado do cálculo da batalha.
    // Quem mostra isso na tela é o ConsoleUI, não a Batalha.
    public class ResultadoBatalha
    {
        public decimal ValorJogador1 { get; set; }
        public decimal ValorJogador2 { get; set; }
        public ResultadoRodada Vencedor { get; set; }
    }
}
