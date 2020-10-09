using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
    class Map
    {
        private Random randomNum = new Random();
        private EmptyTile emptile;

        public Goblin Goblin { get; set; }
        public Tile[,] GameMap { get; set; }

        public Hero PlayerObj { get; set; }

        public Enemy[] EnemeyArray { get; set; }

        public int MapWidth { get; set; }
        public int MapHeight { get; set; }



        public Map(int minwidth, int maxwidth, int minheight, int maxheight, int numofenemies)
        {
            MapWidth = randomNum.Next(minwidth, maxwidth);
            MapHeight = randomNum.Next(minheight, maxheight);
            GameMap = new Tile[MapWidth, MapHeight];
            EnemeyArray = new Enemy[numofenemies];

            for (int i = 0; i < GameMap.GetLength(0); i++)  //Creating of empty tiles so that TIles exisit within the class
            {
                for (int k = 0; k < GameMap.GetLength(1); k++)
                {
                    GameMap[i, k] = new EmptyTile(i, k);
                }
            }

            for (int i = 0; i < GameMap.GetLength(0); i++)  //for loop that creates and palces the border on the top and bottom of the map
            {

                GameMap[i, 0] = new ObstacleSubClass(i, 0); //assiging the top of the map with Obstacles or "X"
                GameMap[i, MapHeight - 1] = new ObstacleSubClass(i, MapHeight - 1); //assigning the bottom of the map with Obstacles or "X"
            }


            for (int i = 0; i < GameMap.GetLength(1); i++)
            {
                GameMap[0, i] = new ObstacleSubClass(0, i);   //assiging Obstacle to the left of the map "X"
                GameMap[MapWidth - 1, i] = new ObstacleSubClass(MapWidth - 1, i);    //assigning Obstacles to the right of the map as "X"
            }


            Create(Tile.TileType.Hero); //Method that creats/intializes the Hero object
            do
            {
                PlayerObj.Xvalue = randomNum.Next(1, MapWidth - 1);
                PlayerObj.Yvalue = randomNum.Next(1, MapHeight - 1);
            } while (GameMap[PlayerObj.Xvalue, PlayerObj.Yvalue].GetType() != typeof(EmptyTile));

            PlaceObject(PlayerObj);


            //looping through an creating the enemies that will be stored within the Enemy Array
            for (int i = 0; i < EnemeyArray.Length; i++)
            {
                EnemeyArray[i] = (Enemy)Create(Tile.TileType.Enemey);
            }
            foreach (var Goblin in EnemeyArray)
            {
                do
                {
                    Goblin.Xvalue = randomNum.Next(1, MapWidth - 1);
                    Goblin.Yvalue = randomNum.Next(1, MapHeight - 1);
                } while (GameMap[Goblin.Xvalue, Goblin.Yvalue].GetType() != typeof(EmptyTile));
                PlaceObject(Goblin);
            }

            IntializePlayerVision();
        }

        public void IntializePlayerVision()
        {
            for (int i = 0; i < PlayerObj.Char_vision.Length; i++)
            {
                PlayerObj.Char_vision[i] = new EmptyTile(PlayerObj.Xvalue, PlayerObj.Yvalue);
            }
        }
        public void MapUpdate()
        {
            for (int i = 0; i < GameMap.GetLength(0); i++)  //Creating of empty tiles so that TIles exisit within the class
            {
                for (int k = 0; k < GameMap.GetLength(1); k++)
                {
                    GameMap[i, k] = new EmptyTile(i, k);
                }
            }

            for (int i = 0; i < GameMap.GetLength(0); i++)  //for loop that creates and palces the border on the top and bottom of the map
            {

                GameMap[i, 0] = new ObstacleSubClass(i, 0); //assiging the top of the map with Obstacles or "X"
                GameMap[i, MapHeight - 1] = new ObstacleSubClass(i, MapHeight - 1); //assigning the bottom of the map with Obstacles or "X"
            }

            for (int i = 0; i < GameMap.GetLength(1); i++)
            {
                GameMap[0, i] = new ObstacleSubClass(0, i);   //assiging Obstacle to the left of the map "X"
                GameMap[MapWidth - 1, i] = new ObstacleSubClass(MapWidth - 1, i);    //assigning Obstacles to the right of the map as "X"
            }


            for (int i = 0; i < EnemeyArray.Length; i++)
            {
                GameMap[EnemeyArray[i].Xvalue, EnemeyArray[i].Yvalue] = EnemeyArray[i];
            }
         
            GameMap[PlayerObj.Xvalue, PlayerObj.Yvalue] = PlayerObj;

        }

        public void UpdateVision()
        {

            PlayerObj.Char_vision[0] = GameMap[PlayerObj.Xvalue, PlayerObj.Yvalue];  //the pos where the player is at that moment
            PlayerObj.Char_vision[1] = GameMap[PlayerObj.Xvalue + 1, PlayerObj.Yvalue]; //To the right of the player 
            PlayerObj.Char_vision[2] = GameMap[PlayerObj.Xvalue, PlayerObj.Yvalue + 1]; //Down from the player
            PlayerObj.Char_vision[3] = GameMap[PlayerObj.Xvalue - 1, PlayerObj.Yvalue]; //Left of the player
            PlayerObj.Char_vision[4] = GameMap[PlayerObj.Xvalue, PlayerObj.Yvalue - 1]; //top of the player


            for (int k = 0; k < EnemeyArray.Length; k++)
            {
                EnemeyArray[k].Char_vision[k] = new EmptyTile(EnemeyArray[k].Xvalue, EnemeyArray[k].Yvalue);

                EnemeyArray[k].Char_vision[k] = GameMap[EnemeyArray[k].Xvalue, EnemeyArray[k].Yvalue]; //the pos where the enemy is
                EnemeyArray[k].Char_vision[k] = GameMap[EnemeyArray[k].Xvalue + 1, EnemeyArray[k].Yvalue]; // the right if the pos of the enemy
                EnemeyArray[k].Char_vision[k] = GameMap[EnemeyArray[k].Xvalue, EnemeyArray[k].Yvalue + 1]; //down from the pos of the enemy
                EnemeyArray[k].Char_vision[k] = GameMap[EnemeyArray[k].Xvalue - 1, EnemeyArray[k].Yvalue]; //the left of the pos of the enenmy
                EnemeyArray[k].Char_vision[k] = GameMap[EnemeyArray[k].Xvalue, EnemeyArray[k].Yvalue - 1]; //the top of the enemy pos
            };
        }



        private Tile Create(Tile.TileType type) //A method that creates AND randomly places objects onto the map TIle
        {
            switch (type)
            {
                case Tile.TileType.Hero:
                    PlayerObj = new Hero(randomNum.Next(1, MapWidth), randomNum.Next(1, MapHeight), 5, 5);
                    return PlayerObj;
                //This will return the Hero object. (which would be the player).

                case Tile.TileType.Enemey:
                    Goblin = new Goblin(randomNum.Next(1, MapWidth - 1), randomNum.Next(1, MapHeight - 1));
                    //this pathway will return the enemy, which is the Goblin from the Goblin class.
                    return Goblin;
                case Tile.TileType.Gold:
                    return null;
                case Tile.TileType.Weapon:
                    return null;
                default:
                    return null;
            }
        }

        public void PlaceObject(Tile obj)
        {
            GameMap[obj.Xvalue, obj.Yvalue] = obj;

        }
    }
}
