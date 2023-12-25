#if !SERIALIZATION4
#define SERIALIZATION4
#endif

#if SERIALIZATION4

using System;
using System.IO;

using Python.Runtime;

namespace HelloWorldConsole;

internal class Serialization4 : IDisposable
{
    public void Run()
    {
        Runtime.PythonDLL = @"C:\Program Files\Python312\python312.dll";
        PythonEngine.Initialize();

        var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
        var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts", "serialization4.py");

        var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

        using(Py.GIL())
        {
            using var scope = Py.CreateScope();
            scope.Exec(scriptContent);
        }

        Console.WriteLine("Finished execution of Run method of Serialization4 class.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // Cleanup
        PythonEngine.Shutdown();
        Console.WriteLine("Dispose method of Serialization4 class was called");
    }
}
#endif
