//------------------------------------------------------------------------------
// Emeric Class
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrafficLightSimulator
{
    [Serializable]
    public class MovingObject
    {
        // Feilds;
        // the size in pixel for calculate the coordinate
        private Point coordinateInRoadPiece;
        private Boolean isPedestrian;
        private Boolean isAlive;

        // Properties
        public Point CoordinateInRoadPiece { get { return coordinateInRoadPiece; } set { coordinateInRoadPiece = value; } }
        public Boolean IsPedestrian { get { return isPedestrian; } set { isPedestrian = value; } }
        public Boolean IsAlive { get { return isAlive; } set { isAlive = value; } }
        public Rectangle MovingObjectPicture { get; set; }

        public roadPiece Path { get; set; }


        // Constructor
        public MovingObject(Boolean isPedest, roadPiece startPoint)
        {
            IsPedestrian = isPedest;
            IsAlive = true;
            CoordinateInRoadPiece = new Point(0, 0);
            MovingObjectPicture = new Rectangle(coordinateInRoadPiece, new Size(10, 10));
            Path = startPoint;
        }

        // Methods
        public void Update()
        {
            Boolean animationDone = false;
            switch (Path.orientation)
            {
                case Orientation.Degree270:
                    if (coordinateInRoadPiece.Y < Path.size.Y)
                    {
                        coordinateInRoadPiece = new System.Drawing.Point(coordinateInRoadPiece.X, coordinateInRoadPiece.Y + 2);
                    }
                    else animationDone = true;
                    break;
                case Orientation.Degree0:
                    if (coordinateInRoadPiece.X > -Path.size.X)
                    {
                        coordinateInRoadPiece = new System.Drawing.Point(coordinateInRoadPiece.X - 2, coordinateInRoadPiece.Y);
                    }
                    else animationDone = true;
                    break;
                case Orientation.Degree90:
                    if (coordinateInRoadPiece.Y > -Path.size.Y)
                    {
                        coordinateInRoadPiece = new System.Drawing.Point(coordinateInRoadPiece.X, coordinateInRoadPiece.Y - 2);
                    }
                    else animationDone = true;
                    break;
                default:
                    if (coordinateInRoadPiece.X < Path.size.X)
                    {
                        coordinateInRoadPiece = new System.Drawing.Point(coordinateInRoadPiece.X + 2, coordinateInRoadPiece.Y);
                    }
                    else animationDone = true;
                    break;
            }
            if (animationDone)
            {
                // We move the car to the next roadPiece (if exist)
                if (Path.getNext() == null)
                {
                    // Car out of the road : should be destroy
                    throw new Exception();
                }
                else
                {
                    if (Path.getNext().trafficlightRefrence == null || Path.getNext().trafficlightRefrence.GetColor() == TrafficColor.Green)
                    {
                        // We check if there is a traffic light and if i we can continue
                        Path = Path.getNext();
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