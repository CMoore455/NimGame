using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim.Models
{
    public class Game
    {
        public int Rows { get; set; }
        public int CurrentRow { get; set; }
        public int MyProperty { get; set; }
        //Players array
        //Board class
        public int CurrentPlayerGoingIndex { get; set; }
    }
}
