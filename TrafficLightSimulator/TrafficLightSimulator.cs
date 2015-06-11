﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightSimulator
{

    [Serializable]
    public partial class TrafficLightSimulator : Form
    {
        private Simulator simulator;
        private Grid myGrid;
        private Graphics g;
        Brush brush;
        Pen pen;

        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;

        public TrafficLightSimulator()
        {
            InitializeComponent();
            simulator = new Simulator(this);
            myGrid = new Grid(24);
            this.DoubleBuffered = true; 
            //g = pictureBoxGrid.CreateGraphics();
            brush = new SolidBrush(Color.Blue);
            pen = new Pen(brush);


        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void drawRoadObjects(List<RoadObject> ros)
        {
            foreach (RoadObject roadObject in ros)
            {
                Point draggedPointer = roadObject.Coordinate;
                g.DrawImage(roadObject.bitmap, draggedPointer);
            }
        }

        public void drawGrid()
        {
            int SquareSize = 150;
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(Pens.Black, 0, i * SquareSize, 6 * SquareSize, i * SquareSize);
            }
            for (int j = 0; j < 7; j++)
            {
                g.DrawLine(Pens.LightGray, j * SquareSize, 0, j * SquareSize, 4 * SquareSize);
            }
        }

        public void drawMovingObject(List<MovingObject> mo)
        {
            foreach (MovingObject moving in mo)
            {
                RoadObject roadObject = moving.Path.RoadObject;
                roadPiece rp = moving.Path;
                int x = roadObject.Coordinate.X + rp.coordinate.X + moving.CoordinateInRoadPiece.X;
                int y = roadObject.Coordinate.Y + rp.coordinate.Y + moving.CoordinateInRoadPiece.Y;
                g.DrawEllipse(pen, x, y, 4, 4);
            }
            
        }

        public void clear()
        {
            g.Clear(Color.White);
        }

        public void render()
        {
            myBuffer.Render();
        }

        /* Drag & Drop Event*/
        private void pictureBoxGrid_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void pictureBox_CrossingA_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox_CrossingA.DoDragDrop(pictureBox_CrossingA.Image, DragDropEffects.Copy);
        }
        private void pictureBox_CrossingB_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox_CrossingB.DoDragDrop(pictureBox_CrossingB.Image, DragDropEffects.Copy);
        }
        private Point RoundXY(Point rawPoint)
        {
            int XX = (rawPoint.X / 150) * 150;
            int XY = (rawPoint.Y / 150) * 150;
            return new Point(XX, XY);
        }
        private void pictureBoxGrid_DragDrop(object sender, DragEventArgs e)
        {
            // TODO Abdullah
            RoadObject roadObject = null; // Declaration
            Image draggedImage = (Image)e.Data.GetData(DataFormats.Bitmap); // Get Imaged Draged
            Point draggedPointer = RoundXY(pictureBoxGrid.PointToClient(new Point(e.X, e.Y))); // Where to draw Image
            if (draggedImage == pictureBox_CrossingA.Image)
            {
                roadObject = new Crossing(draggedPointer, CrossingType.CrossingWithoutPedestrian, draggedImage);
                roadObject.bitmap = new Bitmap(draggedImage);
                simulator.AddCrossing(roadObject);
                Console.WriteLine("Crossing A was Drawn");
            }
            else if (draggedImage == pictureBox_CrossingB.Image)
            {
                roadObject = new Crossing(draggedPointer, CrossingType.CrossingWithPedestrian, draggedImage);
                roadObject.bitmap = new Bitmap(draggedImage);
                simulator.AddCrossing(roadObject);
                Console.WriteLine("Crossing B was Drawn");
            }
            else
            {
                MessageBox.Show("Non of the crossings");
                Console.WriteLine("Crossing xyz was Drawn");
            }
            clear();
            drawGrid();
            drawRoadObjects(simulator.RoadObjects);
            render();
        }

        /* Form Paint Event*/
        private void pictureBox_Grid_Paint(object sender, PaintEventArgs e)
        {

            Graphics gr = e.Graphics;
            gr.Clear(Color.White);
            int SquareSize = 150;
            for (int i = 0; i < 4; i++)
            {
                gr.DrawLine(Pens.Black, 0, i * SquareSize, 6 * SquareSize, i * SquareSize);
            }
            for (int j = 0; j < 7; j++)
            {
                gr.DrawLine(Pens.LightGray, j * SquareSize, 0, j * SquareSize, 4 * SquareSize);
            }

            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(pictureBoxGrid.CreateGraphics(),
            pictureBoxGrid.DisplayRectangle);
            g = myBuffer.Graphics;
        }


        /* Mouse Tracking*/
        private void TrafficLightSimulator_MouseMove(object sender, MouseEventArgs e)
        {
            label_MouseLocation.Text = e.Location.X + "," + e.Location.Y;
        }
        private void pictureBoxGrid_MouseMove(object sender, MouseEventArgs e)
        {
            label_MouseLocation.Text = e.Location.X + "," + e.Location.Y;
        }
        /*Menu Item */
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            simulator.SetTimerInterval(100);
        }
        /* Form Load Event */
        private void TrafficLightSimulator_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            pictureBoxGrid.AllowDrop = true;
            pictureBox_CrossingA.AllowDrop = true;
            pictureBox_CrossingB.AllowDrop = true;
            Console.WriteLine("Form Loaded With all Working componets");
        }
        /* Easter Egg*/
        private void clickMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            MessageBox.Show("Application was created by A", "System Shutdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }
        //*Save methods */
        public bool SaveMethod()
        {
            Stream saveStream = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();


            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
          

            try
            {
                if ((saveStream = saveFileDialog.OpenFile()) != null)
                {
                    IFormatter formater = new BinaryFormatter();
                    formater.Serialize(saveStream, myGrid);
                }
                return true;
            }
            catch (SerializationException e)
            {
                MessageBox.Show("A problem occurred, please try again.\n" + e.Message);
                return false;
            }
            catch (IOException x)
            {
                MessageBox.Show(x.Message);
                return false;
            }
            finally
            {
                if (saveStream != null) saveStream.Close();
            }

        }

        private void MenuItem_File_SaveSimulator_Click(object sender, EventArgs e)
        {
            SaveMethod();
        }
    }
}

      
      
