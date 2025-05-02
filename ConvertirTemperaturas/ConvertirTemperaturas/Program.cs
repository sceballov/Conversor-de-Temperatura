using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertirTemperaturas
{
    using System;

    public class TemperaturaFahrenheit
    {
        public double Grados { get; set; }

        public TemperaturaFahrenheit(double grados)
        {
            Grados = grados;
        }

        public static implicit operator TemperaturaCelsius(TemperaturaFahrenheit f)
        {
            double celsius = (f.Grados - 32) * 5 / 9;
            double rounded = Math.Round(celsius, 2);
            return new TemperaturaCelsius(rounded == Math.Floor(rounded) ? Math.Floor(rounded) : rounded);
        }

        public override string ToString()
        {
            return Grados % 1 == 0 ? $"{Grados:0} °F" : $"{Grados} °F";
        }
    }

    public class TemperaturaCelsius
    {
        public double Grados { get; set; }

        public TemperaturaCelsius(double grados)
        {
            Grados = grados;
        }

        public static implicit operator TemperaturaFahrenheit(TemperaturaCelsius c)
        {
            double fahrenheit = (c.Grados * 9 / 5) + 32;
            double rounded = Math.Round(fahrenheit, 2);
            return new TemperaturaFahrenheit(rounded == Math.Floor(rounded) ? Math.Floor(rounded) : rounded);
        }

        public override string ToString()
        {
            return Grados % 1 == 0 ? $"{Grados:0} °C" : $"{Grados} °C";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("CONVERSOR DE TEMPERATURAS");
                    Console.WriteLine("1. Fahrenheit a Celsius");
                    Console.WriteLine("2. Celsius a Fahrenheit");
                    Console.WriteLine("3. Salir");
                    Console.Write("Seleccione una opción: ");

                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            ConvertirFahrenheitACelsius();
                            break;
                        case "2":
                            ConvertirCelsiusAFahrenheit();
                            break;
                        case "3":
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("El programa continuará funcionando...");
                    Console.ReadKey();
                }
            }
        }

        static void ConvertirFahrenheitACelsius()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese grados Fahrenheit: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Debe ingresar un valor");

                if (!double.TryParse(input, out double fahrenheit))
                    throw new FormatException("Debe ingresar un número válido");

                TemperaturaFahrenheit tempF = new TemperaturaFahrenheit(fahrenheit);
                TemperaturaCelsius tempC = tempF; // Conversión implícita

                Console.WriteLine($"\n{tempF} equivale a {tempC}");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError en conversión: {ex.Message}");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void ConvertirCelsiusAFahrenheit()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese grados Celsius: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Debe ingresar un valor");

                if (!double.TryParse(input, out double celsius))
                    throw new FormatException("Debe ingresar un número válido");

                TemperaturaCelsius tempC = new TemperaturaCelsius(celsius);
                TemperaturaFahrenheit tempF = tempC; // Conversión implícita

                Console.WriteLine($"\n{tempC} equivale a {tempF}");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError en conversión: {ex.Message}");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
