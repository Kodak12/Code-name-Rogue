/*HOMEWORK 5
AUTHOR: CHUK UME
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{

    public class Question1
    {
        // variable dec and def

        public double idealGas(double P, double T)
        {
            // calculates the molar volume given 
            // temperature and pressure
            // units are in SI
            double Vhat;
            double R = 0.08206; // atm*l/mol*K

            Vhat = (T * R) / P;

            return Vhat;
            
        }

        public double virialTrunc(double P, double T)
        {   // implementation for SO2 because it is the compound of interest at moment
            // calculates the molar volume using the
            // virail truncated EOS 
            // units are in SI

            double R = .08206; // Universal gas constant

            double w = 0.251; // pitzer acentric factor for SO2
            double Tc = 430.7; // critical temperature (K)
            double Pc = 77.8; // critical pressusre (atm)

            double Pr = P / Pc; // Reduced pressure
            double Tr = T / Tc; // Reduced temperature

            double Bo = 0.083 - (0.422 / Math.Pow(Tr,1.6)); // calculates Bo for estimation of B
            double B1 = 0.139 -
 (0.172 / Math.Pow(Tr,4.2));  // calculates B1 for estimation of B

            double B = ((R * Tc) / Pc) * (Bo + w * B1); // Calculates virial 2body constant

            double Vhat = (1 + (B * P / (R * T))) * ((R * T) / P); // molar volume

            return Vhat;

            
        }

        public double compChart(double P, double T, double z)
        {
            //Calculates molar volume given Pressure, Temperature and compressibility factor

            double R = 0.08206; // Universal gas constant

            double Vhat = (z * R * T) / P;

            return Vhat;
            
        }

    }


    public class Implementation
    {

        static void Main(string[] args)
        {
            // Call functions defined in the namespace

            Question1 finder = new Question1();

            Console.WriteLine("Solution from IdealGas is {0}",finder.idealGas(41,625));
            Console.WriteLine("Solution from virialTrunc is {0}",finder.virialTrunc(41,625));
            Console.ReadKey();
        }
    }
}
