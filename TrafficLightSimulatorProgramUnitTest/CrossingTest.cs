using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficLightSimulatorProgramUnitTest
{
    [TestClass]
    public class CrossingTest
    {
        [TestMethod]
        public void getGlobalOrientationFromLocalTest()
        {
            Crossing crossing1 = new Crossing(CrossingType.CrossingWithoutPedestrian);
            Oriention test = crossing1.getGlobalOrientationFromLocal(Oriention.Degree0, Oriention.Degree0);
            Assert.AreEqual(test, Oriention.Degree0);
            test = crossing1.getGlobalOrientationFromLocal(Oriention.Degree90, Oriention.Degree0);
            Assert.AreEqual(test, Oriention.Degree90);
            test = crossing1.getGlobalOrientationFromLocal(Oriention.Degree90, Oriention.Degree90);
            Assert.AreEqual(test, Oriention.Degree180);
            test = crossing1.getGlobalOrientationFromLocal(Oriention.Degree270, Oriention.Degree180);
            Assert.AreEqual(test, Oriention.Degree90);
        }
    }
}
