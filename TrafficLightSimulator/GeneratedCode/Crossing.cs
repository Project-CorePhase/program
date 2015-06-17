﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

[Serializable]
public class Crossing : RoadObject
{
    private System.Drawing.Point centerPoint = new System.Drawing.Point(71, 71);
    // Constrcutor
    public Crossing(Point pp,CrossingType ct, Image img) : base(pp)
    {
        this.Image = img;
        this.Coordinate = pp;
        
        this.ReferencePath = new roadPiece[4];
        this.ReferencePathLinked = new Boolean[4];
        // Create all the end point needed by the crossing, those will be connected by the simulator to the other crossing
        // The direction is relative to the crossing, 
        // Deg0 Done
        EndPoints = new roadPiece[4];
        EndPoints[(int)Orientation.Degree0] = new roadPiece(this, (roadPiece)null);
        EndPoints[(int)Orientation.Degree0].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, this.Oriention);
        EndPoints[(int)Orientation.Degree0].coordinate = new System.Drawing.Point(10, 55);

        // Deg90 Done
        EndPoints[(int)Orientation.Degree90] = new roadPiece(this, (roadPiece)null);
        EndPoints[(int)Orientation.Degree90].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, this.Oriention);
        EndPoints[(int)Orientation.Degree90].coordinate = new System.Drawing.Point(84, 10);

        // Deg180 Done
        EndPoints[(int)Orientation.Degree180] = new roadPiece(this, (roadPiece)null);
        EndPoints[(int)Orientation.Degree180].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, this.Oriention);
        EndPoints[(int)Orientation.Degree180].coordinate = new System.Drawing.Point(135, 85);

        // Deg270 Done
        EndPoints[(int)Orientation.Degree270] = new roadPiece(this, (roadPiece)null);
        EndPoints[(int)Orientation.Degree270].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree270, this.Oriention);
        EndPoints[(int)Orientation.Degree270].coordinate = new System.Drawing.Point(56, 135);


        switch (ct)
        {
            case CrossingType.CrossingWithoutPedestrian:
                Image = TrafficLightSimulator.Properties.Resources.crossingA;
                crossingWithoutPedestrian();
                break;
            case CrossingType.CrossingWithPedestrian:
                Image = TrafficLightSimulator.Properties.Resources.crossingB;
                crossingWithPedestrian();
                break;
                
            default :
            System.Windows.Forms.MessageBox.Show("Error From the Crossing class");
                break;

        }
    }

    public System.Drawing.Point rotatePoint(Orientation o, System.Drawing.Point p)
    {
        double alpha = 0;
        switch (o)
        {
            case Orientation.Degree0:
                alpha = 0;
                break;
            case Orientation.Degree90:
                alpha = 90;
                break;
            case Orientation.Degree180:
                alpha = 180;
                break;
            case Orientation.Degree270:
                alpha = 270;
                break;
        }
        /*
         * p'x = cos(theta) * (px-ox) - sin(theta) * (py-oy) + ox
            p'y = sin(theta) * (px-ox) + cos(theta) * (py-oy) + oy
         * */
        alpha = Math.PI / 180 * alpha;

        double rotatedX = Math.Cos(alpha) * (p.X - centerPoint.X) - Math.Sin(alpha) * (p.Y - centerPoint.Y) + centerPoint.X;
        double rotatedY = Math.Sin(alpha) * (p.X - centerPoint.X) + Math.Cos(alpha) * (p.Y - centerPoint.Y) + centerPoint.Y;
        // No go back to the previous coordinate
        return new System.Drawing.Point((int)rotatedX, (int)rotatedY);

    }

    // Methods
    public Orientation getGlobalOrientationFromLocal(Orientation local, Orientation global)
    {
        int localAngle = 0;
        switch (local)
        {
            case Orientation.Degree0:
                localAngle = 0;
                break;
            case Orientation.Degree180:
                localAngle = 180;
                break;
            case Orientation.Degree270:
                localAngle = 270;
                break;
            case Orientation.Degree90:
                localAngle = 90;
                break;
        }

        int globalAngle = 0;
        switch (global)
        {
            case Orientation.Degree0:
                globalAngle = 0;
                break;
            case Orientation.Degree180:
                globalAngle = 180;
                break;
            case Orientation.Degree270:
                globalAngle = 270;
                break;
            case Orientation.Degree90:
                globalAngle = 90;
                break;
        }
        int resultAngle = (globalAngle + localAngle)%360;
        switch (resultAngle)
        {
            case 0:
                return Orientation.Degree0;
            case 180:
                return Orientation.Degree180;
            case 270:
                return Orientation.Degree270;
            case 90:
                return Orientation.Degree90;
        }
        // We want to come back to [0, 270]

        return local;
    }

    // Method : Instead of two diffrent classes

    void crossingWithPedestrian()
    {
        this.Image = TrafficLightSimulator.Properties.Resources.crossingB;

        PedestrianStartPoint = new roadPiece[4];
        PedestrianStartPoint[0] = new roadPiece(this, new roadPiece[]{});
        PedestrianStartPoint[0].coordinate = rotatePoint(getGlobalOrientationFromLocal(global::Orientation.Degree90, this.orientation), new System.Drawing.Point(130, 27));
        PedestrianStartPoint[0].size = new System.Drawing.Point(75, 75);
        
        PedestrianStartPoint[1] = new roadPiece(this, new roadPiece[] { });
        PedestrianStartPoint[1].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, this.orientation);
        PedestrianStartPoint[1].coordinate = rotatePoint(getGlobalOrientationFromLocal(global::Orientation.Degree90, this.orientation), new System.Drawing.Point(135, 27+75));
        PedestrianStartPoint[1].size = new System.Drawing.Point(75, 75);

        PedestrianStartPoint[2] = new roadPiece(this, new roadPiece[] { });
        PedestrianStartPoint[2].coordinate = rotatePoint(getGlobalOrientationFromLocal(global::Orientation.Degree90, this.orientation), new System.Drawing.Point(15, 27));
        PedestrianStartPoint[2].size = new System.Drawing.Point(75, 75);

        PedestrianStartPoint[3] = new roadPiece(this, new roadPiece[] { });
        PedestrianStartPoint[3].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, this.orientation);
        PedestrianStartPoint[3].coordinate = rotatePoint(getGlobalOrientationFromLocal(global::Orientation.Degree90, this.orientation), new System.Drawing.Point(20, 27 + 75));
        PedestrianStartPoint[3].size = new System.Drawing.Point(75, 75);

        // List of all direction
        Orientation[] todo = { Orientation.Degree0, Orientation.Degree90, Orientation.Degree180, Orientation.Degree270 };
        // For all direction, we're making the graph
        foreach (Orientation localO in todo)
        {
            // First, we need the global direction of this direction
            Orientation o = getGlobalOrientationFromLocal(localO, this.Oriention);

            // First endpoint
            roadPiece rp3deg0EndPoint = new roadPiece(this, EndPoints[(int)getGlobalOrientationFromLocal(localO, Orientation.Degree180)]);
            // Orientation of the roadpiece ?
            rp3deg0EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, o);
            // Now generating the good coordinate from 84, 125 which is the point on the picture of Abdullah
            rp3deg0EndPoint.coordinate = rotatePoint(o, new System.Drawing.Point(100, 90));
            rp3deg0EndPoint.size = new System.Drawing.Point(30, 30);

            roadPiece rp1 = new roadPiece(this, rp3deg0EndPoint);
            rp1.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp1.size = new System.Drawing.Point(23, 23);
            rp1.trafficlightRefrence = new TrafficLight(CrossingType.CrossingWithoutPedestrian);
            rp1.coordinate = rotatePoint(o, new System.Drawing.Point(100, 133));


            roadPiece rp5deg90EndPoint = new roadPiece(this, EndPoints[(int)getGlobalOrientationFromLocal(localO, Orientation.Degree90)]);
            rp5deg90EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp5deg90EndPoint.coordinate = rotatePoint(o, new System.Drawing.Point(84, 40));
            rp5deg90EndPoint.size = new System.Drawing.Point(30, 30);

            roadPiece rp6deg180EndPoint = new roadPiece(this, EndPoints[(int)getGlobalOrientationFromLocal(localO, Orientation.Degree0)]);
            rp6deg180EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp6deg180EndPoint.coordinate = rotatePoint(o, new System.Drawing.Point(84, 40));
            rp6deg180EndPoint.size = new System.Drawing.Point(84, 84);

            roadPiece rp4 = new roadPiece(this, new roadPiece[] { rp5deg90EndPoint, rp6deg180EndPoint });//rp6deg180EndPoint rp6deg180EndPoint
            rp4.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp4.coordinate = rotatePoint(o, new System.Drawing.Point(84, 115));
            rp4.size = new System.Drawing.Point(75, 75);

            roadPiece rp2 = new roadPiece(this, rp4);
            rp2.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp2.coordinate = rotatePoint(o, new System.Drawing.Point(84, 140));
            rp2.size = new System.Drawing.Point(25, 25);
            roadPiece rp0StartPoint = new roadPiece(this, new roadPiece[] { rp2, rp1 }); // manque rp1 rp2
            rp0StartPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp0StartPoint.coordinate = rotatePoint(o, new System.Drawing.Point(90, 150));

            //  assign the start point
            this.ReferencePath[(int)localO] = rp0StartPoint;
            this.ReferencePathLinked[(int)localO] = false; // not conencted first
        }
    }

    void crossingWithoutPedestrian()
    {
        this.Image = TrafficLightSimulator.Properties.Resources.crossingA;
        // List of all direction
        Orientation[] todo = {Orientation.Degree0, Orientation.Degree90, Orientation.Degree180 ,Orientation.Degree270};
        // For all direction, we're making the graph
        foreach (Orientation localO in todo) {
            // First, we need the global direction of this direction
            Orientation o = getGlobalOrientationFromLocal(localO, this.Oriention);

            // First endpoint
            roadPiece rp3deg0EndPoint = new roadPiece(this, EndPoints[(int)getGlobalOrientationFromLocal(localO, Orientation.Degree180)]);
            // Orientation of the roadpiece ?
            rp3deg0EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, o);
            // Now generating the good coordinate from 84, 125 which is the point on the picture of Abdullah
            rp3deg0EndPoint.coordinate = rotatePoint(o, new System.Drawing.Point(100, 90));
            rp3deg0EndPoint.size = new System.Drawing.Point(30, 30);

            roadPiece rp1 = new roadPiece(this, rp3deg0EndPoint);
            rp1.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp1.size = new System.Drawing.Point(23, 23);
            rp1.trafficlightRefrence = new TrafficLight(CrossingType.CrossingWithoutPedestrian);
            rp1.coordinate = rotatePoint(o, new System.Drawing.Point(100, 133));


            roadPiece rp5deg90EndPoint = new roadPiece(this, EndPoints[(int)getGlobalOrientationFromLocal(localO, Orientation.Degree90)]);
            rp5deg90EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp5deg90EndPoint.coordinate = rotatePoint(o, new System.Drawing.Point(84, 40));
            rp5deg90EndPoint.size = new System.Drawing.Point(30, 30);

            roadPiece rp6deg180EndPoint = new roadPiece(this, EndPoints[(int)getGlobalOrientationFromLocal(localO, Orientation.Degree0)]);
            rp6deg180EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp6deg180EndPoint.coordinate = rotatePoint(o, new System.Drawing.Point(84, 40));
            rp6deg180EndPoint.size = new System.Drawing.Point(84, 84);

            roadPiece rp4 = new roadPiece(this, new roadPiece[] { rp5deg90EndPoint, rp6deg180EndPoint });//rp6deg180EndPoint rp6deg180EndPoint
            rp4.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp4.coordinate = rotatePoint(o, new System.Drawing.Point(84, 115));
            rp4.size = new System.Drawing.Point(75, 75);

            roadPiece rp2 = new roadPiece(this, rp4);
            rp2.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp2.coordinate = rotatePoint(o, new System.Drawing.Point(84, 140));
            rp2.size = new System.Drawing.Point(25, 25);
            roadPiece rp0StartPoint = new roadPiece(this, new roadPiece[] {   rp2 , rp1}); // manque rp1 rp2
            rp0StartPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp0StartPoint.coordinate = rotatePoint(o, new System.Drawing.Point(90, 150));

            //  assign the start point
            this.ReferencePath[(int)localO] = rp0StartPoint;
            this.ReferencePathLinked[(int)localO] = false; // not conencted first
        }

    }
}

