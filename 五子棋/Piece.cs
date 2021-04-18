using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;   //要先載入forms 的函式庫，才能使用繼承picturebox
using System.Drawing;

namespace 五子棋
{
    abstract class Piece : PictureBox
    {
        private static readonly int IMAGE_WIDTH = 65;  //確保為常數

        public Piece(int x,int y)
        {
            this.BackColor = Color.Transparent;             //color 型別，遇到沒用過的型別需先查閱
            this.Location = new Point(x- IMAGE_WIDTH/2, y- IMAGE_WIDTH/2);
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
            this.SizeMode =  PictureBoxSizeMode.StretchImage;            
        }


        public abstract PieceType getPieceType();
    }
}
