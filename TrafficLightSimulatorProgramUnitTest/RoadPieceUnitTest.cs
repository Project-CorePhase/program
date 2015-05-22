using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLightSimulatorProgram;

namespace TrafficLightSimulatorProgramUnitTest
{
    [TestClass]
    public class RoadPieceUnitTest
    {
        [TestMethod]
        public void Randomize()
        {
            roadPiece roadPiece = new roadPiece();
            for (int i = 0; i < 1000; i++)
            {
                int test = roadPiece.Randomize(10, 1000);
                Assert.IsTrue(test >= 10 && test <= 1000);
            }
        }

        [TestMethod]
        public void getNext()
        {
            // Test the null case
            roadPiece roadPiece1 = new roadPiece();
            Assert.IsNull(roadPiece1.getNext());

            // Test if only one roadPice is connected to this one
            roadPiece roadPiece2 = new roadPiece();
            roadPiece roadPiece2Child1 = new roadPiece();
            roadPiece[] roadPiece2array = new roadPiece[1];
            roadPiece2array[0] = roadPiece2Child1;
            roadPiece2.NextArray = roadPiece2array;
            Assert.AreSame(roadPiece2Child1, roadPiece2.getNext());

            // Test with 3 possibilities
            roadPiece roadPiece3 = new roadPiece();
            roadPiece roadPiece3Child1 = new roadPiece();
            roadPiece roadPiece3Child2 = new roadPiece();
            roadPiece roadPiece3Child3 = new roadPiece();
            roadPiece[] roadPiece3array = new roadPiece[3];
            roadPiece3array[0] = roadPiece3Child1;
            roadPiece3array[1] = roadPiece3Child2;
            roadPiece3array[2] = roadPiece3Child3;
            roadPiece3.NextArray = roadPiece3array;
            roadPiece next = roadPiece3.getNext();
            if (next != roadPiece3Child1 && next != roadPiece3Child2 && next != roadPiece3Child3)
            {
                Assert.Fail();
            }
            
        }
    }
}
