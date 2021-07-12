using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDataStorage__XO_
{
    public partial class Form1 : Form
    {
        class ActorPlane
        {
            public int SX, SY, EX, EY;
        }

        class BitMapActors
        {
            public Bitmap Image;
            public int x, y;
            public String Type;
            public int Pos;
        }

        List<ActorPlane> LPlane = new List<ActorPlane>();
        int Player = 1;
        List<BitMapActors> LX = new List<BitMapActors>();
        List<BitMapActors> LO = new List<BitMapActors>();


        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MouseDown += Form1_MouseDown;
            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreatePlane();
            DrawScene(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Player == 1)
                {
                    int flagFirstC = 0;
                    int flagMiddleC = 0;
                    int flagLastC = 0;

                    int flagFirstR = 0;
                    int flagMiddleR = 0;
                    int flagLastR = 0;

                    BitMapActors pnn = new BitMapActors();
                    pnn.Image = new Bitmap("X.png");

                    if (e.Y < 300)
                    {
                        pnn.y = 300 - pnn.Image.Height;
                        flagFirstR = 1;
                    }
                    else if (e.Y > 300 && e.Y < 500)
                    {
                        pnn.y = 500 - pnn.Image.Height;
                        flagMiddleR = 1;
                    }
                    else if (e.Y > 500)
                    {
                        pnn.y = 500 + pnn.Image.Height;
                        flagLastR = 1;
                    }


                    if (e.X < 500)
                    {
                        pnn.x = 500 - pnn.Image.Width;
                        flagFirstC = 1;
                    }
                    else if (e.X > 500 && e.X < 1000)
                    {
                        pnn.x = 1000 - pnn.Image.Width;
                        flagMiddleC = 1;
                    }
                    else if (e.X > 1000)
                    {
                        pnn.x = 1000 + pnn.Image.Width;
                        flagLastC = 1;
                    }

                    if (flagFirstR == 1)
                    {
                        if (flagFirstC == 1)
                        {
                            pnn.Pos = 1;
                        }

                        if (flagMiddleC == 1)
                        {
                            pnn.Pos = 2;
                        }

                        if (flagLastC == 1)
                        {
                            pnn.Pos = 3;
                        }
                    }
                    else if (flagMiddleR == 1)
                    {
                        if (flagFirstC == 1)
                        {
                            pnn.Pos = 4;
                        }

                        if (flagMiddleC == 1)
                        {
                            pnn.Pos = 5;
                        }

                        if (flagLastC == 1)
                        {
                            pnn.Pos = 6;
                        }
                    }
                    else if (flagLastR == 1)
                    {
                        if (flagFirstC == 1)
                        {
                            pnn.Pos = 7;
                        }

                        if (flagMiddleC == 1)
                        {
                            pnn.Pos = 8;
                        }

                        if (flagLastC == 1)
                        {
                            pnn.Pos = 9;
                        }
                    }


                    pnn.Type = "X";
                    LX.Add(pnn);
                    Player = 2;
                }
                else if (Player == 2)
                {
                    int flagFirstC = 0;
                    int flagMiddleC = 0;
                    int flagLastC = 0;

                    int flagFirstR = 0;
                    int flagMiddleR = 0;
                    int flagLastR = 0;

                    BitMapActors pnn = new BitMapActors();
                    pnn.Image = new Bitmap("O.png");

                    if (e.Y < 300)
                    {
                        pnn.y = 300 - pnn.Image.Height;
                        flagFirstR = 1;
                    }
                    else if (e.Y > 300 && e.Y < 500)
                    {
                        pnn.y = 500 - pnn.Image.Height;
                        flagMiddleR = 1;
                    }
                    else if (e.Y > 500)
                    {
                        pnn.y = 500 + pnn.Image.Height;
                        flagLastR = 1;
                    }


                    if (e.X < 500)
                    {
                        pnn.x = 500 - pnn.Image.Width;
                        flagFirstC = 1;
                    }
                    else if (e.X > 500 && e.X < 1000)
                    {
                        pnn.x = 1000 - pnn.Image.Width;
                        flagMiddleC = 1;
                    }
                    else if (e.X > 1000)
                    {
                        pnn.x = 1000 + pnn.Image.Width;
                        flagLastC = 1;
                    }

                    if (flagFirstR == 1)
                    {
                        if (flagFirstC == 1)
                        {
                            pnn.Pos = 1;
                        }

                        if (flagMiddleC == 1)
                        {
                            pnn.Pos = 2;
                        }

                        if (flagLastC == 1)
                        {
                            pnn.Pos = 3;
                        }
                    }
                    else if (flagMiddleR == 1)
                    {
                        if (flagFirstC == 1)
                        {
                            pnn.Pos = 4;
                        }

                        if (flagMiddleC == 1)
                        {
                            pnn.Pos = 5;
                        }

                        if (flagLastC == 1)
                        {
                            pnn.Pos = 6;
                        }
                    }
                    else if (flagLastR == 1)
                    {
                        if (flagFirstC == 1)
                        {
                            pnn.Pos = 7;
                        }

                        if (flagMiddleC == 1)
                        {
                            pnn.Pos = 8;
                        }

                        if (flagLastC == 1)
                        {
                            pnn.Pos = 9;
                        }
                    }


                    pnn.Type = "O";
                    LO.Add(pnn);
                    Player = 1;
                }
            }
            DrawScene(this.CreateGraphics());
            CheckWinSituation();
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
            for (int i = 0; i < LPlane.Count; i++)
            {
                g.DrawLine(Pens.Black, LPlane[i].SX, LPlane[i].SY, LPlane[i].EX, LPlane[i].EY);
            }

            for (int i = 0; i < LO.Count; i++)
            {
                g.DrawImage(LO[i].Image, LO[i].x, LO[i].y);
            }

            for (int i = 0; i < LX.Count; i++)
            {
                g.DrawImage(LX[i].Image, LX[i].x, LX[i].y);
            }
        }

        void CreatePlane()
        {
            ActorPlane pnn = new ActorPlane();
            pnn.SX = 500;
            pnn.EX = 500;
            pnn.SY = 50;
            pnn.EY = 700;
            LPlane.Add(pnn);

            pnn = new ActorPlane();
            pnn.SX = 1000;
            pnn.EX = 1000;
            pnn.SY = 50;
            pnn.EY = 700;
            LPlane.Add(pnn);

            pnn = new ActorPlane();
            pnn.SX = 100;
            pnn.EX = 1500;
            pnn.SY = 300;
            pnn.EY = 300;
            LPlane.Add(pnn);

            pnn = new ActorPlane();
            pnn.SX = 100;
            pnn.EX = 1500;
            pnn.SY = 500;
            pnn.EY = 500;
            LPlane.Add(pnn);
        }

        void CheckWinSituation()
        {
            CheckDiagonal();
            CheckHorizantel();
            CheckVirtecal();
        }

        void CheckVirtecal()
        {
            int counter = 0;

            for (int i = 0; i < LX.Count; i++)
            {
                if (LX[i].Pos == 1)
                {
                    counter++;
                }
                else if (LX[i].Pos == 4)
                {
                    counter++;
                }
                else if (LX[i].Pos == 7)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 1 Won");
            }

            counter = 0;

            for (int i = 0; i < LX.Count; i++)
            {
                if (LX[i].Pos == 2)
                {
                    counter++;
                }
                else if (LX[i].Pos == 5)
                {
                    counter++;
                }
                else if (LX[i].Pos == 8)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 1 Won");
            }


            counter = 0;

            for (int i = 0; i < LX.Count; i++)
            {
                if (LX[i].Pos == 3)
                {
                    counter++;
                }
                else if (LX[i].Pos == 6)
                {
                    counter++;
                }
                else if (LX[i].Pos == 9)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 1 Won");
            }


            counter = 0;

            for (int i = 0; i < LO.Count; i++)
            {
                if (LO[i].Pos == 1)
                {
                    counter++;
                }
                else if (LO[i].Pos == 4)
                {
                    counter++;
                }
                else if (LO[i].Pos == 7)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 2 Won");
            }

            counter = 0;

            for (int i = 0; i < LO.Count; i++)
            {
                if (LO[i].Pos == 2)
                {
                    counter++;
                }
                else if (LO[i].Pos == 5)
                {
                    counter++;
                }
                else if (LO[i].Pos == 8)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 2 Won");
            }

            counter = 0;

            for (int i = 0; i < LO.Count; i++)
            {
                if (LO[i].Pos == 3)
                {
                    counter++;
                }
                else if (LO[i].Pos == 6)
                {
                    counter++;
                }
                else if (LO[i].Pos == 9)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 2 Won");
            }
        }

        void CheckHorizantel()
        {
            int counter = 0;

            for (int i = 0; i < LX.Count; i++)
            {
                if (LX[i].Pos == 1)
                {
                    counter++;
                }
                else if (LX[i].Pos == 2)
                {
                    counter++;
                }
                else if (LX[i].Pos == 3)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 1 Won");
            }

            counter = 0;

            for (int i = 0; i < LX.Count; i++)
            {
                if (LX[i].Pos == 4)
                {
                    counter++;
                }
                else if (LX[i].Pos == 5)
                {
                    counter++;
                }
                else if (LX[i].Pos == 6)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 1 Won");
            }


            counter = 0;

            for (int i = 0; i < LX.Count; i++)
            {
                if (LX[i].Pos == 7)
                {
                    counter++;
                }
                else if (LX[i].Pos == 8)
                {
                    counter++;
                }
                else if (LX[i].Pos == 9)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 1 Won");
            }


            counter = 0;

            for (int i = 0; i < LO.Count; i++)
            {
                if (LO[i].Pos == 1)
                {
                    counter++;
                }
                else if (LO[i].Pos == 2)
                {
                    counter++;
                }
                else if (LO[i].Pos == 3)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 2 Won");
            }

            counter = 0;

            for (int i = 0; i < LO.Count; i++)
            {
                if (LO[i].Pos == 4)
                {
                    counter++;
                }
                else if (LO[i].Pos == 5)
                {
                    counter++;
                }
                else if (LO[i].Pos == 6)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 2 Won");
            }

            counter = 0;

            for (int i = 0; i < LO.Count; i++)
            {
                if (LO[i].Pos == 7)
                {
                    counter++;
                }
                else if (LO[i].Pos == 8)
                {
                    counter++;
                }
                else if (LO[i].Pos == 9)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 2 Won");
            }
        }

        void CheckDiagonal()
        {
            int counter = 0;

            for (int i = 0; i < LX.Count; i++)
            {
                if (LX[i].Pos == 1)
                {
                    counter++;
                }
                else if (LX[i].Pos == 5)
                {
                    counter++;
                }
                else if (LX[i].Pos == 9)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 1 Won");
            }

            counter = 0;

            for (int i = 0; i < LX.Count; i++)
            {
                if (LX[i].Pos == 3)
                {
                    counter++;
                }
                else if (LX[i].Pos == 5)
                {
                    counter++;
                }
                else if (LX[i].Pos == 7)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 1 Won");
            }


            counter = 0;

            for (int i = 0; i < LO.Count; i++)
            {
                if (LO[i].Pos == 1)
                {
                    counter++;
                }
                else if (LO[i].Pos == 4)
                {
                    counter++;
                }
                else if (LO[i].Pos == 9)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 2 Won");
            }

            counter = 0;

            for (int i = 0; i < LO.Count; i++)
            {
                if (LO[i].Pos == 3)
                {
                    counter++;
                }
                else if (LO[i].Pos == 5)
                {
                    counter++;
                }
                else if (LO[i].Pos == 7)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                MessageBox.Show("Player 2 Won");
            }
        }
    }
}
