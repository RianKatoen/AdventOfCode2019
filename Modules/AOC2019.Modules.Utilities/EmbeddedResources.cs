using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AOC2019.Modules.Utilities
{
    public static class EmbeddedResources
    {
        public static Stream Retrieve(Type type, string fileName)
        {
            var assemblyName = type.Namespace;
            var stream = type.Assembly.GetManifestResourceStream($"{assemblyName}.{fileName}");

            if (stream == null)
            {
                throw new ArgumentException($"Filename ({fileName}) was not found in assembly ({assemblyName}).");
            }

            return stream;
        }

        public static string Read(Type type, string fileName)
        {
            using (var stream = Retrieve(type, fileName))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static T[] ReadLines<T>(Type type, string fileName)
        {
            using (var stream = Retrieve(type, fileName))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                string line;
                var lines = new List<T>();
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add((T)Convert.ChangeType(line, typeof(T)));
                }

                return lines.ToArray();
            }
        }
    }
}
