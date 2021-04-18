using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    class Game     //一般遊戲相關的程式碼會放在這裡，要有良好的分類
    {
        public PieceType currentPlayer = PieceType.BLACK;

        private Board board = new Board();

        private PieceType Winner = PieceType.NONE;

        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }


        public Piece PlacePiece(int x, int y)         //由game類別來管理所有遊戲相關設定，form只留下顯示與互動的程式
        {
            Piece piece = board.PlacePiece(x, y, currentPlayer);
            if (piece != null)
            {
                //先檢查是否現在下棋的人獲勝

                CheckWinner();

                //交換選手
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else
                    currentPlayer = PieceType.BLACK;

                return piece;
            }

            return null;
        }

            /*  因為此程式碼有重複的程式，所以可以簡化合併為上面的\
            
            if(isBlack)
            {
                Piece piece = board.PlacePiece(e.X, e.Y, PieceTypy.BLACK);
                if(piece != null)
                {
                    this.Controls.Add(piece);
                    isBlack = false;
                }
            }
            else
            {
                Piece piece = board.PlacePiece(e.X, e.Y, PieceTypy.WHITE);
                if (piece != null)
                {
                    this.Controls.Add(piece);
                    isBlack = true;
                }
            }
            */
        public void CheckWinner()
        {
            int CenterX = board.LastPlaced.X;
            int CenterY = board.LastPlaced.Y;

            




            for(int yDir = -1; yDir<=1; yDir++)
            {
                for (int xDir = -1; xDir <= 1; xDir++)
                {
                    int count1 = 1;
                    int count2 = 1;
                    int count = count1 + count2 - 1;
                    int findback = 0;

                    if (yDir == 0 & xDir == 0  || findback==2)
                        break;
                    


                    while (findback != 2 & count <= 5) 
                    {
                        switch (findback)
                        {
                            case 0:
                                int targetX = CenterX + count1* xDir;
                                int targetY = CenterY + count1* yDir;
                                //檢查顏色是否相同
                                if (targetX >= 9 ||
                                    targetX < 0 ||
                                    targetY >= 9 ||
                                    targetY < 0 ||
                                    board.GetPieceType(targetX, targetY) != currentPlayer)
                                {
                                    findback = 1;
                                }
                                else
                                {
                                    count1++;
                                    count = count1 + count2 - 1;
                                }
                                break;
                            case 1:
                                targetX = CenterX - count2 * xDir;
                                targetY = CenterY - count2 * yDir;
                                //檢查顏色是否相同
                                if (targetX >= 9 ||
                                    targetX < 0 ||
                                    targetY >= 9 ||
                                    targetY < 0 ||
                                    board.GetPieceType(targetX, targetY) != currentPlayer)
                                {
                                    findback = 2;
                                }
                                else
                                {
                                    count2++;
                                    count = count1 + count2 - 1;
                                }
                                break;
                            default:
                                findback = 2;
                                break;
                        }
                        //檢查是否五子連線
                        count = count1 + count2 - 1;
                        if (count == 5)
                        {
                            Winner = currentPlayer;
                        }
                    }
                }
            }
            

            
                    
        }

        public void  GetWinner()
        {
            
            switch (Winner)
            {
                case PieceType.BLACK:
                    MessageBox.Show("黑棋勝");
                    break;
                case PieceType.WHITE:
                    MessageBox.Show("白棋勝");
                    break;
                default:
                    break;
                

            }
        }

    }
}
