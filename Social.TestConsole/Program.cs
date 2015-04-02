using Social.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TestConsole");
            Console.WriteLine("===========");
            NUnitCustomEngine test = new NUnitCustomEngine();
            test.MethodEvent += test_MethodEvent;
            test.Test();
            Console.WriteLine("Result: " + test.NbSuccess + "/" + test.NbMethod);
            Console.ReadKey();
        }

        static void test_MethodEvent(System.Reflection.MethodInfo mi, string s, Exception ex)
        {
            Console.WriteLine(s);
        }
    }
}
