using System;
using System.Collections.Generic;

namespace NasigoLanguage
{
    public class NasigoLexer : NPSingleton<NasigoLexer>
    {
        enum Kind
        {
            space = 0,
            letter = 1,
            digit = 2,
            equal = 3,
            lparen = 4,     // (
            rparen = 5,     // )
            lbrace = 6,     // {
            rbrace = 7,     // }
            lbraket = 8,    // [
            rbraket = 9,    // ]
            lbrack = 10,    // <
            rbrack = 11,    // >
            dot = 12,
            comma = 13,
            semi = 14,      // ;
            error = 999
        }

        static int Cursor = -1;
        static int line = 0;
        List<string> list = null;

        public void DoLexicalAnalysis(ParsingData parsingData)
        {
            list = parsingData.ParsingData_List;

            List<Kind> Tokens = GetTokens(list);
#if DEBUG
            TokensPrint();            
#endif



            void TokensPrint()
            {
                Console.WriteLine("------------- Tokens -------------------------");
                for (int i = 0; i < Tokens.Count; i++)
                {
                    Console.WriteLine("<" + Tokens[i] + ">");
                }
            }
        }

        List<Kind> GetTokens(List<string> codeList)
        {
            List<Kind> Kinds = new List<Kind>();
            for (int Line = 0; Line < codeList.Count; Line++)
            {
                for (int Cursor = 0; Cursor < codeList[Line].Length; Cursor++)
                {
                    Kinds.Add(Throwkind(codeList[Line][Cursor]));
                }
            }

            return Kinds;

            Kind Throwkind(char ch)
            {
                Kind kind;
                if (isSpace(ch)) kind = Kind.space;
                else if (isLetter(ch)) kind = Kind.letter;
                else if (isDigit(ch)) kind = Kind.digit;
                else if (isEqual(ch)) kind = Kind.equal;
                else if (isLPAREN(ch)) kind = Kind.lparen;
                else if (isRPAREN(ch)) kind = Kind.rparen;
                else if (isLBRACE(ch)) kind = Kind.lbrace;
                else if (isRBRACE(ch)) kind = Kind.rbrace;
                else if (isLBRAKET(ch)) kind = Kind.lbraket;
                else if (isRBRAKET(ch)) kind = Kind.rbraket;
                else if (isLBRACK(ch)) kind = Kind.lbrack;
                else if (isRBRACK(ch)) kind = Kind.rbrack;
                else if (isDot(ch)) kind = Kind.dot;
                else if (isComma(ch)) kind = Kind.comma;
                else if (isSemi(ch)) kind = Kind.semi;
                else kind = Kind.error;
                return kind;
            }



            bool isSpace(char ch) => ch == 32;
            bool isLetter(char ch) => (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122);
            bool isDigit(char ch) => (ch >= 48 && ch <= 57);
            bool isEqual(char ch) => ch == 61;
            bool isLPAREN(char ch) => ch == 40;
            bool isRPAREN(char ch) => ch == 41;
            bool isLBRACE(char ch) => ch == 123;
            bool isRBRACE(char ch) => ch == 125;
            bool isLBRAKET(char ch) => ch == 91;
            bool isRBRAKET(char ch) => ch == 93;
            bool isLBRACK(char ch) => ch == 60;
            bool isRBRACK(char ch) => ch == 62;
            bool isDot(char ch) => ch == 46;
            bool isComma(char ch) => ch == 44;
            bool isSemi(char ch) => ch == 59;
        }

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
            //char ch = 'a';
            //ch = nextChar();
            //if (isletter(ch)) goto state2;

            //state2: ch = nextChar();
            //if (isletter(ch) || isdigit(ch)) goto state2;
            //else goto state3;

            //state3: backchar();
        }
       
        

        
        
    }
}
