using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECDict
{
    //定义单词结构，用于序列化
    [Serializable]
    class Word
    {
        string en;
        string cn;

        public string En { get => en; set => en = value; }
        public string Cn { get => cn; set => cn = value; }

        public Word(string en, string cn)
        {
            this.en = en;
            this.cn = cn;
        }

        public override string ToString()
        {
            return string.Format("{0}\n中文释义：{1}", en, cn);
        }
    }
}
