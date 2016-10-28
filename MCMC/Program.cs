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
        int[,] AcceptN;
        int Temp;
        double R;
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
        int[,] XN;
        int[,] XN1;
        int[] Y;
  
        ///Define Theta Method, where double sum is subtracted from single sum

        public double ThetaMethod(int [,] XN,int M, double R)
        {
            return R*(XN.Sum());
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

        ///Define MCMC Method, with For Loop, and through calling previously defined methods
        
        static void Main()
        {
            ///Define adjustable fixed values of Temp and r

            int M = 3;///based on the graph with 3 vertices

            int B = 2; ///NEEDS TO BE CALCULATED FOR EACH LOOP, CURRENTLY PLACEHOLDER

            int W = ((M * (M - 1)) / 2) - B;
            int Temp = 298;
            double R = 1;
            int IttN = 100;
            ///
            ///Define Matrix of Weighted Edges.
            ///Currently the array is defined between 3 vertices
            ///
            int[,] XN = new int[3,3] {
                { 1, 2, 3 }, 
                { 4, 5, 6 }, 
                { 7, 8, 9 }};

            int[,] XN1 = new int[3, 3];

            int[] AcceptN = new int[IttN];

            ///Define the loop

            for (int i = 0; i < IttN; i++)
            {
                ///Insert simulate Y ~ q(j|XN=i), Y=j portion
                


                ///Call ThetaMethod for Theta I and Theta J

                double ThetaI = new MCMC().ThetaMethod(XN,M,R);

                double ThetaJ = new MCMC().ThetaMethod(XN,M,R);

                ///Call PiRatio Method to be used in alpha calculations

                double PiR = new MCMC().PiRatio(ThetaI,ThetaJ,Temp);

                ///Call QRatio Method to be used in alpha calculations

                double QR = new MCMC().QRatio(B,M,W);

                ///Call AlphaCalc Method

                double alpha = new MCMC().AlphaCalc(PiR,QR); 

                ///Generate random state by calling Rnd Method

                double U = new MCMC().Rnd();

                ///'If' statement to check criteria for accepting a proposed state 

                if (U <= alpha)
                {
                    AcceptN[i]=XN1; ///Edit, keep the generated graph
                }
                else
                {
                    XN1 = XN;
                }
            }
        }

    }
}