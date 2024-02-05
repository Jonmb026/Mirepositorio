using System;
using System.Linq;

class Tarea3_P2
{
    static int tamano = 2;
    static string[] nombre = new string[tamano];
    static int[] edad = new int[tamano];
    static string[] cita = new string[tamano];
    static int opcion = 0;

    static void Main()
    {
        menu();
    }

    static void inicializar()
    {
        nombre = Enumerable.Repeat("", tamano).ToArray<string>();
        cita = Enumerable.Repeat("", tamano).ToArray<string>();
        edad = Enumerable.Repeat(0, tamano).ToArray<int>();

        Console.WriteLine("Los arreglos han sido inicializados");
        Console.ReadKey();
        Console.Clear();
    }

    static void Agregar()
    {
        for (int i = 0; i < tamano; i++)
        {
            Console.WriteLine("Ingrese el nombre del paciente: ");
            nombre[i] = Console.ReadLine();
            Console.WriteLine("Ingrese la edad del paciente: ");
            edad[i] = int.Parse(Console.ReadLine());
        }
    }

    static void Consulta()
    {
        bool encontrado = false;
        Console.WriteLine("Digite el nombre a consultar");
        string nomb = Console.ReadLine();
        for (int i = 0; i < nombre.Length; i++)
        {
            if (nomb.Equals(nombre[i]))
            {
                Console.WriteLine($"La edad de {nomb} es {edad[i]}");
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine($"El Cliente {nomb} no existe");
        }
    }

    static void Reporte()
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < tamano; i++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   Nombre              Edad");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("---------           ----");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nombre[i]}   {edad[i]}");
        }
    }

    static void Agregarcitas()
    {
        for (int i = 0; i < tamano; i++)
        {
            Console.WriteLine($"Ingrese la cita para {nombre[i]}: ");
            cita[i] = Console.ReadLine();
        }
        Console.WriteLine("Citas agregadas correctamente.");
    }

    static void menu()
    {
        do
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("********* CONSULTORIO MEDICO ***********");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1- Inicializar arreglos");
            Console.WriteLine("2- Ingresar paciente");
            Console.WriteLine("3- Consultar paciente");
            Console.WriteLine("4- Reporte");
            Console.WriteLine("5- Asignar citas");
            Console.WriteLine("6- Salir");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite una opcion...");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: inicializar(); break;
                case 2: Agregar(); break;
                case 3: Consulta(); break;
                case 4: Reporte(); break;
                case 5: Agregarcitas(); break;
                default:
                    break;
            }
        } while (opcion != 6);
    }
}
