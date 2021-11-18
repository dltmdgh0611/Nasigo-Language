using System;
using System.Collections.Generic;
using System.Text;

namespace NasigoLanguage.Nasigo_LL_Parser
{
    class NasigoLLParser
    {

        Token GetToken() => NasigoLexer.Instance.GetToken();

        void block(int blockIndex, Token token)
        {
             
            while (true)
            {
                switch (token.kind)
                {
                    case Kind.Int:
                        token = GetToken();

                        break;
                    default:
                        break;
                }

            }
        }
    }
}
