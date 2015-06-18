using System;
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
        private Graphics myGraphics;
        private string lastSave;
        private string filename;
        private bool isSaved;
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
            //myGraphics = pictureBoxGrid.CreateGraphics();
            brush = new SolidBrush(Color.Blue);
            pen = new Pen(brush);

            timer1.Enabled = true;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void drawRoadObjects(List<RoadObject> ros)
        {
            foreach (RoadObject roadObject in ros)
            {
                Point draggedPointer = roadObject.Coordinate;
                myGraphics.DrawImage(roadObject.bitmap, draggedPointer);
                // Drawing Trafficlight
                roadObject.TrafficController.Update();  // Abdullah Added The code here
                foreach (TrafficLight item in roadObject.TrafficController.GetTrafficLight(1))
                {
                    myGraphics.DrawEllipse(new Pen(new SolidBrush(DetermineColorOfTrafficLight(item.GetColor()))), item.TrafficlightCordinate.X, item.TrafficlightCordinate.Y, 10, 10);
                    myGraphics.FillEllipse(new SolidBrush(DetermineColorOfTrafficLight(item.GetColor())), item.TrafficlightCordinate.X, item.TrafficlightCordinate.Y, 10, 10); ;
                }
                foreach (TrafficLight item in roadObject.TrafficController.GetTrafficLight(2))
                {
                    myGraphics.DrawEllipse(new Pen(new SolidBrush(DetermineColorOfTrafficLight(item.GetColor()))), item.TrafficlightCordinate.X, item.TrafficlightCordinate.Y, 10, 10);
                    myGraphics.FillEllipse(new SolidBrush(DetermineColorOfTrafficLight(item.GetColor())), item.TrafficlightCordinate.X, item.TrafficlightCordinate.Y, 10, 10); ;
                }
            }
        }

        // Drawing Components For the traffic light
        [MethodImpl(MethodImplOptions.Synchronized)]
        private Color DetermineColorOfTrafficLight(TrafficColor currentColor)
        {
            Color holder = Color.Purple; // Purple is for debugging purposses onliy
            switch (currentColor)
            {
                case TrafficColor.Red:
                    holder = Color.Red;
                    break;
                case TrafficColor.Yellow:
                    holder = Color.Yellow;
                    break;
                case TrafficColor.Green:
                    holder = Color.Green;
                    break;
            }
            return holder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void drawGrid()
        {
            int SquareSize = 150;
            for (int i = 0; i < 4; i++)
            {
                myGraphics.DrawLine(Pens.Black, 0, i * SquareSize, 6 * SquareSize, i * SquareSize);
            }
            for (int j = 0; j < 7; j++)
            {
                myGraphics.DrawLine(Pens.LightGray, j * SquareSize, 0, j * SquareSize, 4 * SquareSize);
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
                myGraphics.DrawEllipse(pen, x, y, 4, 4);
            }

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void clear()
        {
            myGraphics.Clear(Color.White);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (simulator.RoadObjects != null)
            {
                DrawAll();
            }
        }

        private void DrawAll()
        {
            clear();
            drawGrid();
            drawRoadObjects(simulator.RoadObjects);
            timer1.Enabled = true;
            render();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void render()
        {
            myBuffer.Render();
        }

        #region Drag Drop Events Method
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
                isSaved = false;
                Console.WriteLine("Crossing A was Drawn");
            }
            else if (draggedImage == pictureBox_CrossingB.Image)
            {
                roadObject = new Crossing(draggedPointer, CrossingType.CrossingWithPedestrian, draggedImage);
                roadObject.bitmap = new Bitmap(draggedImage);
                simulator.AddCrossing(roadObject);
                Console.WriteLine("Crossing B was Drawn");
                isSaved = false;
            }
            else if (draggedImage == pictureBox_StrightLane.Image)
            {
                roadObject = new Crossing(draggedPointer, CrossingType.Straigh, draggedImage);
                roadObject.bitmap = new Bitmap(draggedImage);
                simulator.AddCrossing(roadObject);
                Console.WriteLine("Straigh Lane was Drawn");
                isSaved = false;
            }
            else if (draggedImage == pictureBox_CurvedLane.Image)
            {
                roadObject = new Crossing(draggedPointer, CrossingType.Curved, draggedImage);
                roadObject.bitmap = new Bitmap(draggedImage);
                simulator.AddCrossing(roadObject);
                Console.WriteLine("Curved Lane was Drawn");
                isSaved = false;
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
        # endregion

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
            myGraphics = myBuffer.Graphics;
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
            timer1.Enabled = false;
            simulator.SetTimerInterval(100);
        }
        /* Form Load Event */
        private void TrafficLightSimulator_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            pictureBoxGrid.AllowDrop = true;
            pictureBox_CrossingA.AllowDrop = true;
            pictureBox_CrossingB.AllowDrop = true;
            pictureBox_StrightLane.AllowDrop = true;
            pictureBox_CurvedLane.AllowDrop = true;
            Console.WriteLine("Form Loaded With all Working componets");
        }
        /* Easter Egg*/
        private void clickMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            //System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        #region Saveing & Loading & saving As methods
        //*Save As methods */
        public bool SaveMethod()
        {
            Stream saveStream = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Simulation1"; //Default filename.
            saveFileDialog.Filter = "TrafficSimulation Extension files (*.trf)|*.trf";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (lastSave != null)
            {
                Stream stream = File.Open(lastSave, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();

                bFormatter.Serialize(stream, simulator.RoadObjects);
                stream.Close();
                return true;
            }
            else
            {
                DialogResult res = saveFileDialog.ShowDialog();
                if (!(res == DialogResult.Cancel || res == DialogResult.Abort ||
                    res == DialogResult.No || res == DialogResult.No))
                {


                    if (lastSave == null)
                    {
                        string fileName = saveFileDialog.FileName;
                        lastSave = fileName;
                    }
                    try
                    {

                        if ((saveStream = saveFileDialog.OpenFile()) != null)
                        {
                            IFormatter formater = new BinaryFormatter();

                            formater.Serialize(saveStream, simulator.RoadObjects);

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
                else
                {
                    return false;
                }
            }
        }

        private void MenuItem_File_SaveSimulator_Click(object sender, EventArgs e)
        {

            if (simulator.RoadObjects != null && simulator.RoadObjects.Count > 0)
            {
                isSaved = SaveMethod();

            }
            else
            {
                MessageBox.Show("There is nothing on the workspace");
            }
        }
        public bool SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();


            saveFileDialog.FileName = "Simulation1";
            saveFileDialog.Filter = "TrafficSimulation Extension files (*.trf)|*.trf";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lastSave = saveFileDialog.FileName;
                    Stream stream = File.Open(saveFileDialog.FileName, FileMode.Create);
                    BinaryFormatter bFormatter = new BinaryFormatter();

                    bFormatter.Serialize(stream, simulator.RoadObjects);
                    stream.Close();
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
            }
            else
            {
                return false;
            }
        }
        private void openSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (simulator.RoadObjects != null && simulator.RoadObjects.Count > 0)
            {
                if (isSaved == false)
                {
                    String text = "You have unsaved changes do you want to save them?";
                    string caption = "Error";
                    if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        isSaved = SaveMethod();
                    }

                }
            }
            LoadFromFile();
        }
        public bool LoadFromFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult res = ofd.ShowDialog();

            if (!(res == DialogResult.Cancel || res == DialogResult.Abort ||
                res == DialogResult.No || res == DialogResult.No))
            {

                String file = ofd.FileName;
                FileStream myFS = new FileStream(file, FileMode.Open, FileAccess.Read);
                BinaryFormatter myBF = new BinaryFormatter();
                simulator.RoadObjects = (List<RoadObject>)myBF.Deserialize(myFS);
                if (simulator.RoadObjects == null) return false;
                DrawAll();
                return true;
            }
            return false;
        }
        #endregion
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            simulator.FastForward(30);
        }
        private void saveAsSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSaved = SaveAs();
        }

        private void MenuItem_File_ClearSimulator_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure that u want to clear the workspace", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                myGraphics.Clear(Color.White);
                this.simulator.RoadObjects = new List<RoadObject>();
                DrawAll();
            }
        }

        private void pictureBox_StrightLane_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox_CrossingB.DoDragDrop(pictureBox_StrightLane.Image, DragDropEffects.Copy);
        }

        private void pictureBox_CurvedLane_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox_CurvedLane.DoDragDrop(pictureBox_CurvedLane.Image, DragDropEffects.Copy);

        }

    }
}



