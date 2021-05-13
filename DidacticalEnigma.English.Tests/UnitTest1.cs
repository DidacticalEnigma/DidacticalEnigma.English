using System.IO;
using System.Xml.Serialization;
using DidacticalEnigma.English.Parsing.Models;
using NUnit.Framework;

namespace DidacticalEnigma.English.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var serializer = new XmlSerializer(typeof(LexicalResource));
            var res = (LexicalResource) serializer.Deserialize(
                File.OpenRead("/media/milleniumbug/stuff/asdf/english_resources/english-wordnet-2020.xml"));
            ;
            ;
        }
    }
}