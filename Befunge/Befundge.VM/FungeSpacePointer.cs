using System;
using System.Collections.Generic;
using System.Text;

namespace Befunge.VM
{
    public struct FungeSpacePointer
    {
        public int X;
        public int Y;

        public FungeSpacePointer(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static bool operator ==(FungeSpacePointer a, FungeSpacePointer b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(FungeSpacePointer a, FungeSpacePointer b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        public override bool Equals(object obj)
        {
            return this == (FungeSpacePointer)obj;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, Y);
        }
    }

    public struct FungeSpaceDirection
    {
        public int DX;
        public int DY;

        public FungeSpaceDirection(int dx, int dy)
        {
            this.DX = dx;
            this.DY = dy;
        }

        public static FungeSpacePointer operator +(FungeSpacePointer pointer, FungeSpaceDirection direction)
        {
            return new FungeSpacePointer(
                pointer.X + direction.DX, pointer.Y + direction.DY);
        }

        public static FungeSpaceDirection operator -(FungeSpaceDirection direction)
        {
            return new FungeSpaceDirection(
                -direction.DX, -direction.DY);
        }
    }
}
