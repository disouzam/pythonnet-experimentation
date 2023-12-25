#if !EXECUTENATIVECSHARPCODE
//#define EXECUTENATIVECSHARPCODE
#endif

using System;
using System.IO;

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

        var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
        var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts","scriptFile.py");

        var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

        using(Py.GIL())
        {
            PythonEngine.Exec(scriptContent);

            using var scope = Py.CreateScope();
            scope.Exec(scriptContent);
            dynamic greetings = scope.Get("greetings");
            Console.WriteLine(greetings("world of Python.NET Nuget package"));
        }

        PythonEngine.Shutdown();
        Console.WriteLine("Finished execution of console app.");
    }
}
