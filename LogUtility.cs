using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ToDebugString
{
    public static class LogUtility
    {
        private static Type[] pureTypes = new[]
        {
            typeof(bool),
            typeof(byte), typeof(sbyte),
            typeof(ushort), typeof(short),
            typeof(uint), typeof(int),
            typeof(ulong), typeof(long),
            typeof(char),
            typeof(float), typeof(double), typeof(decimal),
            typeof(string)
        };

        public static StringBuilder logBuilder = new StringBuilder();
        
        public static void DebugToString(this object target, BindingFlags bindingFlags, StringBuilder outputLogBuilder, int tabCount = 0)
        {
            var type = target.GetType();
            if (pureTypes.Contains(type))
            {
                outputLogBuilder.Append(GetTabsByCount(tabCount));
                outputLogBuilder.Append($"{type.Name}: {target}\n");
                return;
            }

            outputLogBuilder.Append(GetTabsByCount(tabCount));
            outputLogBuilder.Append($"{target.GetType().Name}\n");
            var fields = target.GetType().GetFields(bindingFlags);
            foreach (var field in fields)
            {
                if (!pureTypes.Contains(field.DeclaringType) && field.GetValue(target) == null)
                {
                    outputLogBuilder.Append(GetTabsByCount(tabCount));
                    outputLogBuilder.Append($"{field.Name}: Null\n");
                    continue;
                }
                field.GetValue(target).DebugToString(bindingFlags, outputLogBuilder, tabCount + 1);
            }
        }

        private static string GetTabsByCount(int count)
        {
            ReadOnlySpan<char> tabs = Enumerable.Range(0, count * 2).Select(_ => ' ').ToArray().AsSpan();
            return new string(tabs);
        }
    }
}
