﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
namespace TrafficLightSimulator
{
    public class Simulator
    {
        int SquareSize = 150;
        TrafficLightSimulator onform;
        List<roadPiece> carStartPoints = null;
        public Simulator(TrafficLightSimulator form)
        {
            onform = form;
            UpdateTimer = new System.Timers.Timer();
            UpdateTimer.Elapsed += new ElapsedEventHandler(timerTicks);
        }

        private void addMovingObject(roadPiece rp, bool isPedestrian)
        {
            MovingObject mo = new MovingObject(isPedestrian, rp);
            if (MovingObjects == null)
            {
                MovingObjects = new List<MovingObject>();
            }
            MovingObjects.Add(mo);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void timerTicks(object sender, ElapsedEventArgs e)
        {
            
                Random rd = new Random();
                // Create moving object here, we have to look on the startpoint of the system
                foreach (roadPiece rp in carStartPoints)
                {
                    if (rp != null && rd.Next(100) > 70 && MovingObjects.Count < 30)
                    {
                        this.addMovingObject(rp, false);
                    }
                }

                if (MovingObjects == null) { return; }
                List<MovingObject> tmp = new List<MovingObject>();

                foreach (MovingObject mo in MovingObjects)
                {
                    try
                    {
                        mo.Update();
                        tmp.Add(mo);
                    }
                    catch (Exception ex)
                    {
                        tmp.Remove(mo);
                        // The car is out of the grid

                    }
                }
                MovingObjects = tmp;

   
                onform.clear();
                onform.drawGrid();
                onform.drawRoadObjects(this.RoadObjects);
                onform.drawMovingObject(this.MovingObjects);
                onform.render();

            
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
        public void FastForward(int duration)
        {
            if (UpdateTimer.Interval - duration > 0) { 
                UpdateTimer.Interval -= duration;
            }
        }

        public void Reset()
        {
            if (RoadObjects == null)
            {
                return;
            }
            // Setting everything ready for the simulator   
            // Reset referencePath Linked
            foreach (RoadObject ro in RoadObjects)
            {
                ro.ReferencePathLinked[(int)Orientation.Degree0] = false;
                ro.ReferencePathLinked[(int)Orientation.Degree90] = false;
                ro.ReferencePathLinked[(int)Orientation.Degree180] = false;
                ro.ReferencePathLinked[(int)Orientation.Degree270] = false;
            }


            // First create the link between the crossing
            addConnections();
            Console.WriteLine("Car Start point number : " + carStartPoints.Count);

            // Seconds we have to create cars
            MovingObjects = new List<MovingObject>();



        }

        public void updateGraphic()
        {
            throw new System.NotImplementedException();
        }

        private void addConnections()
        {
            carStartPoints = new List<roadPiece>(); // reset the list
            Console.WriteLine("Adding connections");
            foreach (RoadObject ro in RoadObjects)
            {
                foreach (RoadObject top in RoadObjects)
                {
                    if (ro == top) { continue; }
                    if (ro.Coordinate.X == top.Coordinate.X - SquareSize)
                    {
                        top.EndPoints[(int)Orientation.Degree0].NextArray = new roadPiece[] { ro.ReferencePath[(int)Orientation.Degree270] };
                        ro.ReferencePathLinked[(int)Orientation.Degree270] = true;
                    }
                    if (ro.Coordinate.Y == top.Coordinate.Y + SquareSize)
                    {
                        top.EndPoints[(int)Orientation.Degree270].NextArray = new roadPiece[] { ro.ReferencePath[(int)Orientation.Degree180] };
                        ro.ReferencePathLinked[(int)Orientation.Degree90] = true;
                    }
                    if (ro.Coordinate.X == top.Coordinate.X + SquareSize)
                    {
                        top.EndPoints[(int)Orientation.Degree180].NextArray = new roadPiece[] { ro.ReferencePath[(int)Orientation.Degree90] };
                        ro.ReferencePathLinked[(int)Orientation.Degree180] = true;
                    }
                    if (ro.Coordinate.Y == top.Coordinate.Y - SquareSize)
                    {
                        top.EndPoints[(int)Orientation.Degree90].NextArray = new roadPiece[] { ro.ReferencePath[(int)Orientation.Degree0] };
                        ro.ReferencePathLinked[(int)Orientation.Degree0] = true;
                    }
                }
            }
            foreach (RoadObject ro in RoadObjects)
            {
                // Note the car startpoint
                Orientation[] todo = { Orientation.Degree0, Orientation.Degree180, Orientation.Degree270, Orientation.Degree90 };
                foreach (Orientation o in todo)
                {
                    if (ro.ReferencePathLinked[(int)o] == false)
                    {
                        this.carStartPoints.Add(ro.ReferencePath[(int)o]);
                    }
                }
            }
        }
    }

}