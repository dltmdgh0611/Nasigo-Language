using Nasigo_Design;
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
                if (!ParsingLine(ref result, path)) throw new Exception("Parsing Error... \n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return result;
        }
        
        private bool ParsingLine(ref ParsingData data, string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    data.Add(line);
                }
#if DEBUG
                data.Print();
#endif
            }
            return true;
        }
    }
}
