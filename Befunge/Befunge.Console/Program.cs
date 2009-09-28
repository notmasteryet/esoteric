namespace Befundge.Console
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Befunge.VM;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage(); return;
            }

            string codePath = args[0];
            try
            {
                FungeEngine engine = new FungeEngine(codePath);

                engine.Run();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("USAGE: Befundge.Console.exe <bf-file>");
        }
    }
}
