using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
//using System.Drawing.Drawing2D;
//2021年2月9日より2月11日まで（3日間）

namespace Lifegame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Form1クラスのコンストラクタ、一回しか呼び出されない。初期値入れとけ。

            // this.ClientSize = new System.Drawing.Size(600, 600);584,561  messsize+16=sitano_settei_size(600) 

            //プロパティ画面583,630  コンパネ画面リサイズ拡縮125%だと774,786になる。
            //(クライアント)領域の座標値はwidth値-1,height値-1です。

            InitializeComponent();

            this.MinimumSize = new Size(616, 639);//クライアント領域600，600になり。
            this.MaximumSize = new Size(616, 639);
            System.Drawing.Size tSize = this.ClientSize;
            //MessageBox.Show(tSize.ToString());
  
            Squares.square0();
            Squares.nextU();
            Squares.nextMU();
            Squares.nextM();
            Squares.nextMS();
            Squares.nextS();
            Squares.nextHS();
            Squares.nextH();
            Squares.nextHU();
            Squares.zahyou();
            Squares.setting();

        }

        
        //チラツキしないように手動で書くなら。
        /*     protected override void OnPaintBackground(PaintEventArgs e)
               {
                   DoubleBuffered = true;
               }
       */
        //paintいべんと（「再」描画のリクエスト）での呼び出されるイベントハンドラ
        private void ReDraw(object sender, PaintEventArgs e)
        {
            //Color color = ColorTranslator.FromHtml("#330066");
            Color color = Color.RosyBrown;
            SolidBrush brush = new SolidBrush(color);
            SolidBrush brush2 = new SolidBrush(Color.Black);

            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    // SolidBrush brush = new SolidBrush(color);

                    if (Squares.square[j, 0] == 1)
                    {
                        e.Graphics.FillRectangle
                        (brush, Squares.square[j, 9], Squares.square[j, 10],
                        Squares.width, Squares.height);
                    }
                }
            }
            //MessageBox.Show("開始します");

            //周りを調べます
            int kosu;
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    kosu = 0;
                    for (int ii = 1; ii < 9; ii++)
                    {
                        if (Squares.square[(Squares.square[j, ii]), 0] == 1)//[]が示しているのは番地
                        {
                            kosu++;
                            // Console.WriteLine("jは" + j + "  iiは" + ii);
                        }
                    }

                    // Console.WriteLine(j.ToString() + "  個数" + kosu.ToString());

                    /*
                                            if (j == 280)
                                            {
                                                for (int k = 1; k < 9; k++)
                                                {
                                                    Console.WriteLine(j + "," + k + "   " + Squares.square[j, k]);
                                                }
                                            }
                    */
                    //こうしんします

                    //誕生　自分が死、周りちょうど３
                    if (Squares.square[j, 0] == 0 && kosu == 3)
                    {
                        Squares.square[j, 11] = 1;
                        //  Console.WriteLine(j.ToString()+"誕生");
                    }

                    //生存　生きているセルに隣接する生きたセルが２か３
                    if (Squares.square[j, 0] == 1 && (kosu == 2 | kosu == 3))
                    {
                        Squares.square[j, 11] = 1;
                        //   Console.WriteLine(j.ToString() + "生存");
                    }

                    //過疎　自分が生、周り１以下
                    if (Squares.square[j, 0] == 1 && kosu <= 1)
                    {
                        Squares.square[j, 11] = 0;
                        //   Console.WriteLine(j.ToString() + "過疎"+kosu.ToString());
                    }

                    //過密　自分が生、周り4以上
                    if (Squares.square[j, 0] == 1 && kosu >= 4)
                    {
                        Squares.square[j, 11] = 0;
                        //   Console.WriteLine(j.ToString() + "過密");
                    }

                    //Console.WriteLine(j.ToString() + "通過");
                }
            }

            //描画する
            for (int ii = 124; ii <= 14642; ii += 122)
            {
                for (int j = ii; j <= ii + 119; j++)
                {


                    if (Squares.square[j, 11] == 1 && Squares.square[j, 0] == 0)
                    {
                        e.Graphics.FillRectangle
                            (brush, Squares.square[j, 9], Squares.square[j, 10],
                            Squares.width, Squares.height);
                        // Console.WriteLine(j.ToString()+"あり");

                    }
                    else if (Squares.square[j, 11] == 0 && Squares.square[j, 0] == 1)
                    {
                        e.Graphics.FillRectangle
                            (brush2, Squares.square[j, 9], Squares.square[j, 10],
                            Squares.width, Squares.height);
                        // Console.WriteLine(j.ToString()+"なし");
                    }

                }
            }
            //描画が済んだのでRedraw先頭に戻れるように上書き
            for (int i = 124; i <= 14642; i += 122)
            {
                for (int j = i; j <= i + 119; j++)
                {
                    Squares.square[j, 0] = Squares.square[j, 11];
                }
            }

            /*
            for(int i=1; i <= 100; i++)
            {
                i = i * 2;
            }  */
            Application.DoEvents();
            Invalidate();
        
        }//ReDraw()終わり


        //画面上で一度クリックしたあとにAltキーを押してください
        public void FormClicked(object sender, EventArgs e)
            {
                MessageBox.Show("終了する");
                Application.Exit();
            }

    }
}
