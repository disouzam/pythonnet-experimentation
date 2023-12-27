﻿#if !UNPICKLING2
#define UNPICKLING2
#endif

#if UNPICKLING2

using System;
using System.IO;

using Python.Runtime;

namespace HelloWorldConsole;

internal static class Unpickling2
{
    public static void Run()
    {
        try
        {
            using(var runtimeManager = new PythonRuntimeManager())
            {
                var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
                var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts", "unpickling2.py");

                var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

                using(Py.GIL())
                {
                    using var scope = Py.CreateScope();
                    scope.Exec(scriptContent);

                    dynamic X = scope.Get("X");
                    Console.WriteLine(X);
                }

                Console.WriteLine("Finished execution of Run method of Unpickling2 class.");
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