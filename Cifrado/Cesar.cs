using System;
using System.Collections.Generic;
using System.Text;

namespace Cifrado
{
    class Cesar
    {

        private int desplazamiento;
        private static string alfabetoMay = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        private static string alfabetoMin = alfabetoMay.ToLower();
        private static string numeros = "0123456789";

        public Cesar(int desplazamiento)
        {
            this.desplazamiento = desplazamiento;        }

        public string Cifrar(string cadena, TipoCifrado tipo) {

            string nuevo = "";

            switch(tipo) {
                case TipoCifrado.Encriptar:
                    for(int i = 0; i < cadena.Length; i++)
                    {
                        if (!Char.IsLetter(cadena[i]))
                        {
                            if(Char.IsDigit(cadena[i])) 
                            {
                                nuevo += numeros[ObtenerPosicion(cadena[i], TipoCaracter.Numero, 
                                    TipoDesplazamiento.Derecha)];
                            } 
                            else {
                                nuevo += (char)ObtenerPosicion(cadena[i], TipoCaracter.Simbolo,
                                    TipoDesplazamiento.Derecha);
                            }
                        }
                        else
                        {
                            if(Char.IsUpper(cadena[i])) 
                            {
                                nuevo += alfabetoMay[ObtenerPosicion(cadena[i], TipoCaracter.Letra, 
                                    TipoDesplazamiento.Derecha)];
                            } 
                            else 
                            {
                                nuevo += alfabetoMin[ObtenerPosicion(cadena[i], TipoCaracter.Letra, 
                                    TipoDesplazamiento.Derecha)];
                            }
                            
                        }
                    }
                break;
                case TipoCifrado.Desencriptar:
                    for(int i = 0; i < cadena.Length; i++)
                    {
                        if (!Char.IsLetter(cadena[i]))
                        {
                            if(Char.IsDigit(cadena[i])) 
                            {
                                nuevo += numeros[ObtenerPosicion(cadena[i], TipoCaracter.Numero, 
                                    TipoDesplazamiento.Izquierda)];
                            }
                            else 
                            {
                                nuevo += (char)ObtenerPosicion(cadena[i], TipoCaracter.Simbolo,
                                    TipoDesplazamiento.Izquierda);
                            }
                        }
                        else
                        {
                            if(Char.IsUpper(cadena[i])) 
                            {
                                nuevo += alfabetoMay[ObtenerPosicion(cadena[i], TipoCaracter.Letra, 
                                    TipoDesplazamiento.Izquierda)];
                            }
                            else 
                            {
                                nuevo += alfabetoMin[ObtenerPosicion(cadena[i], TipoCaracter.Letra, 
                                    TipoDesplazamiento.Izquierda)];
                            }
                            
                        }
                    }
                break;
            }

            return nuevo;

        }

        private int ObtenerPosicion(char caracter, TipoCaracter t, TipoDesplazamiento e)
        {
            int posicion = 0;

            if(t == TipoCaracter.Letra || t == TipoCaracter.Numero)
                for (int i = 0; i < alfabetoMay.Length; i++)
                {
                    if (caracter.Equals(alfabetoMay[i]) || caracter.Equals(alfabetoMin[i]))
                    {
                        posicion = i;
                        break;
                    }
                    if(i < numeros.Length)
                        if(caracter.Equals(numeros[i]))
                        {
                            posicion = i;
                            break;
                        }
                }

            switch(t) 
            {
                case TipoCaracter.Letra:
                    switch (e)
                    {
                        case TipoDesplazamiento.Derecha:
                            posicion += desplazamiento;
                            posicion = (posicion > alfabetoMay.Length - 1) ? (posicion - alfabetoMay.Length) : posicion;
                            break;
                        case TipoDesplazamiento.Izquierda:
                            posicion -= desplazamiento;
                            posicion = (posicion < 0) ? (alfabetoMay.Length - Math.Abs(posicion)) : posicion;
                            break;
                    }
                break;
                case TipoCaracter.Numero:
                    switch(e) 
                    {
                        case TipoDesplazamiento.Derecha:
                            posicion += desplazamiento;
                            posicion = (posicion > numeros.Length - 1) ? (posicion - numeros.Length) : posicion;
                        break;
                        case TipoDesplazamiento.Izquierda:
                            posicion -= desplazamiento;
                            posicion = (posicion < 0) ? (numeros.Length - Math.Abs(posicion)) : posicion;
                        break;
                    }
                break;
                case TipoCaracter.Simbolo:
                    switch(e) {
                        case TipoDesplazamiento.Derecha:
                            posicion = (int)caracter + desplazamiento;
                            posicion = (posicion > 256 - 1) ? (posicion - 256) : posicion;
                        break;
                        case TipoDesplazamiento.Izquierda:
                            posicion = (int)caracter - desplazamiento;
                            posicion = (posicion < 0) ? (256 - Math.Abs(posicion)) : posicion;
                        break;
                    }
                break;
            }

            return posicion;

        }
        
        enum TipoDesplazamiento
        {
            Derecha,
            Izquierda
        }

        public enum TipoCifrado{
            Encriptar,
            Desencriptar
        }

        private enum TipoCaracter {
            Letra,
            Numero,
            Simbolo
        }

    }
}
