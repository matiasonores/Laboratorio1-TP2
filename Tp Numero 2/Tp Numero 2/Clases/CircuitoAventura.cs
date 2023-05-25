using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tp_Numero_2.Clases
{
    // VERIFICAR EDADES NEGATIVAS y 0


    //    Como en muchas situaciones grupos familiares han solicitado ingreso al mismo, el parque implementó un sistema
    //    de “pasaportes” grupales(mínimo 4 personas, máximo 10), donde se permite el ingreso de menores con la
    //   siguiente condición:
    // Por cada 5 menores deberá ingresar un adulto responsable(mayor de 21 años)
    // El pasaporte incluye un descuento del 15% para grupos desde 4 a 10 personas.
    // EL grupo también puede ser formado por personas mayores de edad, es decir un grupo con descuento,
    //donde no hay menores a 16.
    //En caso de los menores las entradas se fijaron con los siguientes valores
    // De 0 a 3 años pagan solo el seguro que equivale al 10% de la entrada, es decir $ 150. En este caso no se
    //aplica el descuento del pasaporte
    // De 4 a 10 años el valor del ingreso es el 50% de la entrada, es decir $ 750
    // De 11 a 15 años el valor del ingreso es el 80% de la entrada, es decir $ 1200





    public class CircuitoAventura
    {
        double entrada = 1500.00;
        int individuales = 0; // esta mal
        int EdadEntre10y15 = 0;
        double recaudacionTotal = 0;
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

        void MostrarMenu()
        {

            Console.WriteLine("1-Ingresar pase individual");
            Console.WriteLine("2-Ingresar pase grupal: menor a 4 personas");
            Console.WriteLine("3-Ingresar pase grupal: 4 a 10 personas");
            Console.WriteLine("4-Finalizar jornada del dia");
            ConsoleKeyInfo opcion = Console.ReadKey();
            Console.Clear();
            while (opcion.Key != ConsoleKey.D4)
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
                        if (cantPersonasSinPasaporte != 0)
                        {
                          if (cantPersonasSinPasaporte > 1)
                            {
                                CasoGrupalMenos4();
                                
                            } else
                            {
                                CasoIndividual();
                            }
                        }

                        break;


                    default:
                        Console.WriteLine("4");
                        break;

                }
                Console.WriteLine("1-Ingresar pase individual");
                Console.WriteLine("2-Ingresar pase grupal: menor a 4 personas");
                Console.WriteLine("3-Ingresar pase grupal: 4 a 10 personas");
                Console.WriteLine("4-Finalizar jornada del dia");
                opcion = Console.ReadKey();
                Console.Clear();

            }
        }

        void FinalizarDia()
        {
           int  cantPersonasFinal = cantPersonasPasaporte + cantPersonasGrupoMenosde4+ individuales;
            double promedio = totalEdades / cantPersonasFinal;
            Console.WriteLine("El Promedio de edades es de:    {0}", promedio);
            Console.WriteLine("La cantidad de pasaportes es:   {0}", cantPasaportes);
            Console.WriteLine("Personas utilizando pasaportes: {0}", cantPersonasPasaporte);
            Console.WriteLine("Total de Grupos: {0}", totalGrupos);
            Console.WriteLine("Total de Grupos: {0}", totalGrupos);
        }


        public int CasoPasaporte()
        {
            int cantPersonas = 0;
            int cantMayores21 = 0;
            int cantMenores16 = 0;
            int cantMenores = 0;
            int cantMenoresEntre10y15 = 0;
            int contPersonas = 0;
            double totalrecaudado = 0;
            int cantPersonasAfueraPasaporte = 0;
            int edadtotal = 0;
            double descuentoTotal = 0;
            

            Console.WriteLine("Ingrese Cantidad de Personas");
            cantPersonas = Convert.ToInt32(Console.ReadLine());
            //if (cantPersonas > 3 && cantPersonas < 11)
            //{
            //    Console.WriteLine("Cuantas personas son mayores de 21 años");
            //    cantMayores21 = Convert.ToInt32(Console.ReadLine());
            //    cantMenores21 = cantMayores21 - cantPersonas;
            //}
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
                            CasoPasaporte();
                            return 0;
                        case "n":
                            salir = true;
                            break;
                    }
                }
            }
            if (cantPersonas > 10)
            {
                cantPersonasAfueraPasaporte = cantPersonas - 10;
                cantPersonas = 10;
            } 
            Console.WriteLine("Ingrese Edades:  ");
           for (int i = 0; i< cantPersonas; i++)
            {
                contPersonas++;
                double total = 0;
                int edad = 0;
                Console.WriteLine("Ingrese la edad de la persona: {0}", (i+1));
                edad = Convert.ToInt32(Console.ReadLine());
                if (edad >= 21)
                {
                    cantMayores21++;
                    total = 1500;
                }
                else if (edad >= 16)
                {
                    cantMenores16++;
                    total = 1500;
                } else
                {
                    cantMenores++;
                    total = CalcularDescuentoMenores(edad);
                    descuentoTotal += total;
                    if (edad >=10 && edad <= 15)
                    {
                        cantMenoresEntre10y15++;
                    }
                }
                edadtotal += edad;
                totalrecaudado += total;
              }
           // 15 % descuento
            double descuento = totalrecaudado * 0.15;
            descuentoTotal += descuento;
            totalrecaudado -= descuento;
            Console.WriteLine("El monto a pagar es ${0:C2}. Desea proseguir? (S/N)", totalrecaudado);
            string compra = Console.ReadLine();
            compra = compra.ToLower();
            switch (compra)
            {
                case "s":
                    {
                        Console.Clear();
                        ConfirmarCompra(totalrecaudado, cantPersonas, descuentoTotal);
                        EdadEntre10y15 += cantMenoresEntre10y15;
                        recaudacionTotal += totalrecaudado;
                        totalEdades += edadtotal;
                        cantPersonasPasaporte = cantPersonas;
                        cantPasaportes++;
                        return cantPersonasAfueraPasaporte;
                       
                    }
                case "n":
                    {
                        Console.Clear();
                        Console.WriteLine("Se regresará al menu principal sin efectuar la compra");
                        return 0;
                    }
                default:
                    {
                        Console.WriteLine("Ingreso un Caracter invalido, ingrese nuevamente porfavor: ");
                        Console.WriteLine("El monto a pagar es ${0:C2}. Desea proseguir? (S/N)", totalrecaudado);
                        break;
                    }
                   
            }
            return cantPersonasAfueraPasaporte;









        }



        public void CasoGrupalMenos4()
        {
            int edad = 0;
            bool hayUnMayor = false;
            bool hayMenores = false;
            int cantPersonas;
            double total = 0;
            int contador10y15 = 0;
            int acumuladorEdades = 0;
            double descuentoTotal = 0;
            Console.WriteLine("Ingrese Cantidad de Personas");
            cantPersonas = Convert.ToInt32(Console.ReadLine());
            if (cantPersonas > 3 || cantPersonas == 1)
            {
                if (cantPersonas > 3)
                {
                    // MAYOR DE 3
                    string siOno;
                    Console.WriteLine("Detectamos que ingreso mas de 3 personas, Desea corregir la cantidad? (S/N)");
                    siOno = Console.ReadLine();
                    siOno = siOno.ToLower();
                    while (true)
                    {
                        switch (siOno)
                        {
                            case "s":
                                CasoGrupalMenos4();
                                return;
                            case "n":
                                //CasoPasaporte();
                                break;
                        }
                        Console.WriteLine("Ingreso un Caracter no Valido Intentelo de nuevo");
                        Console.WriteLine("Detectamos que ingreso mas de 3 personas, Desea corregir la cantidad? (S/N)");
                        siOno = Console.ReadLine();
                    }
                }
                else
                {
                    // SE CONFUNDIO Y CASO INDIVIDUAL
                    string siOno;
                    Console.WriteLine("Detectamos que ingreso 1 persona, Desea corregir la cantidad? (S/N)");
                    siOno = Console.ReadLine();
                    siOno = siOno.ToLower();
                    while (true)
                    {
                        switch (siOno)
                        {
                            case "s":
                                CasoGrupalMenos4();
                                return;

                            case "n":
                                CasoIndividual();
                                return;
                        }
                        Console.WriteLine("Ingreso un Caracter no Valido Intentelo de nuevo");
                        Console.WriteLine("Detectamos que ingreso 1 persona, Desea corregir la cantidad? (S/N)");
                        siOno = Console.ReadLine();
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
                        descuentoTotal += CalcularDescuentoMenores(edades);
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
                    return;
                }
                else
                {
                    Console.WriteLine("El monto a pagar es ${0}. Desea proseguir? (S/N)", total);
                    string compra = Console.ReadLine();
                    compra = compra.ToLower();
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
                                break;
                            }
                        case "n":
                            {
                                Console.Clear();
                                Console.WriteLine("Se regresará al menu principal sin efectuar la compra");
                            }
                            break;
                    }

                }

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
                entradatotal =  entrada * 0.50;
            }
            else
            {
                entradatotal = entrada * 0.75;
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

            //{
            //    Console.WriteLine("Imprimiendo...");

            //    // Reproducir el sonido de la impresora
            //    Console.Beep(150, 2000);
            contFactura++;
            totalGrupos++;

            string numeroFac = GenerarNumeroFactura(contFactura);
            Console.WriteLine("Factura  {0}", numeroFac);
            Console.WriteLine("--------------------");
            Console.WriteLine($"Fecha:   {DateTime.Now.ToString()}");
            Console.WriteLine("--------------------");
            Console.WriteLine("Descripción           Precio - Entrada: {0:C}",entrada);
            Console.WriteLine("--------------------");
            Console.WriteLine("Total sin Descuento        {0:C}", (descuentototal + total));
            Console.WriteLine("Descuento Total            {0:C}",descuentototal);
            Console.WriteLine("--------------------");
            Console.WriteLine("Total:                {0:C}", total);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine(" Precione una tecla para continuar: ");

            Console.ReadKey();
            Console.Clear();
        }

        public string GenerarNumeroFactura(int numero)
        {
            // Convertir el número a una cadena de 6 dígitos rellenando con ceros a la izquierda
            string numeroFactura = numero.ToString().PadLeft(6, '0');

            // Construir el número de factura completo con el formato "0001-000000"
            string numeroCompleto = "0001-" + numeroFactura;

            return numeroCompleto;
        }
        void CasoIndividual()
        {
            int edad = 0;
            char compra;
            Console.WriteLine("1-Ingresar edad");
            edad = Convert.ToInt32(Console.ReadLine());
            if (edad < 16)
            {
                Console.WriteLine("No cumple con la edad suficiente para ingresar");
                Console.WriteLine("¿Desea reingresar la edad (1) o Regresar al menu principal (2)?");

                ConsoleKeyInfo opcion = Console.ReadKey();
                Console.Clear();
                while (true)
                {

                    switch (opcion.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            CasoIndividual();
                            return;

                        case ConsoleKey.D2:
                            Console.Clear();
                            return;

                    }
                    Console.WriteLine("Ingreso una opcion invalida, intentalo nuevamente");
                    Console.WriteLine("¿Desea reingresar la edad (1) o Regresar al menu principal (2)?");
                    opcion = Console.ReadKey();
                    Console.Clear();
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
        public void MostrarResultados()
        {
            // AL FINAL UN MOSTRAR RESULTADO 
        }

    }

}