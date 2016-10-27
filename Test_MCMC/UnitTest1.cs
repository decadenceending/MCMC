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
            int B=2;int M=9;int W=34; int ActualQR = 1 / 1156;

            double QR = new MCMC().QRatio(B,M,W);

            Assert.AreEqual(QR,ActualQR);

        }

        public void MCMC_Random_U_TestMethod()
            ///Asses functionality of random value generator, by comparing a generator values, if it between 0 and 1
        {
            double GenU = new MCMC().Rnd();

            bool RndExp = true;

            bool RndStat = false;

            if (GenU >= 0 && GenU <= 1)
            {
                RndStat = true;
            }

            Assert.AreEqual(RndStat, RndExp);
        }

        public void MCMC_TargetPI_Ratio_TestMethod()
            ///Asses functionality of ratio calculations, alpha
        {
            int ThetaI = 100; int ThetaJ = 105; int Temp = 298; double PiRExp = 1.01692;

            double PiR = new MCMC().PiRatio(ThetaI,ThetaJ,Temp);

            Assert.AreEqual(PiR, PiRExp, 0.0001);
        }
    }
}
