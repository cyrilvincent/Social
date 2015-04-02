using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Social.UnitTests
{
    public class NUnitCustomEngine
    {

        public int NbMethod { get; set; }
        public int NbSuccess { get; set; }
        public void Test(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types.Where(t => t.GetCustomAttributes().Any(a => a.GetType() == typeof(TestFixtureAttribute))).OrderBy(t => t.FullName))
                Test(type);
        }
        public void Test()
        {
            Test(typeof(NUnitCustomEngine).Assembly);
        }

        public delegate void MethodHandler(MethodInfo mi, string s, Exception ex);
        public event MethodHandler MethodEvent;
        public void Test(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            object instance = Activator.CreateInstance(type);
            foreach (MethodInfo method in methods.Where(m => m.GetCustomAttributes().Any(a => a.GetType() == typeof(TestAttribute))).OrderBy(m => m.Name))
            {
                NbMethod++;
                DateTime dt = DateTime.Now;
                Exception ex = Test(instance, method);
                if (ex == null) NbSuccess++;
                string s = type.Name + "." + method.Name + " ";
                s += ex == null ? "ok" : ex.StackTrace;
                s += String.Format(" ({0:N0} ms)", (DateTime.Now - dt).TotalMilliseconds);
                if (MethodEvent != null)
                    MethodEvent(method, s, ex);
            }
        }

        private Exception Test(object instance, MethodInfo method)
        {
            Exception result = null;
            try
            {
                method.Invoke(instance, null);
            }
            catch (Exception ex)
            {
                result = ex.InnerException;
            }
            return result;
        }
    }
}
