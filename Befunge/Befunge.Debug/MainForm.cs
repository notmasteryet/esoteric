using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Befunge.VM;

namespace Befunge.Debug
{
    public partial class MainForm : Form
    {
        private Font baseFont;
        private Size cellSize;
        const int CellPadding = 1;

        FungeDebugEngine engine;

        public MainForm()
        {
            InitializeComponent();
            baseFont = new Font(FontFamily.GenericMonospace, 10.0f);

            ReinitializeSpacePaint();            

            engine = new FungeDebugEngine(outputTextBox);
        }

        const int SpaceWidth = 80;
        const int SpaceHeight = 25;

        private void ReinitializeSpacePaint()
        {
            SizeF charSize;
            using (Graphics g = spacePictureBox.CreateGraphics())
            {
                charSize = g.MeasureString("W", baseFont);
            }
            cellSize = new Size(CellPadding * 2 + (int)Math.Ceiling(charSize.Width),
                CellPadding * 2 + (int)Math.Ceiling(charSize.Height));

            spacePictureBox.Size = new Size(cellSize.Width * SpaceWidth, cellSize.Height * SpaceHeight);

            spacePictureBox.Invalidate();
        }

        Point selectedCell = new Point(0, 0);
        Point currentCell = new Point(0,0);
        Dictionary<Point, bool> breakpoints = new Dictionary<Point, bool>();
        string filename = null;

        private Rectangle GetCellRectangle(int row, int cell)
        {
            return new Rectangle(cell * cellSize.Width, row * cellSize.Height,
                        cellSize.Width, cellSize.Height);
        }

        private bool GetCellPosition(int x, int y, out int row, out int column)
        {
            column = x / cellSize.Width;
            row = y / cellSize.Height;
            return row >= 0 && column >= 0 && row < SpaceHeight && column < SpaceWidth;
        }

        private void spacePictureBox_Paint(object sender, PaintEventArgs e)
        {
            byte[,] cells = GetCells();
            for (int i = 0; i < SpaceHeight; i++)
            {
                for (int j = 0; j < SpaceWidth; j++)
                {
                    Rectangle bounds = GetCellRectangle(i, j);

                    if (bounds.IntersectsWith(e.ClipRectangle))
                    {
                        e.Graphics.FillRectangle(Brushes.White, bounds);

                        DrawCell(e.Graphics, cells, i, j, bounds);
                    }
                }
            }
        }

        private byte[,] GetCells()
        {
            return engine.FundgeSpace.ToArray();
        }

        private void DrawCell(Graphics g, byte[,] cells, int row, int column, Rectangle bounds)
        {
            Rectangle area = new Rectangle(bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);

            g.DrawLines(Pens.LightGray, new Point[] {
                new Point(area.Left, area.Bottom), new Point(area.Right, area.Bottom), new Point(area.Right, area.Top)});

            if (currentCell.X == column && currentCell.Y == row)
            {
                g.FillRectangle(Brushes.Silver, bounds);
            }

            if (selectedCell.X == column && selectedCell.Y == row)
            {
                g.DrawRectangle(Pens.Black, area);
            }

            if (breakpoints.ContainsKey(new Point(column, row)))
            {
                g.FillEllipse(Brushes.Red, area);
            }

            char ch = (char)cells[row, column];
            g.DrawString(ch.ToString(), baseFont, Brushes.Black, bounds.X + CellPadding, bounds.Y + CellPadding);

        }

        private void spacePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int newRow, newColumn;
            if (GetCellPosition(e.X, e.Y, out newRow, out newColumn))
            {
                Rectangle oldBounds = GetCellRectangle(selectedCell.Y, selectedCell.X);
                Rectangle newBounds = GetCellRectangle(newRow, newColumn);

                selectedCell = new Point(newColumn, newRow);
                spacePictureBox.Invalidate(oldBounds);
                spacePictureBox.Invalidate(newBounds);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (bfOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = bfOpenFileDialog.FileName;

                LoadSpace();
            }
        }

        bool running = false;

        private void LoadSpace()
        {
            running = false;
            engine.Reset();
            engine.FundgeSpace.LoadFrom(filename);

            RefreshAllPanels();

            outputTextBox.Clear();
        }

        private void RefreshAllPanels()
        {
            currentCell = new Point(engine.InstructionPointer.X, engine.InstructionPointer.Y);
            spacePictureBox.Invalidate();

            stackListBox.BeginUpdate();
            stackListBox.Items.Clear();
            int[] stack = engine.StackStack.ToArray();
            foreach (int item in stack)
            {
                string line = item.ToString();
                if(item >= 32 && item <= 126) line += String.Format(" '{0}'", (char)item);
                stackListBox.Items.Add(line);
            }
            stackListBox.EndUpdate();
        }

        private void stepToolStripButton_Click(object sender, EventArgs e)
        {
            Step();
        }

        private void breakpointToolStripButton_Click(object sender, EventArgs e)
        {
            if (breakpoints.ContainsKey(selectedCell))
                breakpoints.Remove(selectedCell);
            else
                breakpoints[selectedCell] = true;
            spacePictureBox.Invalidate(GetCellRectangle(selectedCell.Y, selectedCell.X));
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {
            LoadSpace();
        }

        private void runToolStripButton_Click(object sender, EventArgs e)
        {
            running = true;
            runTimer.Enabled = true;
        }

        private void runTimer_Tick(object sender, EventArgs e)
        {
            if (running)
            {
                Step();

                if (breakpoints.ContainsKey(currentCell))
                {
                    runTimer.Enabled = false;
                }
            }
            else
            {
                runTimer.Enabled = false;
            }
        }

        private void Step()
        {
            try
            {
                running = engine.Step();

                RefreshAllPanels();
            }
            catch(Exception ex)
            {
                running = false;
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
