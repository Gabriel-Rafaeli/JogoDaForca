namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static string[] letraCerta = new string[26];
        static string[] letraErrada = new string[26];
        static string letra;

        static int errosLimite = 0;

        static int contadorErrado = 0;
        static int contadorCerto = 0;

        static string palavraAleatoria;
        static string[] palavras =
            { "Abacate", "Abacaxi", "Acerola",
              "Acai", "Araca", "Bacaba", "Bacuri",
              "Banana", "Caja", "Caju", "Carambola",
              "Cupuacu", "Graviola", "Goiaba", "Jabuticaba",
              "Jenipapo", "Maca", "Mangaba", "Manga", "Maracuja",
              "Murici", "Pequi", "Pitanga", "Pitaya", "Sapoti",
              "Tangerina", "Umbu", "Uva", "Uvaia" };

        static void Main(string[] args)
        {
            Random random = new Random();
            int numeroPalavraAleatoria = random.Next(0, 29);
            palavraAleatoria = palavras[numeroPalavraAleatoria].ToUpper();

            Console.Clear();
            Console.WriteLine("*Jogo da Forca*");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                IniciarJogo();

            }
        }
        static void IniciarJogo()
        {
            char[] charPalavraAleatoria = palavraAleatoria.ToCharArray();


            do
            {
                int contadorDeLetrasEscritas = 0;
                Console.Clear();
                DesenharForca();

                if (errosLimite >= 5)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ACABARAM AS CHANCES, VOCÊ FOI ENFORCADO!");
                    Console.ResetColor();

                    Console.ReadLine();
                    return;
                }

                for (int i = 0; i < charPalavraAleatoria.Length; i++)
                {
                    if (letraCerta.Contains(charPalavraAleatoria[i].ToString()))
                    {
                        Console.Write(charPalavraAleatoria[i]);
                        contadorDeLetrasEscritas++;
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }

                if (palavraAleatoria.Length == contadorDeLetrasEscritas)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("VOCÊ VENCEU!");
                    Console.ResetColor();

                    Console.ReadLine();
                    return;
                }

                Console.WriteLine();
                Console.Write("Chute uma letra: ");
                letra = Console.ReadLine().ToUpper();

                ChecarLetraChutada(letra);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            } while (errosLimite < 5);
        }
        static void ChecarLetraChutada(string letra)
        {
            int posicaoLetra = palavraAleatoria.IndexOf(letra);


            if (posicaoLetra < 0)
            {
                letraErrada[contadorErrado] = letra;
                contadorErrado++;
                errosLimite++;

                Console.WriteLine("Letra Errada!");
                Console.ReadLine();
            }
            else if (posicaoLetra >= 0)
            {
                letraCerta[contadorCerto] = letra;
                contadorCerto++;

                Console.WriteLine("Acertou!");
                Console.ReadLine();
            }
        }
        static void DesenharForca()
        {
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" _____________     ");
                Console.WriteLine(" |           |     ");
                Console.WriteLine(" |           |     ");
                Console.WriteLine(" |          {0}       ", (errosLimite >= 1 ? " o " : " "));
                Console.WriteLine(" |          {0}{1}{2} ", (errosLimite >= 3 ? "/" : " "), (errosLimite >= 2 ? "x" : " "), (errosLimite >= 3 ? "\\" : " "));
                Console.WriteLine(" |          {0}       ", (errosLimite >= 2 ? " x " : " "));
                Console.WriteLine(" |          {0}       ", (errosLimite >= 4 ? "/ \\" : " "));
                Console.WriteLine(" |                 ");
                Console.WriteLine(" |                 ");
                Console.WriteLine("_|_                ");
                Console.ResetColor();
                Console.WriteLine("\n\n");
            }
        }
    }
}