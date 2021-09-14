using System;
using System.IO;

namespace NasigoLanguage
{
    public class NasigoReader : NPSingleton<NasigoReader>
    {
        

        public ReadData DoRead(string path)
        {
            ReadData result = new ReadData();

            try
            {
                if (!NReadLine(ref result, path)) throw new Exception("Reading Error... \n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return result;
        }
        
        private bool NReadLine(ref ReadData data, string path)
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
