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

public abstract class RoadObject
{
	public virtual RoadObject StartArray
	{
		get;
		set;
	}

    public roadPiece[] ReferencePath;
    public roadPiece[] endPoints;
    public roadPiece[] pedestrianStartPoint = null;
 
	public virtual int cellIndexInGrid
	{
		get;
		set;
	}

	public virtual System.Drawing.Point coordinate
	{
		get;
		set;
	}

	public virtual System.Drawing.Image Image
	{
		get;
		set;
	}

	public virtual Oriention Oriention
	{
		get;
		set;
	}

	public virtual TrafficController TrafficController
	{
		get;
		set;
	}

	public virtual void DrawRoadObject()
	{
		throw new System.NotImplementedException();
	}

	public virtual void SetOrientation(Oriention arg)
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddConnection(RoadObject next)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Update()
	{
		throw new System.NotImplementedException();
	}

	public virtual RoadObject GetRoadObject()
	{
		throw new System.NotImplementedException();
	}

}

