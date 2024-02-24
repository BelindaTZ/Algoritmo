using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prueba
{
    struct Estudiantes
    {
        public string nombre;
        public string cedula;
        public int edad;
        public string genero;
        public double promedio;
    }

    internal class Program
    {
        private static Estudiantes[] estudiantes; 

        private static void Main(string[] args)
        {
            Menu();

            Console.ReadKey();
        }

        private static void Menu()
        {
            bool salir = false;
            repetir:
            Volver:
            Console.WriteLine("\t\t\t\tMenú:\n1. Ingresar estudiantes\n2. Ingresar notas\n3. Mostrar promedios\n4. Mostrar mejor estudiante\n5. Mostrar peor estudiante\n6. Salir");
            Console.Write("Digite su opción: --> ");
            int elección = int.Parse(Console.ReadLine());

            switch (elección)
            {
                case 1:
                    Console.Clear();
                    IngresoEstudiantes();
                    break;
                case 2:
                    Console.Clear();
                    Promedio();
                    break;
                case 3:
                    Console.Clear();
                    MostrarProm();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("El mejor estudiante es: --> ");
                    Console.WriteLine(estudiantes[Ranking(estudiantes)].nombre);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("El peor estudiante es: --> ");
                    Console.WriteLine(estudiantes[RankingMenor(estudiantes)].nombre);
                    break;
                case 6:
                    salir = true;
                    Console.WriteLine("Adios.");
                    break;
                default:
                    Console.WriteLine("Opción no valida!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto Volver;
            }

            if (salir) { goto salir; }

            Console.Write("\nDesea repetir el proceso de selección del menú 'Si' o 'No' : --> ");
            string opc = Console.ReadLine();

            if (opc.Equals("Si", StringComparison.OrdinalIgnoreCase) || opc.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                goto repetir;
            }
            else { Console.WriteLine("Adios."); }

            salir:;
        }

        private static void IngresoEstudiantes()
        {
            Console.Write("Digite la cantidad de estudiantes que desea ingresar: --> ");
            int cant = int.Parse(Console.ReadLine());
            Thread.Sleep(2000);
            estudiantes = new Estudiantes[cant];
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.Clear();
                Console.Write("\nIngrese el nombre del {0} estudiante --> ", i + 1);
                estudiantes[i].nombre = Console.ReadLine();

                Console.Write("\nIngrese la cedula del {0} estudiante --> ", i + 1);
                estudiantes[i].cedula = Console.ReadLine();

                Console.Write("\nIngrese la edad del {0} estudiante -- > ", i + 1);
                estudiantes[i].edad = int.Parse(Console.ReadLine());

                Console.Write("\nIngrese el genero del {0} estudiante --> ", i + 1);
                estudiantes[i].genero = Console.ReadLine();
            }
        }

        private static void Promedio()
        {
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine("\nIngrese las notas del {0} estudiante del estudiante --> ", i + 1);
                Thread.Sleep(2000);

                Console.Write("Ingrese la nota 1 del primer corte --> ");
                int n1 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la nota 2 del primer corte -- > ");
                int n2 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la nota de evaluación del primer corte --> ");
                int nev1 = int.Parse(Console.ReadLine());

                double Prom1 = (n1 * 0.35) + (n2 * 0.35) + (nev1 * 0.3);
                Console.Clear();

                Console.Write("Ingrese la nota 1 del segundo corte --> ");
                int n1c2 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la nota 2 del segundo corte -- > ");
                int n2c2 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la nota de evaluación del segundo corte --> ");
                int nev1c2 = int.Parse(Console.ReadLine());
                Console.Clear();

                Console.Write("Ingrese la nota del examen final --> ");
                int notexfinal = int.Parse(Console.ReadLine());

                double Prom2 = (n1c2 * 0.35) + (n2c2 * 0.35) + (nev1c2 * 0.3);

                double npt = ((Prom1 + Prom2) / 2) * 0.7;
                double nex1 = notexfinal * 0.3;
                double notafinal = npt + nex1;
                estudiantes[i].promedio = notafinal;
            }
        }

        private static void MostrarProm()
        {
            Console.WriteLine("El promedio de los estudiantes es: -->");
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine("\nEstudiante {0}: --> {1}", estudiantes[i].nombre, estudiantes[i].promedio);
            }
        }

        private static int Ranking(Estudiantes[] es)
        {
            int contadoraux = 0;
            for (int i = 0; i < es.Length; i++)
            {
                if (es[i].promedio > es[contadoraux].promedio)
                {
                    contadoraux = i;
                }
            }
            return contadoraux;
        }

        private static int RankingMenor(Estudiantes[] es)
        {
            int contadoraux = 0;
            for (int i = 0; i < es.Length; i++)
            {
                if (es[i].promedio < es[contadoraux].promedio)
                {
                    contadoraux = i;
                }
            }
            return contadoraux;
        }
    }
}
