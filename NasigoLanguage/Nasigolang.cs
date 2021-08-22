using System;
using System.Collections.Generic;

namespace NasigoLanguage
{
    class Nasigolang
    {
        static void Main(string[] args)
        {
            ParsingData parsingData = new ParsingData();
            parsingData = NasigoParser.Instance.DoParse(@"G:\NasigoLang\NasigoLanguage\code.ns");

            NasigoLexer.Instance.DoLexicalAnalysis(parsingData);

            Console.WriteLine("계속하려면 아무 키나 누르십시오..");
            Console.ReadLine();

        }
    }
}
