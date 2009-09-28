using System;
using System.Collections.Generic;
using System.Text;

namespace Befunge.VM
{
    // Implementation of basic version of Befundge-93
    // http://quadium.net/funge/spec98.html
    public class FungeEngine
    {
        FungeSpace fundgeSpace;
        StackStack stackStack;
        FungeSpacePointer instructionPointer;
        FungeSpaceDirection instructionPointerDirection;
        bool is2dDisabled = false;
        Random randomizer;

        public FungeSpace FundgeSpace
        {
            get { return fundgeSpace; }
        }

        public StackStack StackStack
        {
            get { return stackStack; }
        }

        public FungeSpacePointer InstructionPointer
        {
            get { return instructionPointer; }
        }

        public FungeSpaceDirection Direction
        {
            get { return instructionPointerDirection; }
        }

        public byte CurrentInstruction
        {
            get { return FundgeSpace.Cells[InstructionPointer]; }
        }

        /// <summary>
        /// Disables 2D movements. Simulates Unefunge.
        /// </summary>
        public bool Is2dDisabled
        {
            get { return is2dDisabled; }
            set { is2dDisabled = value; }
        }

        public FungeEngine()
        {
            this.fundgeSpace = new FungeSpace();
            this.stackStack = new StackStack();
            this.instructionPointer = new FungeSpacePointer();
            this.instructionPointerDirection = new FungeSpaceDirection(1, 0);
            this.randomizer = new Random();
        }

        public FungeEngine(string path)
            : this()
        {
            FundgeSpace.LoadFrom(path);
        }

        public void Reset()
        {
            StackStack.Clear();
            FundgeSpace.Clear();

            this.instructionPointer = new FungeSpacePointer();
            this.instructionPointerDirection = new FungeSpaceDirection(1, 0);
        }

        [System.Diagnostics.Conditional("Debug")]
        private void Dump()
        {
            System.Diagnostics.Debug.WriteLine(String.Format("Instruction {0} at {1}",
                ConversionUtils.ToChar(CurrentInstruction), InstructionPointer));
            int[] stack = StackStack.ToArray();
            System.Diagnostics.Debug.Write("  stack: [");
            for (int i = 0; i < stack.Length; i++)
            {
                System.Diagnostics.Debug.Write(" " + stack[i]);
            }
            System.Diagnostics.Debug.WriteLine("]");
        }

        public bool Step()
        {
            Dump();

            try
            {
                byte instruction = FundgeSpace.Cells[InstructionPointer];

                bool programExecuting = true;
                bool move = true;
                int a, b, c;
                switch (ConversionUtils.ToChar(instruction))
                {
                    case ' ':
                        break;
                    case '!': // Logical Not 
                        b = StackStack.Pop();
                        if (b == 0)
                            StackStack.Push(1);
                        else
                            StackStack.Push(0);
                        break;
                    case '\"': // Toggle Stringmode 
                        ReadString();
                        break;
                    case '#': // Trampoline 
                        MoveOnePosition();
                        break;
                    case '$': // Pop
                        StackStack.Pop();
                        break;
                    case '%':
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        c = Reminder(a, b);
                        StackStack.Push(c);
                        break;
                    case '&':
                        a = ReadInteger();
                        StackStack.Push(a);
                        break;
                    case '*':
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        c = a * b;
                        StackStack.Push(c);
                        break;
                    case '+':
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        c = a + b;
                        StackStack.Push(c);
                        break;
                    case ',':
                        c = StackStack.Pop();
                        WriteChar(c);
                        break;
                    case '-':
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        c = a - b;
                        StackStack.Push(c);
                        break;
                    case '.':
                        a = StackStack.Pop();
                        WriteInt(a);
                        break;
                    case '/':
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        c = Divide(a, b);
                        StackStack.Push(c);
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        a = instruction - '0';
                        StackStack.Push(a);
                        break;
                    case ':':
                        a = StackStack.Pop();
                        StackStack.Push(a);
                        StackStack.Push(a);
                        break;
                    case '<':
                        instructionPointerDirection = new FungeSpaceDirection(-1, 0);
                        break;
                    case '>':
                        instructionPointerDirection = new FungeSpaceDirection(+1, 0);
                        break;
                    case '?':
                        b = randomizer.Next(4);
                        switch (b)
                        {
                            case 0:
                                instructionPointerDirection = new FungeSpaceDirection(+1, 0);
                                break;
                            case 1:
                                instructionPointerDirection = new FungeSpaceDirection(-1, 0);
                                break;
                            case 2:
                                instructionPointerDirection = new FungeSpaceDirection(0, +1);
                                break;
                            case 3:
                                instructionPointerDirection = new FungeSpaceDirection(0, -1);
                                break;
                        }
                        break;
                    case '@': // halt
                        move = false;
                        programExecuting = false;
                        break;
                    case '\\':
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        StackStack.Push(b);
                        StackStack.Push(a);
                        break;
                    case '^':
                        Ensure2D();
                        instructionPointerDirection = new FungeSpaceDirection(0, -1);
                        break;
                    case '_':
                        b = StackStack.Pop();
                        instructionPointerDirection = b != 0 ?
                            new FungeSpaceDirection(-1, 0) : new FungeSpaceDirection(+1, 0);
                        break;
                    case '`':
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        c = a > b ? 1 : 0;
                        StackStack.Push(c);
                        break;
                    case 'g': // get
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        c = FundgeSpace.Cells[a, b];
                        StackStack.Push(c);
                        break;
                    case 'p': // put
                        b = StackStack.Pop();
                        a = StackStack.Pop();
                        c = StackStack.Pop();
                        FundgeSpace.Cells[a, b] = (byte)c;
                        break;
                    case 'v':
                        Ensure2D();
                        instructionPointerDirection = new FungeSpaceDirection(0, +1);
                        break;
                    case '|':
                        Ensure2D();
                        b = StackStack.Pop();
                        instructionPointerDirection = b != 0 ?
                            new FungeSpaceDirection(0, -1) : new FungeSpaceDirection(0, +1);
                        break;
                    case '~':
                        c = ReadChar();
                        StackStack.Push(c);
                        break;
                    default:
                        throw new FungeException(
                            String.Format("Unknown instruction {0} at {1}", CurrentInstruction, InstructionPointer));
                }

                if (move)
                {
                    Skip();
                }

                return programExecuting;
            }
            catch (FungeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new FungeException(
                    String.Format("Fundge exception at {0}: {1}", InstructionPointer, ex.Message));
            }
        }

        private void Ensure2D()
        {
            if (is2dDisabled)
                throw new FungeException(
                    String.Format("Vertical movement is disabled. Instruction {0} at {1}", CurrentInstruction, InstructionPointer));
        }

        private void ReadString()
        {
            do
            {
                MoveOnePosition();
                byte code = FundgeSpace.Cells[InstructionPointer];
                if (ConversionUtils.ToChar(code) == '\"') break;
                StackStack.Push(code);
            } while (true);
        }

        protected virtual int ReadChar()
        {
            int ch = Console.Read();
            if (ch < 0)
                throw new FungeException("End of input stream");

            return ConversionUtils.FromChar((char)ch);
        }

        protected virtual void WriteInt(int a)
        {
            Console.Write(a.ToString() + " ");
        }

        protected virtual void WriteChar(int c)
        {
            char ch = ConversionUtils.ToChar(checked((byte)c));
            Console.Write(ch);
        }

        protected virtual int ReadInteger()
        {
            int result;
            bool valid = true;
            do
            {
                Console.Write(valid ? "?" : "??");
                string s = Console.ReadLine();
                valid = Int32.TryParse(s, out result);
            } while (!valid);
            return result;
        }

        private int Reminder(int x, int y)
        {
            if (y == 0)
                return 0; //throw new DivideByZeroException();
            return x % y;
        }

        private int Divide(int x, int y)
        {
            if (y == 0)
                return 0; // throw new DivideByZeroException();
            return x / y;
        }

        private void Skip()
        {
            MoveOnePosition();
            if (CurrentInstruction == FungeSpace.EmptyCell)
            {
                FungeSpacePointer initialPointer = InstructionPointer;
                do
                {
                    MoveOnePosition();
                } while (CurrentInstruction == FungeSpace.EmptyCell);
            }
        }

        private void MoveOnePosition()
        {
            instructionPointer += instructionPointerDirection;

            // wrapping
            if (InstructionPointer.X < FungeSpace.MinX)
                instructionPointer.X = FungeSpace.MaxX;
            else if (InstructionPointer.X > FungeSpace.MaxX)
                instructionPointer.X = FungeSpace.MinX;
            else if (InstructionPointer.Y < FungeSpace.MinY)
                instructionPointer.Y = FungeSpace.MaxY;
            else if (InstructionPointer.Y > FungeSpace.MaxY)
                instructionPointer.Y = FungeSpace.MinY;
        }

        public void Run()
        {
            while (Step()) ;
        }
    }
}
