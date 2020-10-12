using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
    class Hero : Character
    {
        public Hero(int X, int Y, int Hero_HP, int Hero_MaxHP) : base(X, Y, 'H')
        {
            HP = Hero_HP;
            Max_HP = Hero_MaxHP;
            Damage = 2;
            Xvalue = X;
            Yvalue = Y;
        }

        public override Movement ReturnMove(Movement move)
        {
            switch (move)
            {
                case Movement.No_movement:

                    return Movement.No_movement;

                case Movement.Up:
                    if (char_vision[4].GetType() == typeof(EmptyTile) | char_vision[4].GetType() == typeof(Item))
                    {
                        return Movement.Up;
                    }
                    else
                    {
                        return Movement.No_movement;
                    }


                case Movement.Down:
                    if (char_vision[2].GetType() == typeof(EmptyTile) | char_vision[2].GetType() == typeof(Item))
                    {
                        return Movement.Down;
                    }
                    else
                    {
                        return Movement.No_movement;
                    }

                case Movement.Left:
                    if (char_vision[3].GetType() == typeof(EmptyTile) | char_vision[3].GetType() == typeof(Item))
                    {
                        return Movement.Left;
                    }
                    else
                    {
                        return Movement.No_movement;
                    }

                case Movement.Right:
                    if (char_vision[1].GetType() == typeof(EmptyTile) | char_vision[1].GetType()==typeof(Item))
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

        public override string ToString()
        {
            return string.Format("Player Stats: \n" + "HP: " + this.HP + "/ " + this.Max_HP + "\n" +
                                    "Damage: " + this.Damage + "\n" + "[" + this.Xvalue + "," + this.Yvalue + "]" + "\n" + "Gold: " + this.Gold_Purse);
        }
    }
}
