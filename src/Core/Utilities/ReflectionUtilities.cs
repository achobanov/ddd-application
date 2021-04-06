using System;
using System.Linq;
using System.Reflection;

namespace EnduranceJudge.Core.Utilities
{
    public static class ReflectionUtilities
    {
        public static Assembly[] GetAssemblies(params string[] projectNames)
        {
            var assemblies = projectNames
                .Select(name =>
                {
                    try
                    {
                        return Assembly.Load(name);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(assembly => assembly != null)
                .ToArray();

            return assemblies;
        }

        public static PropertyInfo[] GetProperties<T>(BindingFlags bindingFlags)
        {
            var properties = typeof(T).GetProperties(bindingFlags);
            return properties;
        }

        public static PropertyInfo[] GetProperties(Type type, BindingFlags bindingFlags)
        {
            var properties = type.GetProperties(bindingFlags);
            return properties;
        }

        public static MethodInfo GetMethod(Type type, string name, params Type[] arguments)
        {
            var method = type.GetMethod(name, arguments);
            if (method == null)
            {
                throw new InvalidOperationException($"Method '{name}' not found on type '{type}'");
            }

            return method;
        }
    }
}
