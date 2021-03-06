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
        TextBox[] textboxes;
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
                // Drawing Trafficlight
                /*foreach (TrafficLight tl in roadObject.TrafficController.TrafficGroupList)
                {
                    //Point trafficLightC = new Point(tl.coordinate.X + roadObject.Coordinate.X, )
                    //g.DrawImage(tl.imagen tl.coordinate)
                }*/
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
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


        [MethodImpl(MethodImplOptions.Synchronized)]
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

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void clear()
        {
            g.Clear(Color.White);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
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
            bool start = false;
            int i = 0;
            if (textboxes != null )
            {
                foreach (TextBox box in textboxes)
                {
                    if (box.Text != "")
                    {
                        start = true;
                    }
                    else
                    {
                        start = false;
                    }

                }
            }
            else if (simulator.RoadObjects != null)
            {
                AddTextBox();
            }
            else
            {
                MessageBox.Show("Please add a Road Object first!");
            }
            
            if (start)
            {
                simulator.amount = new int[textboxes.Count()];
                foreach (TextBox Tb in textboxes)
                {
                    simulator.amount[i] = Convert.ToInt32(Tb.Text);
                    simulator.counter += Convert.ToInt32(Tb.Text);
                    i++;
                }
                simulator.SetTimerInterval(100);
                toolStripButton3.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please enter The amount of cars you want!");
            }
            
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            simulator.FastForward(30);
        }

        private void openSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void addCarAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTextBox();
        }
        public void AddTextBox()
        {
            textboxes = new TextBox[simulator.RoadObjects.Count];
            int i = 0;
            foreach (RoadObject obj in simulator.RoadObjects)
            {
                TextBox txtBx = new TextBox();
                txtBx.MaxLength = 2;
                txtBx.BackColor = Color.White;
                txtBx.Size = new Size(25, 25);
                txtBx.KeyPress += txtBx_KeyPress;
                txtBx.TextChanged += txtBx_TextChanged;
                txtBx.Text = "0";
                txtBx.Location = new Point(obj.Coordinate.X + 65, obj.Coordinate.Y);
                textboxes[i] = txtBx;

                i++;
            }
            foreach (TextBox box in textboxes)
            {
                pictureBoxGrid.Controls.Add(box);
            }
        }
        void txtBx_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "0")
            {
                ((TextBox)sender).Clear();
            }
        }

        void txtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!simulator.pause)
            {
                simulator.SetTimerInterval(0);
                simulator.pause = true;
            }
            else if (simulator.pause)
            {
                simulator.SetTimerInterval(100);
                simulator.pause = false;
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            simulator.SetTimerInterval(0);
            simulator.Reset();
            clear();
            render();
            //Add DrawAll() method here!
            toolStripButton3.Enabled = true;
        }
    }
}

      
      
