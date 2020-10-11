using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
    class Gold : Item   //class that the player can pick up
    {

        private int goldAmount;
        private Random randomAmount = new Random();
        public Gold(int X, int Y) : base(X, Y)  //gold constructor 
        {
            GoldAmount = randomAmount.Next(1, 6);   //randomizes the gold amount by 1 to 5
        }

        public int GoldAmount
        {
            get { return goldAmount; }
            set { goldAmount = value; }
        }

        public override string ToString() //returns the type of item, in this case, it will be "Gold" item
        {
            return Convert.ToString(GetType());
        }
    }
}
