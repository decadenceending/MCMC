using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main_MCMC
{

    class program
    {
        ///Declare Variables
        
        int i;
        int Dim;
        int IttN;
        int AcceptN;
        int Temp;
        int R;
        int W; ///number of edge mutations
        int M; ///number of vertices
        int B; ///number of edges that could make the graph disconnected
        double U;
        double alpha;
        double ThetaC;
        double ThetaN;
        double h;
        double PiR;
        double QR;
        int[] XN;
        int[] XN1;
        int[] Y;
        double MCMCSUM;

        ///Define Theta Method, where double sum is subtracted from single sum

        public double ThetaMethod()
        {
            return ThetaC;
        }

        ///Define Ratio of Pi Method

        public double PiRatio(double ThetaC, double ThetaN,int Temp)
        {
            return Math.Exp(-(ThetaN - ThetaC) / Temp);
        }

        ///Defina Ratio of q's, q(i|j)/q(j|i)

        public double QRatio(int B,int M,int W)
        {
            return (1/W)/((M*(M-1))/(2-B));
        }

        ///Define Random Number Generator Method

        public double Rnd()
        {
            Random rand = new Random();
            return rand.NextDouble();
        }

        ///Calculate alpha value Method

        public double AlphaCalc()
        {
            return Math.Min(1, PiRatio(ThetaC,ThetaN,Temp) * (QRatio(B,M,W)));
        }

        ///Define MCMC Method, with For Loop, with random state generator and acceptance argument
        
        public void MCMC()
        {
            for (i = 0; i < IttN; i++)
            {
                ///Insert simulate Y ~ q(j|XN=i), Y=j portion



                ///Call AlphaCalc Method

                alpha = AlphaCalc(); 

                ///Generate random state by calling Rnd Method

                double U = Rnd();

                ///'If' statement to check criteria for accepting a proposed state 

                if (U <= alpha)
                {
                    AcceptN += 1;
                }
                else
                {
                    XN1 = XN;
                }

                ///Calculating the sum

                MCMCSUM=(1 / IttN);
            }
        }

    }
}