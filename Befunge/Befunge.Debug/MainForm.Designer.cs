namespace Befunge.Debug
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.spacePictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stepToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ioTabPage = new System.Windows.Forms.TabPage();
            this.stackTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.stackListBox = new System.Windows.Forms.ListBox();
            this.bfOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.breakpointToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.runToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.runTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spacePictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ioTabPage.SuspendLayout();
            this.stackTabPage.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.spacePictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(550, 298);
            this.splitContainer1.SplitterDistance = 156;
            this.splitContainer1.TabIndex = 0;
            // 
            // spacePictureBox
            // 
            this.spacePictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.spacePictureBox.Location = new System.Drawing.Point(0, 0);
            this.spacePictureBox.Name = "spacePictureBox";
            this.spacePictureBox.Size = new System.Drawing.Size(136, 165);
            this.spacePictureBox.TabIndex = 0;
            this.spacePictureBox.TabStop = false;
            this.spacePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.spacePictureBox_MouseClick);
            this.spacePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.spacePictureBox_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.toolStripSeparator1,
            this.stepToolStripButton,
            this.breakpointToolStripButton,
            this.stopToolStripButton,
            this.runToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(550, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // stepToolStripButton
            // 
            this.stepToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stepToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stepToolStripButton.Image")));
            this.stepToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepToolStripButton.Name = "stepToolStripButton";
            this.stepToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stepToolStripButton.Text = "Step";
            this.stepToolStripButton.Click += new System.EventHandler(this.stepToolStripButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ioTabPage);
            this.tabControl1.Controls.Add(this.stackTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(156, 298);
            this.tabControl1.TabIndex = 0;
            // 
            // ioTabPage
            // 
            this.ioTabPage.Controls.Add(this.splitContainer2);
            this.ioTabPage.Location = new System.Drawing.Point(4, 22);
            this.ioTabPage.Name = "ioTabPage";
            this.ioTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ioTabPage.Size = new System.Drawing.Size(148, 272);
            this.ioTabPage.TabIndex = 0;
            this.ioTabPage.Text = "General";
            this.ioTabPage.UseVisualStyleBackColor = true;
            // 
            // stackTabPage
            // 
            this.stackTabPage.Controls.Add(this.stackListBox);
            this.stackTabPage.Location = new System.Drawing.Point(4, 22);
            this.stackTabPage.Name = "stackTabPage";
            this.stackTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.stackTabPage.Size = new System.Drawing.Size(148, 272);
            this.stackTabPage.TabIndex = 1;
            this.stackTabPage.Text = "Stack Stack";
            this.stackTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.inputTextBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.outputTextBox);
            this.splitContainer2.Size = new System.Drawing.Size(142, 266);
            this.splitContainer2.SplitterDistance = 139;
            this.splitContainer2.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextBox.Location = new System.Drawing.Point(0, 0);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(142, 139);
            this.inputTextBox.TabIndex = 0;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(0, 0);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(142, 123);
            this.outputTextBox.TabIndex = 1;
            // 
            // stackListBox
            // 
            this.stackListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackListBox.FormattingEnabled = true;
            this.stackListBox.IntegralHeight = false;
            this.stackListBox.Location = new System.Drawing.Point(3, 3);
            this.stackListBox.Name = "stackListBox";
            this.stackListBox.Size = new System.Drawing.Size(142, 266);
            this.stackListBox.TabIndex = 0;
            // 
            // bfOpenFileDialog
            // 
            this.bfOpenFileDialog.FileName = "*.bf";
            this.bfOpenFileDialog.Filter = "BF files|*.bf|Any files|*.*";
            // 
            // breakpointToolStripButton
            // 
            this.breakpointToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.breakpointToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("breakpointToolStripButton.Image")));
            this.breakpointToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.breakpointToolStripButton.Name = "breakpointToolStripButton";
            this.breakpointToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.breakpointToolStripButton.Text = "Set Breakpoint";
            this.breakpointToolStripButton.Click += new System.EventHandler(this.breakpointToolStripButton_Click);
            // 
            // stopToolStripButton
            // 
            this.stopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripButton.Image")));
            this.stopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolStripButton.Name = "stopToolStripButton";
            this.stopToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopToolStripButton.Text = "Stop";
            this.stopToolStripButton.Click += new System.EventHandler(this.stopToolStripButton_Click);
            // 
            // runToolStripButton
            // 
            this.runToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("runToolStripButton.Image")));
            this.runToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runToolStripButton.Name = "runToolStripButton";
            this.runToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.runToolStripButton.Text = "Run";
            this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
            // 
            // runTimer
            // 
            this.runTimer.Interval = 50;
            this.runTimer.Tick += new System.EventHandler(this.runTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 323);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Befunge Debug";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spacePictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ioTabPage.ResumeLayout(false);
            this.stackTabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox spacePictureBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ioTabPage;
        private System.Windows.Forms.TabPage stackTabPage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton stepToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.ListBox stackListBox;
        private System.Windows.Forms.OpenFileDialog bfOpenFileDialog;
        private System.Windows.Forms.ToolStripButton breakpointToolStripButton;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private System.Windows.Forms.ToolStripButton runToolStripButton;
        private System.Windows.Forms.Timer runTimer;
    }
}

