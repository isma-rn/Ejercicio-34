using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E34_BinarioADecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            string opcion, numeroBinario;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Programa que convierte número binario a decimal\nIngrese número Binario:");
                numeroBinario = Console.ReadLine();
                if ( ValidarNumeroBinario( numeroBinario ) )
                    Console.WriteLine("Resultado {0}", ConvertirBinarioADecimal( numeroBinario ) );
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error no se puede convertir...");
                }
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("n : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);
            } while (!salir);
        }
        public static int ConvertirBinarioADecimal(string numero)
        {            
            int resultado = 0;
            char[] numeros = numero.ToCharArray();
            Array.Reverse(numeros);
            for(int i = 0; i < numeros.Length; i++)
                if( numeros[i] != '0' )
                    resultado += (int)Math.Pow(2, i) * Int32.Parse(numeros[i].ToString());
            return resultado;
        }
        public static bool ValidarNumeroBinario(string numero)
        {
            Regex patron = new Regex("^[0-1]+$");
            return patron.IsMatch(numero);
        }
    }
}
