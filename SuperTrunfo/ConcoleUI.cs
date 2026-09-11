using System;

namespace SuperTrunfo
{
    public static class ConsoleUI
    {
        public static void EscreverTitulo(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n=== {texto} ===");
            Console.ResetColor();
        }

        public static void EscreverSeparador()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('-', 44));
            Console.ResetColor();
        }

        public static void Escrever(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static void EscreverInline(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(texto);
            Console.ResetColor();
        }

        public static ConsoleColor CorDoTipo(Elementos tipo)
        {
            return tipo switch
            {
                Elementos.Fogo => ConsoleColor.Red,
                Elementos.Planta => ConsoleColor.Green,
                Elementos.Agua => ConsoleColor.Cyan,
                _ => ConsoleColor.White
            };
        }
    }
}