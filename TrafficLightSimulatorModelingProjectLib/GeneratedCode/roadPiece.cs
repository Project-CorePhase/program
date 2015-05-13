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

	public virtual roadPiece getNext()
	{
        if (NextArray == null)
        {
            return null;
        }
        if (NextArray.Length == 1)
        {
            return NextArray[0];
        }
        return NextArray[Randomizer.Next(0, NextArray.Length-1)];
	}

	public virtual void Randomize()
	{
		throw new System.NotImplementedException();
	}

	public virtual System.Drawing.Point GetCoordinates()
	{
		throw new System.NotImplementedException();
	}

	public virtual void PushSensorButton()
	{
		throw new System.NotImplementedException();
	}

}

