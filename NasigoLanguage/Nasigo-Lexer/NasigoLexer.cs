using System;
using System.Collections.Generic;

namespace NasigoLanguage
{
    public enum Kind
    {
        Unknown,
        letter,
        digit,
        equal,
        lparen,     // (
        rparen,     // )
        lbrace,     // {
        rbrace,     // }
        lbraket,    // [
        rbraket,    // ]
        lbrack,    // <
        rbrack,    // >
        noteq, // !=
        lesseq, // <=
        gtreq, // >=
        change, // <=>
        dot,
        comma,
        semi,      // ;
        error
    }
    public class NasigoLexer : NPSingleton<NasigoLexer>
    {
        

        static Kind[] KindTable = new Kind[128]; 
        static int Cursor = 0;
        static int Line = 0;
        List<string> list = null;

        void initKindTable()
        {
            int i;
            for (i = 0; i < 128; i++) KindTable[i] = Kind.error;
            for (i = '0'; i <= '9'; i++) KindTable[i] = Kind.digit;
            for (i = 'A'; i <= 'Z'; i++) KindTable[i] = Kind.letter;
            for (i = 'a'; i <= 'z'; i++) KindTable[i] = Kind.letter;
            KindTable['='] = Kind.equal;
            KindTable['('] = Kind.lparen;
            KindTable[')'] = Kind.rparen;
            KindTable['{'] = Kind.lbrace;
            KindTable['}'] = Kind.rbrace;
            KindTable['['] = Kind.lbraket;
            KindTable[']'] = Kind.rbraket;
            KindTable['<'] = Kind.lbrack;
            KindTable['>'] = Kind.rbrack;
            KindTable['.'] = Kind.dot;
            KindTable[','] = Kind.comma;
            KindTable[';'] = Kind.semi;
        }

        char nextChar()
        {
            char result = ' ';
            if (Line >= list.Count) return '$';
            if (list[Line].Length != 0) result = list[Line][Cursor];
            Cursor++;
            if (Cursor >= list[Line].Length)
            {
                Line++;
                Cursor = 0;
            }
            return result;
        }

        void prevChar()
        {
            if (Cursor == 0)
            {
                Line--;
                Cursor = list[Line].Length-1;
            }
            else Cursor--;
        }

        public void DoLexicalAnalysis(ParsingData parsingData)
        {
            list = parsingData.ParsingData_List;
            initKindTable();
            for (int i = 0; i < 100; i++)
            {
                Token t = GetToken();
                switch (t.kind)
                {
                    case Kind.Unknown:
                        break;
                    case Kind.letter:
                        Console.WriteLine(t.word + " <letter>");
                        break;
                    case Kind.digit:
                        Console.WriteLine(t.value + " <digit>");
                        break;
                    default:
                        Console.WriteLine(t.ch + " <"+t.kind+">");
                        break;
                }
                
            }
            ;

        }

        Token GetToken()
        {
            Token token = new Token();
            Kind k = new Kind();
            char ch = ' ';
            int num = 0;
            string block = "";
            while (true)
            {
                ch = nextChar();
                if (ch != ' ') break;
            }
            switch (k = KindTable[ch])
            {
                case Kind.letter:
                    do
                    {
                        block += ch.ToString();
                        ch = nextChar();
                    } while (KindTable[ch] == Kind.digit || KindTable[ch] == Kind.letter);
                    token.kind = Kind.letter;
                    token.word = block;
                    prevChar();
                    break;
                    
                case Kind.digit:
                    do
                    {
                        num = 10 * num + (ch - '0');
                        ch = nextChar();
                    } while (KindTable[ch] == Kind.digit);
                    token.kind = Kind.digit;
                    token.value = num;
                    prevChar();
                    break;

                case Kind.lbrack:
                    if ((ch = nextChar()) == '=')
                    {
                        token.kind = Kind.lesseq;
                        if ((ch = nextChar()) == '>')
                        {
                            ch = nextChar();
                            token.kind = Kind.change;
                            break;
                        }
                    }
                    else
                    {
                        prevChar();
                        token.kind = Kind.lbrack;
                    }
                    break;
                case Kind.rbrack:
                    if ((ch = nextChar()) == '=')
                    {
                        ch = nextChar();
                        token.kind = Kind.gtreq;
                    }
                    else
                    {
                        prevChar();
                        token.kind = Kind.rbrack;
                    }
                    break;
                case Kind.semi:
                    token.ch = ch;
                    token.kind = Kind.semi;
                    break;
                case Kind.dot:
                    token.ch = ch;
                    token.kind = Kind.dot;
                    break;
                case Kind.comma:
                    token.ch = ch;
                    token.kind = Kind.comma;
                    break;
                case Kind.lparen:
                    token.ch = ch;
                    token.kind = Kind.lparen;
                    break;
                case Kind.rparen:
                    token.ch = ch;
                    token.kind = Kind.rparen;
                    break;
                case Kind.lbrace:
                    token.ch = ch;
                    token.kind = Kind.lbrace;
                    break;
                case Kind.rbrace:
                    token.ch = ch;
                    token.kind = Kind.rbrace;
                    break;
                case Kind.equal:
                    token.ch = ch;
                    token.kind = Kind.equal;
                    break;
                default:
                    break;
            }
            return token;
        }


        //List<Kind> GetTokens(List<string> codeList)
        //{
        //    List<Kind> Kinds = new List<Kind>();
        //    for (int Line = 0; Line < codeList.Count; Line++)
        //    {
        //        for (int Cursor = 0; Cursor < codeList[Line].Length; Cursor++)
        //        {
        //            Kinds.Add(Throwkind(codeList[Line][Cursor]));
        //        }
        //    }

        //    return Kinds;

        //    Kind Throwkind(char ch)
        //    {
        //        Kind kind;
        //        if (isSpace(ch)) kind = Kind.space;
        //        else if (isLetter(ch)) kind = Kind.letter;
        //        else if (isDigit(ch)) kind = Kind.digit;
        //        else if (isEqual(ch)) kind = Kind.equal;
        //        else if (isLPAREN(ch)) kind = Kind.lparen;
        //        else if (isRPAREN(ch)) kind = Kind.rparen;
        //        else if (isLBRACE(ch)) kind = Kind.lbrace;
        //        else if (isRBRACE(ch)) kind = Kind.rbrace;
        //        else if (isLBRAKET(ch)) kind = Kind.lbraket;
        //        else if (isRBRAKET(ch)) kind = Kind.rbraket;
        //        else if (isLBRACK(ch)) kind = Kind.lbrack;
        //        else if (isRBRACK(ch)) kind = Kind.rbrack;
        //        else if (isDot(ch)) kind = Kind.dot;
        //        else if (isComma(ch)) kind = Kind.comma;
        //        else if (isSemi(ch)) kind = Kind.semi;
        //        else kind = Kind.error;
        //        return kind;
        //    }



        //    bool isSpace(char ch) => ch == 32;
        //    bool isLetter(char ch) => (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122);
        //    bool isDigit(char ch) => (ch >= 48 && ch <= 57);
        //    bool isEqual(char ch) => ch == 61;
        //    bool isLPAREN(char ch) => ch == 40;
        //    bool isRPAREN(char ch) => ch == 41;
        //    bool isLBRACE(char ch) => ch == 123;
        //    bool isRBRACE(char ch) => ch == 125;
        //    bool isLBRAKET(char ch) => ch == 91;
        //    bool isRBRAKET(char ch) => ch == 93;
        //    bool isLBRACK(char ch) => ch == 60;
        //    bool isRBRACK(char ch) => ch == 62;
        //    bool isDot(char ch) => ch == 46;
        //    bool isComma(char ch) => ch == 44;
        //    bool isSemi(char ch) => ch == 59;
        //}

        //char nextChar()
        //{
        //    char ch = 'a';

        //    if(Cursor == list[line].Length)
        //    {
        //        ch = list[line][Cursor];
        //        line++;
        //        Cursor = -1;
        //    }

        //    return ch;
        //}


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
