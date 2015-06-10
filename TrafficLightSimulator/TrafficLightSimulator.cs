using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public TrafficLightSimulator()
        {
            InitializeComponent();
            simulator = new Simulator(this);
            myGrid = new Grid(24);
            g = pictureBoxGrid.CreateGraphics();

        }

        public void drawMovingObject(List<MovingObject> mo)
        {
            Graphics ga = pictureBoxGrid.CreateGraphics();
            Brush brush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(brush);
            foreach (MovingObject moving in mo)
            {
                // Coordinate ARE LOCALS, TODO : make GLOBAL
                roadPiece rp = moving.Path;
                int x = rp.coordinate.X + moving.CoordinateInRoadPiece.X;
                int y = rp.coordinate.Y + moving.CoordinateInRoadPiece.Y;
                ga.DrawEllipse(pen, x, moving.CoordinateInRoadPiece.Y, 2, 2);
            }
            this.DoubleBuffered = true; 
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
                roadObject = new Crossing(draggedPointer, CrossingType.CrossingWithoutPedestrian);
                Bitmap image = new Bitmap(draggedImage);
                g.DrawImage(image, draggedPointer);
                simulator.AddCrossing(roadObject);
                Console.WriteLine("Crossing A was Drawn");
            }
            else if (draggedImage == pictureBox_CrossingB.Image)
            {
                roadObject = new Crossing(draggedPointer, CrossingType.CrossingWithPedestrian);
                Bitmap image = new Bitmap(draggedImage);
                g.DrawImage(image, draggedPointer);
                simulator.AddCrossing(roadObject);
                Console.WriteLine("Crossing B was Drawn");
            }
            else
            {
                MessageBox.Show("Non of the crossings");
                Console.WriteLine("Crossing xyz was Drawn");
            }
        }

        /* Form Paint Event*/
        private void pictureBox_Grid_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            int SquareSize = 150;
            for (int i = 0; i < 4; i++)
            {
                gr.DrawLine(Pens.Black, 0, i * SquareSize, 6 * SquareSize, i * SquareSize);
            }
            for (int j = 0; j < 7; j++)
            {
                gr.DrawLine(Pens.LightGray, j * SquareSize, 0, j * SquareSize, 4 * SquareSize);
            }
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
            simulator.SetTimerInterval(500);
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

      
      
