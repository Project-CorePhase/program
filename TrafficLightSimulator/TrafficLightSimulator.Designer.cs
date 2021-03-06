﻿namespace TrafficLightSimulator
{
    partial class TrafficLightSimulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficLightSimulator));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_File_CreateNewSimulator = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_File_SaveSimulator = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_File_ClearSimulator = new System.Windows.Forms.ToolStripMenuItem();
            this.openSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Utilities = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Utilities_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Utilities_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.addCarAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.type3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.subTypeToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_AboutUS = new System.Windows.Forms.ToolStripMenuItem();
            this.clickMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCurvedLane = new System.Windows.Forms.Label();
            this.label_StrighLane = new System.Windows.Forms.Label();
            this.label_CrossingB = new System.Windows.Forms.Label();
            this.label_CrossingType1 = new System.Windows.Forms.Label();
            this.label_HowManyCars = new System.Windows.Forms.Label();
            this.textBox_InputCars = new System.Windows.Forms.TextBox();
            this.pictureBox_CurvedLane = new System.Windows.Forms.PictureBox();
            this.pictureBox_StrightLane = new System.Windows.Forms.PictureBox();
            this.pictureBox_CrossingB = new System.Windows.Forms.PictureBox();
            this.pictureBox_CrossingA = new System.Windows.Forms.PictureBox();
            this.label_MouseLocation = new System.Windows.Forms.Label();
            this.pictureBoxGrid = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CurvedLane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StrightLane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CrossingB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CrossingA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
            this.MenuItem_Utilities,
            this.type3ToolStripMenuItem,
            this.MenuItem_AboutUS});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1061, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File_CreateNewSimulator,
            this.MenuItem_File_SaveSimulator,
            this.MenuItem_File_ClearSimulator,
            this.openSimulatorToolStripMenuItem,
            this.saveAsSimulatorToolStripMenuItem});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(40, 20);
            this.MenuItem_File.Text = "File";
            // 
            // MenuItem_File_CreateNewSimulator
            // 
            this.MenuItem_File_CreateNewSimulator.Name = "MenuItem_File_CreateNewSimulator";
            this.MenuItem_File_CreateNewSimulator.Size = new System.Drawing.Size(191, 22);
            this.MenuItem_File_CreateNewSimulator.Text = "Create new Simulator";
            // 
            // MenuItem_File_SaveSimulator
            // 
            this.MenuItem_File_SaveSimulator.Name = "MenuItem_File_SaveSimulator";
            this.MenuItem_File_SaveSimulator.Size = new System.Drawing.Size(191, 22);
            this.MenuItem_File_SaveSimulator.Text = "Save Simulator";
            this.MenuItem_File_SaveSimulator.Click += new System.EventHandler(this.MenuItem_File_SaveSimulator_Click);
            // 
            // MenuItem_File_ClearSimulator
            // 
            this.MenuItem_File_ClearSimulator.Name = "MenuItem_File_ClearSimulator";
            this.MenuItem_File_ClearSimulator.Size = new System.Drawing.Size(191, 22);
            this.MenuItem_File_ClearSimulator.Text = "Clear Simulator";
            // 
            // openSimulatorToolStripMenuItem
            // 
            this.openSimulatorToolStripMenuItem.Name = "openSimulatorToolStripMenuItem";
            this.openSimulatorToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openSimulatorToolStripMenuItem.Text = "Open Simulator";
            this.openSimulatorToolStripMenuItem.Click += new System.EventHandler(this.openSimulatorToolStripMenuItem_Click);
            // 
            // saveAsSimulatorToolStripMenuItem
            // 
            this.saveAsSimulatorToolStripMenuItem.Name = "saveAsSimulatorToolStripMenuItem";
            this.saveAsSimulatorToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveAsSimulatorToolStripMenuItem.Text = "Save As Simulator";
            // 
            // MenuItem_Utilities
            // 
            this.MenuItem_Utilities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Utilities_Undo,
            this.MenuItem_Utilities_Redo,
            this.addCarAmountToolStripMenuItem});
            this.MenuItem_Utilities.Name = "MenuItem_Utilities";
            this.MenuItem_Utilities.Size = new System.Drawing.Size(62, 20);
            this.MenuItem_Utilities.Text = "Utilities";
            // 
            // MenuItem_Utilities_Undo
            // 
            this.MenuItem_Utilities_Undo.Name = "MenuItem_Utilities_Undo";
            this.MenuItem_Utilities_Undo.Size = new System.Drawing.Size(159, 22);
            this.MenuItem_Utilities_Undo.Text = "Undo";
            // 
            // MenuItem_Utilities_Redo
            // 
            this.MenuItem_Utilities_Redo.Name = "MenuItem_Utilities_Redo";
            this.MenuItem_Utilities_Redo.Size = new System.Drawing.Size(159, 22);
            this.MenuItem_Utilities_Redo.Text = "Redo";
            // 
            // addCarAmountToolStripMenuItem
            // 
            this.addCarAmountToolStripMenuItem.Name = "addCarAmountToolStripMenuItem";
            this.addCarAmountToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addCarAmountToolStripMenuItem.Text = "Add car amount";
            this.addCarAmountToolStripMenuItem.Click += new System.EventHandler(this.addCarAmountToolStripMenuItem_Click);
            // 
            // type3ToolStripMenuItem
            // 
            this.type3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Help});
            this.type3ToolStripMenuItem.Name = "type3ToolStripMenuItem";
            this.type3ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.type3ToolStripMenuItem.Text = "Help";
            // 
            // MenuItem_Help
            // 
            this.MenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subTypeToolStripMenuItem5});
            this.MenuItem_Help.Name = "MenuItem_Help";
            this.MenuItem_Help.Size = new System.Drawing.Size(122, 22);
            this.MenuItem_Help.Text = "sub-Type";
            // 
            // subTypeToolStripMenuItem5
            // 
            this.subTypeToolStripMenuItem5.Name = "subTypeToolStripMenuItem5";
            this.subTypeToolStripMenuItem5.Size = new System.Drawing.Size(122, 22);
            this.subTypeToolStripMenuItem5.Text = "sub-Type";
            // 
            // MenuItem_AboutUS
            // 
            this.MenuItem_AboutUS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clickMeToolStripMenuItem});
            this.MenuItem_AboutUS.Name = "MenuItem_AboutUS";
            this.MenuItem_AboutUS.Size = new System.Drawing.Size(68, 20);
            this.MenuItem_AboutUS.Text = "About Us";
            // 
            // clickMeToolStripMenuItem
            // 
            this.clickMeToolStripMenuItem.Name = "clickMeToolStripMenuItem";
            this.clickMeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.clickMeToolStripMenuItem.Text = "Click Me";
            this.clickMeToolStripMenuItem.Click += new System.EventHandler(this.clickMeToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1061, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::TrafficLightSimulator.Properties.Resources.play105;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::TrafficLightSimulator.Properties.Resources.pause15;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::TrafficLightSimulator.Properties.Resources.track4;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::TrafficLightSimulator.Properties.Resources.fast13;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCurvedLane);
            this.groupBox2.Controls.Add(this.label_StrighLane);
            this.groupBox2.Controls.Add(this.label_CrossingB);
            this.groupBox2.Controls.Add(this.label_CrossingType1);
            this.groupBox2.Controls.Add(this.label_HowManyCars);
            this.groupBox2.Controls.Add(this.textBox_InputCars);
            this.groupBox2.Controls.Add(this.pictureBox_CurvedLane);
            this.groupBox2.Controls.Add(this.pictureBox_StrightLane);
            this.groupBox2.Controls.Add(this.pictureBox_CrossingB);
            this.groupBox2.Controls.Add(this.pictureBox_CrossingA);
            this.groupBox2.Location = new System.Drawing.Point(12, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 532);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Components";
            // 
            // labelCurvedLane
            // 
            this.labelCurvedLane.AutoSize = true;
            this.labelCurvedLane.Location = new System.Drawing.Point(7, 377);
            this.labelCurvedLane.Name = "labelCurvedLane";
            this.labelCurvedLane.Size = new System.Drawing.Size(64, 13);
            this.labelCurvedLane.TabIndex = 11;
            this.labelCurvedLane.Text = "Curved lane";
            // 
            // label_StrighLane
            // 
            this.label_StrighLane.AutoSize = true;
            this.label_StrighLane.Location = new System.Drawing.Point(7, 255);
            this.label_StrighLane.Name = "label_StrighLane";
            this.label_StrighLane.Size = new System.Drawing.Size(64, 13);
            this.label_StrighLane.TabIndex = 10;
            this.label_StrighLane.Text = "Stright Lane";
            // 
            // label_CrossingB
            // 
            this.label_CrossingB.AutoSize = true;
            this.label_CrossingB.Location = new System.Drawing.Point(7, 140);
            this.label_CrossingB.Name = "label_CrossingB";
            this.label_CrossingB.Size = new System.Drawing.Size(57, 13);
            this.label_CrossingB.TabIndex = 9;
            this.label_CrossingB.Text = "Crossing B";
            // 
            // label_CrossingType1
            // 
            this.label_CrossingType1.AutoSize = true;
            this.label_CrossingType1.Location = new System.Drawing.Point(7, 16);
            this.label_CrossingType1.Name = "label_CrossingType1";
            this.label_CrossingType1.Size = new System.Drawing.Size(57, 13);
            this.label_CrossingType1.TabIndex = 8;
            this.label_CrossingType1.Text = "Crossing A";
            // 
            // label_HowManyCars
            // 
            this.label_HowManyCars.AutoSize = true;
            this.label_HowManyCars.Location = new System.Drawing.Point(6, 492);
            this.label_HowManyCars.Name = "label_HowManyCars";
            this.label_HowManyCars.Size = new System.Drawing.Size(75, 13);
            this.label_HowManyCars.TabIndex = 4;
            this.label_HowManyCars.Text = "Cars on street ";
            // 
            // textBox_InputCars
            // 
            this.textBox_InputCars.Location = new System.Drawing.Point(10, 508);
            this.textBox_InputCars.Name = "textBox_InputCars";
            this.textBox_InputCars.Size = new System.Drawing.Size(104, 20);
            this.textBox_InputCars.TabIndex = 5;
            this.textBox_InputCars.Text = "77";
            // 
            // pictureBox_CurvedLane
            // 
            this.pictureBox_CurvedLane.Location = new System.Drawing.Point(6, 393);
            this.pictureBox_CurvedLane.Name = "pictureBox_CurvedLane";
            this.pictureBox_CurvedLane.Size = new System.Drawing.Size(107, 96);
            this.pictureBox_CurvedLane.TabIndex = 7;
            this.pictureBox_CurvedLane.TabStop = false;
            // 
            // pictureBox_StrightLane
            // 
            this.pictureBox_StrightLane.Location = new System.Drawing.Point(6, 269);
            this.pictureBox_StrightLane.Name = "pictureBox_StrightLane";
            this.pictureBox_StrightLane.Size = new System.Drawing.Size(107, 96);
            this.pictureBox_StrightLane.TabIndex = 6;
            this.pictureBox_StrightLane.TabStop = false;
            // 
            // pictureBox_CrossingB
            // 
            this.pictureBox_CrossingB.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CrossingB.Image")));
            this.pictureBox_CrossingB.Location = new System.Drawing.Point(6, 156);
            this.pictureBox_CrossingB.Name = "pictureBox_CrossingB";
            this.pictureBox_CrossingB.Size = new System.Drawing.Size(107, 96);
            this.pictureBox_CrossingB.TabIndex = 5;
            this.pictureBox_CrossingB.TabStop = false;
            this.pictureBox_CrossingB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_CrossingB_MouseMove);
            // 
            // pictureBox_CrossingA
            // 
            this.pictureBox_CrossingA.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CrossingA.Image")));
            this.pictureBox_CrossingA.Location = new System.Drawing.Point(6, 32);
            this.pictureBox_CrossingA.Name = "pictureBox_CrossingA";
            this.pictureBox_CrossingA.Size = new System.Drawing.Size(107, 96);
            this.pictureBox_CrossingA.TabIndex = 4;
            this.pictureBox_CrossingA.TabStop = false;
            this.pictureBox_CrossingA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_CrossingA_MouseMove);
            // 
            // label_MouseLocation
            // 
            this.label_MouseLocation.AutoSize = true;
            this.label_MouseLocation.Location = new System.Drawing.Point(12, 612);
            this.label_MouseLocation.Name = "label_MouseLocation";
            this.label_MouseLocation.Size = new System.Drawing.Size(13, 13);
            this.label_MouseLocation.TabIndex = 13;
            this.label_MouseLocation.Text = ":-";
            // 
            // pictureBoxGrid
            // 
            this.pictureBoxGrid.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxGrid.Location = new System.Drawing.Point(143, 24);
            this.pictureBoxGrid.Name = "pictureBoxGrid";
            this.pictureBoxGrid.Size = new System.Drawing.Size(901, 601);
            this.pictureBoxGrid.TabIndex = 12;
            this.pictureBoxGrid.TabStop = false;
            this.pictureBoxGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBoxGrid_DragDrop);
            this.pictureBoxGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBoxGrid_DragEnter);
            this.pictureBoxGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Grid_Paint);
            this.pictureBoxGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGrid_MouseMove);
            // 
            // TrafficLightSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1061, 633);
            this.Controls.Add(this.label_MouseLocation);
            this.Controls.Add(this.pictureBoxGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TrafficLightSimulator";
            this.Text = "Traffic Light Simulator";
            this.Load += new System.EventHandler(this.TrafficLightSimulator_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrafficLightSimulator_MouseMove);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CurvedLane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StrightLane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CrossingB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CrossingA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File_CreateNewSimulator;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File_SaveSimulator;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File_ClearSimulator;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Utilities;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Utilities_Undo;
        private System.Windows.Forms.ToolStripMenuItem type3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem subTypeToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_AboutUS;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_HowManyCars;
        private System.Windows.Forms.TextBox textBox_InputCars;
        private System.Windows.Forms.PictureBox pictureBox_CurvedLane;
        private System.Windows.Forms.PictureBox pictureBox_StrightLane;
        private System.Windows.Forms.PictureBox pictureBox_CrossingB;
        private System.Windows.Forms.PictureBox pictureBox_CrossingA;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Utilities_Redo;
        private System.Windows.Forms.Label labelCurvedLane;
        private System.Windows.Forms.Label label_StrighLane;
        private System.Windows.Forms.Label label_CrossingB;
        private System.Windows.Forms.Label label_CrossingType1;
        private System.Windows.Forms.PictureBox pictureBoxGrid;
        private System.Windows.Forms.Label label_MouseLocation;
        private System.Windows.Forms.ToolStripMenuItem clickMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSimulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsSimulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCarAmountToolStripMenuItem;
    }
}

