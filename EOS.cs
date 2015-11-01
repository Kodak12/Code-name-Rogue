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

        public double idealGas(double P, double T, double m)
        {
            // calculates the molar volume given 
            // temperature and pressure
            // units are in SI
            double Vhat;
            double R = 0.08206; // atm*l/mol*K
            double Mw = 64.07; // Molecualr weight of SO2 in (g/mol)
            double n = (m / Mw) * 1000; // molar flow rate in (mol/s)
            //
            Vhat = (T * R) / P;
            double Vflow_I = Vhat * n; // volumetric flow in (L/s)

           return Vflow_I;
            
        }

        public double virialTrunc(double P, double T, double m)
        {   // implementation for SO2 because it is the compound of interest at moment
            // calculates the molar volume using the
            // virail truncated EOS 
            // units are in SI

            double R = .08206; // Universal gas constant
            double Mw = 64.07; // Molecualr weight of SO2 in (g/mol)
            double n = (m / Mw) * 1000; // molar flow rate in (mol/s)

            double w = 0.251; // pitzer acentric factor for SO2
            double Tc = 430.7; // critical temperature (K)
            double Pc = 77.8; // critical pressusre (atm)

            double Pr = P / Pc; // Reduced pressure
            double Tr = T / Tc; // Reduced temperature

            double Bo = 0.083 - (0.422 / Math.Pow(Tr,1.6)); // calculates Bo for estimation of B
            double B1 = 0.139 - (0.172 / Math.Pow(Tr,4.2));  // calculates B1 for estimation of B

            double B = ((R * Tc) / Pc) * (Bo + w * B1); // Calculates virial 2body constant

            double Vhat = (1 + (B * P / (R * T))) * ((R * T) / P); // molar volume

            double Vflow_V = Vhat * n; // volumetric flow in (L/s)

            return Vflow_V;

            
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

            Console.WriteLine("Solution from IdealGas is {0}",finder.idealGas(41,625,20));

            Console.WriteLine("Solution from virialTrunc is {0}",finder.virialTrunc(41,625,20));

            Console.ReadKey();
        }
    }
}
