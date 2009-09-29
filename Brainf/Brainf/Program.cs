using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.CodeDom.Compiler;

namespace Brainf
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage(); return;
            }

            string path = args[0];
            try
            {
                BrainfProgramBase program = Compile(path);
                program.Run();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        // syntax from http://en.wikipedia.org/wiki/Brainfuck
        private static BrainfProgramBase Compile(string path)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(path);
            string filename = Path.GetFileName(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string Indent = "\t\t";
                sb.AppendLine(String.Format("#line {0} \"{1}\"", i + 1, filename));
                string line = lines[i];
                sb.Append("// ").Append(line).AppendLine();
                for (int j = 0; j < line.Length; j++)
                {
                    switch (line[j])
                    {
                        case '>':
                            sb.Append(Indent).AppendLine("++IP;");
                            break;
                        case '<':
                            sb.Append(Indent).AppendLine("--IP;");
                            break;
                        case '+':
                            sb.Append(Indent).AppendLine("++Memory[IP];");
                            break;
                        case '-':
                            sb.Append(Indent).AppendLine("--Memory[IP];");
                            break;
                        case '.':
                            sb.Append(Indent).AppendLine("PutChar(Memory[IP]);");
                            break;
                        case ',':
                            sb.Append(Indent).AppendLine("Memory[IP] = GetChar();");
                            break;
                        case '[':
                            sb.Append(Indent).AppendLine("while(Memory[IP] != 0)");
                            sb.Append(Indent).AppendLine("{");
                            Indent += "\t";
                            break;
                        case ']':
                            Indent = Indent.Remove(0, Indent.Length - 1);
                            sb.Append(Indent).AppendLine("}");
                            break;
                    }
                }
            }

            string Body = "using Brainf;" + Environment.NewLine +
                Environment.NewLine +
                "public class BrainfProgram : BrainfProgramBase" + Environment.NewLine +
                "{" + Environment.NewLine +
                "\tpublic override void Run()" + Environment.NewLine +
                "\t{" + Environment.NewLine +
                sb.ToString() +
                "\t}" + Environment.NewLine +
                "}";


            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters @params = new CompilerParameters();
            @params.GenerateInMemory = true;
            @params.GenerateExecutable = false;
            @params.ReferencedAssemblies.Add(typeof(Program).Assembly.Location);
            
            CompilerResults results;
            results = compiler.CompileAssemblyFromSource(@params, Body);

            if (results.Errors.Count > 0)
            {
                throw new InvalidOperationException("Cannot compile: " + results.Errors[0]);
            }

            Type programType = results.CompiledAssembly.GetType("BrainfProgram");
            BrainfProgramBase program = (BrainfProgramBase)Activator.CreateInstance(programType);
            return program;
        }

        private static void PrintUsage()
        {
            Console.WriteLine("USAGE: Brainf.exe <f-file>");
        }
    }
}
