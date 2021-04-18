﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    public partial class Form1 : Form
    {
        private Game game = new Game();

        //private bool isBlack = true;  //判斷是否要下黑棋，並且寫一段程序改變bool值
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlacePiece(e.X,e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);
                game.GetWinner();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

        }
    }
}
