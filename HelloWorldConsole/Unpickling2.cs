#if !UNPICKLING2
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
                    Console.WriteLine("Array of inputs X");
                    Console.WriteLine(X);
                    Console.WriteLine();
                    Console.WriteLine();

                    dynamic y = scope.Get("y");
                    Console.WriteLine("Array of dependent variable y");
                    Console.WriteLine(y);
                    Console.WriteLine();
                    Console.WriteLine();

                    dynamic linearModel = scope.Get("unpickled_linear_model");
                    Console.WriteLine("Linear Model");
                    Console.WriteLine(linearModel.intercept_);
                    Console.WriteLine(linearModel.coef_);
                    Console.WriteLine(linearModel.coef_[0]);
                    Console.WriteLine(linearModel.coef_[1]);
                    Console.WriteLine(linearModel.coef_[2]);
                    Console.WriteLine(linearModel.score(X, y));

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Prediction using C# created 2D array");
                    var singleArray = new double[1][];
                    singleArray.SetValue(new double[] { -0.84520564, -0.0126646, -0.67124613 }, 0);
                    Console.WriteLine(linearModel.predict(singleArray));

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Prediction using Python created 2D array and dynamically imported to C#");

                    Console.WriteLine(X);

                    // Get individual values from Python object (index 0 and 1 were selected at random for example)
                    var x0 = X[0];
                    var x1 = X[1];

                    // Created a 2D array with one element in first dimension
                    var x0n = new double[1][];
                    x0n.SetValue((double[])x0, 0); // Used casting to an array of doubles to convert from a dynamic Python object

                    // Created a 2D array with one element in first dimension
                    var x1n = new double[1][];
                    x1n.SetValue((double[])x1, 0);  // Used casting to an array of doubles to convert from a dynamic Python object

                    // Created a 2D array with two elements in first dimension
                    var xComb = new double[2][];
                    xComb.SetValue((double[])x0, 0);
                    xComb.SetValue((double[])x1, 1);

                    Console.WriteLine(linearModel.predict(x0n));
                    Console.WriteLine(linearModel.predict(x1n));
                    
                    // This prediction would display the same two values as the previous two calls
                    Console.WriteLine(linearModel.predict(xComb));

                    Console.WriteLine();
                    Console.WriteLine();
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
