using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TrafficLightSimulatorProgramUnitTest
{
    [TestClass]
    public class CrossingTest
    {
        [TestMethod]
        public void getGlobalOrientationFromLocalTest()
        {
            Crossing crossing1 = new Crossing(new Point(), CrossingType.CrossingWithoutPedestrian);
            Orientation test = crossing1.getGlobalOrientationFromLocal(Orientation.Degree0, Orientation.Degree0);
            Assert.AreEqual(test, Orientation.Degree0);
            test = crossing1.getGlobalOrientationFromLocal(Orientation.Degree90, Orientation.Degree0);
            Assert.AreEqual(test, Orientation.Degree90);
            test = crossing1.getGlobalOrientationFromLocal(Orientation.Degree90, Orientation.Degree90);
            Assert.AreEqual(test, Orientation.Degree180);
            test = crossing1.getGlobalOrientationFromLocal(Orientation.Degree270, Orientation.Degree180);
            Assert.AreEqual(test, Orientation.Degree90);
        }
    }
}
