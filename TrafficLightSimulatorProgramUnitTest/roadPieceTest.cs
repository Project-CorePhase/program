using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLightSimulatorProgram;

namespace TrafficLightSimulatorProgramUnitTest
{
    [TestClass]
    public class roadPieceTest
    {
        [TestMethod]
        public void getNext()
        {
            roadPiece roadPiece1 = new roadPiece();
            Assert.IsNull(roadPiece1.getNext());
        }
    }
}
