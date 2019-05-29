using System;

namespace Cifrado
{
    class Program
    {
        static void Main(string[] args)
        {
            Cesar cesar = new Cesar(6);

            string cifrado = cesar.Cifrar("WIKIPEDIA, LA ENCICLOPEDIA LIBRE", Cesar.Tipo.Encriptar);

            Console.WriteLine(cifrado);

            Console.WriteLine(cesar.Cifrar(cifrado, Cesar.Tipo.Desencriptar));

            Cesar.Imprimir();

        }
    }
}
