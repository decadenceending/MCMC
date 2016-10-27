using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main_MCMC
{

    public class MCMC
    {
        ///Declare Variables
        
        int i;
        int IttN;
        int[] AcceptN;
        int Temp;
        int R;
        int W; ///number of edge mutations possible
        int M; ///number of vertices
        int B; ///number of edges that could make the graph disconnected
        int VM; /// minimum number of edges needed to make the graph connected
        double U;
        double alpha;
        double ThetaI;
        double ThetaJ;
        double h;
        double PiR;
        double QR;
        int[] XN;
        int[] XN1;
        int[] Y;
        double MCMCSUM;
   
        ///Define Theta Method, where double sum is subtracted from single sum

        public double ThetaMethod(int M, double R)
        {
            return ThetaCalc;
        }

        ///Define Ratio of Pi Method

        public double PiRatio(double ThetaI, double ThetaJ,int Temp)
        {
            return Math.Exp(-(ThetaI - ThetaJ) / Temp);
        }

        ///Defina Ratio of q's, q(i|j)/q(j|i)

        public double QRatio(int B,int M,int W)
        {
            return (1/W)/((((M*(M-1))/2)-B));
        }

        ///Define Random Number Generator Method

        public double Rnd()
        {
            Random rand = new Random();
            return rand.NextDouble();
        }

        ///Calculate alpha value Method

        public double AlphaCalc(double PiR,double QR)
        {
            return Math.Min(1, PiR * QR);
        }

        ///Define MCMC Method, with For Loop, with random state generator and acceptance argument
        
        static void Main()
        {
            ///Define adjustable fixed values of Temp and r

            int Temp = 298;
            int R = 1;
            int IttN = 100;
            ///
            ///Define Matrix of Weighted Edges.
            ///Currently the array is defined between 3 vertices
            ///
            int[,] XN = new int[3,3] {
                { 1, 2, 3 }, 
                { 4, 5, 6 }, 
                { 7, 8, 9 }
            };

            for (int i = 0; i < IttN; i++)
            {
                ///Insert simulate Y ~ q(j|XN=i), Y=j portion
                


                ///Call ThetaMethod for Theta I and Theta J

                double ThetaI = new MCMC().ThetaMethod();

                double ThetaJ = new MCMC().ThetaMethod();

                ///Call PiRatio Method to be used in alpha calculations

                double PiR = new MCMC().PiRatio(ThetaI,ThetaJ,Temp);

                ///Call QRatio Method to be used in alpha calculations

                double QR = new MCMC().QRatio();

                ///Call AlphaCalc Method

                double alpha = new MCMC().AlphaCalc(PiR,QR); 

                ///Generate random state by calling Rnd Method

                double U = new MCMC().Rnd();

                ///'If' statement to check criteria for accepting a proposed state 

                if (U <= alpha)
                {
                    int [,] AcceptN= new int[1,IttN]; ///Edit, keep the generated graph
                }
                else
                {
                    XN1 = XN;
                }

                ///Calculating the sum

                double MCMCSUM=(1 / IttN);
            }
        }

    }
}