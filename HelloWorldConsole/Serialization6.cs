#if !SERIALIZATION6
//#define SERIALIZATION6
#endif

#if SERIALIZATION6

using System;
using System.IO;

namespace HelloWorldConsole;

internal static class Serialization6
{
    public static void Run()
    {
        var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
        var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts", "serialization6.py");

        var scriptContent = File.ReadAllText(scriptFilePath, System.Text.Encoding.UTF8);

        var eng = IronPython.Hosting.Python.CreateEngine();
        var scope = eng.CreateScope();
        eng.Execute(scriptContent, scope);
    }
}
#endif
