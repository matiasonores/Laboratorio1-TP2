﻿using System.Threading;
using System;
using Ejercicio_Parque;

public class CircuitoAventura
{
    double entrada = 1500.00;
    int individuales = 0; // esta mal
    int EdadEntre10y15 = 0;
    double recaudacionTotal = 0;
    double recaudacionPasaporte = 0;
    int totalGrupos = 0;
    int cantPasaportes = 0;
    int cantPersonasGrupoMenosde4 = 0;
    int cantPersonasPasaporte = 0; // esta mal
    int totalEdades;
    int contFactura = 0;


    public void Iniciar()
    {
        MostrarMenu();
    }

    private void MostrarMenu()
    {

        bool salir = false;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.WindowHeight = 34;
        Console.WindowWidth = 117;

        Marco();
        Console.CursorTop = 2;
        Console.WriteLine("          \n           ░                        \n           ░             CIRCUITO AVENTURA\n", Console.ForegroundColor = ConsoleColor.White);
        Console.WriteLine("           ░                                                    ");
        Console.WriteLine("           ░                                                    ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("           ░            1-Ingresar pase individual\n");
        Console.WriteLine("           ░            2-Ingresar pase grupal: menor a 4 personas\n");
        Console.WriteLine("           ░            3-Ingresar pase grupal: 4 a 10 personas\n");
        Console.WriteLine("           ░            4-Mostrar caja\n");
        Console.WriteLine("           ░            5-Finalizar jornada del dia\n");
        ConsoleKeyInfo opcion = Console.ReadKey();
        Console.Clear();
        while (true)
        {
            switch (opcion.Key)
            {
                case ConsoleKey.D1:
                    CasoIndividual();
                    break;

                case ConsoleKey.D2:
                    CasoGrupalMenos4();
                    break;

                case ConsoleKey.D3:
                    int cantPersonasSinPasaporte = CasoPasaporte();
                    while (cantPersonasSinPasaporte > 3)
                    {
                        cantPersonasSinPasaporte = CasoPasaporte(cantPersonasSinPasaporte);
                    }
                    if (cantPersonasSinPasaporte != 0 && cantPersonasSinPasaporte > 1)
                    {
                        CasoGrupalMenos4();

                    }
                    else if (cantPersonasSinPasaporte == 1)
                    {
                        CasoIndividual();
                    }


                    break;
                case ConsoleKey.D4:
                    //Console.Clear();
                    MostrarResultados();
                    break;

                case ConsoleKey.D5:
                    string salir2;
                    Console.WriteLine("Esta seguro que quiere finalizar la jornada? Presione S para confirmar");
                    salir2 = Console.ReadLine();
                    if (salir2.ToLower() == "s")
                    {
                        MostrarResultados();
                        return;
                    }
                    Console.Clear();
                    break;


                default:
                    Console.WriteLine("Ingreso un caracter invalido");

                    break;

            }
            if (salir == true)
            {
                return;
            }

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WindowHeight = 34;
            Console.WindowWidth = 117;

            Marco();
            Console.CursorTop = 2;
            Console.WriteLine("          \n           ░                        \n           ░             CIRCUITO AVENTURA\n", Console.ForegroundColor = ConsoleColor.White);
            Console.WriteLine("           ░                                                    ");
            Console.WriteLine("           ░                                                    ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("           ░            1-Ingresar pase individual\n");
            Console.WriteLine("           ░            2-Ingresar pase grupal: menor a 4 personas\n");
            Console.WriteLine("           ░            3-Ingresar pase grupal: 4 a 10 personas\n");
            Console.WriteLine("           ░            4-Mostrar caja\n");
            Console.WriteLine("           ░            5-Finalizar jornada del dia\n");
            opcion = Console.ReadKey();
            Console.Clear();

        }
    }

    private void Marco()
    {

        for (int y = 1; y < 23; y++)
        {
            Console.CursorLeft = 11;
            Console.CursorTop = y;
            Console.Write("░");
            Console.CursorLeft = 69;
            Console.Write("░");

        }

        for (int x = 11; x < 69; x++)
        {

            Console.CursorLeft = x;
            Console.CursorTop = 1;
            Console.Write("░");
            Console.CursorTop = 22;
            Console.Write("░");

        }


    }

    private int CasoPasaporte(int cantPersonas = 0)
    {

        int cantMayores21 = 0;
        int cantMenores3 = 0;
        int cantMenores16 = 0;
        int cantMenores = 0;
        int cantMenoresEntre10y15 = 0;
        double totalrecaudado = 0;
        int cantPersonasAfueraPasaporte = 0;
        int edadtotal = 0;
        int contPersonas = 0;
        double descuentoTotal = 0;
        bool retornar = false;

        if (cantPersonas == 0)
        {
            Console.WriteLine("Ingrese Cantidad de Personas");
            cantPersonas = Convert.ToInt32(Console.ReadLine());

        }
        if (Program.VerficarNegativo(cantPersonas))
        {

            if (cantPersonas < 4)
            {
                // MAYOR DE 3
                string siOno;
                Console.WriteLine("Detectamos que ingreso menos de 4 personas, Desea corregir la cantidad? (S/N)");
                siOno = Console.ReadLine();
                siOno = siOno.ToLower();
                bool salir = false;
                while (salir == false)
                {
                    switch (siOno)
                    {
                        case "s":
                            Console.Clear();
                            CasoPasaporte();
                            retornar = true;
                            break;
                        case "n":
                            Console.Clear();
                            retornar = true;
                            break;

                    }
                    if (retornar == true)
                    {
                        salir = true;
                    }
                }
            }
            if (retornar != true)
            {



                if (cantPersonas >= 10)
                {
                    cantPersonasAfueraPasaporte = cantPersonas - 10;
                    cantPersonas = 10;
                }
                bool sePuede;
                Console.WriteLine("Ingrese Cantidad de Menores a 16 años que van a ingresar");
                int cantMenores16anios = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese Cantidad de Mayores responsables que van a ingresar");
                int cantMayoresa21anios = Convert.ToInt32(Console.ReadLine());
                if (cantMayoresa21anios > 1)
                {
                    sePuede = true;
                }
                else if (cantMenores16anios > 5 && cantMayoresa21anios < 2)
                {
                    sePuede = false;
                }
                else if (cantMenores16anios <= 5 && cantMayoresa21anios == 1)
                {
                    sePuede = true;
                }
                else
                {
                    sePuede = true;
                }
                // termina prueba
                Console.Clear();
                if (!sePuede)
                {
                    Console.WriteLine("No se cumple con las normas de Acceso al Parque!\nRecuerda que necesitas tener 1 adulto cada 5 menores de 16 años");
                    Console.WriteLine();
                    Console.WriteLine("Precione una tecla para volver al Menu Principal.");
                    Console.ReadKey();
                    Console.Clear();
                    return 0;
                }
                Console.WriteLine("Ingrese Edades:  ");
                for (int i = 0; i < cantPersonas; i++)
                {

                    contPersonas++;
                    double total = 0;
                    int edad = 0;
                    Console.WriteLine("Ingrese la edad de la persona: {0}", (i + 1));
                    edad = Convert.ToInt32(Console.ReadLine());
                    bool verificacion;
                    verificacion = Program.VerficarNegativo(edad);
                    while (verificacion == false)
                    {
                        Console.WriteLine("Ingreso una edad no valida \n\n Ingrese nuevamente Edad Visitante: " + (i + 1));
                        edad = Convert.ToInt32(Console.ReadLine());
                        verificacion = Program.VerficarNegativo(edad);
                    }
                    if (edad >= 21)
                    {
                        cantMayores21++;
                        total = 1500;
                    }
                    else if (edad >= 16)
                    {
                        cantMenores16++;
                        total = 1500;
                    }
                    else
                    {

                        cantMenores++;
                        total = CalcularDescuentoMenores(edad);
                        //descuentoTotal += entrada - total;
                        if (edad >= 10 && edad <= 15)
                        {
                            cantMenoresEntre10y15++;
                        }
                        if (edad <= 3)
                        {
                            cantMenores3++;

                        }
                    }
                    edadtotal += edad;
                    totalrecaudado += total;
                }
                double correccionDescMen3 = cantMenores3 * (150 * 0.15);
                // 15 % descuento
                double descuento = totalrecaudado * 0.15;
                descuentoTotal += (descuento - correccionDescMen3);
                totalrecaudado -= descuento;
                totalrecaudado += correccionDescMen3;
                Console.WriteLine("El monto a pagar es {0:C2}. Desea proseguir? (S/N)", totalrecaudado);
                string compra = Console.ReadLine();
                compra = compra.ToLower();
                bool salir = true;
                bool salirPagando = false;
                while (salir)
                {

                    switch (compra)
                    {
                        case "s":
                            {
                                Console.Clear();
                                ConfirmarCompra(totalrecaudado, contPersonas, descuentoTotal);
                                EdadEntre10y15 += cantMenoresEntre10y15;
                                recaudacionTotal += totalrecaudado;
                                recaudacionPasaporte += totalrecaudado;
                                totalEdades += edadtotal;
                                cantPersonasPasaporte += contPersonas;
                                cantPasaportes++;
                                salir = false;
                                salirPagando = true;
                                break;

                            }
                        case "n":
                            {
                                Console.Clear();
                                Console.WriteLine("Se regresará al menu principal sin efectuar la compra");
                                salir = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Ingreso un Caracter invalido, ingrese nuevamente porfavor: ");
                                Console.WriteLine("El monto a pagar es ${0:C2}. Desea proseguir? (S/N)", totalrecaudado);
                                break;
                            }

                    }
                    if (salirPagando == false)
                    {
                        cantPersonasAfueraPasaporte = 0;
                    }

                }
            }
            else
            {
                cantPersonasAfueraPasaporte = 0;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ingreso un numero invalido \n\n Precione una tecla para continuar");
            Console.ReadKey();
            cantPersonasAfueraPasaporte = 0;

        }
        return cantPersonasAfueraPasaporte;

    }



    private void CasoGrupalMenos4()
    {
        bool hayUnMayor = false;
        bool hayMenores = false;
        int cantPersonas;
        double total = 0;
        int contador10y15 = 0;
        int acumuladorEdades = 0;
        double descuentoTotal = 0;
        Console.WriteLine("Ingrese Cantidad de Personas");
        cantPersonas = Convert.ToInt32(Console.ReadLine());
        if (Program.VerficarNegativo(cantPersonas))
        {
            if (cantPersonas > 3 || cantPersonas == 1)
            {
                if (cantPersonas > 3)
                {
                    // MAYOR DE 3
                    string siOno;
                    Console.WriteLine("Detectamos que ingreso mas de 3 personas, Desea corregir la cantidad? (S/N)");
                    siOno = Console.ReadLine();
                    siOno = siOno.ToLower();
                    bool salir = true;
                    while (salir)
                    {
                        switch (siOno)
                        {
                            case "s":
                                CasoGrupalMenos4();
                                salir = false;
                                break;
                            case "n":
                                salir = false;
                                break;
                        }
                        if (salir == true)
                        {
                            Console.WriteLine("Ingreso un Caracter no Valido Intentelo de nuevo");
                            Console.WriteLine("Detectamos que ingreso mas de 3 personas, Desea corregir la cantidad? (S/N)");
                            siOno = Console.ReadLine();
                        }
                    }
                }
                else
                {
                    // SE CONFUNDIO Y CASO INDIVIDUAL
                    string siOno;
                    Console.WriteLine("Detectamos que ingreso 1 persona, Desea corregir la cantidad? (S/N)");
                    siOno = Console.ReadLine();
                    siOno = siOno.ToLower();
                    bool salir = true;
                    while (salir)
                    {
                        switch (siOno)
                        {
                            case "s":
                                CasoGrupalMenos4();
                                salir = false;
                                break;

                            case "n":
                                Console.Clear();
                                Console.WriteLine("Detectamos 1 Persona Redirigiendo al Caso Individual.\n");
                                CasoIndividual();
                                salir = false;
                                break;
                        }
                        if (salir == true)
                        {
                            Console.WriteLine("Ingreso un Caracter no Valido Intentelo de nuevo");
                            Console.WriteLine("Detectamos que ingreso 1 persona, Desea corregir la cantidad? (S/N)");
                            siOno = Console.ReadLine();
                        }
                    }
                }


            }
            else
            {
                Console.WriteLine("Ingrese Edades");
                for (int i = 0; i < cantPersonas; i++)
                {
                    int edades = 0;
                    Console.WriteLine("Edad Visitante: " + (i + 1));
                    edades = Convert.ToInt32(Console.ReadLine());
                    bool verificacion;
                    verificacion = Program.VerficarNegativo(edades);
                    while (verificacion == false)
                    {
                        Console.WriteLine("Ingreso una edad no valida \n\n Ingrese nuevamente Edad Visitante: " + (i + 1));
                        edades = Convert.ToInt32(Console.ReadLine());
                        verificacion = Program.VerficarNegativo(edades);
                    }
                    if (edades >= 21)
                    {
                        hayUnMayor = true;

                    }
                    if (edades < 16)
                    {
                        hayMenores = true;
                        if (edades > 9)
                        {
                            contador10y15++;
                        }
                        total += CalcularDescuentoMenores(edades);
                        //descuentoTotal += CalcularDescuentoMenores(edades);

                    }
                    else
                    {
                        total += entrada;
                    }
                    acumuladorEdades += edades;

                }

                // Termina el for 

                if (hayMenores == true && hayUnMayor == false)
                {
                    Console.Clear();
                    Console.WriteLine("No pueden Ingresar menores de 16 sin un Mayor Responsable.");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("El monto a pagar es ${0}. Desea proseguir? (S/N)", total);
                    string compra = Console.ReadLine();
                    compra = compra.ToLower();
                    bool salir = true;
                    while (salir)
                    {


                        switch (compra)
                        {
                            case "s":
                                {
                                    Console.Clear();
                                    ConfirmarCompra(total, cantPersonas, descuentoTotal);
                                    EdadEntre10y15 += contador10y15;
                                    recaudacionTotal += total;
                                    totalEdades += acumuladorEdades;
                                    cantPersonasGrupoMenosde4 += cantPersonas;
                                    salir = false;
                                    break;
                                }
                            case "n":
                                {
                                    Console.Clear();
                                    Console.WriteLine("Se regresará al menu principal sin efectuar la compra");
                                    salir = false;
                                }
                                break;

                            default:
                                {
                                    Console.WriteLine("Ingreso un Caracter invalido, ingrese nuevamente porfavor: ");
                                    Console.WriteLine("El monto a pagar es ${0:C2}. Desea proseguir? (S/N)", total);
                                    break;
                                }
                        }
                        if (salir == true)
                        {
                            compra = Console.ReadLine();
                            compra = compra.ToLower();
                        }
                    }

                }

            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ingreso un numero invalido \n\n Precione una tecla para continuar");
            Console.ReadKey();
        }


    }
    private double CalcularDescuentoMenores(int edad)
    {
        double entradatotal;
        if (edad < 4)
        {
            entradatotal = entrada * 0.10;
        }
        else if (edad < 11)
        {
            entradatotal = entrada * 0.50;
        }
        else
        {
            entradatotal = entrada * 0.80;
        }

        return entradatotal;
    }

    private void ConfirmarCompra(double total, int cantpersonas, double descuentototal = 0.00)
    {
        Console.Clear();
        int frequency = 2000; // Frecuencia inicial del tono
        int duration = 100; // Duración del tono en milisegundos

        // Reproducir el patrón de sonido de la impresora Epson TM-U220D
        Console.WriteLine("Iniciando impresión...");

        for (int i = 0; i < 3; i++)
        {
            Console.Beep(frequency, duration); // Tono inicial
            Thread.Sleep(50);

            Console.Beep(frequency / 2, duration); // Tono más bajo
            Thread.Sleep(50);

            Console.Beep(frequency, duration); // Tono inicial
            Thread.Sleep(50);

            Console.Beep(frequency / 2, duration); // Tono más bajo
            Thread.Sleep(50);

            Console.Beep(frequency, duration * 2); // Tono inicial más largo
            Thread.Sleep(200);
        }

        Console.WriteLine("Impresión finalizada.");
        Console.Clear();
        contFactura++;
        totalGrupos++;

        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Marco();
        string numeroFac = GenerarNumeroFactura(contFactura);
        Console.CursorTop = 2;
        Console.WriteLine("\n           ░            Factura  {0}\n", numeroFac);

        Console.WriteLine($"           ░            Fecha:   {DateTime.Now.ToString()}\n");
        Console.WriteLine("           ░    Descripción           Precio - Entrada: {0:C}", entrada);
        Console.WriteLine("           ░           Total sin Descuento        {0:C}\n", (descuentototal + total));
        Console.WriteLine("           ░           Descuento Total            {0:C}\n", (descuentototal));
        Console.WriteLine("           ░           Total:             {0:C}\n", (total));
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");

        Console.WriteLine("           ░      Precione una tecla para continuar: ");

        Console.ReadKey();
        Console.Clear();
    }

    private string GenerarNumeroFactura(int numero)
    {


        string numeroFactura = numero.ToString().PadLeft(6, '0');

        string numeroCompleto = "0001-" + numeroFactura;

        return numeroCompleto;
    }
    private void CasoIndividual()
    {
        int edad = 0;
        char compra;
        Console.WriteLine("1-Ingresar edad");
        edad = Convert.ToInt32(Console.ReadLine());
        if (Program.VerficarNegativo(edad))

        {
            if (edad < 16)
            {
                Console.WriteLine("No cumple con la edad suficiente para ingresar");
                Console.WriteLine("¿Desea reingresar la edad (1) o Regresar al menu principal (2)?");

                ConsoleKeyInfo opcion = Console.ReadKey();
                Console.Clear();
                bool salir = true;
                while (salir)
                {

                    switch (opcion.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            CasoIndividual();
                            salir = false;
                            break;

                        case ConsoleKey.D2:
                            Console.Clear();
                            salir = false;
                            break;

                    }
                    if (salir == true)
                    {

                        Console.WriteLine("Ingreso una opcion invalida, intentalo nuevamente");
                        Console.WriteLine("¿Desea reingresar la edad (1) o Regresar al menu principal (2)?");
                        opcion = Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine("El monto a pagar es ${0}. Desea proseguir? (S/N)", entrada);
                compra = Convert.ToChar(Console.ReadLine());

                switch (char.ToLower(compra))
                {
                    case 's':
                        {
                            individuales += 1;
                            totalEdades += edad;
                            recaudacionTotal += entrada;
                            ConfirmarCompra(entrada, 1);

                        }
                        break;
                    case 'n':
                        {
                            Console.WriteLine("Se regresará al menu principal sin efectuar la compra");
                        }
                        break;
                }
                Console.Clear();
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ingreso una edad invalida \n\n Precione una tecla para continuar");
            Console.ReadKey();
        }
    }
    private void MostrarResultados()
    {
        Console.ResetColor();
        Console.Clear();
        int totalPersonas = cantPersonasPasaporte + cantPersonasGrupoMenosde4 + individuales;
        if (totalPersonas != 0)
        {
            double totalIndividuales = (individuales + cantPersonasGrupoMenosde4) * entrada;
            double totalIndividualesPasaporte = totalIndividuales + recaudacionPasaporte;
            double edadPromedio = ((double)totalEdades / totalPersonas);
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────── ┐");
            Console.WriteLine("El total de grupos fue de: {0} │ Personas totales: {1}                 │ ", totalGrupos, totalPersonas);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────│");
            Console.WriteLine("Recaudación: con Pasaportes: {0:C2} │ Individuales: {1:C2} │ Total:{2:C2}  │", recaudacionPasaporte, totalIndividuales, totalIndividualesPasaporte);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────│ ");
            Console.WriteLine("Personas con Pasaporte: {0}.│ Personas entre 10 y 15: {1}    │", cantPersonasPasaporte, EdadEntre10y15);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────│ ");
            Console.WriteLine("Edad Promedio: {0} │                                                              │", edadPromedio);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────┘ ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
        }
        else
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────── ┐");
            Console.WriteLine("El total de grupos fue de: {0} │ Personas totales: {1}│                                │ ", 0.00, 0.00);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────│");
            Console.WriteLine("Recaudación: con Pasaportes: {0:C2} │ Individuales: {1:C2} │ Total:{2:C2}          │", 0.00, 0.00, 0.00);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────│ ");
            Console.WriteLine("Personas con Pasaporte: {0}.│ Personas entre 10 y 15: {1}                              │", 0.00, 0.00);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────│ ");
            Console.WriteLine("Edad Promedio: {0:C2} │                                                                 │", 0.00);
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────── ┘ ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");

        }

        Console.WriteLine(" Precione una tecla para Salir: ");
        Console.ReadKey();
        Console.Clear();
    }

}
