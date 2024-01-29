
using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Variables para estadísticas
        int countOperarios = 0, countTecnicos = 0, countProfesionales = 0;
        decimal acumuladoNetoOperarios = 0, acumuladoNetoTecnicos = 0, acumuladoNetoProfesionales = 0;

        while (true)
        {
            // Solicitar datos al usuario
            Console.Write("Ingrese los datos del empleado (o escriba 'fin' para salir): ");
            Console.Write("Por favor digite la cédula del empleado: ");
            string cedula = Console.ReadLine();

            if (cedula == "fin") // Finaliza las peticion de información
                break;

            Console.Write("Por favor digite el nombre del empleado: ");
            string nombre = Console.ReadLine();

            Console.Write("Por favor selecciones el tipo de empleado (Digite: 1-Operario, Digite: 2-Técnico, Digite: 3-Profesional): ");
            int tipoEmpleado = int.Parse(Console.ReadLine());

            Console.Write("Por favor ingrese la cantidad de horas laboradas: ");
            decimal horasLaboradas = decimal.Parse(Console.ReadLine());

            Console.Write("Por favor ingrese el salario por hora: ");
            decimal salarioPorHora = decimal.Parse(Console.ReadLine());

            // Calcular salario ordinario
            decimal salarioOrdinario = horasLaboradas * salarioPorHora;

            // Calcular aumento
            decimal aumento = 0;
            switch (tipoEmpleado)
            {
                case 1: // Operario
                    aumento = salarioOrdinario * 0.15m;
                    countOperarios++;
                    acumuladoNetoOperarios += (salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917m);
                    break;
                case 2: // Técnico
                    aumento = salarioOrdinario * 0.10m;
                    countTecnicos++;
                    acumuladoNetoTecnicos += (salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917m);
                    break;
                case 3: // Profesional
                    aumento = salarioOrdinario * 0.05m;
                    countProfesionales++;
                    acumuladoNetoProfesionales += (salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917m);
                    break;
                default:
                    Console.WriteLine("Tipo de empleado no válido.");
                    continue;
            }

            // Calcular el salario bruto, deducciones y salario neto
            decimal salarioBruto = salarioOrdinario + aumento;
            decimal deduccionesCCSS = salarioBruto * 0.0917m;
            decimal salarioNeto = salarioBruto - deduccionesCCSS;

            // Mostrar resultados / n es para salto de linea
            Console.WriteLine("\nResultados:");
            Console.WriteLine($"Cédula: {cedula}");
            Console.WriteLine($"Nombre Empleado: {nombre}");
            Console.WriteLine($"Tipo Empleado: {tipoEmpleado}");
            Console.WriteLine($"Salario por Hora: ₡{salarioPorHora:N}");
            Console.WriteLine($"Cantidad de Horas: {horasLaboradas}");
            Console.WriteLine($"Salario Ordinario: ₡{salarioOrdinario:N}");
            Console.WriteLine($"Aumento: ₡{aumento:N}");
            Console.WriteLine($"Salario Bruto: ₡{salarioBruto:N}");
            Console.WriteLine($"Deducción CCSS: ₡{deduccionesCCSS:N}");
            Console.WriteLine($"Salario Neto: ₡{salarioNeto:N}");

            Console.WriteLine("--------------------------------------");
        }

        // Mostrar las estadísticas
        Console.WriteLine("\nEstadísticas:");
        Console.WriteLine($"La Cantidad de Empleados Tipo Operarios son: {countOperarios}");
        Console.WriteLine($"El Salario Acumulado Neto para Operarios: ₡{acumuladoNetoOperarios:N}");

        if (countOperarios > 0)
        {
            decimal promedioNetoOperarios = acumuladoNetoOperarios / countOperarios;
            Console.WriteLine($"El Salario Promedio Neto para Operarios es: ₡{promedioNetoOperarios:N}");
        }

        Console.WriteLine("--------------------------------------");// escribe una linea para separar

        Console.WriteLine($"La Cantidad de Empleados Tipo Técnicos son: {countTecnicos}");
        Console.WriteLine($"El Salario Acumulado Neto para Técnicos es: ₡{acumuladoNetoTecnicos:N}");

        if (countTecnicos > 0)
        {
            decimal promedioNetoTecnicos = acumuladoNetoTecnicos / countTecnicos;
            Console.WriteLine($"El Salario Promedio Neto para Técnicos es: ₡{promedioNetoTecnicos:N}");
        }

        Console.WriteLine("--------------------------------------");// escribe una linea para separar

        Console.WriteLine($"La Cantidad de Empleados Tipo Profesionales son: {countProfesionales}");
        Console.WriteLine($"El Salario Acumulado Neto para Profesionales es: ₡{acumuladoNetoProfesionales:N}");

        if (countProfesionales > 0)
        {
            decimal promedioNetoProfesionales = acumuladoNetoProfesionales / countProfesionales;
            Console.WriteLine($"El Salario Promedio Neto para Profesionales es: ₡{promedioNetoProfesionales:N}");
        }

        Console.WriteLine("--------------------------------------");
    }
}
