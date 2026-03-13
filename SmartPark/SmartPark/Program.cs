using System;
class Program
{
    static void Main()
    {
        // Proyecto #1
        // Carlos Daniel Angulo Campos - Carnet: 1250826
        // Luis Pedro Martinez Bobadilla - Carnet (Agrega tu carnet)

        // Parqueo Inteligente hecho solamente con estructuras cíclicas y repetitivas

        Console.WriteLine("Ingrese el nombre del operador");
        string nombre_operador = Console.ReadLine()!;

        string? codigo_turno;

        do
        {
            Console.WriteLine("Ingrese su código de turno");
            codigo_turno = Console.ReadLine()!;

            if(codigo_turno.Length != 4)
            {
                Console.WriteLine("Por favor ingrese un código de turno correcto");
            }
        } while (codigo_turno.Length != 4);

        int capacidad = 0;

        do
        {
            Console.WriteLine("Ingrese la capacidad del parqueo");
            string dato = Console.ReadLine()!;
            capacidad = int.Parse(dato);

            if(capacidad < 10)
            {
                Console.WriteLine("El mínimo de capacidad debe de ser 10");
            }
        } while (capacidad < 10);

        int tickets_creados = 0;
        int tickets_cerrados = 0;
        double dinero = 0;
        int tiempo_simulado = 0;
        Boolean ticket_activo_booleano = false;
        int opcion_menu = 0;

        do
        {
            Console.WriteLine("¿A qué parte del menú se quiere dirigir?" +
                "\n 1. CREAR TICKET DE ENTRADA" +
                "\n 2. REGISTRAR SALIDA Y CALCULAR COBRO" +
                "\n 3. VER ESTADO DE PARQUEO" +
                "\n 4. SIMULAR PASO DEL TIEMPO" +
                "\n 5. SALIR");
            string dato1 = Console.ReadLine()!;
            opcion_menu = int.Parse(dato1);

            if(opcion_menu < 1 || opcion_menu > 5)
            {
                Console.WriteLine("Ingrese una opción válida");
                continue;
            }

            switch (opcion_menu)
            {
                case 1:

                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:

                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 3:

                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 4:

                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        } while (opcion_menu != 5);
    }
}