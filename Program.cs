using System;
using System.Reflection;
using System.Text;

namespace ToDebugString
{
    class Program
    {
        static void Main(string[] args)
        {
            var userData = new UserData();
            try
            {
                var logBuilder = new StringBuilder();
                userData.DebugToString(BindingFlags.Instance | BindingFlags.Public, logBuilder);
                Console.WriteLine(logBuilder.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
