using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

        [Serializable]
        class Game
        {
            public Player Player { get; set; }
            public Room[] Rooms { get; set; }

            public Game(Player player, Room[] rooms)
            {
                Player = player;
                Rooms = rooms;
            }
        }
}
