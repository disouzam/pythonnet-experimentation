using System;
using System.IO;

using Python.Runtime;

namespace HelloWorldConsole;

internal class PythonRuntimeManager : IDisposable
{
    public PythonRuntimeManager()
    {
        var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
        var pythonDllPath = Path.Combine(basePath.FullName, "tools", "python312.dll");
        Runtime.PythonDLL = pythonDllPath;
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
