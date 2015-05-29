using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightSimulatorProgram
{
    [Serializable]
    public class Cell
    {
        private int topLeftCornerX;
        private int topLeftCornerY;
        private RoadObject roadObject;

        [NonSerialized]
        private TextBox[] spawntextboxes;

        public Cell(int x, int y)
        {
            this.topLeftCornerX = x;
            this.topLeftCornerY = y;
            this.roadObject = null;
            spawntextboxes = new TextBox[4];
        }

        public int GetCellX()
        {
            return topLeftCornerX; 
        }
        public void SetCellX(int value) 
        { 
            this.topLeftCornerX = value;
        }

        public int GetCellY()
        { 
            return topLeftCornerY;
        }
        public void SetCellY(int value) 
        {
            this.topLeftCornerY = value;
        }

        public void SetRoadObject(RoadObject o) { this.roadObject = o; }
        public RoadObject GetRoadObject()
        {
            return this.roadObject;
        }

        /// <summary>
        /// Draw the cell with the image of the roadobject on the cell.
        /// </summary>
        /// <param name="gr"></param>
        public void DrawCell(Graphics gr)
        {
            gr.DrawImage(GetRoadObject().Image, new Point((int)this.topLeftCornerX, (int)this.topLeftCornerY));
        }

        public TextBox[] SpawnTextBoxes()
        {
            return this.spawntextboxes;
        }

        public void ResetTextBoxes()
        {
            this.spawntextboxes = new TextBox[4];
        }

        /// <summary>
        /// Adds the label connected to the entry point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="i">Side of the cell to position the text box in.</param>
        public TextBox AddTextBox(int x, int y, int i)
        {
            TextBox txtBx = new TextBox();
            txtBx.MaxLength = 2;
            txtBx.BackColor = Color.White;
            txtBx.Size = new Size(25, 25);
            txtBx.KeyPress += txtBx_KeyPress;
            txtBx.TextChanged += txtBx_TextChanged;

            switch (i)
            {
                case 0:
                    x = x + Grid.CellSize / 2 - txtBx.Width / 2;
                    break;
                case 1:
                    x = x + Grid.CellSize - txtBx.Width;
                    y = y + Grid.CellSize / 2 - txtBx.Height / 2;
                    break;
                case 2:
                    x = x + Grid.CellSize / 2 - txtBx.Width / 2;
                    y = y + Grid.CellSize - txtBx.Height;
                    break;
                case 3:
                    y = y + Grid.CellSize / 2 - txtBx.Height / 2;
                    break;
            }
            txtBx.Location = new Point(x, y);
            this.spawntextboxes[i] = txtBx;
            return txtBx;
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
    }
}