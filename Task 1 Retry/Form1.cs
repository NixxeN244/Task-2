using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1_Retry
{
    public partial class Form1 : Form
    {
        GameEngine gameEngine = new GameEngine();
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameMapUILbl.Text = gameEngine.ToString();
            PlayerStatsLbl.Text = gameEngine.PlayerStatsString();
            EnemyListbox.Items.AddRange(gameEngine.GmMap.EnemeyArray);
        }

        private void Upbtn_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Up);
            GameMapUILbl.Text = gameEngine.ToString();
            PlayerStatsLbl.Text = gameEngine.PlayerStatsString();
            
           // EnemyListbox.Items.Add(gameEngine.Map.EnemeyArray[0]);
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Right);
            GameMapUILbl.Text = gameEngine.ToString();
            PlayerStatsLbl.Text = gameEngine.PlayerStatsString();
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Down);
            GameMapUILbl.Text = gameEngine.ToString();
            PlayerStatsLbl.Text = gameEngine.PlayerStatsString();
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.Left);
            GameMapUILbl.Text = gameEngine.ToString();
            PlayerStatsLbl.Text = gameEngine.PlayerStatsString();
        }

        private void AttackBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void EnemyListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
