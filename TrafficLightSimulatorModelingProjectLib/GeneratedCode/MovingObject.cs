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
        public virtual System.Drawing.Point coordinateInRoadPiece
        {
            get;
            set;
        }

        public virtual Boolean isPedestrian
        {
            get;
            set;
        }

        public virtual Boolean isAlive
        {
            get;
            set;
        }

        public virtual System.Drawing.Graphics picture
        {
            get;
            set;
        }

        public virtual roadPiece path
        {
            get;
            set;
        }

        public virtual void Update()
        {
            throw new System.NotImplementedException();
        }

        public virtual System.Drawing.Point GetPosition()
        {
            throw new System.NotImplementedException();
        }

    }

}