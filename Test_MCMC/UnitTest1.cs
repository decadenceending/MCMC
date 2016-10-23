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
        {
            double U = 0.01;double alpha = 0.05; int AcceptN = 0;int IttN = 10; int ActualAcceptN = 0;

            MCMC(U, alpha, IttN, AcceptN);
            int ActualAcceptN=AcceptN.MCMC
            Assert.AreEqual(IttN, ActualAcceptN, 0, "Loop is not evaluating if statement correctly");

        }
    }
}
