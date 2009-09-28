using System;
using System.Collections.Generic;
using System.Text;

namespace Befunge.VM
{
    /// <summary>
    /// Fundge-Space as in http://quadium.net/funge/spec98.html#Space
    /// </summary>
    public class FungeSpace
    {
        public const byte EmptyCell = 32;
        public const byte HaltCell = 64;
        const int Width = 80;
        const int Height = 25;

        public const int MinX = 0;
        public const int MinY = 0;
        public const int MaxX = Width - 1;
        public const int MaxY = Height - 1;

        byte[,] cellsArray;
        CellsIndexer cells;

        public CellsIndexer Cells
        {
            get { return cells; }
        }

        internal FungeSpace()
        {
            this.cellsArray = new byte[Height, Width];
            this.cells = new CellsIndexer(this);
            Clear();
        }

        public void Clear()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    cellsArray[i, j] = EmptyCell;
                }
            }
            cellsArray[0, 0] = HaltCell;
        }

        public void LoadFrom(string path)
        {
            Load(System.IO.File.ReadAllLines(path));
        }

        public void Load(string[] lines)
        {
            Clear();
            for (int i = 0; i < Math.Min(lines.Length, Height); i++)
            {                
                byte[] bytes = ConversionUtils.FromChars(lines[i].ToCharArray());
                for (int j = 0; j < Math.Min(bytes.Length, Width); j++)
                {
                    cellsArray[i, j] = bytes[j];
                }
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append(ConversionUtils.ToChar(cellsArray[i, j]));
                }

                if (i < Height - 1)
                    sb.AppendLine();
            }
            return sb.ToString();
        }

        public byte[,] ToArray()
        {
            return (byte[,])cellsArray.Clone();
        }

        public class CellsIndexer
        {
            internal FungeSpace Owner;

            internal CellsIndexer(FungeSpace owner)
            {
                this.Owner = owner;
            }

            public byte this[int x, int y]
            {
                get { return Owner.cellsArray[y, x]; }
                set { Owner.cellsArray[y, x] = value; }
            }

            public byte this[FungeSpacePointer pointer]
            {
                get { return this[pointer.X, pointer.Y]; }
                set { this[pointer.X, pointer.Y] = value; }
            }
        }
    }
}
