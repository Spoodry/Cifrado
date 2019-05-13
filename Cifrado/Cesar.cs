using System;
using System.Collections.Generic;
using System.Text;

namespace Cifrado
{
    class Cesar
    {

        private int desplazamiento;
        private static string alfabeto = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

        enum TipoDesplazamiento
        {
            Derecha,
            Izquierda
        }

        public Cesar(int desplazamiento)
        {
            this.desplazamiento = desplazamiento;
        }

        public string Encriptar(string cadena)
        {
            string nuevo = "";

            for(int i = 0; i < cadena.Length; i++)
            {
                if (!EsLetra(cadena[i]))
                {
                    nuevo += cadena[i];
                }
                else
                {
                    nuevo += alfabeto[ObtenerPosicion(cadena[i], TipoDesplazamiento.Derecha)];
                }
            }
            
            return nuevo;
        }

        public string Desencriptar(string cadena)
        {
            string nuevo = "";

            for(int i = 0; i < cadena.Length; i++)
            {
                if (!EsLetra(cadena[i]))
                {
                    nuevo += cadena[i];
                }
                else
                {
                    nuevo += alfabeto[ObtenerPosicion(cadena[i], TipoDesplazamiento.Izquierda)];
                }
            }

            return nuevo;
        }

        private int ObtenerPosicion(char letra, TipoDesplazamiento e)
        {
            int posicion = 0;

            for (int i = 0; i < alfabeto.Length; i++)
            {
                if (letra.Equals(alfabeto[i]))
                {
                    posicion = i;
                    break;
                }
            }

            switch (e)
            {
                case TipoDesplazamiento.Derecha:
                    posicion += desplazamiento;
                    posicion = (posicion > alfabeto.Length - 1) ? (posicion - alfabeto.Length) : posicion;
                    break;
                case TipoDesplazamiento.Izquierda:
                    posicion -= desplazamiento;
                    posicion = (posicion < 0) ? (alfabeto.Length - Math.Abs(posicion)) : posicion;
                    break;
            }

            return posicion;

        }

        private bool EsLetra(char caracter)
        {
            bool band = false;
            string alfabetoMin = alfabeto.ToLower();

            for(int i = 0; i < alfabeto.Length; i++)
            {
                if(caracter.Equals(alfabeto[i]) || caracter.Equals(alfabetoMin[i]))
                {
                    band = true;
                    break;
                }
            }

            return band;
        }

    }
}
