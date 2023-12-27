#if !SCRIPTFILE
#define SCRIPTFILE
#endif

#if !SERIALIZATION1
#define SERIALIZATION1
#endif

#if !SERIALIZATION2
#define SERIALIZATION2
#endif

#if !SERIALIZATION3
#define SERIALIZATION3
#endif

#if !SERIALIZATION4
#define SERIALIZATION4
#endif

#if !SERIALIZATION5
#define SERIALIZATION5
#endif

#if !SERIALIZATION6
#define SERIALIZATION6
#endif

#if !UNPICKLING1
#define UNPICKLING1
#endif

#if !UNPICKLING2
#define UNPICKLING2
#endif

using System;
using System.IO;

using Python.Runtime;

namespace HelloWorldConsole;

internal static class Program
{
    static void Main(string[] args)
    {
#if SCRIPTFILE
        using(var runtimeManager = new PythonRuntimeManager())
        {
            var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
            var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts", "scriptFile.py");

            var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

            using(Py.GIL())
            {
                using var scope = Py.CreateScope();
                scope.Exec(scriptContent);
                dynamic greetings = scope.Get("greetings");
                Console.WriteLine(greetings("world of Python.NET Nuget package"));
            }
        }

        Console.WriteLine("Finished execution of console app.");
#endif

#if SERIALIZATION1
        try
        {
            Serialization1.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
#endif

#if SERIALIZATION2
        try
        {
            Serialization2.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
#endif

#if SERIALIZATION3
        try
        {
            Serialization3.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
#endif

#if SERIALIZATION4
        try
        {
            var serialization4 = new Serialization4();
            serialization4.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
#endif

#if SERIALIZATION5
        try
        {
            Serialization5.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
#endif

#if SERIALIZATION6
        try
        {
            Serialization6.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
#endif

#if UNPICKLING1
        try
        {
            Unpickling1.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
#endif

#if UNPICKLING2
        try
        {
            Unpickling2.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
#endif
    }
}
