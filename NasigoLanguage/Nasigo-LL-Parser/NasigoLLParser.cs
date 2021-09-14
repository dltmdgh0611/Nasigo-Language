using System;
using System.Collections.Generic;
using System.Text;

namespace NasigoLanguage.Nasigo_LL_Parser
{
    class NasigoLLParser
    {
        void block(int blockIndex, Token token)
        {
             
            while (true)
            {
                switch (token.kind)
                {
                    case Kind.Int:
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
