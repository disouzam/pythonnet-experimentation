using System;

using Python.Runtime;

namespace HelloWorldConsole;

internal class PythonRuntimeManager : IDisposable
{

    public PythonRuntimeManager()
    {
        Runtime.PythonDLL = @"C:\Program Files\Python312\python312.dll";
        PythonEngine.Initialize();
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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Dispose method of PythonRuntimeManager class was called.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
