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
        decimal MCMCSUM;

        ///Define Theta Method

        public double ThetaMethod()
        {
            return ThetaC;
        }

        ///Define Ratio of Pi Method

        public double PiRatio(double ThetaC, double ThetaN,int Temp)
        {
            PiR=Math.Exp(-(ThetaN - ThetaC) / Temp);
            return PiR;
        }

        ///Defina Ratio of q's

        public double QRatio()
        {
            return QR;
        }

        ///Define Random Number Generator Method

        public double Rnd()
        {
            Random rand = new Random();
            double U = rand.NextDouble();
            return U;
        }

        ///Define MCMC Method, with For Loop, with random state generator and acceptance argument
        
        public void MCMC()
        {
            for (i = 0; i < IttN; i++)
            {
                ///Insert simulate Y ~ q(j|XN=i), Y=j portion

                alpha = Math.Min(1, PiR*(PiRatio(,) / PiRatio(,))); ///Needs Editing

                ///Generate random state by calling Rnd method

                double U = Rnd();

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

        ///Graph Generation

        public class Graph()
        {
        
            private List<XN>[] childNodes;
            public Graph(XN size)
            {
                this.childNodes = new List<XN>[size];
                for (int i = 0; i < size;i++)
                {
                    this.childNodes[i] = new List<XN>();
                }
            }
    }
}