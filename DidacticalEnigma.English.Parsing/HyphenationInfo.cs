using System;
using System.Collections.Generic;

namespace DidacticalEnigma.English.Parsing
{
    public class HyphenationInfo : IEquatable<HyphenationInfo>
    {
        private readonly string data;

        public string Word => data.Replace("\0", "");

        public IEnumerable<string> Syllables => data.Split(new char[]{'\0'}, StringSplitOptions.RemoveEmptyEntries);
        
        public HyphenationInfo(string word, string separator)
        {
            data = word.Replace(separator, "\0");
        }
        
        public bool Equals(HyphenationInfo? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Word, other.Word, StringComparison.InvariantCulture);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HyphenationInfo) obj);
        }

        public override int GetHashCode()
        {
            return StringComparer.InvariantCulture.GetHashCode(Word);
        }

        public static bool operator ==(HyphenationInfo? left, HyphenationInfo? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HyphenationInfo? left, HyphenationInfo? right)
        {
            return !Equals(left, right);
        }
    }
}