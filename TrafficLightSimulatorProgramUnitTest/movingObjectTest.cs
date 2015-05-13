using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLightSimulatorProgram;


namespace TrafficLightSimulatorProgramUnitTest
{
    [TestClass]
    class movingObjectTest
    {
        [TestMethod]
        public void update() {
            // First we create a road
            roadPiece piece1 = new roadPiece();
            roadPiece piece2 = new roadPiece(piece1);
            roadPiece piece3 = new roadPiece(piece2);
            MovingObject car = new MovingObject(false, piece3);
            // piece3 -> piece2 -> piece1
            // The moving object is on piece3
            car.Update();
            
        }

    }
}
