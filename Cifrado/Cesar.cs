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
        private static string caracteres = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~áéíóúÁÉÍÓÚ";

        public Cesar(int desplazamiento)
        {
            this.desplazamiento = desplazamiento;        }

        public string Cifrar(string cadena, TipoCifrado tipo) {

            string nuevo = "";

            switch(tipo) {
                case TipoCifrado.Encriptar:
                    for(int i = 0; i < cadena.Length; i++)
                    {
                        if (!Char.IsLetter(cadena[i]) || cadena[i].Equals((char)AcentosMay.A) || cadena[i].Equals((char)AcentosMay.E) || 
                            cadena[i].Equals((char)AcentosMay.I) || cadena[i].Equals((char)AcentosMay.O) || cadena[i].Equals((char)AcentosMay.U) || 
                            cadena[i].Equals((char)AcentosMin.a) || cadena[i].Equals((char)AcentosMin.e) || cadena[i].Equals((char)AcentosMin.i) || 
                            cadena[i].Equals((char)AcentosMin.o) || cadena[i].Equals((char)AcentosMin.u))
                        {
                            if(Char.IsDigit(cadena[i])) 
                            {
                                nuevo += numeros[ObtenerPosicion(cadena[i], TipoCaracter.Numero, 
                                    TipoDesplazamiento.Derecha)];
                            } 
                            else {
                                nuevo += caracteres[ObtenerPosicion(cadena[i], TipoCaracter.Simbolo,
                                    TipoDesplazamiento.Derecha)];
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
                        if (!Char.IsLetter(cadena[i]) || cadena[i].Equals((char)AcentosMay.A) || cadena[i].Equals((char)AcentosMay.E) ||
                            cadena[i].Equals((char)AcentosMay.I) || cadena[i].Equals((char)AcentosMay.O) || cadena[i].Equals((char)AcentosMay.U) ||
                            cadena[i].Equals((char)AcentosMin.a) || cadena[i].Equals((char)AcentosMin.e) || cadena[i].Equals((char)AcentosMin.i) ||
                            cadena[i].Equals((char)AcentosMin.o) || cadena[i].Equals((char)AcentosMin.u))
                        {
                            if(Char.IsDigit(cadena[i])) 
                            {
                                nuevo += numeros[ObtenerPosicion(cadena[i], TipoCaracter.Numero, 
                                    TipoDesplazamiento.Izquierda)];
                            }
                            else 
                            {
                                nuevo += caracteres[ObtenerPosicion(cadena[i], TipoCaracter.Simbolo,
                                    TipoDesplazamiento.Izquierda)];
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

            for (int i = 0; i < caracteres.Length; i++)
            {
                if(caracter.Equals(caracteres[i])) {
                    posicion = i;
                    break;
                }

                if(i < alfabetoMay.Length)
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
                            posicion += desplazamiento;
                            posicion = (posicion > caracteres.Length - 1) ? (posicion - caracteres.Length) : posicion;
                        break;
                        case TipoDesplazamiento.Izquierda:
                            posicion -= desplazamiento;
                            posicion = (posicion < 0) ? (caracteres.Length - Math.Abs(posicion)) : posicion;
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

        private enum AcentosMay
        {
            A = 'Á',
            E = 'É',
            I = 'Í',
            O = 'Ó',
            U = 'Ú'
        }

        private enum AcentosMin
        {
            a = 'á',
            e = 'é',
            i = 'í',
            o = 'ó',
            u = 'ú'
        }

    }
}
