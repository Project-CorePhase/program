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
            Bitmap image = new Bitmap(200, 100);
            Crossing crossing1 = new Crossing(new Point(), CrossingType.CrossingWithoutPedestrian, image);
            Orientation test = crossing1.getGlobalOrientationFromLocal(Orientation.Degree0, Orientation.Degree0);
            Assert.AreEqual(test, Orientation.Degree0);
            test = crossing1.getGlobalOrientationFromLocal(Orientation.Degree90, Orientation.Degree0);
            Assert.AreEqual(test, Orientation.Degree90);
            test = crossing1.getGlobalOrientationFromLocal(Orientation.Degree90, Orientation.Degree90);
            Assert.AreEqual(test, Orientation.Degree180);
            test = crossing1.getGlobalOrientationFromLocal(Orientation.Degree270, Orientation.Degree180);
            Assert.AreEqual(test, Orientation.Degree90);
        }

    [TestMethod]
        public void rotatePointTest()
        {
            Bitmap image = new Bitmap(200, 100);
            Crossing crossing1 = new Crossing(new Point(), CrossingType.CrossingWithoutPedestrian, image);
            System.Drawing.Point test = new System.Drawing.Point(0, 0);
            System.Drawing.Point result = crossing1.rotatePoint(Orientation.Degree0, test);
            Assert.AreEqual(result, new System.Drawing.Point(0,0));

            test = new System.Drawing.Point(0, 0);
            result = crossing1.rotatePoint(Orientation.Degree90, test);
            Assert.AreEqual(result, new System.Drawing.Point(142, 0));
        }
    }
}
