using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Numero_2.Clases
{
    // VERIFICAR EDADES NEGATIVAS y 0
    public class CircuitoAventura
    {
        double entrada = 1500.00;
        int individuales = 0;
        int EdadEntre10y15 = 0;
        double recaudacionTotal;
        int cantPasaportes;
        int cantPersonasPasaporte;
        int totalEdades;
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
                        Console.WriteLine("3");
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

            }
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
            if (cantPersonas > 3 || cantPersonas == 1 )
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
                } else
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


            } else
            {
                    Console.WriteLine("Ingrese Edades");
                 for (int i = 0; i<cantPersonas; i++)
                {
                    int edades = 0;
                    Console.WriteLine("Edad Visitante: " + (i+1));
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
                    } else
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
                                ConfirmarCompra(total, cantPersonas,descuentoTotal);
                                individuales += cantPersonas;
                                EdadEntre10y15 += contador10y15;
                                recaudacionTotal += total;
                                totalEdades += acumuladorEdades;
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
            if (edad < 4)
            {
                return entrada * 0.10;
            } else if (edad < 11)
            {
                return entrada * 0.50;
            } else
            {
                return entrada * 0.75;
            }
        }


        private void ConfirmarCompra(double total, int cantpersonas, double descuentototal = 0.00)
        {

                // Imprimir la factura
                //Console.WriteLine("Factura");
                //Console.WriteLine("--------------------");
                //Console.WriteLine($"Cliente: {nombreCliente}");
                //Console.WriteLine($"Número de factura: {numeroFactura}");
                //Console.WriteLine($"Fecha: {fechaFactura}");
                //Console.WriteLine("--------------------");
                //Console.WriteLine("Descripción           Precio");
                //Console.WriteLine("--------------------");
                //Console.WriteLine("Producto 1            $50.25");
                //Console.WriteLine("Producto 2            $30.75");
                //Console.WriteLine("--------------------");
                //Console.WriteLine($"Total:                ${totalFactura}");
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