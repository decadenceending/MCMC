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
        double U;
        double alpha;
        decimal theta;
        decimal h;
        decimal previous;
        decimal nextp;
        int[] XN;
        int[] XN1;
        int[] Y;


        ///Define TargetPI Method
        
        public decimal TargetPI(int Dim,int U,decimal theta, decimal h)
        {
            if (theta < 0 || theta > 1)
            {
                return 0;
            }
            else
            {
                return nextp(Dim, theta).ProbabilityMassFunction(h) * previous.PDF(theta); ///Probability Mass Function and Probabaility Density Function
            }
        }

        ///Define MCMC Method, with For Loop, with random state generator and acceptance argument

        public void MCMC()
        {
            for (i = 0; i < IttN; i++)
            {
                ///Insert simulate Y ~ q(j|XN=i), Y=j portion
                
                alpha=Math.Min(1,TargetPI(i|j)/TargetPI(j|i)) ///Needs Editing

                ///Generate random state
                
                Random rand = new Random();
                U = rand.NextDouble();
                if (U <= alpha)
                {
                    AcceptN += 1;
                }
                else
                {
                    XN1=XN
                }
                (1/IttnN)
            }
        }
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
}