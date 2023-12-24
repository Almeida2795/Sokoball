using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoball
{
    internal class GoalObj : Character
    {
        public GoalObj(int row, int col)
        {
            this.currentColumn = col;
            this.currentRow = row;
        }
    }
}
