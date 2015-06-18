using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficLightSimulator;
using System.Drawing;

namespace TrafficLightSimulatorProgramUnitTest
{
    [TestClass]
    public class MovingObjectUnitTest
    {
        [TestMethod]
        public void Update() {
            roadPiece piece = new roadPiece();
            Bitmap image = new Bitmap(200, 100);

            // First we create a road
            TrafficLight tl1 = new TrafficLight();
            RoadObject roadObject = new Crossing(new System.Drawing.Point(0, 0), CrossingType.Curved, image);
            tl1.SetColor(TrafficColor.Red); // you shall not pass !
            roadPiece piece1 = new roadPiece(roadObject, piece);
            piece1.trafficlightRefrence = tl1;
            piece1.orientation = Orientation.Degree270;

            roadPiece piece2 = new roadPiece(roadObject, piece1);
            piece2.orientation = Orientation.Degree90; // because I don't like when it is too easy :p
            roadPiece piece3 = new roadPiece(roadObject, piece2);
            MovingObject car = new MovingObject(false, piece3);
            Assert.AreEqual(car.Path, piece3);
            // piece3 -> piece2 -> piece1v
            // The moving object is on piece3

            // First I want to test the animation
            Assert.AreEqual(car.CoordinateInRoadPiece,  new System.Drawing.Point(0,0));
            for (int i = 0; i > -10; i-=2)
            {
                car.Update();
                Assert.AreEqual(car.CoordinateInRoadPiece, new System.Drawing.Point(i-2, 0));
            }
            // Now we should move to the new roadpiece
            car.Update();
            Assert.AreEqual(car.CoordinateInRoadPiece, new System.Drawing.Point(0, 0));
            Assert.AreEqual(car.Path, piece2);
            for (int i = 0; i > -10; i-=2)
            {
                car.Update();
                Assert.AreEqual(car.CoordinateInRoadPiece, new System.Drawing.Point(0, i - 2));
            }
            car.Update();
            Assert.AreEqual(car.CoordinateInRoadPiece, new System.Drawing.Point(0, 0));
            Assert.AreEqual(car.Path, piece1);

            // Now i want to do the same but with a traffic light
            for (int i = 0; i < 10; i+=2)
            {
                car.Update();
                Assert.AreEqual(car.CoordinateInRoadPiece, new System.Drawing.Point(0, i + 2));
            }
            // We check several times
            for (int i = 0; i < 10; i+=2)
            {
                car.Update();
                Assert.AreEqual(car.CoordinateInRoadPiece, new System.Drawing.Point(0, +10));
                Assert.AreEqual(car.Path, piece1);
            }
            // Now we change the color of the light
            tl1.SetColor(TrafficColor.Green);
            car.Update();
            Assert.AreEqual(car.CoordinateInRoadPiece, new System.Drawing.Point(0, 0));
            Assert.AreEqual(car.Path, piece);
        }

    }
}
