using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoball
{
    class Character
    {
        public int currentRow { get; set; }
        public int currentColumn { get; set; }

        public Character() { }
        public Character (int row, int col)
        {
            currentRow = row;
            currentColumn = col;
        }
    }
}
