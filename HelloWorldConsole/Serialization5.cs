﻿#if !SERIALIZATION5
#define SERIALIZATION5
#endif

#if SERIALIZATION5

using System;
using System.IO;

using Python.Runtime;

namespace HelloWorldConsole;

internal static class Serialization5
{
    public static void Run()
    {
        using(var runtimeManager = new PythonRuntimeManager())
        {
            var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
            var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts", "serialization5.py");

            var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

            using(Py.GIL())
            {
                using var scope = Py.CreateScope();
                scope.Exec(scriptContent);
            }

            Console.WriteLine("Finished execution of Run method of Serialization5 class."); 
        }
    }
}
#endif
