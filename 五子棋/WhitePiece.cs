using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class WhitePiece : Piece
    {
        public WhitePiece(int x, int y) : base(x, y)   //基底類別有設定建構子，需要傳入對應的數值
        {
            this.Image = Properties.Resources.white;
        }

        public override PieceType getPieceType()
        {
            return PieceType.WHITE;
        }
    }
}
