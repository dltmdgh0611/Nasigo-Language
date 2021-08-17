using System;
using Nasigo_Parser;

namespace NasigoLanguage
{
    class Nasigolang
    {
        static void Main(string[] args)
        {
            NasigoParser.Instance.DoParse(@"D:\Nasigo-lang\NasigoLanguage\NasigoLanguage\code.ns");
        }
    }
}
