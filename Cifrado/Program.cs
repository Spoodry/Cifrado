using System;

namespace Cifrado
{
    class Program
    {
        static void Main(string[] args)
        {
            Cesar cesar = new Cesar(6);

            string cadena = "Juan Pablo Altamirano Flores, 2798";

            string cifrado = cesar.Cifrar(cadena, Cesar.TipoCifrado.Encriptar);

            Console.WriteLine(cifrado);

            Console.WriteLine(cesar.Cifrar(cifrado, Cesar.TipoCifrado.Desencriptar));

        }
    }
}
