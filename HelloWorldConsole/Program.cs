#if !EXECUTENATIVECSHARPCODE
//#define EXECUTENATIVECSHARPCODE
#endif

#if !SCRIPTFILE
//#define SCRIPTFILE
#endif

#if !SERIALIZATION1
//#define SERIALIZATION1
#endif

#if !SERIALIZATION2
//#define SERIALIZATION2
#endif

#if !SERIALIZATION3
//#define SERIALIZATION3
#endif

#if !SERIALIZATION4
//#define SERIALIZATION4
#endif

#if !SERIALIZATION5
//#define SERIALIZATION5
#endif

#if !SERIALIZATION6
//#define SERIALIZATION6
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

#if SCRIPTFILE
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
#endif

#if SERIALIZATION1
        Serialization1.Run();
#endif

#if SERIALIZATION2
        Serialization2.Run();
#endif

#if SERIALIZATION3
        Serialization3.Run();
#endif

#if SERIALIZATION4
        Serialization4.Run();
#endif

#if SERIALIZATION5
        Serialization5.Run();
#endif

#if SERIALIZATION6
        Serialization6.Run();
#endif
    }
}
