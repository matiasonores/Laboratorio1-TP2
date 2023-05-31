using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Numero_2.Clases;

namespace Ejercicio_Parque
{
    class Program
    {
        static void Main(string[] args)
        {
           CircuitoAventura circuitoAventura = new CircuitoAventura();
            circuitoAventura.Iniciar();
            //circuitoAventura.MostrarResultados();
            Console.ReadKey();
        }

    }

}