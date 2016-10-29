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
        int[,] XN;
        int[,] XN1;
        int[,] Y;

        ///Define Theta Method, where double sum is subtracted from single sum

        public double ThetaMethod(int[,] XN, int M, double R)
        {
            return R * XN.Cast<int>().Sum();
        }

        ///Define Ratio of Pi Method

        public double PiRatio(double ThetaI, double ThetaJ, int Temp)
        {
            return Math.Exp(-(ThetaI - ThetaJ) / Temp);
        }

        ///Defina Ratio of q's, q(i|j)/q(j|i)

        public double QRatio(int B, int M, int W)
        {
            return (1 / W) / ((((M * (M - 1)) / 2) - B));
        }

        ///Define Random Number Generator Method

        public double Rnd()
        {
            Random rand = new Random();
            return rand.NextDouble();
        }

        ///Calculate alpha value Method

        public double AlphaCalc(double PiR, double QR)
        {
            return Math.Min(1, PiR * QR);
        }

        ///Define method to sample from XN

        public int RndCoord()
        {
            Random rnd = new Random();
            return rnd.Next(1, 3);
        }
        ///Define MCMC Method, with For Loop, and through calling previously defined methods

        static void Main()
        {
            ///Define adjustable fixed values of Temp and r

            int M = 3;///based on the graph with 3 vertices

            int B = 2; ///NEEDS TO BE CALCULATED FOR EACH LOOP, CURRENTLY PLACEHOLDER

            int W = ((M * (M - 1)) / 2) - B;
            int Temp = 298;
            int R = 1;
            int IttN = 100;
            ///
            ///Define Matrix of Weighted Edges.
            ///Currently the array is defined between 3 vertices
            ///
            int[,] XN = new int[3, 3] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }};

            int[,] Y = new int[3,3];

            List<int[,]> AcceptN = new List<int[,]>();

            ///Define the loop

            for (int i = 0; i < IttN; i++)
            {
                ///Simulate Y ~ q(j|XN=i), Y=j portion

                int ic = new MCMC().RndCoord();
                int jc = new MCMC().RndCoord();

                ///Use if statements to check if an element is non-zero or zero.

                if (XN[ic,jc]!=0)
                {

                    ///Remove simulated element if not equal to 0, and set it to zero

                    Y = XN;
                    Y[ic, jc] = 0;
                }
                else
                {
                    ///Append array if the simulated element is 0
                    
                    Y = XN;
                    Y[ic, jc] = 1;

                }

                ///Call ThetaMethod for Theta I and Theta J

                double ThetaI = new MCMC().ThetaMethod(XN, M, R);

                double ThetaJ = new MCMC().ThetaMethod(Y, M, R);

                ///Call PiRatio Method to be used in alpha calculations

                double PiR = new MCMC().PiRatio(ThetaI, ThetaJ, Temp);

                ///Call QRatio Method to be used in alpha calculations

                double QR = new MCMC().QRatio(B, M, W);

                ///Call AlphaCalc Method

                double alpha = new MCMC().AlphaCalc(PiR, QR);

                ///Generate random state by calling Rnd Method

                double U = new MCMC().Rnd();

                ///'If' statement to check criteria for accepting a proposed state 

                if (U <= alpha)
                {
                    ///Keep the generated graph

                    AcceptN.Add(XN1);

                    XN = Y;

                    ///Otherwise keep XN as is and simulate again
                }

                ///Automatically flattens an array and adds the elements

                double h = (1 / IttN) * AcceptN.Cast<int>().Sum(); ///Edit,

                ///Display expected h

                Console.Write(h);

                ///Generating a graph based on the listed edges connecting vertices
                
                
                
                ///Plotting the results for a number of trials

            }

        }
    }
}