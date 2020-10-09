using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
  abstract class Character : Tile
    {
        protected int hP;   //the field that contains the Character's Health
        protected int max_HP; //the field that contains the Character's max Heath.
        protected int damage;
        protected Tile[] char_vision = new Tile[5];


        public Character(int X, int Y, char symbol) : base(X, Y)
        {

        }

        public int HP
        {
            get { return hP; }
            set { hP = value; }
        }

        public int Max_HP
        {
            get { return max_HP; }
            set { max_HP = value; }
        }

        public int Damage   //the accessor for the character's damage value. 
        {
            get { return damage; }
            set { damage = value; }
        }

        public Tile[] Char_vision   //the accessor for the array that is a tile. The elements in the array will say what is in the charater's vision
        {
            get { return char_vision; }
            set { char_vision = value; }
        }
        public enum Movement    //an enum that is similiar to the tile class. Where each member is denoted with an int value.
        {
            No_movement,    //Movement.No_Movement =0;
            Up,             //Movement.Up = 1;
            Down,           //
            Left,
            Right
        }
        public virtual void Attack(Character target)
        {
            target.HP = target.HP - this.Damage;
        }
        public bool IsDead()
        {
            if (this.HP >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public virtual bool CheckRange(Character target)    //A method that basically checks to see if the intened target is in range of this character
        {
            if (DistanceTo(target) <= 1)
            {
                return true;
                //returns true if the intended target is within range
            }
            else
            {
                return false;
                //returns false if the target is out of range
            }
        }

        private int DistanceTo(Character target)
        {
            int distance = (this.Xvalue - target.Xvalue) + (this.Yvalue - target.Yvalue);   //this returns a value that is between the character and the target.
            /*example:
                this.Xvalue = 1     target.Xvalue = 2   this.Yvalue = 0     target.Yvale = 3
                distance = (1-2) + (0-3)
                distance = -1 -3 = -4 
                this value needs to be positive for us to use properly
             */

            int absoluteVal = Math.Abs(distance);    //the absolute method returns 
            return absoluteVal;
        }

        public void Move(Movement move)
        {   //this method moves the charater based on which option the player chooses to do
            switch (move)
            {
                case Movement.No_movement:  //this would be 0. so no movement 
                    this.Xvalue = this.Xvalue;
                    this.Yvalue = this.Yvalue;
                    break;
                case Movement.Up:       //this would be 1, so they go up.
                    this.Xvalue = this.Xvalue;
                    this.Yvalue = this.Yvalue - 1;
                    break;
                case Movement.Down:     //this would be 2. so they go down.
                    this.Xvalue = this.Xvalue;
                    this.Yvalue = this.Yvalue + 1;
                    break;
                case Movement.Left:     //this would be 3. so they go left.
                    this.Xvalue = this.Xvalue - 1;
                    this.Yvalue = this.Yvalue;
                    break;
                case Movement.Right:    //this would be 4. so they go right.
                    this.Xvalue = this.Xvalue + 1;
                    this.Yvalue = this.Yvalue;
                    break;
                default:
                    break;
            }
        }

        public abstract Movement ReturnMove(Movement move = 0);

        public abstract override string ToString();
    }
}
