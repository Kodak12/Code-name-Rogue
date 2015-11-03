/*HOMEWORK 5
AUTHOR: CHUK UME
*/
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
