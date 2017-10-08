using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim.PlayerClass
{
    public class Player
    {
        private string playerName;

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private bool isHuman;

        public bool IsHuman
        {
            get { return isHuman; }
            set { isHuman = value; }
        }

        public Player(string name, bool issaHuman)
        {
            PlayerName = name;
            IsHuman = issaHuman;
        }


    }
}
