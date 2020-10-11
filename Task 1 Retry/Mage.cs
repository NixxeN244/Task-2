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
            if (Math.Abs(target.Yvalue- Yvalue) == 1 && target.Xvalue == Xvalue ) //first postion, which 1 unit to the left of the Mage
            {
                return true;
                
            }
            else if (Math.Abs(target.Yvalue - Yvalue) == 1 && Math.Abs(target.Xvalue - Xvalue) ==1) //second position, which is 1 unit left and 1 unit up fo the mage
            {
                return true;
            }
            else if (target.Yvalue == Yvalue && Math.Abs(target.Xvalue - Xvalue) ==1)
            {
                return true;
            }
            
        }
    }
}
