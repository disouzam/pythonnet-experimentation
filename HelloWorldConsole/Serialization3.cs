#if !SERIALIZATION3
#define SERIALIZATION3
#endif

#if SERIALIZATION3

using System;
using System.IO;

using Python.Runtime;

namespace HelloWorldConsole;

internal static class Serialization3
{
    public static void Run()
    {
        try
        {
            using(var runtimeManager = new PythonRuntimeManager())
            {
                var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
                var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts", "serialization3.py");

                var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

                using(Py.GIL())
                {
                    using var scope = Py.CreateScope();
                    scope.Exec(scriptContent);
                } 
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }
        finally
        {            
            Console.WriteLine("Finished execution of Run method of Serialization3 class.");
        }
    }
}
#endif
