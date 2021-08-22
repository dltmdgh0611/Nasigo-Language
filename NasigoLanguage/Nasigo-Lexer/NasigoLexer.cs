using System;
using System.Collections.Generic;

namespace NasigoLanguage
{
    public class NasigoLexer : NPSingleton<NasigoLexer>
    {
        static int Cursor = -1;
        static int line = 0;
        List<string> list = null;
       

        char nextChar()
        {
            char ch = 'a';

            if(Cursor == list[line].Length)
            {
                ch = list[line][Cursor];
                line++;
                Cursor = -1;
            }

            return ch;
        }

        void Automata_Var()
        {
            char ch = 'a';
            ch = nextChar();
            if (isletter(ch)) goto state2;

            state2: ch = nextChar();
            if (isletter(ch) || isdigit(ch)) goto state2;
            else goto state3;

            state3: backchar();
        }



        

        void DoLexicalAnalysis(ParsingData parsingData)
        {
            list = parsingData.ParsingData_List;
        }

        
        
    }
}
