using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test3
{
    public partial class Form1 : Form
    {
        const int num_row = 15, num_col = 15;
        Button[,] buttonlist = new Button[num_row, num_col];
        int[,] button_state = new int[num_row, num_col];
        // state - 0:blank;   1:filled;   -1:not filled
        //         0:空白     1:確定要填   -1:確定不填   
        int[,] solution = new int[num_row, num_col];
        int count = 0;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < num_row; i++)
                for (int j = 0; j < num_col; j++)
                    button_state[i,j] = 0;             // initializing all state to 0
            // -testing solution
            for (int i = 0; i < num_row; i++)
                for (int j = 0; j < num_col; j++)
                    solution[i, j] = 0;
            
            for (int j = 0; j < num_col; j++)
                if(j%4 != 3)
                    solution[5, j] = 1;
            for(int i = 5; i<=9; i++)
            {
                solution[i, 1] = 1; solution[i, 4] = 1; solution[i, 13] = 1;
            }
            solution[7, 5] = 1; solution[9, 5] = 1; solution[7, 6] = 1; solution[9, 6] = 1;
            solution[6, 8] = 1; solution[7, 8] = 1; solution[7, 9] = 1; solution[7, 10] = 1;
            solution[8, 10] = 1; solution[9, 10] = 1; solution[9, 9] = 1; solution[9, 8] = 1;


            // solution[0,0] = 1; solution[0,1] = 1; solution[0,2] = 1;
            // testing solution-

            // connecting buttons to list
            buttonlist[0, 0] = a1;  buttonlist[0, 1] = a2;  buttonlist[0, 2] = a3;
            buttonlist[0, 3] = a4;  buttonlist[0, 4] = a5;  buttonlist[0, 5] = a6;
            buttonlist[0, 6] = a7;  buttonlist[0, 7] = a8;  buttonlist[0, 8] = a9;
            buttonlist[0, 9] = a10;  buttonlist[0, 10] = a11;buttonlist[0, 11] = a12;
            buttonlist[0, 12] = a13; buttonlist[0, 13] = a14; buttonlist[0, 14] = a15;

            buttonlist[1, 0] = b1; buttonlist[1, 1] = b2; buttonlist[1, 2] = b3;
            buttonlist[1, 3] = b4; buttonlist[1, 4] = b5; buttonlist[1, 5] = b6;
            buttonlist[1, 6] = b7; buttonlist[1, 7] = b8; buttonlist[1, 8] = b9;
            buttonlist[1, 9] = b10; buttonlist[1, 10] = b11; buttonlist[1, 11] = b12;
            buttonlist[1, 12] = b13; buttonlist[1, 13] = b14; buttonlist[1, 14] = b15;

            buttonlist[2, 0] = c1; buttonlist[2, 1] = c2; buttonlist[2, 2] = c3;
            buttonlist[2, 3] = c4; buttonlist[2, 4] = c5; buttonlist[2, 5] = c6;
            buttonlist[2, 6] = c7; buttonlist[2, 7] = c8; buttonlist[2, 8] = c9;
            buttonlist[2, 9] = c10; buttonlist[2, 10] = c11; buttonlist[2, 11] = c12;
            buttonlist[2, 12] = c13; buttonlist[2, 13] = c14; buttonlist[2, 14] = c15;

            buttonlist[3, 0] = d1; buttonlist[3, 1] = d2; buttonlist[3, 2] = d3;
            buttonlist[3, 3] = d4; buttonlist[3, 4] = d5; buttonlist[3, 5] = d6;
            buttonlist[3, 6] = d7; buttonlist[3, 7] = d8; buttonlist[3, 8] = d9;
            buttonlist[3, 9] = d10; buttonlist[3, 10] = d11; buttonlist[3, 11] = d12;
            buttonlist[3, 12] = d13; buttonlist[3, 13] = d14; buttonlist[3, 14] = d15;

            buttonlist[4, 0] = e1; buttonlist[4, 1] = e2; buttonlist[4, 2] = e3;
            buttonlist[4, 3] = e4; buttonlist[4, 4] = e5; buttonlist[4, 5] = e6;
            buttonlist[4, 6] = e7; buttonlist[4, 7] = e8; buttonlist[4, 8] = e9;
            buttonlist[4, 9] = e10; buttonlist[4, 10] = e11; buttonlist[4, 11] = e12;
            buttonlist[4, 12] = e13; buttonlist[4, 13] = e14; buttonlist[4, 14] = e15;

            buttonlist[5, 0] = f1; buttonlist[5, 1] = f2; buttonlist[5, 2] = f3;
            buttonlist[5, 3] = f4; buttonlist[5, 4] = f5; buttonlist[5, 5] = f6;
            buttonlist[5, 6] = f7; buttonlist[5, 7] = f8; buttonlist[5, 8] = f9;
            buttonlist[5, 9] = f10; buttonlist[5, 10] = f11; buttonlist[5, 11] = f12;
            buttonlist[5, 12] = f13; buttonlist[5, 13] = f14; buttonlist[5, 14] = f15;

            buttonlist[6, 0] = g1; buttonlist[6, 1] = g2; buttonlist[6, 2] = g3;
            buttonlist[6, 3] = g4; buttonlist[6, 4] = g5; buttonlist[6, 5] = g6;
            buttonlist[6, 6] = g7; buttonlist[6, 7] = g8; buttonlist[6, 8] = g9;
            buttonlist[6, 9] = g10; buttonlist[6, 10] = g11; buttonlist[6, 11] = g12;
            buttonlist[6, 12] = g13; buttonlist[6, 13] = g14; buttonlist[6, 14] = g15;

            buttonlist[7, 0] = h1; buttonlist[7, 1] = h2; buttonlist[7, 2] = h3;
            buttonlist[7, 3] = h4; buttonlist[7, 4] = h5; buttonlist[7, 5] = h6;
            buttonlist[7, 6] = h7; buttonlist[7, 7] = h8; buttonlist[7, 8] = h9;
            buttonlist[7, 9] = h10; buttonlist[7, 10] = h11; buttonlist[7, 11] = h12;
            buttonlist[7, 12] = h13; buttonlist[7, 13] = h14; buttonlist[7, 14] = h15;

            buttonlist[8, 0] = i1; buttonlist[8, 1] = i2; buttonlist[8, 2] = i3;
            buttonlist[8, 3] = i4; buttonlist[8, 4] = i5; buttonlist[8, 5] = i6;
            buttonlist[8, 6] = i7; buttonlist[8, 7] = i8; buttonlist[8, 8] = i9;
            buttonlist[8, 9] = i10; buttonlist[8, 10] = i11; buttonlist[8, 11] = i12;
            buttonlist[8, 12] = i13; buttonlist[8, 13] = i14; buttonlist[8, 14] = i15;

            buttonlist[9, 0] = j1; buttonlist[9, 1] = j2; buttonlist[9, 2] = j3;
            buttonlist[9, 3] = j4; buttonlist[9, 4] = j5; buttonlist[9, 5] = j6;
            buttonlist[9, 6] = j7; buttonlist[9, 7] = j8; buttonlist[9, 8] = j9;
            buttonlist[9, 9] = j10; buttonlist[9, 10] = j11; buttonlist[9, 11] = j12;
            buttonlist[9, 12] = j13; buttonlist[9, 13] = j14; buttonlist[9, 14] = j15;

            buttonlist[10, 0] = k1; buttonlist[10, 1] = k2; buttonlist[10, 2] = k3;
            buttonlist[10, 3] = k4; buttonlist[10, 4] = k5; buttonlist[10, 5] = k6;
            buttonlist[10, 6] = k7; buttonlist[10, 7] = k8; buttonlist[10, 8] = k9;
            buttonlist[10, 9] = k10; buttonlist[10, 10] = k11; buttonlist[10, 11] = k12;
            buttonlist[10, 12] = k13; buttonlist[10, 13] = k14; buttonlist[10, 14] = k15;

            buttonlist[11, 0] = l1; buttonlist[11, 1] = l2; buttonlist[11, 2] = l3;
            buttonlist[11, 3] = l4; buttonlist[11, 4] = l5; buttonlist[11, 5] = l6;
            buttonlist[11, 6] = l7; buttonlist[11, 7] = l8; buttonlist[11, 8] = l9;
            buttonlist[11, 9] = l10; buttonlist[11, 10] = l11; buttonlist[11, 11] = l12;
            buttonlist[11, 12] = l13; buttonlist[11, 13] = l14; buttonlist[11, 14] = l15;

            buttonlist[12, 0] = m1; buttonlist[12, 1] = m2; buttonlist[12, 2] = m3;
            buttonlist[12, 3] = m4; buttonlist[12, 4] = m5; buttonlist[12, 5] = m6;
            buttonlist[12, 6] = m7; buttonlist[12, 7] = m8; buttonlist[12, 8] = m9;
            buttonlist[12, 9] = m10; buttonlist[12, 10] = m11; buttonlist[12, 11] = m12;
            buttonlist[12, 12] = m13; buttonlist[12, 13] = m14; buttonlist[12, 14] = m15;

            buttonlist[13, 0] = n1; buttonlist[13, 1] = n2; buttonlist[13, 2] = n3;
            buttonlist[13, 3] = n4; buttonlist[13, 4] = n5; buttonlist[13, 5] = n6;
            buttonlist[13, 6] = n7; buttonlist[13, 7] = n8; buttonlist[13, 8] = n9;
            buttonlist[13, 9] = n10; buttonlist[13, 10] = n11; buttonlist[13, 11] = n12;
            buttonlist[13, 12] = n13; buttonlist[13, 13] = n14; buttonlist[13, 14] = n15;

            buttonlist[14, 0] = o1; buttonlist[14, 1] = o2; buttonlist[14, 2] = o3;
            buttonlist[14, 3] = o4; buttonlist[14, 4] = o5; buttonlist[14, 5] = o6;
            buttonlist[14, 6] = o7; buttonlist[14, 7] = o8; buttonlist[14, 8] = o9;
            buttonlist[14, 9] = o10; buttonlist[14, 10] = o11; buttonlist[14, 11] = o12;
            buttonlist[14, 12] = o13; buttonlist[14, 13] = o14; buttonlist[14, 14] = o15;
        }

        // 當滑鼠移到按鈕上，該行列變成灰色，以便玩家對應左方及上方的數字
        private void a1_MouseEnter(object sender, EventArgs e)
        {
            Button hovered_button = (Button)sender; 
            for (int i = 0; i < num_row; i++)
                for (int j = 0; j < num_col; j++)
                {
                    if (hovered_button == buttonlist[i, j])
                    {
                        for (int m = 0; m < num_row; m++)
                            if(button_state[m,j] == 0)  // 是白色的才變色
                                buttonlist[m, j].BackColor = Color.LightSteelBlue;
                        for (int n = 0; n < num_col; n++)
                            if (button_state[i, n] == 0)    // 是白色的才變色
                                buttonlist[i, n].BackColor = Color.LightSteelBlue;
                    }
                }
        
        }
        // 滑鼠離開後顏色變回
        private void a1_MouseLeave(object sender, EventArgs e)
        {
            Button hovered_button = (Button)sender;
 
            for (int i = 0; i < num_row; i++)
                for (int j = 0; j < num_col; j++)
                {
                    if (hovered_button == buttonlist[i, j])
                    {
                        Color now_state = Color.White;
                        // 先隨便設初值，因為不設的話好像不給使用該變數= = (unassigned variable)

                        for (int m = 0; m < num_row; m++)
                        {   // 判斷原本的顏色
                            switch (button_state[m, j])
                            {
                                case 0: now_state = Color.White; break;
                                case 1: now_state = Color.Black; break;
                                case -1: now_state = Color.Gray; break;
                            }
                            buttonlist[m, j].BackColor = now_state;
                        }
                        for (int n = 0; n < num_col; n++)
                        {   // 判斷原本的顏色
                            switch (button_state[i, n])
                            {
                                case 0: now_state = Color.White; break;
                                case 1: now_state = Color.Black; break;
                                case -1: now_state = Color.Gray; break;
                            }
                            buttonlist[i, n].BackColor = now_state;
                        }
                    }
                }
                    
        }

        private void getsol_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < num_row; i++)
            {
                for (int j = 0; j < num_col; j++)
                    File.AppendAllText(".\\sol\\sol1.text", solution[i, j].ToString());
                File.AppendAllText(".\\sol\\sol1.text", "\r\n");
            }
        }

        // 按下後變色
        private void a1_Click(object sender, EventArgs e)
        {
            Button clicked_button = (Button)sender;
            count = 0;      // initializing count (judge finished or not)
            for (int i = 0; i < num_row; i++)
                for (int j = 0; j < num_col; j++)
                {
                    if (clicked_button == buttonlist[i, j])
                        switch (button_state[i, j])
                        {
                            case 0: // 白->黑
                                buttonlist[i, j].BackColor = Color.Black;
                                button_state[i, j] = 1; break;
                            case 1: // 黑->灰
                                buttonlist[i, j].BackColor = Color.Gray;
                                button_state[i, j] = -1; break;
                            case -1: // 灰->白
                                buttonlist[i, j].BackColor = Color.White;
                                button_state[i, j] = 0; break;
                        }
                    switch (solution[i, j])
                    {
                        case 0:
                            if (button_state[i, j] == 0 || button_state[i, j] == -1)
                                count++;
                            break;
                        case 1:
                            if (button_state[i, j] == 1)
                                count++;
                            break;
                    }
                }
            if (count == num_row * num_col)     // all button are correct
            {
                label1.Visible = true;          // "finished" appears
                for (int i = 0; i < num_row; i++)
                    for (int j = 0; j < num_col; j++)
                        buttonlist[i, j].Enabled = false;   // unable all buttons
            }

        }
    }
}
