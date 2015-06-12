//------------------------------------------------------------------------------
// Emeric Class
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class roadPiece
{
    
    public Orientation orientation { get; set; }
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

    public roadPiece[] endPoints = new roadPiece[4];

	public System.Drawing.Point coordinate
	{
		get;
		set;
	}

    public System.Drawing.Point size
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
        size = new System.Drawing.Point(10, 10);
        Randomizer = new Random();
        coordinate = new System.Drawing.Point();
        trafficlightRefrence = null;
        NextArray = null;
        Sensor = null;
        orientation = Orientation.Degree0;
    }

    public roadPiece(RoadObject ro,roadPiece next)
    {
        size = new System.Drawing.Point(10, 10);
        RoadObject = ro;
        Randomizer = new Random();
        coordinate = new System.Drawing.Point();
        trafficlightRefrence = null;
        orientation = Orientation.Degree0;
        NextArray = new roadPiece[1];
        NextArray[0] = next;
        Sensor = null;
    }

    public roadPiece(RoadObject ro, roadPiece[] nexts)
    {
        size = new System.Drawing.Point(10, 10);
        RoadObject = ro;
        Randomizer = new Random();
        coordinate = new System.Drawing.Point();
        orientation = Orientation.Degree0;
        trafficlightRefrence = null;
        NextArray = nexts;
        Sensor = null;
    }

    public void addNextRoadPiece(roadPiece n) {
        if (NextArray == null)
        {
            NextArray = new roadPiece[1];
            NextArray[0] = n;
            return;
        }

        roadPiece[] newArray = new roadPiece[NextArray.Length + 1];
        int i;
        for (i = 0; i < NextArray.Length; i++)
        {// Copy the old array
            newArray[i] = NextArray[i];
        }
        newArray[i] = n;
        // Push the new element on the array

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
        return NextArray[Randomize(0, NextArray.Length)];
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

