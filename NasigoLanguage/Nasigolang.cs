using System;
using System.Collections.Generic;

namespace NasigoLanguage
{
    class Nasigolang
    {
        static void Main(string[] args)
        {
            ReadData parsingData = new ReadData();
            parsingData = NasigoReader.Instance.DoRead(@"D:\Nasigo-lang\NasigoLanguage\NasigoLanguage\code.ns");

            NasigoLexer.Instance.DoLexicalAnalysis(parsingData);

            Console.WriteLine("계속하려면 아무 키나 누르십시오..");
            Console.ReadLine();

        }
    }
}
