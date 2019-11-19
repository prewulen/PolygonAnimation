namespace GK_proj2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DrawArea = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.StartB = new System.Windows.Forms.Button();
            this.LightXY = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LightZC = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SpeedC = new System.Windows.Forms.NumericUpDown();
            this.SpawnPolyB = new System.Windows.Forms.Button();
            this.ColorPicker = new System.Windows.Forms.Button();
            this.InterpolationCheckBox = new System.Windows.Forms.CheckBox();
            this.ClipCheckbox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddPoly = new System.Windows.Forms.Button();
            this.DeletePoly = new System.Windows.Forms.Button();
            this.EditPoly = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.FillMoving = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PickTexture = new System.Windows.Forms.Button();
            this.PickBumpMap = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FillStatic = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightZC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedC)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(924, 620);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.DrawArea, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(918, 564);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // DrawArea
            // 
            this.DrawArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawArea.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DrawArea.Location = new System.Drawing.Point(3, 3);
            this.DrawArea.Name = "DrawArea";
            this.DrawArea.Size = new System.Drawing.Size(762, 558);
            this.DrawArea.TabIndex = 0;
            this.DrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawArea_Paint);
            this.DrawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDown);
            this.DrawArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseUp);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.StartB);
            this.flowLayoutPanel2.Controls.Add(this.LightXY);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.LightZC);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.SpeedC);
            this.flowLayoutPanel2.Controls.Add(this.SpawnPolyB);
            this.flowLayoutPanel2.Controls.Add(this.ColorPicker);
            this.flowLayoutPanel2.Controls.Add(this.InterpolationCheckBox);
            this.flowLayoutPanel2.Controls.Add(this.ClipCheckbox);
            this.flowLayoutPanel2.Controls.Add(this.FillMoving);
            this.flowLayoutPanel2.Controls.Add(this.FillStatic);
            this.flowLayoutPanel2.Controls.Add(this.PickTexture);
            this.flowLayoutPanel2.Controls.Add(this.PickBumpMap);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(771, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(144, 558);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // StartB
            // 
            this.StartB.Location = new System.Drawing.Point(3, 3);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(141, 52);
            this.StartB.TabIndex = 0;
            this.StartB.Text = "Start";
            this.StartB.UseVisualStyleBackColor = true;
            this.StartB.Click += new System.EventHandler(this.StartB_Click);
            // 
            // LightXY
            // 
            this.LightXY.Location = new System.Drawing.Point(3, 61);
            this.LightXY.Name = "LightXY";
            this.LightXY.Size = new System.Drawing.Size(141, 52);
            this.LightXY.TabIndex = 1;
            this.LightXY.Text = "Choose light position";
            this.LightXY.UseVisualStyleBackColor = true;
            this.LightXY.Click += new System.EventHandler(this.LightXY_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Light Z";
            // 
            // LightZC
            // 
            this.LightZC.Location = new System.Drawing.Point(3, 132);
            this.LightZC.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LightZC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LightZC.Name = "LightZC";
            this.LightZC.Size = new System.Drawing.Size(141, 20);
            this.LightZC.TabIndex = 2;
            this.LightZC.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.LightZC.ValueChanged += new System.EventHandler(this.LightZC_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Speed (1 - 200)";
            // 
            // SpeedC
            // 
            this.SpeedC.Location = new System.Drawing.Point(3, 184);
            this.SpeedC.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SpeedC.Name = "SpeedC";
            this.SpeedC.Size = new System.Drawing.Size(141, 20);
            this.SpeedC.TabIndex = 5;
            this.SpeedC.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SpeedC.ValueChanged += new System.EventHandler(this.SpeedC_ValueChanged);
            // 
            // SpawnPolyB
            // 
            this.SpawnPolyB.Location = new System.Drawing.Point(3, 210);
            this.SpawnPolyB.Name = "SpawnPolyB";
            this.SpawnPolyB.Size = new System.Drawing.Size(141, 52);
            this.SpawnPolyB.TabIndex = 6;
            this.SpawnPolyB.Text = "Spawn poly";
            this.SpawnPolyB.UseVisualStyleBackColor = true;
            this.SpawnPolyB.Click += new System.EventHandler(this.SpawnPolyB_Click);
            // 
            // ColorPicker
            // 
            this.ColorPicker.Location = new System.Drawing.Point(3, 268);
            this.ColorPicker.Name = "ColorPicker";
            this.ColorPicker.Size = new System.Drawing.Size(141, 52);
            this.ColorPicker.TabIndex = 7;
            this.ColorPicker.Text = "Pick light color";
            this.ColorPicker.UseVisualStyleBackColor = true;
            this.ColorPicker.Click += new System.EventHandler(this.ColorPicker_Click);
            // 
            // InterpolationCheckBox
            // 
            this.InterpolationCheckBox.AutoSize = true;
            this.InterpolationCheckBox.Location = new System.Drawing.Point(3, 326);
            this.InterpolationCheckBox.Name = "InterpolationCheckBox";
            this.InterpolationCheckBox.Size = new System.Drawing.Size(105, 17);
            this.InterpolationCheckBox.TabIndex = 8;
            this.InterpolationCheckBox.Text = "Use interpolation";
            this.InterpolationCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClipCheckbox
            // 
            this.ClipCheckbox.AutoSize = true;
            this.ClipCheckbox.Location = new System.Drawing.Point(3, 349);
            this.ClipCheckbox.Name = "ClipCheckbox";
            this.ClipCheckbox.Size = new System.Drawing.Size(84, 17);
            this.ClipCheckbox.TabIndex = 9;
            this.ClipCheckbox.Text = "Use clipping";
            this.ClipCheckbox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.AddPoly);
            this.flowLayoutPanel1.Controls.Add(this.DeletePoly);
            this.flowLayoutPanel1.Controls.Add(this.EditPoly);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(918, 44);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // AddPoly
            // 
            this.AddPoly.Location = new System.Drawing.Point(3, 3);
            this.AddPoly.Name = "AddPoly";
            this.AddPoly.Size = new System.Drawing.Size(62, 41);
            this.AddPoly.TabIndex = 0;
            this.AddPoly.Text = "Add polygon";
            this.AddPoly.UseVisualStyleBackColor = true;
            this.AddPoly.Click += new System.EventHandler(this.AddPoly_Click);
            // 
            // DeletePoly
            // 
            this.DeletePoly.Location = new System.Drawing.Point(71, 3);
            this.DeletePoly.Name = "DeletePoly";
            this.DeletePoly.Size = new System.Drawing.Size(62, 41);
            this.DeletePoly.TabIndex = 1;
            this.DeletePoly.Text = "Delete polygon";
            this.DeletePoly.UseVisualStyleBackColor = true;
            this.DeletePoly.Click += new System.EventHandler(this.DeletePoly_Click);
            // 
            // EditPoly
            // 
            this.EditPoly.Location = new System.Drawing.Point(139, 3);
            this.EditPoly.Name = "EditPoly";
            this.EditPoly.Size = new System.Drawing.Size(62, 41);
            this.EditPoly.TabIndex = 2;
            this.EditPoly.Text = "Move polygon";
            this.EditPoly.UseVisualStyleBackColor = true;
            this.EditPoly.Click += new System.EventHandler(this.EditPoly_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FillMoving
            // 
            this.FillMoving.AutoSize = true;
            this.FillMoving.Location = new System.Drawing.Point(3, 372);
            this.FillMoving.Name = "FillMoving";
            this.FillMoving.Size = new System.Drawing.Size(120, 17);
            this.FillMoving.TabIndex = 10;
            this.FillMoving.Text = "Fill moving polygons";
            this.FillMoving.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "1 - fast, 200 - slow";
            // 
            // PickTexture
            // 
            this.PickTexture.Location = new System.Drawing.Point(3, 418);
            this.PickTexture.Name = "PickTexture";
            this.PickTexture.Size = new System.Drawing.Size(141, 52);
            this.PickTexture.TabIndex = 12;
            this.PickTexture.Text = "Pick texture";
            this.PickTexture.UseVisualStyleBackColor = true;
            this.PickTexture.Click += new System.EventHandler(this.PickTexture_Click);
            // 
            // PickBumpMap
            // 
            this.PickBumpMap.Location = new System.Drawing.Point(3, 476);
            this.PickBumpMap.Name = "PickBumpMap";
            this.PickBumpMap.Size = new System.Drawing.Size(141, 52);
            this.PickBumpMap.TabIndex = 13;
            this.PickBumpMap.Text = "Pick bump map";
            this.PickBumpMap.UseVisualStyleBackColor = true;
            this.PickBumpMap.Click += new System.EventHandler(this.PickBumpMap_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FillStatic
            // 
            this.FillStatic.AutoSize = true;
            this.FillStatic.Location = new System.Drawing.Point(3, 395);
            this.FillStatic.Name = "FillStatic";
            this.FillStatic.Size = new System.Drawing.Size(111, 17);
            this.FillStatic.TabIndex = 14;
            this.FillStatic.Text = "Fill static polygons";
            this.FillStatic.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 647);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Polygon Animation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightZC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedC)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel DrawArea;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddPoly;
        private System.Windows.Forms.Button DeletePoly;
        private System.Windows.Forms.Button EditPoly;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button StartB;
        private System.Windows.Forms.Button LightXY;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown LightZC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SpeedC;
        private System.Windows.Forms.Button SpawnPolyB;
        private System.Windows.Forms.Button ColorPicker;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox InterpolationCheckBox;
        private System.Windows.Forms.CheckBox ClipCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox FillMoving;
        private System.Windows.Forms.Button PickTexture;
        private System.Windows.Forms.Button PickBumpMap;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox FillStatic;
    }
}

