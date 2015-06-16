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
[Serializable]
public class TrafficController
{
    //******************************************************************************************************************************
    // Feilds & properties
	private  List<TrafficLight> TrafficGroupList{ get; set;}
    int innerCounter;                                       // Counter For How many Seconds each traffic - "Stand Alone" - can be set for
    int outterCounter;                                      //Counter For the pair of each Traffic light;

    //******************************************************************************************************************************
    // constructor

    public TrafficController()
    {
        innerCounter = 6; // Every 6 seconds the timer will change the value By setting
        TrafficGroupList = new List<TrafficLight>();
    }

    //******************************************************************************************************************************
    //Methods
	public void SetSensor()
	{
        // TODO
	}

	public  void Update()
	{
        // Called at each timer tick 
        // Update Values By changeing the colors of each Cordinate in the traffic light 
        // The update Happens by the inner Counter and Outter Counter 
        innerCounter--;
        foreach (TrafficLight item in TrafficGroupList)
        {
            // TO DO : Form static set color to dynamic set color
            if (innerCounter <0 )
            {
                item.SetColor(TrafficColor.Green);
            }
            // Update all the values
        }
	}
    
    public void SetInnerCounter(int Seconds)
    {
        innerCounter = Seconds;
    } 
    public void SetOutterCounter(int Seconds)
    {
        outterCounter = Seconds;
    }

	public  List<TrafficLight> GetTrafficLight()
	{
        return this.TrafficGroupList;
	}

}

