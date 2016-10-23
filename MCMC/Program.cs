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
                Random rand = new Random(); ///Generate random state
                U = rand.NextDouble();
                if (U < alpha)
                {
                    AcceptN += 1;
                }
            }
        }
        public void GenerateGraph()
        { }
    }
}