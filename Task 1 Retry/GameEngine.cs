using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Retry
{
    class GameEngine
    {
        private Map map;
        private static readonly string Hero = "H";
        private static readonly string Goblin = "G";
        private static readonly string Empty = " ";
        private static readonly string Obstacle = "X";
        private static readonly string gold = "$";
        private static readonly string mage = "M";

        

        public GameEngine()
        {
           map = new Map(15, 15, 15, 15, 4, 3);
        }

        public Map GmMap { get { return map; } set { map = value; } }
        
        public string ParseMap { get; set; }
      

        public void MovePlayer(Character.Movement move)
        {
            map.UpdateVision();
            if (map.PlayerObj.ReturnMove(move) == Character.Movement.Up)
            {
                map.PlayerObj.PickupItem(map.GetItemAtPos(map.PlayerObj.Xvalue, map.PlayerObj.Yvalue));
                map.PlayerObj.Move(move);
               
                //Console.WriteLine(map.PlayerObj.ReturnMove(move));
                map.MapUpdate();
            }
            else if (map.PlayerObj.ReturnMove(move) == Character.Movement.Down)
            {
                map.PlayerObj.PickupItem(map.GetItemAtPos(map.PlayerObj.Xvalue, map.PlayerObj.Yvalue));
                map.PlayerObj.Move(move);
              
              //  Console.WriteLine(map.PlayerObj.ReturnMove(move));
                map.MapUpdate();
            }
            else if (map.PlayerObj.ReturnMove(move) == Character.Movement.Left)
            {
                map.PlayerObj.PickupItem(map.GetItemAtPos(map.PlayerObj.Xvalue, map.PlayerObj.Yvalue));
                map.PlayerObj.Move(move);
                
              //  Console.WriteLine(map.PlayerObj.ReturnMove(move));
                map.MapUpdate();
            }
            else if (map.PlayerObj.ReturnMove(move) == Character.Movement.Right)
            {
                map.PlayerObj.PickupItem(map.GetItemAtPos(map.PlayerObj.Xvalue, map.PlayerObj.Yvalue));
                map.PlayerObj.Move(move);
             
             //   Console.WriteLine(map.PlayerObj.ReturnMove(move));
                map.MapUpdate();
            }


        }

        public override string ToString()   //A method that will return the Map array into a string so that we can see it on the form
        {
            string returnString = "";
           for (int k = 0; k < map.GameMap.GetLength(0); k++)
            {
                for (int i = 0; i < map.GameMap.GetLength(1); i++)
                {
                    if (map.GameMap[i,k].GetType() == typeof(EmptyTile))
                    {
                        returnString += Empty; 
                    }
                    else if (map.GameMap[i,k].GetType() == typeof(ObstacleSubClass))
                    {
                        returnString += Obstacle;
                    }
                    else if (map.GameMap[i,k].GetType() == typeof(Hero))
                    {
                        returnString += Hero;
                    }
                    else if (map.GameMap[i,k].GetType() == typeof(Goblin))
                    {
                        returnString += Goblin;
                    }
                    else if (map.GameMap[i,k].GetType() == typeof(Gold))
                    {
                        returnString+= gold;
                    }
                    else if (map.GameMap[i,k].GetType() == typeof(Mage))
                    {
                        returnString += mage;
                    }
                    
                }
                returnString += "\n";
            }
            return returnString;
        }



        public string EnemyStats()
        {
            string returninfo = " ";
            for (int i = 0; i < map.EnemeyArray.Length; i++)
            {
                returninfo += map.EnemeyArray[i].ToString() + "\n";
            }
            return returninfo;
        }
        public string PlayerStatsString()
        {
             return map.PlayerObj.ToString();

        }

    }
}
