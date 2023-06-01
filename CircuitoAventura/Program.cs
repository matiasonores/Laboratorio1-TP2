using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ejercicio_Parque
{
    class Program
    {
        static void Main(string[] args)
        {
            CircuitoAventura circuitoAventura = new CircuitoAventura();
            circuitoAventura.Iniciar();
            Console.ReadKey();
        }

    }

}