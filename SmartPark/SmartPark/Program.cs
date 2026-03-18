using System;
class Program
{
    static void Main()
    {
        // Proyecto #1
        // Carlos Daniel Angulo Campos - Carnet: 1250826
        // Luis Pedro Martinez Bobadilla - Carnet 1081126

        // Parqueo Inteligente hecho solamente con estructuras cíclicas y repetitivas

        Console.WriteLine("Ingrese el nombre del operador");
        string nombre_operador = Console.ReadLine()!;

        string? codigo_turno;

        // Bloque 1 - Datos del operador
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

        // Bloque 2 - Inicialización variables

        int tickets_creados = 0;
        int tickets_cerrados = 0;
        double dinero = 0;
        int tiempo_simulado = 0;
        Boolean ticket_activo_booleano = false;
        int opcion_menu = 0;
        int vehiculo_actual = 0;
        string nombre_cliente_actual = "";
        int minuto_de_entrada = 0;
        int minutos_estacionados = 0;
        int tarifa = 0;
        int multa_fija = 0;
        int cliente_vip = 0;
        double monto_final;

        // Menú - Hecho con ciclo do-while

        do
        {
            Console.WriteLine("¿A qué parte del menú se quiere dirigir?" +
                "\n 1 = CREAR TICKET DE ENTRADA" +
                "\n 2 = REGISTRAR SALIDA Y CALCULAR COBRO" +
                "\n 3 = VER ESTADO DE PARQUEO" +
                "\n 4 = SIMULAR PASO DEL TIEMPO" +
                "\n 5 = SALIR");
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

                    // Caso 1 - El operador genera un nuevo ticket

                    int espacios_ocupados = tickets_creados - tickets_cerrados;
                    if(ticket_activo_booleano == true || espacios_ocupados == capacidad)
                    {
                        Console.WriteLine("No se pueden crear tickets en este momento");
                        continue;
                    }

                    int vehiculo = 0;

                    do
                    {
                        Console.WriteLine("Ingrese el tipo de vehiculo" +
                            "\n 1 = MOTO" +
                            "\n 2 = AUTO" +
                            "\n 3 = PICKUP/SUV");
                        string dato3 = Console.ReadLine()!;
                        vehiculo = int.Parse(dato3);

                        if(vehiculo > 3 || vehiculo < 1)
                        {
                            Console.WriteLine("Ingrese un número válido");
                        }
                    } while (vehiculo > 3 || vehiculo < 1);

                    Console.WriteLine("Ingrese el nombre del cliente");
                    string nombre_cliente = Console.ReadLine()!;

                    vehiculo_actual = vehiculo;
                    nombre_cliente_actual = nombre_cliente;
                    minuto_de_entrada = tiempo_simulado;
                    ticket_activo_booleano = true;
                    tickets_creados++;

                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:

                    // Caso 2 - El operador cierra un ticket

                    if(ticket_activo_booleano == false)
                    {
                        Console.WriteLine("No hay tickets activos");
                        continue;
                    }

                    minutos_estacionados = tiempo_simulado - minuto_de_entrada;

                    // Se aplica tarifa

                    switch (vehiculo_actual)
                    {
                        case 1:
                            tarifa = 5;
                            break;

                        case 2:
                            tarifa = 10;
                            break;

                        case 3:
                            tarifa = 15;
                            break;
                    }

                    // Cálculos del monto final

                    if(minutos_estacionados >= 15)
                    {
                        int horas = minutos_estacionados / 60;

                        if(minutos_estacionados % 60 > 0)
                        {
                            horas = horas + 1;
                        }

                        if(horas > 6)
                        {
                            multa_fija = 25;
                        }
                        else
                        {
                            multa_fija = 0;
                        }

                        monto_final = (tarifa * horas) + multa_fija;

                        // 2.1 El cliente indica si es VIP

                        do
                        {
                            Console.WriteLine("¿Usted es cliente VIP?" +
                                "\n 1 = Sí" +
                                "\n 0 = No");
                            string dato4 = Console.ReadLine()!;
                            cliente_vip = int.Parse(dato4);
                            if(cliente_vip > 1 || cliente_vip < 0)
                            {
                                Console.WriteLine("Ingrese un número válido");
                                continue;
                            }
                        } while (cliente_vip > 1 || cliente_vip < 0);

                        if(cliente_vip == 1)
                        {
                            monto_final = monto_final * 0.90;
                        }

                        if(horas > 12)
                        {
                            monto_final = monto_final * 1.20;
                        }
                    }
                    else
                    {
                        monto_final = 0;
                    }

                    Console.WriteLine("Se cobraron Q" + monto_final);
                    dinero += monto_final;
                    tickets_cerrados++;
                    ticket_activo_booleano = false;

                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 3:
                    //Caso 3 - El operador ve el estado del parqueo

                    Console.WriteLine("Capacidad del parqueo: " + capacidad);
                    Console.WriteLine();

                    espacios_ocupados = tickets_creados - tickets_cerrados;
                    Console.WriteLine("Espacios ocupados: " + espacios_ocupados);
                    Console.WriteLine();

                    int espacios_disponibles = capacidad - espacios_ocupados;
                    Console.WriteLine("Espacios disponibles: " + espacios_disponibles);
                    Console.WriteLine();

                    Console.WriteLine("El tiempo simulado es de: " + tiempo_simulado + " minutos.");
                    Console.WriteLine();

                    Console.WriteLine("Dinero recaudado: Q" + dinero);
                    Console.WriteLine();

                    Console.WriteLine("Tickets cerrados : " + tickets_cerrados);
                    Console.WriteLine();

                    Console.WriteLine("Tickets creados: " + tickets_creados);
                    Console.WriteLine();

                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 4:

                    // Caso 4 - El operador simula el paso del tiempo

                    Console.WriteLine("Ingrese la cantidad de minutos transcurridos desde la ultima actualización");
                    int minutos_transcurridos = int.Parse(Console.ReadLine()!);

                    tiempo_simulado += minutos_transcurridos;

                    Console.WriteLine("El tiempo simulado es de: " + tiempo_simulado + " minutos.");

                    if (ticket_activo_booleano == true) // Si hay un ticket activo,se muestra el tiempo que lleva estacionado y si se aplica multa o no
                    {
                        minutos_estacionados = tiempo_simulado - minuto_de_entrada;

                        if (minutos_estacionados > 360)
                        {
                            if (minutos_estacionados > 720) //Advertencia de multa por más de 12 horas, multa del 20% al monto final
                            {
                                Console.WriteLine("El cliente lleva estacionado más de 12 horas, se le aplicará una multa del 20% al monto final");
                            }
                            else
                            {
                                Console.WriteLine("ADVERTENCIA, MULTA PROXIMA");
                            }
                        }
                    }

                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        } while (opcion_menu != 5);

        // 5 - Resumen de turno
        Console.WriteLine("RESUMEN FINAL DEL TURNO: ");
        Console.WriteLine();
        Console.WriteLine("Se crearon " + tickets_creados + " tickets.");
        Console.WriteLine();
        Console.WriteLine("Se cerraron " + tickets_cerrados + " tickets.");
        Console.WriteLine();
        Console.WriteLine("El dinero recaudado fue de: Q" + dinero);
        Console.WriteLine();
        Console.WriteLine("Se simularon " + tiempo_simulado + " minutos.");
        Console.WriteLine();
        Console.WriteLine("Gracias por usar el programa, presione Enter para salir");
        Console.Read();
        Console.Clear();
    }
}
