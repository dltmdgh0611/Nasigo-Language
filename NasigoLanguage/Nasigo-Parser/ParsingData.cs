using System;
using System.Collections.Generic;
using System.Text;

namespace NasigoLanguage
{
    /// <summary>
    /// Parsing한 String을 저장하고, Parsing Status에 관한 정보들을 포함한다.
    /// </summary>
    public class ParsingData
    {
        private string _parsingdata_Str = null;
        private List<string> _parsingdata_List = new List<string>();

        /// <summary>
        /// String 형태의 Parsing Data
        /// </summary>
        public string ParsingData_Str { get => _parsingdata_Str; }

        /// <summary>
        /// List 형태의 Parsing Data
        /// </summary>
        public List<string> ParsingData_List { get => _parsingdata_List; }

        /// <summary>
        /// Parsing Data Class에 line을 추가합니다.
        /// </summary>
        /// <param name="line">추가할 line</param>
        public void Add(string line)
        {
            _parsingdata_List.Add(line);
            _parsingdata_Str += line + "\n";
        }

        /// <summary>
        /// Debug용 Parsing Data Print 함수.
        /// </summary>
        public void Print()
        {
            Console.WriteLine();
            int count = 1;
            int listcount = ParsingData_List.Count.ToString().Length;
            string space = " ";
            foreach (string i in ParsingData_List)
            {
                int curcount = listcount - count.ToString().Length;
                for (int j = 0; j < curcount; j++) space += " ";
                Console.WriteLine(space + count + "   " + i);
                count++;
                space = " ";
            }
        }
    }
}
