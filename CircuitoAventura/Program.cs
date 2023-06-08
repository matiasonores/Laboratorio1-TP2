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
        public static bool VerficarNegativo(int num)
        {
            bool confirmacionNegativo;
            if (num < 1) 
            { 
                confirmacionNegativo = false;
            } 
            else confirmacionNegativo= true;
            return confirmacionNegativo;
        }
    }
}