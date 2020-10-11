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
            return string.Format(this.GetType().Name + " at " + "[" + this.Xvalue + "," + this.Yvalue + "]" + " (with " + this.Damage + " Damge)");
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
                    if (char_vision[4].GetType() == typeof(EmptyTile))  //Goblin will move up if there is an wmpty slot
                    {
                        return Movement.Up;
                    }
                    else
                    {
                        return Movement.No_movement;
                    }
                    
                    
                case Movement.Down:
                    if (char_vision[2].GetType() ==typeof(EmptyTile))   //goblin will down if there is an empty tile
                    {
                        return Movement.Down;
                    }
                    else
                    {
                        return Movement.No_movement;
                    }
                    
                case Movement.Left:
                    if (char_vision[3].GetType() == typeof(EmptyTile)) // Goblin will move left if there is an empty tile
                    {
                        return Movement.Left;
                    }
                    else
                    {
                        return Movement.No_movement;
                    }
                    
                case Movement.Right:
                    if (char_vision[1].GetType() == typeof(EmptyTile))  //Goblin will move right if there is an empty tile
                    {
                        return Movement.Right;
                    }
                    else
                    {
                        return Movement.No_movement;
                    }
                    
                default:
                    return Movement.No_movement;
            }
        }
    }
}
