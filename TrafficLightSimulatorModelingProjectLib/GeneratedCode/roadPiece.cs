//------------------------------------------------------------------------------
// Emeric Class
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class roadPiece
{

	public TrafficLight trafficlightRefrence
	{
		get;
		set;
	}

	public Random Randomizer
	{
		get;
		set;
	}

	public roadPiece[] NextArray
	{
		get;
		set;
	}

	public System.Drawing.Point coordinate
	{
		get;
		set;
	}

	public RoadObject RoadObject
	{
		get;
		set;
	}

	public Sensor Sensor
	{
		get;
		set;
	}

    public roadPiece()
    {
        Randomizer = new Random();
        coordinate = new System.Drawing.Point();
        trafficlightRefrence = null;
        NextArray = null;
        Sensor = null;
    }

    public roadPiece(roadPiece next)
    {
        Randomizer = new Random();
        coordinate = new System.Drawing.Point();
        trafficlightRefrence = null;
        NextArray = new roadPiece[1];
        NextArray[0] = next;
        Sensor = null;
    }

    public roadPiece(roadPiece[] nexts)
    {
        Randomizer = new Random();
        coordinate = new System.Drawing.Point();
        trafficlightRefrence = null;
        NextArray = nexts;
        Sensor = null;
    }

	public roadPiece getNext()
	{
        if (NextArray == null)
        {
            return null;
        }
        if (NextArray.Length == 1)
        {
            return NextArray[0];
        }
        return NextArray[Randomize(0, NextArray.Length - 1)];
	}

	public int Randomize(int min, int max)
	{
        return Randomizer.Next(min, max);
	}

	public System.Drawing.Point GetCoordinates()
	{
        return coordinate;
	}

	public void PushSensorButton()
	{
		if (Sensor != null) {
            Sensor.SetState(true);
        }
	}

}

