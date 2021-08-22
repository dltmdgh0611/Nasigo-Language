using System;
using System.Collections.Generic;
using System.Text;

namespace NasigoLanguage
{
    public class Token
    {
        Key Kind { get; set; }

        string _word = null;
        string word { get => _word;
            set
            {
                if (value.ToString().Length > 30) throw new Exception("error : 개체 이름의 최대 길이는 30입니다.");
                else _word = value.ToString();
            }
        }
        int value { get; set; }
    }

    public class Key
    {

    }
}
