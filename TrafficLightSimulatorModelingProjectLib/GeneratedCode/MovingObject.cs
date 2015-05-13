//------------------------------------------------------------------------------
// Emeric Class
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightSimulatorProgram
{

    public class MovingObject
    {
        public System.Drawing.Point coordinateInRoadPiece
        {
            get;
            set;
        }

        public Boolean isPedestrian
        {
            get;
            set;
        }

        public Boolean isAlive
        {
            get;
            set;
        }

        public System.Drawing.Rectangle picture
        {
            get;
            set;
        }

        public roadPiece path
        {
            get;
            set;
        }

        public MovingObject(Boolean isPedest, roadPiece startPoint) {
            isPedestrian = isPedest;
            isAlive = true;
            coordinateInRoadPiece = new System.Drawing.Point();
            picture = new System.Drawing.Rectangle(coordinateInRoadPiece, new System.Drawing.Size(10, 10));
            path = startPoint;
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public System.Drawing.Point GetPosition()
        {
            throw new System.NotImplementedException();
        }

    }

}