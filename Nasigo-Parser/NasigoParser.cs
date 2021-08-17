using System;
using System.IO;

namespace Nasigo_Parser
{
    public class NasigoParser : NPSingleton<NasigoParser>
    {
        public ParsingData DoParse(string path)
        {
            ParsingData result = new ParsingData();

            try
            {
                if (!ParsingLine(ref result)) throw new Exception("Parsing Error... \n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return result;
        }
        
        private bool ParsingLine(ref ParsingData data)
        {
            
            return true;
        }
    }
}
