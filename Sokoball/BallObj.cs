using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoball
{
    class BallObj : Character
    {

        public BallObj(int row, int col)
        {
            this.currentRow = row;
            this.currentColumn = col;
        }
    }
}
