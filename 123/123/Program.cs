using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarera2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                MostrarMenu();

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            EjercicioTiendaCamisas();
                            break;
                        case 2:
                            EjercicioPromedioEstudiante();
                            break;
                        case 3:
                            EjercicioVendedorProductos();
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opción incorrecta. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
                }

                Console.WriteLine();
            } while (opcion != 4);
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("**Menú de Ejercicios**");
            Console.WriteLine("1- Ejercicio #1 de Tienda de Camisas");
            Console.WriteLine("2- Ejercicio #2 de Promedio de Estudiante");
            Console.WriteLine("3- Ejercicio #3 de Vendedor de Productos");
            Console.WriteLine("4- Salir");
            Console.Write("Seleccione una opción (1-4): ");
        }

        static float LeerFloat(string mensaje)
        {
            Console.Write(mensaje);
            return float.Parse(Console.ReadLine());
        }

        static int LeerInt(string mensaje)
        {
            Console.Write(mensaje);
            return int.Parse(Console.ReadLine());
        }

        static void MostrarResultado(string mensaje, float valor)
        {
            Console.WriteLine($"{mensaje}{valor}");
        }

        static void MostrarResultados(string[] etiquetas, string[] valores)
        {
            Console.WriteLine("**Resultados**");
            for (int i = 0; i < etiquetas.Length; i++)
            {
                Console.WriteLine($"{etiquetas[i]} {valores[i]}");
            }
        }

        static void EjercicioTiendaCamisas()
        {
            Console.Clear();
            Console.WriteLine("**Ejercicio de Tienda de Camisas**");
            float precioCamisa = LeerFloat("Ingrese el precio de una camisa: ");
            int cantidadCamisas = LeerInt("Ingrese la cantidad de camisas: ");
            float total = CalcularPrecioCamisas(precioCamisa, cantidadCamisas);
            MostrarResultado("El precio total es: $", total);
        }

        static float CalcularPrecioCamisas(float precioUnitario, int cantidad)
        {
            float descuento = 0.0f;
            if (cantidad >= 2 && cantidad <= 5)
            {
                descuento = 0.15f;
            }
            else if (cantidad > 5)
            {
                descuento = 0.20f;
            }
            return cantidad * precioUnitario * (1 - descuento);
        }

        static void EjercicioPromedioEstudiante()
        {
            Console.Clear();
            Console.WriteLine("**Ejercicio de Promedio de Estudiante**");

            string carnet = Console.ReadLine();
            string nombre = Console.ReadLine();
            float[] notas = LeerNotas();
            float promedioFinal = CalcularPromedioFinal(notas);
            string condicion = CalcularCondicion(promedioFinal);

            string[] etiquetas = { "Carnet:", "Nombre:", "Porcentaje de quices:", "Porcentaje de tareas:", "Porcentaje de exámenes:", "Promedio final:", "Condición:" };
            string[] valores = { carnet, nombre, CalcularPorcentaje(notas, 0, 2, 0.25f) + "%", CalcularPorcentaje(notas, 3, 5, 0.30f) + "%", CalcularPorcentaje(notas, 6, 8, 0.45f) + "%", promedioFinal.ToString(), condicion };
            MostrarResultados(etiquetas, valores);
        }

        static float[] LeerNotas()
        {
            float[] notas = new float[9];
            for (int i = 0; i < notas.Length; i++)
            {
                notas[i] = Math.Max(0, Math.Min(100, LeerFloat($"Ingrese la nota {i + 1}: ")));
            }
            return notas;
        }

        static float CalcularPromedioFinal(float[] notas)
        {
            float porcentajeQuices = CalcularPorcentaje(notas, 0, 2, 0.25f);
            float porcentajeTareas = CalcularPorcentaje(notas, 3, 5, 0.30f);
            float porcentajeExamenes = CalcularPorcentaje(notas, 6, 8, 0.45f);
            return Math.Min(100, porcentajeQuices + porcentajeTareas + porcentajeExamenes);
        }

        static float CalcularPorcentaje(float[] notas, int inicio, int fin, float porcentaje)
        {
            float suma = 0.0f;
            for (int i = inicio; i <= fin; i++)
            {
                suma += notas[i];
            }
            return suma * porcentaje;
        }

        static string CalcularCondicion(float promedio)
        {
            if (promedio >= 70)
            {
                return "Aprobado";
            }
            else if (promedio >= 50)
            {
                return "Aplazado";
            }
            else
            {
                return "Reprobado";
            }
        }

        static void EjercicioVendedorProductos()
        {
            Console.Clear();
            Console.WriteLine("**Ejercicio de Vendedor de Productos**");
            int cantidadProductos = LeerInt("Ingrese la cantidad de productos vendidos: ");
            float precioPorProducto = cantidadProductos <= 10 ? 20 : 15;
            float totalVenta = cantidadProductos * precioPorProducto;
            MostrarResultado("Precio por producto: $", precioPorProducto);
            MostrarResultado("Total de la venta: $", totalVenta);
        }
    }
}
