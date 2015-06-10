//------------------------------------------------------------------------------
// Emeric Class
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightSimulator
{
    [Serializable]
    public class MovingObject
    {
        // the size in pixel for calculate the coordinate
        private int roadPieceSize = 10;
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
            coordinateInRoadPiece = new System.Drawing.Point(0, 0);
            picture = new System.Drawing.Rectangle(coordinateInRoadPiece, new System.Drawing.Size(2, 2));
            path = startPoint;
        }

        public void Update()
        {
            Boolean animationDone = false;
            switch (path.orientation)
            {
                case Orientation.Degree90:
                    if (coordinateInRoadPiece.Y < roadPieceSize)
                    {
                        coordinateInRoadPiece = new System.Drawing.Point(coordinateInRoadPiece.X, coordinateInRoadPiece.Y+1);
                    }
                    else animationDone = true;
                    break;
                case Orientation.Degree180:
                    if (coordinateInRoadPiece.X > -roadPieceSize)
                    {
                        coordinateInRoadPiece = new System.Drawing.Point(coordinateInRoadPiece.X-1, coordinateInRoadPiece.Y);
                    }
                    else animationDone = true;
                    break;
                case Orientation.Degree270:
                    if (coordinateInRoadPiece.Y > -roadPieceSize)
                    {
                        coordinateInRoadPiece = new System.Drawing.Point(coordinateInRoadPiece.X, coordinateInRoadPiece.Y-1);
                    }
                    else animationDone = true;
                    break;
                default:
                    if (coordinateInRoadPiece.X < roadPieceSize)
                    {
                        coordinateInRoadPiece = new System.Drawing.Point(coordinateInRoadPiece.X + 1, coordinateInRoadPiece.Y);
                    }
                    else animationDone = true;
                    break;
            }
            if (animationDone)
            {
                // We move the car to the next roadPiece (if exist)
                if (path.getNext() == null)
                {
                    // Car out of the road : should be destroy
                    throw new Exception();
                }
                else
                {
                    if (true) //path.trafficlightRefrence == null || path.trafficlightRefrence.GetColor() == TrafficColor.Green)
                    {
                        // We check if there is a traffic light and if i we can continue
                        path = path.getNext();
                        coordinateInRoadPiece = new System.Drawing.Point(0, 0);
                    }

                }
            }
 
        }

        public System.Drawing.Point GetPosition()
        {
            return coordinateInRoadPiece;
        }

    }

}