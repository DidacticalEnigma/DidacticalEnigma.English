using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DidacticalEnigma.English.Parsing
{
    public static class HyphenationFileReader
    {
        public static IEnumerable<HyphenationInfo> ReadFromReader(TextReader stream, string separator)
        {
            string? line;
            while ((line = stream.ReadLine()) != null)
            {
                var split = line.Split(new []{'='}, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length != 2)
                {
                    continue;
                }
                yield return new HyphenationInfo(split[1], separator);
            }
        }

        public static IEnumerable<HyphenationInfo> ReadFromFile(string path, string separator, Encoding? encoding = null)
        {
            using (var file = File.OpenRead(path))
            using (var reader = new StreamReader(file, encoding ?? Encoding.UTF8))
            {
                foreach (var info in ReadFromReader(reader, separator))
                {
                    yield return info;
                }
            }
        }
    }
}