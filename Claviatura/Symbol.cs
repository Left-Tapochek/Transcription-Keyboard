using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard
{
    public class Symbol: ISymbolSet
    {
        private readonly List<char> _symbolsSet = new List<char>
        {
            (char)105,
            (char)618,
            (char)650,
            (char)117,
            (char)101,
            (char)601,
            (char)604,
            (char)596,
            (char)230,
            (char)652,
            (char)593,
            (char)594,
            (char)97,
            (char)658,
            (char)331,
            (char)643,
            (char)240,
            (char)952,
            (char)676,
            (char)112,
            (char)98,
            (char)116,
            (char)100,
            (char)102,
            (char)609,
            (char)104,
            (char)106,
            (char)107,
            (char)108,
            (char)109,
            (char)110,
            (char)114,
            (char)679,
            (char)115,
            (char)118,
            (char)119,
            (char)122,
            (char)718,
            (char)719,
            (char)715,
            (char)714,
            (char)709,
            (char)708,
            (char)448,
            (char)449,
            (char)712,
            (char)58,
            (char)32,
        };
        public List<char> Symbols { get; }

        public Symbol()
        {

            Symbols = _symbolsSet;
        
        }

    }
}
