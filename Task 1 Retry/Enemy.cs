using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
   abstract class Enemy :Character
    {
        //commit changes
        protected Random randomobj;

        public Random Randomobj
        {
            get { return randomobj; }
            set { randomobj = value; }
        }

        public Enemy(int Xvalue, int Yvalue,int HP, int max_HP, int Enemy_dmage, char symbol) : base(Xvalue, Yvalue, symbol)
        {
            this.HP = HP;
            this.Max_HP = max_HP;
            this.Damage = Enemy_dmage;
        }

        public override string ToString()   //override method that returns a string that shows the enemy type, it X and Y values as well as it's damage
        {
            return string.Format(this.GetType() + " at " + "[" + this.Xvalue + "," + this.Yvalue + "]" + " (with " + this.Damage + " Damge)");
        }
    }

    class Goblin : Enemy
    {

        public Goblin(int Xvalue, int Yvalue) : base(Xvalue, Yvalue,10, 10, 1, 'G')    //A basic subclass that takes info from the enemy class
        {


        }

        public override Movement ReturnMove(Movement move)   //movement of the Goblin class 
        {
            switch (move)
            {
                case Movement.No_movement:
                    return Movement.No_movement;
                    
                case Movement.Up:
                    return Movement.Up;
                    
                case Movement.Down:
                    return Movement.Down;
                    
                case Movement.Left:
                    return Movement.Left;
                    
                case Movement.Right:
                    return Movement.Right;
                    
                default:
                    return Movement.No_movement;
            }
        }
    }
}
