using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_6_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ingresar datos
            Console.Write("\nIngrese la probabilidad de que X ≤ 165: ");
            double prob1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nIngrese la probabilidad de que 165 ≤ X < 180: ");
            double prob2 = Convert.ToDouble(Console.ReadLine());

            // Límites
            double LInferior = 165;
            double LSuperior = 180;
            double LTratamiento = 183;

            var normal = new Normal(0, 1);

            double zInferior = normal.InverseCumulativeDistribution(prob1);
            double zSuperior = normal.InverseCumulativeDistribution(prob1 + prob2);
            double desviacion2 = (LSuperior - LInferior) / (zSuperior - zInferior);
            double media2 = LInferior - zInferior * desviacion2;
            double zTratamiento = (LTratamiento - media2) / desviacion2;
            double probTratamiento = 1 - normal.CumulativeDistribution(zTratamiento);
            int poblacionTotal = 100000;
            int personasTratamiento = (int)(poblacionTotal * probTratamiento);


            Console.WriteLine($"\nMedia: {media2:F2}\n");
            Console.WriteLine($"Desviación: {desviacion2:F2}\n");
            Console.WriteLine($"Probabilidad de índice de colesterol > 183: {probTratamiento:P2}\n");
            Console.WriteLine($"Personas que necesitan tratamiento: {personasTratamiento}");
        }
    }
}
