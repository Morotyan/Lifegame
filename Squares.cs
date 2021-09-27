using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lifegame
{
    public partial class Squares {

        //public static Point startPos, EndPos;

        public static int width = 5;
        public static int height = 5;
        public static int[,] square;//14884

        public static void square0()
        {
            square = new int[14885, 12];//個数1多いが14884番を使いたい

            for (int i = 1; i < 14885; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    square[i, j] = 0;
                }
            }
        }

        //[～,1,2,3,4,5,6,7,8]上～右回りで左上まで　　
        //上　　　　　　　ひとまとめにできるが今のところ別々で。
        public static void nextU()//14642
        {
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    square[j, 1] = j - 122;
                }
            }
        }
        //右上
        public static void nextMU()//14642
        {
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    square[j, 2] = j - 122+1;
                }
            }
        }
        //右
        public static void nextM()//14642
        {
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    square[j, 3] = j + 1;
                }
            }
        }//右下
        public static void nextMS()//14642
        {
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    square[j, 4] = j + 122 + 1;
                }
            }
        }//下
        public static void nextS()//14642
        {
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    square[j, 5] = j + 122;
                }
            }
        }//左下
        public static void nextHS()//14642
        {
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    square[j, 6] = j + 122 - 1;
                }
            }
        }//左
        public static void nextH()//14642
        {
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    square[j, 7] = j - 1;
                }
            }
        }//左上
        public static void nextHU()//14642
        {
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    square[j, 8] = j - 122-1;
                }
            }
        }
        
        //各スクウェアの左上座標を求める
        public static void zahyou()
        {
            //int k = 0;int l = 0;
            for (int i = 124; i <= 14642; i += 122)
            {
                //k++;
                for (int j = i; j <= i + 119; j++)
                {
                    // X          L  ->  124 246 368
                    //先頭の番号をしっておく必要あり。
                    //l = 124 + (k - 1) * 122;
                    square[j, 9] = (j - i) * width;
                   // square[j, 9] = (j - l) * width;
                   
                    //Y
                    square[j, 10] =((i-2)/122-1)*height;
                    //Console.WriteLine(square[j, 9].ToString()+","+ square[j, 10]);
                }
            }
        }

        public static void setting()
        {
            Random r = new System.Random();
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    Squares.square[j, 0] = r.Next(0,2); 
                }
            }



            Squares.square[400, 0] = 1;
            Squares.square[401, 0] = 1;
            Squares.square[402, 0] = 1;
            
            Squares.square[1900, 0] = 1;
            Squares.square[1901, 0] = 1;
            Squares.square[1902, 0] = 1;

            Squares.square[14400, 0] = 1;
            Squares.square[14401, 0] = 1;
            Squares.square[14402, 0] = 1;

            Squares.square[8400, 0] = 1;
            Squares.square[8401, 0] = 1;
            Squares.square[8402, 0] = 1;

            Squares.square[4500, 0] = 1;
            Squares.square[4501, 0] = 1;
            Squares.square[4500-122, 0] = 1;
            Squares.square[4501-122, 0] = 1;
        }

    }

}

