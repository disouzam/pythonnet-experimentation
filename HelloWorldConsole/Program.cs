#if !EXECUTENATIVECSHARPCODE
//#define EXECUTENATIVECSHARPCODE
#endif

using System;

using Python.Runtime;

namespace HelloWorldConsole;

internal static class Program
{
    static void Main(string[] args)
    {
#if EXECUTENATIVECSHARPCODE
        Console.WriteLine("Hello, World!");
#endif
        Runtime.PythonDLL = @"C:\Program Files\Python312\python312.dll";
        PythonEngine.Initialize();
        PythonEngine.Shutdown();
        Console.WriteLine("Finished execution of console app.");
    }
}
