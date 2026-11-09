using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Tema7Examen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] codAuto = { "AUTO-201", "AUTO-202", "AUTO-203", "AUTO-204", "AUTO-205", "AUTO-206" };
            string[] modAuto = { "SUV Interceptor", "Sedan Executive", "PickUp Titan", "City Hatchback", "Electric EV", "Van Carga" };
            double[,] SellData = { { 28000, 2 }, { 18500, 4 }, { 35000, 1 }, { 14000, 5 }, { 42000, 1 }, { 22500, 3 } };
            double[] montoNet = new double[6];
            int ventasPremium = 0;
            double GranTotalAcu = 0;
            Console.WriteLine("--------CONTROL DE VENTAS AUTOMOTRICEA-------------");
            Matriz(SellData, codAuto);
            for (int i = 0; i < 6; i++)
            {
                if (ValidarDatos(SellData[i, 0], (int)SellData[i, 1]))
                {
                    montoNet[i] = SellData[i, 0] * SellData[i, 1];
                    GranTotalAcu += montoNet[i];

                    if (montoNet[i] > 50000)
                    {
                        ventasPremium++;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("------REPORTE MONTO NETO------------");

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Codigo: {codAuto[i]} / Modelo: {modAuto[i]} / Monto: {montoNet[i]}");
            }
            Console.WriteLine($"Gran total acumulado: {GranTotalAcu}");
            Console.WriteLine($"Ventas Premium: {ventasPremium}");


            Console.WriteLine("Buscado AUTO-203: ");
            BuscarCodigo(codAuto, modAuto, montoNet, "AUTO-203");
            Console.ReadKey();


        }

        static bool ValidarDatos(double precio, int cantidad)
        {
            if (precio > 0 && cantidad > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error, se necesita un precio y cantidad mayor a 0 para ejecutar.");
                return false;
            }
            ;

        }
        static void Matriz(double[,] matriz, string[] codigos)
        {
            Console.WriteLine("/ codigo        / Precio         / cantidad");
            Console.WriteLine("________________________________________________________");

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Console.WriteLine($"{codigos[i]} /   {matriz[i, 0]}  / {matriz[i, 1]}");
            }
        }

        static void BuscarCodigo(string[] codigos, string[] modelos, double[] montos, string codigoBuscado)
        {
            for (int i = 0; i < codigos.Length; i++)
            {
                if (codigos[i] == codigoBuscado)
                {
                    Console.WriteLine($"Auto encontrado| Modelo: {modelos[i]}, Monto: {montos[i]}");
                    return;
                }

            }
        }
    }
}