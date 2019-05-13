using System;

namespace Cifrado
{
    class Program
    {
        static void Main(string[] args)
        {
            Cesar cesar = new Cesar(6);

            Console.WriteLine(cesar.Encriptar("WIKIPEDIA, LA ENCICLOPEDIA LIBRE"));


        }
    }
}
