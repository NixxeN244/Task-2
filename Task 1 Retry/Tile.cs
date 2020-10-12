using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
   abstract class Tile
    {
        protected int x;    //this value is a protected field   Ghost commit.
        protected int y;    //this value is a protected filed

        public int Xvalue   //this accessor is a PROPERTY of this class for the x value.
        {
            get { return x; }
            set { x = value; }
        }

        public int Yvalue //this accessor is a PROPRTTY of this class for the y value.
        {
            get { return y; }
            set { y = value; }
        }

        public enum TileType    //enums members are denoted as an int "type". starting from 0 and increasing by 1 for each member. Ghost commit for the Tile enum type
        {
            Hero,   // TileType.Hero = 0. meaning this int value member will be 0.
            Goblin, //TileType.Enemy = 1. meaning this int value member will be 1
            Mage,
            Gold,   //TileType.Gold = 2.
            Weapon  //TileType.Weapon =3. 
        }

        public Tile(int X, int Y) //Constructor for this base class that sets the parameters to the properties of the class.
        {
            X = 0;
            Y = 0;
            Xvalue = X;
            Yvalue = Y;
        }

    }

    class ObstacleSubClass : Tile   //class that inherits from the Tile class Ghost commit on the Obs class
    {
        public ObstacleSubClass(int X, int Y) : base(X, Y)
        {
            //this constructor is mainly going to be used to border our map.
            //Hence the Obstacle Name.
        }
    }

    class EmptyTile : Tile
    {
        public EmptyTile(int X, int Y) : base(X, Y)
        { }

    }
}
