using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
    class Gold : Item
    {

        private int goldAmount;
        private Random randomAmount = new Random();
        public Gold(int X, int Y) : base(X, Y)
        {
            GoldAmount = randomAmount.Next(1, 6);
        }

        public int GoldAmount
        {
            get { return goldAmount; }
            set { goldAmount = value; }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
