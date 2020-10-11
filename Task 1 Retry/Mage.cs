using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
    class Mage:Enemy
    {
        public Mage(int X, int Y) : base(X,Y, 10,10, 5, 'M')
        {

        }

        public override Movement ReturnMove(Movement move = Movement.No_movement)
        {
            return move;
        }

        public override bool CheckRange(Character target)
        {
            if (Math.Abs()
            {

            }
        }
    }
}
