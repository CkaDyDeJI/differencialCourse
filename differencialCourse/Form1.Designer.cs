namespace differencialCourse
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
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.calculatedData = new System.Windows.Forms.DataGridView();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.leftBorderBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.rightBorderBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stepLabel = new System.Windows.Forms.ToolStripLabel();
            this.stepBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.methodComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.calculateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.yLabel = new System.Windows.Forms.ToolStripLabel();
            this.yTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calculatedData)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Исходная функция";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(979, 558);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(979, 583);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.calculatedData);
            this.splitContainer1.Size = new System.Drawing.Size(979, 558);
            this.splitContainer1.SplitterDistance = 142;
            this.splitContainer1.TabIndex = 2;
            // 
            // calculatedData
            // 
            this.calculatedData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.calculatedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calculatedData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x,
            this.y,
            this.Yy});
            this.calculatedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculatedData.Location = new System.Drawing.Point(0, 0);
            this.calculatedData.Name = "calculatedData";
            this.calculatedData.RowHeadersVisible = false;
            this.calculatedData.Size = new System.Drawing.Size(979, 412);
            this.calculatedData.TabIndex = 0;
            // 
            // x
            // 
            this.x.HeaderText = "x";
            this.x.Name = "x";
            this.x.ReadOnly = true;
            // 
            // y
            // 
            this.y.HeaderText = "y";
            this.y.Name = "y";
            this.y.ReadOnly = true;
            // 
            // Yy
            // 
            this.Yy.HeaderText = "y\'";
            this.Yy.Name = "Yy";
            this.Yy.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.leftBorderBox,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.rightBorderBox,
            this.toolStripSeparator2,
            this.stepLabel,
            this.stepBox,
            this.toolStripSeparator3,
            this.methodComboBox,
            this.calculateButton});
            this.toolStrip1.Location = new System.Drawing.Point(136, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(731, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "left border (a)";
            // 
            // leftBorderBox
            // 
            this.leftBorderBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.leftBorderBox.Name = "leftBorderBox";
            this.leftBorderBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(88, 22);
            this.toolStripLabel2.Text = "right border (b)";
            // 
            // rightBorderBox
            // 
            this.rightBorderBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rightBorderBox.Name = "rightBorderBox";
            this.rightBorderBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // stepLabel
            // 
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(47, 22);
            this.stepLabel.Text = "step (h)";
            // 
            // stepBox
            // 
            this.stepBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.stepBox.Name = "stepBox";
            this.stepBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // methodComboBox
            // 
            this.methodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodComboBox.Items.AddRange(new object[] {
            "Euler",
            "Runge-Kutte",
            "Adams"});
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // calculateButton
            // 
            this.calculateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.calculateButton.Image = ((System.Drawing.Image)(resources.GetObject("calculateButton.Image")));
            this.calculateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(58, 22);
            this.calculateButton.Text = "calculate";
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yLabel,
            this.yTextBox});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(133, 25);
            this.toolStrip2.TabIndex = 1;
            // 
            // yLabel
            // 
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(19, 22);
            this.yLabel.Text = "y0";
            // 
            // yTextBox
            // 
            this.yTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(111, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(235, 50);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "y^\'=x+ycos(x)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(979, 583);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Диффуры";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calculatedData)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox leftBorderBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox rightBorderBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel stepLabel;
        private System.Windows.Forms.ToolStripTextBox stepBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox methodComboBox;
        private System.Windows.Forms.ToolStripButton calculateButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView calculatedData;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel yLabel;
        private System.Windows.Forms.ToolStripTextBox yTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yy;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

