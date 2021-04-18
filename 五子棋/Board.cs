using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace 五子棋
{
    class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 20;
        private static readonly int NODE_DISTANCE = 75;

        private Point lastPlaced = NO_MATCH_NODE;

        public Point LastPlaced { get { return lastPlaced; } }    //對外面來說就是個唯獨的值


        /*
        [
        命名傳統：public  >第一個字大寫
                  private >第一個字小寫
        ]
        */

        //用二維陣列紀錄是否有棋子
        public Piece[,] piese = new Piece[9, 9]; //9*9棋盤大小

        public bool CanBePlaced(int x, int y)
        {
            ///todo：找出最近節點           //先把要做的事情列出來，再一步步編寫程式
            Point nodeID = FindTheCrossNode(x, y);


            ///如果沒有就回傳 false
            if (nodeID == NO_MATCH_NODE)
                return false;

            ///如果有就檢查是否有棋子存在
            if(piese[nodeID.X,nodeID.Y] != null)
                return false;

            return true;
        }

       

        public Piece PlacePiece(int x, int y,PieceType type)   //判斷是不是可以放棋子，可以就給棋子，不可以就給個null
        {
            ///todo：找出最近節點           //先把要做的事情列出來，再一步步編寫程式
            Point nodeID = FindTheCrossNode(x, y);


            ///如果沒有就回傳 false
            if (nodeID == NO_MATCH_NODE)
            {
                MessageBox.Show("no~這邊不能下喔");
                return null;
            }

            ///如果有就檢查是否有棋子存在
            if (piese[nodeID.X, nodeID.Y] != null)
            {
                MessageBox.Show("搞笑嗎，這裡已經有棋子了");
                return null;
            }

            ///根據type產生白或黑棋
            Point formPosition = converToFormPosition(nodeID);

            if (type == PieceType.BLACK)
                piese[nodeID.X, nodeID.Y] = new BlackPiece(formPosition.X, formPosition.Y);
            else if(type == PieceType.WHITE)
                piese[nodeID.X, nodeID.Y] = new WhitePiece(formPosition.X, formPosition.Y);

            //紀錄最後下棋子的位置
            lastPlaced = nodeID;
            
            return piese[nodeID.X, nodeID.Y];
        }


        private Point FindTheCrossNode(int x, int y)
        {
            int nodeIDX = FindTheCrossNode(x);
            if (nodeIDX == -1)
                return NO_MATCH_NODE;

            int nodeIDY = FindTheCrossNode(y);
            if (nodeIDY == -1)
                return NO_MATCH_NODE;

            return new Point(nodeIDX, nodeIDY);
        }

        private int FindTheCrossNode(int pos)
        {

            if (pos < OFFSET - NODE_RADIUS)
                
                return -1;
            else if (pos> OFFSET+ NODE_DISTANCE*8+ NODE_RADIUS)
                return - 1;
            pos -= OFFSET;


                int quotient = pos / NODE_DISTANCE;  //商數
            int remainder = pos % NODE_DISTANCE;   //餘數

            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;   //定義為沒有符合任何變數
        }


        private Point converToFormPosition(Point nodeID)
        {
            Point formPosition = new Point();
            formPosition.X = nodeID.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeID.Y * NODE_DISTANCE + OFFSET;

            return formPosition;
        }


        public PieceType GetPieceType(int nodeIDX, int nodeIDY)
        {
            if (piese[nodeIDX, nodeIDY] == null)
                return PieceType.NONE;
            else
                return piese[nodeIDX, nodeIDY].getPieceType();
        }

    }
}
