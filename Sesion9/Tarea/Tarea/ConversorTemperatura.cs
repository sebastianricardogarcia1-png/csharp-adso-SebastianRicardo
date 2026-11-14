using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea
{
    internal class ConversorTemperatura
    {


            public static double Convertir(double valor, string origen, string destino)
            {
                double celsius = 0;

                // Convertimos primero a Celsius
                if (origen == "Celsius")
                {
                    celsius = valor;
                }
                else if (origen == "Fahrenheit")
                {
                    celsius = (valor - 32) / 1.8;
                }
                else if (origen == "Kelvin")
                {
                    celsius = valor - 273.15;
                }

                // Convertimos de Celsius a la unidad de destino
                if (destino == "Celsius")
                {
                    return celsius;
                }
                else if (destino == "Fahrenheit")
                {
                    return (celsius * 1.8) + 32;
                }
                else if (destino == "Kelvin")
                {
                    return celsius + 273.15;
                }

                return celsius;
            }

    }
}
