#if !EXECUTENATIVECSHARPCODE
//#define EXECUTENATIVECSHARPCODE
#endif

using System;

namespace HelloWorldConsole;

internal static class Program
{
    static void Main(string[] args)
    {
#if EXECUTENATIVECSHARPCODE
        Console.WriteLine("Hello, World!");
#endif
    }
}
