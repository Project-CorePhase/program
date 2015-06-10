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

public class Crossing : RoadObject
{

    // Constrcutor
    public Crossing(Point pp,CrossingType ct) : base(pp)
    {
        this.Coordinate = pp;

        this.ReferencePath = new roadPiece[4];
        this.ReferencePathLinked = new Boolean[4];
        // Create all the end point needed by the crossing, those will be connected by the simulator to the other crossing
        // The direction is relative to the crossing, 
        // Deg0
        EndPoints = new roadPiece[4];
        EndPoints[(int)Orientation.Degree0] = new roadPiece((roadPiece)null);
        EndPoints[(int)Orientation.Degree0].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, this.Oriention);
        EndPoints[(int)Orientation.Degree0].coordinate = new System.Drawing.Point(10, 10);

        // Deg90
        EndPoints[(int)Orientation.Degree90] = new roadPiece((roadPiece)null);
        EndPoints[(int)Orientation.Degree90].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, this.Oriention);
        EndPoints[(int)Orientation.Degree90].coordinate = new System.Drawing.Point(10, 10);

        // Deg180
        EndPoints[(int)Orientation.Degree180] = new roadPiece((roadPiece)null);
        EndPoints[(int)Orientation.Degree180].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, this.Oriention);
        EndPoints[(int)Orientation.Degree180].coordinate = new System.Drawing.Point(10, 10);

        // Deg270
        EndPoints[(int)Orientation.Degree270] = new roadPiece((roadPiece)null);
        EndPoints[(int)Orientation.Degree270].orientation = getGlobalOrientationFromLocal(global::Orientation.Degree270, this.Oriention);
        EndPoints[(int)Orientation.Degree270].coordinate = new System.Drawing.Point(10, 10);


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
        Orientation[] todo = { Orientation.Degree0, Orientation.Degree180 };
        foreach (Orientation localO in todo)
        {
            // Pedestrian road
            PedestrianStartPoint[(int)localO] = new roadPiece((roadPiece)null);
            // car road

            Orientation o = getGlobalOrientationFromLocal(localO, this.orientation);


            roadPiece rp2RightEndPoint = new roadPiece(EndPoints[(int)Orientation.Degree0]);
            rp2RightEndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp2RightEndPoint.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp4TopEndPoint = new roadPiece(EndPoints[(int)Orientation.Degree90]);
            rp4TopEndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp4TopEndPoint.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp5LeftEndPoint = new roadPiece(EndPoints[(int)Orientation.Degree180]);
            rp5LeftEndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, o);
            rp5LeftEndPoint.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp3 = new roadPiece(new roadPiece[] {rp4TopEndPoint, rp5LeftEndPoint});
            rp3.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp3.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp1 = new roadPiece(new roadPiece[] { rp3, rp2RightEndPoint });
            rp1.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp1.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp0StartPoint = new roadPiece(rp1);
            rp0StartPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp0StartPoint.coordinate = new System.Drawing.Point(10, 10);
            //  assign the start point
            this.ReferencePath[(int)localO] = rp0StartPoint;
            this.ReferencePathLinked[(int)localO] = false; // not conencted first
        }

        // A5,A6, ...
        Orientation[] todo2 = { Orientation.Degree90, Orientation.Degree270 };
        foreach (Orientation localO in todo2)
        {
            Orientation o = getGlobalOrientationFromLocal(localO, this.Oriention);

            roadPiece rp12BottomEndPoint = new roadPiece(EndPoints[(int)Orientation.Degree270]);
            rp12BottomEndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree270, o);
            rp12BottomEndPoint.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp11 = new roadPiece(rp12BottomEndPoint);
            rp11.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, o);
            rp11.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp16RightEndPoint = new roadPiece(EndPoints[(int)Orientation.Degree0]);
            rp16RightEndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp16RightEndPoint.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp17TopEndPoint = new roadPiece(EndPoints[(int)Orientation.Degree90]);
            rp17TopEndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp17TopEndPoint.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp15 = new roadPiece(rp16RightEndPoint);
            rp15.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp15.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp14 = new roadPiece(new roadPiece[] { rp17TopEndPoint, rp15 });
            rp14.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp14.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp13 = new roadPiece(rp14);
            rp13.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp13.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp10StartPoint = new roadPiece(rp13);
            rp10StartPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp10StartPoint.coordinate = new System.Drawing.Point(10, 10);

            this.ReferencePath[(int)localO] = rp10StartPoint;
            this.ReferencePathLinked[(int)localO] = false; // not conencted first
        }
    }

    void crossingWithoutPedestrian()
    {
        this.Image = TrafficLightSimulator.Properties.Resources.crossingA;

        Orientation[] todo = {Orientation.Degree0, Orientation.Degree90, Orientation.Degree180 ,Orientation.Degree270};
        foreach (Orientation localO in todo) {
            Orientation o = getGlobalOrientationFromLocal(localO, this.Oriention);

            roadPiece rp3deg0EndPoint = new roadPiece(EndPoints[(int)Orientation.Degree0]);
            rp3deg0EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree0, o);
            rp3deg0EndPoint.coordinate = new System.Drawing.Point(10,10);

            roadPiece rp1 = new roadPiece(rp3deg0EndPoint);
            rp1.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp1.coordinate = new System.Drawing.Point(10, 10);


            roadPiece rp5deg90EndPoint = new roadPiece(EndPoints[(int)Orientation.Degree90]);
            rp5deg90EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp5deg90EndPoint.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp6deg180EndPoint = new roadPiece(EndPoints[(int)Orientation.Degree180]);
            rp6deg180EndPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree180, o);
            rp6deg180EndPoint.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp4 = new roadPiece(new roadPiece[] {rp6deg180EndPoint, rp5deg90EndPoint});
            rp4.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp4.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp2 = new roadPiece(rp4);
            rp2.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp2.coordinate = new System.Drawing.Point(10, 10);

            roadPiece rp0StartPoint = new roadPiece(new roadPiece[] { rp2 , rp1});
            rp0StartPoint.orientation = getGlobalOrientationFromLocal(global::Orientation.Degree90, o);
            rp0StartPoint.coordinate = new System.Drawing.Point(10, 10);

            //  assign the start point
            this.ReferencePath[(int)localO] = rp0StartPoint;
            this.ReferencePathLinked[(int)localO] = false; // not conencted first
        }
    }
}

