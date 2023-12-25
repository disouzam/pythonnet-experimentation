﻿#if !SERIALIZATION1
#define SERIALIZATION1
#endif

#if SERIALIZATION1
using System;
using System.IO;

using Python.Runtime;

namespace HelloWorldConsole;

internal static class Serialization1
{
    public static void Run()
    {
        Runtime.PythonDLL = @"C:\Program Files\Python312\python312.dll";
        PythonEngine.Initialize();

        var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
        var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts","serialization1.py");

        var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

        using(Py.GIL())
        {
            using var scope = Py.CreateScope();
            scope.Exec(scriptContent);
        }

        PythonEngine.Shutdown();
        Console.WriteLine("Finished execution of Run method of Serialization1 class.");
    }
}
#endif