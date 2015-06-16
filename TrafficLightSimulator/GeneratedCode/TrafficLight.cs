﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

[Serializable]
public class TrafficLight
{
    // Fields 
    Point[] trafficCordinates = new Point[4];                   // Car Traffic Cordinates
    Point[] pedstrianTrafficCordinates = new Point[4];          // Pedstrian With Two Colors
    Size colorSize = new Size(4, 4);                            // Size of the Rectangle
    Color[] Colors = { Color.Red, Color.Yellow, Color.Green }; // All Possible Colors
    Rectangle[] TrafficLightMachine;                           // The rectangle will hold the cordinate of the all traffic light
    int innerCounter;                                           // Counter For How many Seconds each traffic - "Stand Alone" - can be set for
    int outterCounter;                                          //Counter For the pair of each Traffic light;
    private TrafficColor CurrentColor;

    // Properties
    public Point[] TrafficCordinates { get { return trafficCordinates; } set { trafficCordinates = value; } }
    public Point[] PedstrianTrafficCordinates { get { return pedstrianTrafficCordinates; } set { pedstrianTrafficCordinates = value; } }
    // Constructor
    public TrafficLight(CrossingType ct)
    {
        CurrentColor = new TrafficColor();

        switch (ct)
        {
            case CrossingType.CrossingWithPedestrian:
                // For pedstrian
                pedstrianTrafficCordinates[(int)Orientation.Degree0] = new Point(30, 30);
                pedstrianTrafficCordinates[(int)Orientation.Degree90] = new Point(120, 10);
                pedstrianTrafficCordinates[(int)Orientation.Degree180] = new Point(30, 140);
                pedstrianTrafficCordinates[(int)Orientation.Degree270] = new Point(104, 140);
                // For Cards 
                trafficCordinates[(int)Orientation.Degree0] = new Point(120, 30);
                trafficCordinates[(int)Orientation.Degree90] = new Point(30, 120);
                break;
            //
            case CrossingType.CrossingWithoutPedestrian:
                trafficCordinates[(int)Orientation.Degree0] = new Point(32, 32);
                trafficCordinates[(int)Orientation.Degree90] = new Point(120, 30);
                trafficCordinates[(int)Orientation.Degree180] = new Point(32, 120);
                trafficCordinates[(int)Orientation.Degree270] = new Point(110, 120);
                break;
        }
    }


    // Methods
 

    public void SetInnerCounter(int Seconds)
    {
        innerCounter = Seconds;
    }
    public void SetOutterCounter(int Seconds)
    {
        outterCounter = Seconds;
    }

    public void SetColor(TrafficColor color)
    {
        switch (color)
        {
            case TrafficColor.Red:
                CurrentColor = TrafficColor.Red;
                break;
            case TrafficColor.Yellow:
                CurrentColor = TrafficColor.Yellow;
                break;
            case TrafficColor.Green:
                CurrentColor = TrafficColor.Green;
                break;

        }
    }
    public TrafficColor GetColor()
    {
        return CurrentColor;
    }

}

