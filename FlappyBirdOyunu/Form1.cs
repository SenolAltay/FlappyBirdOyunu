using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;  
namespace FlappyBirdOyunu
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        int playerScore = 0;
        int playerSpeed = 10;
        int playerGravity = 5;
        

        private void gamekeyisdown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode==Keys.Space)
            {
                playerGravity =  -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.Space)
            {
                playerGravity =  +5;
            }
        }

        private void gameTimerEvent(object sender, EventArgs eventArgs)
        {
            flappybird.Top += playerGravity;
            boruAlt.Left -= playerSpeed;
            boruUst.Left -= playerSpeed;
            scoretxt.Text  = "Score: " + playerScore;
            if (boruAlt.Left<-25)
            {
                boruAlt.Left = 600;
                playerScore++;
            }
            if (boruUst.Left<-50)
            {
                boruUst.Left = 600;
                
            }
            if (flappybird.Top < -25 || flappybird.Bounds.IntersectsWith(boruUst.Bounds) || flappybird.Bounds.IntersectsWith(boruAlt.Bounds)|| flappybird.Bounds.IntersectsWith(zemin.Bounds))
            {
                endGame();
            }
            //for (int i = 0; i < playerScore; i++)
            //{
            //    playerSpeed = 15;
            //}
            if (playerScore > 5)
            {
                playerSpeed = 15;
            }

        }
        private void endGame()
        {
            gameTimer.Stop();
            gameOverText.Visible = true;     
            scoretxt.Text = "Score: "+playerScore;
        }
    }
}
