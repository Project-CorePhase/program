using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLightSimulatorProgram;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightSimulatorProgramUnitTest
{
    [TestClass]
    public class movingObjectTest
    {
        [TestMethod]
        public void Update() {
            roadPiece piece = new roadPiece();


            // First we create a road
            TrafficLightUnitTest tl1 = new TrafficLightUnitTest();
            tl1.SetColor(TrafficColor.Red); // you shall not pass !
            roadPiece piece1 = new roadPiece(piece);
            piece1.trafficlightRefrence = tl1;
            piece1.orientation = Oriention.Degree270;

            roadPiece piece2 = new roadPiece(piece1);
            piece2.orientation = Oriention.Degree90; // because I don't like when it is too easy :p
            roadPiece piece3 = new roadPiece(piece2);
            MovingObject car = new MovingObject(false, piece3);
            Assert.AreEqual(car.path, piece3);
            // piece3 -> piece2 -> piece1
            // The moving object is on piece3

            // First I want to test the animation
            Assert.AreEqual(car.coordinateInRoadPiece,  new System.Drawing.Point(0,0));
            for (int i = 0; i < 10; i++)
            {
                car.Update();
                Assert.AreEqual(car.coordinateInRoadPiece, new System.Drawing.Point(i+1, 0));
            }
            // Now we should move to the new roadpiece
            car.Update();
            Assert.AreEqual(car.coordinateInRoadPiece, new System.Drawing.Point(0, 0));
            Assert.AreEqual(car.path, piece2);
            for (int i = 0; i < 10; i++)
            {
                car.Update();
                Assert.AreEqual(car.coordinateInRoadPiece, new System.Drawing.Point(0, i+1));
            }
            car.Update();
            Assert.AreEqual(car.coordinateInRoadPiece, new System.Drawing.Point(0, 0));
            Assert.AreEqual(car.path, piece1);

            // Now i want to do the same but with a traffic light
            for (int i = 0; i < 10; i++)
            {
                car.Update();
                Assert.AreEqual(car.coordinateInRoadPiece, new System.Drawing.Point(0, i - 1));
            }
            // We check several times
            for (int i = 0; i < 10; i++)
            {
                car.Update();
                Assert.AreEqual(car.coordinateInRoadPiece, new System.Drawing.Point(0, -10));
                Assert.AreEqual(car.path, piece1);
            }
            // Now we change the color of the light
            tl1.SetColor(TrafficColor.Green);
            car.Update();
            Assert.AreEqual(car.coordinateInRoadPiece, new System.Drawing.Point(0, 0));
            Assert.AreEqual(car.path, piece);
        }

    }
}
