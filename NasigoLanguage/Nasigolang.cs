using System;
using System.Collections.Generic;

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
