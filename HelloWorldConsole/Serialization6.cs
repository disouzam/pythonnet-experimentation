#if !SERIALIZATION6
#define SERIALIZATION6
#endif

#if SERIALIZATION6

using System;
using System.IO;

using Python.Runtime;

namespace HelloWorldConsole;

internal static class Serialization6
{
    public static void Run()
    {
        try
        {
            using(var runtimeManager = new PythonRuntimeManager())
            {
                var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
                var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts", "serialization6.py");

                var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

                using(Py.GIL())
                {
                    using var scope = Py.CreateScope();
                    scope.Exec(scriptContent);
                }

                Console.WriteLine("Finished execution of Run method of Serialization6 class.");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
    }
}
#endif
