using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main_MCMC; 

namespace Test_MCMC
{
    [TestClass]
    public class MCMC_Loop_UnitTest
    {
        [TestMethod]
        public void MCMC_Acceptance_TestMethod()
            ///Asses functionality of trial acceptance portion
        {
            double U = 0.01;double alpha = 0.05; int AcceptN = 0;int IttN = 10; int ActualAcceptN = 0;

            MCMC(U, alpha, IttN, AcceptN);
            int ActualAcceptN=AcceptN.MCMC
            Assert.AreEqual(IttN, ActualAcceptN, 0, "Loop is not evaluating if statement correctly");

        }
        public void MCMC_Random_U_TestMethod()
            ///Asses functionality of random value generator, by comparing a generator values, if it between 0 and 1
        {

        }
        public void MCMC_TargetPI_Ratio_TestMethod()
            ///Asses functionality of ratio calculations, alpha
        {

        }
    }
}
