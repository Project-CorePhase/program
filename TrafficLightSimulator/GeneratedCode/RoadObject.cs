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
public abstract class RoadObject
{

    // Fields & properties
    private RoadObject[] startArray;
    private roadPiece[] referencePath;
    private Boolean[] referencePathLinked;
    private roadPiece[] endPoints;
    private roadPiece[] pedestrianStartPoint = null;
    private int cellIndexInGrid = 0;  // Each Cell has a uniqe Number
    private Point coordinate;        // Where each crossing should be drawn 
    private Image image;             // Refrence to crossing Image
    public Orientation orientation;     // How to orintate : Default by 0 deggres
    private TrafficController trafficController;

 
    //Adding a list with all the connections (from 2 to 4)
    private List<RoadObject> connections = null;


    public RoadObject[] StartArray { get { return startArray; } set { startArray = value; } }
    public roadPiece[] ReferencePath { get { return referencePath; } set { referencePath = value; } }
    public Boolean[] ReferencePathLinked { get { return referencePathLinked; } set { referencePathLinked = value; } }
    public roadPiece[] EndPoints { get { return endPoints; } set { endPoints = value; } }
    public roadPiece[] PedestrianStartPoint { get { return pedestrianStartPoint; } set { pedestrianStartPoint = value; } }
    public List<RoadObject> Connections() { return connections; }
    public int CellIndexInGrid { get { return cellIndexInGrid; } set { cellIndexInGrid = value; } }
    public Point Coordinate { get { return coordinate; } set { coordinate = value; } }
    public Image Image { get { return image; } set { image = value; } }
    public Orientation Oriention { get { return orientation; } set { orientation = value; } }
    public TrafficController TrafficController { get { return trafficController; } set { trafficController = value; }}

    // Constructor 
    public RoadObject(Point p)
    {
        cellIndexInGrid++;
        p = coordinate;
        Image = null;
    }



    // Methods
    public void SetOrientation(Orientation arg)
    {
        throw new System.NotImplementedException();
    }
    public void AddConnection(RoadObject next)
    {
        connections.Add(next);
    }
    public void Update()
    {
        throw new System.NotImplementedException();
    }
    public RoadObject GetRoadObject()
    {
        throw new System.NotImplementedException();
    }

}

