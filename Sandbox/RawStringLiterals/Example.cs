using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.RawStringLiterals
{
    public static class Example
    {
        public static void Run()
        {
            // By using raw string literals, we can easily format a string.
            const string formattingExample = """
                public class ExampleClass
                {
                  public ExampleClass()
                  {

                  }

                  public override string ToString()
                  {
                    return "raw string literal example";
                  }
                }
                """;

            Console.WriteLine(formattingExample);

            // $$ means use two brackets for interpolation expression {{className}}
            // $ would not work, as it would expect an expression for the curly braces
            // that are part of the string.
            const string className = "ExampleTwo";
            const string interpolatedExample = $$"""
                public class {{className}}
                {
                  public ExampleClass()
                  {
                
                  }
                
                  public override string ToString()
                  {
                    return "raw string literal example";
                  }
                }
                """;

            Console.WriteLine(interpolatedExample);
        }
    }
}
