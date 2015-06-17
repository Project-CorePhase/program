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

[Serializable]
public class TrafficLight
{
    // Fields 
    //****************************************************************************************************************************************
    private TrafficColor CurrentColor;
    private Point trafficlightCordinate;

    // Properties
    //*****************************************************************************************************************************************
    // Constructor
    public TrafficLight(CrossingType ct , Point tlc)
    {
        CurrentColor = new TrafficColor();
        trafficlightCordinate = tlc;
    }

    //*****************************************************************************************************************************************
    // Methods
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
    //*****************************************************************************************************************************************
}

