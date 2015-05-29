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
using System.Timers;
namespace TrafficLightSimulator
{
    public class Simulator
    {
        public Simulator()
        {
            UpdateTimer = new System.Timers.Timer();
            UpdateTimer.Elapsed += new ElapsedEventHandler(timerTicks);
        }

        private void timerTicks(object sender, ElapsedEventArgs e)
        {

            Console.WriteLine("Timer ticks !");
            Console.WriteLine("Moving movingObjects");
            if (MovingObjects == null) { return; }
            foreach (MovingObject mo in MovingObjects)
            {
                mo.Update();
            }


        }


        public Grid Grid
        {
            get;
            set;
        }

        public List<MovingObject> MovingObjects = null;

        public List<RoadObject> RoadObjects = null;

        public System.Timers.Timer UpdateTimer;



        public void AddCrossing(RoadObject ro)
        {
            if (RoadObjects == null)
            {
                RoadObjects = new List<RoadObject>();
            }
            RoadObjects.Add(ro);
        }

        public void RemoveCrossing()
        {
            throw new System.NotImplementedException();
        }

        public void MoveCrossing()
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public void SetTimerInterval(int duration)
        {
            if (duration == 0)
            {
                UpdateTimer.Stop();
            }
            else
            {
                Reset();
                UpdateTimer.Interval = duration;
                UpdateTimer.Start();
            }
        }

        public void Reset()
        {
            if (RoadObjects == null)
            {
                return;
            }
            // Setting everything ready for the simulator   
            
            // First create the link between the crossing
            foreach (RoadObject ro in RoadObjects)
            {
/*Oriention[] todo = {Oriention.Degree0, Oriention.Degree180, Oriention.Degree270, Oriention.Degree90};
                // Looking for all starting point of the object, and trying to get the endpoint of the other
                foreach (Oriention o in todo) {
                    if (ro.ReferencePath[o] == null) { continue; }
                    // Looking for the neighdoor
                    
                }*/
            }

            // Seconds we have to create cars
            MovingObjects = new List<MovingObject>();


            // We looking for each startpoint of RoadObject
            foreach (RoadObject ro in RoadObjects)
            {
                foreach (roadPiece rp in ro.ReferencePath)
                {
                    // Create a car into the roadPiece
                    // TODO : LINK BETWEEN STARTPOINT AND NEIGHDOOR ENDPOINT
                    MovingObject car = new MovingObject(false, rp);
                    MovingObjects.Add(car);
                }
            }

        }

        public void updateGraphic()
        {
            throw new System.NotImplementedException();
        }

        private void addConnections()
        {
            List<Cell> allCells = Grid.GetCellsWithRoadObject();
            int x, y;
            foreach (Cell cell in allCells)
            {
                x = cell.GetCellX();
                y = cell.GetCellY();

                foreach (Cell neighbour in allCells)
                {
                    if (neighbour != cell)
                    {
                        // Link all the startpoint and the endpoint of the neighbour to the current cells
                        Oriention[] todo = {Oriention.Degree0, Oriention.Degree180, Oriention.Degree270, Oriention.Degree90};
                        // Looking for all starting point of the object, and trying to get the endpoint of the other
                        foreach (Oriention o in todo) {
                            // Looking for the neighdoor
                            // Looking for the start point of the current grid and current orientation
                           // roadPiece destination = neighbour.GetRoadObject().endPoints[(int)o];
                            // TODO : set oppoositOfO
                           // roadPiece source = cell.GetRoadObject().ReferencePath[(int)oppositeOfO];
                           // source.NextArray = new roadPiece[] { destination };
                        }
                    }
                }
            }
        }
    }

}