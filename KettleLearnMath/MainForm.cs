using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace KettleLearnMath
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private int TotalCount = 10;
        private int CurrentCount = 0;
        private int CorrectCount = 0;
        private int WrongCount = 0;

        private int Mode = 2;
        private int Sign_Question = 0;
        private int Sign_Ans = 0;
        private int[,] Ans = new int[3, 5] { {0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        private int[,] Ans_Si = new int[2,4] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, } };
        private int Opt1 = 0;
        private int Opt2 = 0;

        private bool isNewQuestion = false;
        private bool isFixNeeded = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            reset();
            switchMode(Mode);
        }
        void clear_Ask()
        {
            uiTB_Question1.Text = "";
            uiTB_Question2.Text = "";
            Ans = new int[3, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        }
        void clear_Ans1()
        {
            uiTB_Ans.Text = "";
            uiTB_Ans.Visible = false;

            //uiSBtn_Ok1.Visible = false;
        }
        void clear_Ans2()
        {
            uiTB_Ans1_1.Text = "";
            uiTB_Ans1_2.Text = "";
            uiTB_Ans1_3.Text = "";
            uiTB_Ans1_4.Text = "";
            
            uiTB_Ans2_1.Text = "";
            uiTB_Ans2_2.Text = "";
            uiTB_Ans2_3.Text = "";
            uiTB_Ans2_4.Text = "";

            uiTB_Ans3_1.Text = "";
            uiTB_Ans3_2.Text = "";
            uiTB_Ans3_3.Text = "";
            uiTB_Ans3_4.Text = "";
            uiTB_Ans3_5.Text = "";

            uiLine1.FillColor = Color.Transparent;
            uiTB_Ans_M_2.SymbolColor = Color.Transparent;
            uiTB_Ans_M_3.SymbolColor = Color.Transparent;
            uiTB_Ans_M_4.SymbolColor = Color.Transparent;
            uiTB_Ans_M_5.SymbolColor = Color.Transparent;

            uiTB_Ans_P_2.SymbolColor = Color.Transparent;
            uiTB_Ans_P_3.SymbolColor = Color.Transparent;
            uiTB_Ans_P_4.SymbolColor = Color.Transparent;
            uiTB_Ans_P_5.SymbolColor = Color.Transparent;
        }
        void Mode1(bool isEnable)
        {
            clear_Ans1();

            uiTB_Ans.Visible = isEnable;

            //uiSBtn_Ok1.Visible = isEnable;
        }
        void Mode2(bool isEnable)
        {
            clear_Ans2();

            uiTB_Ans1_1.Visible = isEnable;
            uiTB_Ans1_2.Visible = isEnable;
            uiTB_Ans1_3.Visible = isEnable;
            uiTB_Ans1_4.Visible = isEnable;

            uiTB_Ans2_1.Visible = isEnable;
            uiTB_Ans2_2.Visible = isEnable;
            uiTB_Ans2_3.Visible = isEnable;
            uiTB_Ans2_4.Visible = isEnable;

            uiTB_Ans3_1.Visible = isEnable;
            uiTB_Ans3_2.Visible = isEnable;
            uiTB_Ans3_3.Visible = isEnable;
            uiTB_Ans3_4.Visible = isEnable;
            uiTB_Ans3_5.Visible = isEnable;

            uiSl_Sign.Visible = isEnable;
            uiLine1.Visible = isEnable;

            uiTB_Ans_M_2.Visible = isEnable;
            uiTB_Ans_M_3.Visible = isEnable;
            uiTB_Ans_M_4.Visible = isEnable;
            uiTB_Ans_M_5.Visible = isEnable;

            uiTB_Ans_P_2.Visible = isEnable;
            uiTB_Ans_P_3.Visible = isEnable;
            uiTB_Ans_P_4.Visible = isEnable;
            uiTB_Ans_P_5.Visible = isEnable;

            //uiSBtn_Ok1.Visible = isEnable;
        }
        void switchMode(int mode)
        {
            switch(mode)
            {
                case 1:
                    Mode1(true);
                    Mode2(false);
                    break;
                case 2:
                    Mode1(false);
                    Mode2(true);
                    break;
            }
        }

        int GetMode()
        {
            Mode = GetRandom(1,3);
            switchMode(Mode);
            return Mode;
        }
        int GetSign()
        {
            Sign_Question = GetRandom(0,2);
            return Sign_Question;
        }
        void SetSign(object sender, int Sign)
        {
            if (Sign == 0) //加法
                ((Sunny.UI.UISymbolLabel)sender).Symbol = 61543;
            else
                ((Sunny.UI.UISymbolLabel)sender).Symbol = 61544;
        }

        int RevertSign(object sender)
        {
            int sign = 0;
            if (((Sunny.UI.UISymbolLabel)sender).Symbol == 61543)
            {
                ((Sunny.UI.UISymbolLabel)sender).Symbol = 61544;
                sign = 1;
            }
            else if (((Sunny.UI.UISymbolLabel)sender).Symbol == 61544)
            {
                ((Sunny.UI.UISymbolLabel)sender).Symbol = 61543;
                sign = 0;
            }
            return sign;
        }
        void RevertSign(object sender, ref int Sign)
        {
            Sign = RevertSign(sender);
        }

        int GetRandom(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }
        void GetQuestion()
        {
            Ans = new int[3, 5] { { 0, 0, 0, 0, 0}, { 0, 0, 0, 0, 0}, { 0, 0, 0, 0, 0} };
            Ans_Si = new int[2, 4] { { 0, 0, 0, 0}, { 0, 0, 0, 0} };

            if (uiRBtn_Random.Checked) GetMode();

            Opt1 = GetRandom(20, 10000);
            uiTB_Question1.Text = Opt1.ToString();

            SetSign(uiSL_Sign_Question, GetSign());

            if(Sign_Question == 0)
            {
                Opt2 = GetRandom(10, 10000);
            }
            else
            {
                do
                {
                    Opt2 = GetRandom(10, Opt1);
                } while ((Opt2 + 20) > Opt1);
            }

            uiTB_Question2.Text = Opt2.ToString();

            isNewQuestion = true;
        }
        void clear_rabbit()
        {
            uiIBtn_Rabit.Location = new Point(0, 792);
        }

        void clear_turtle()
        {
            uiIBtn_Turtle.Location = new Point(514, 801);
        }

        void Update_Tips()
        {
            uiSL_TotalCount.Text = "总数：" + TotalCount;
            uiSL_CurrentCount.Text = "完成：" + CurrentCount;
            uiSL_CorrectCount.Text = "正确：" + CorrectCount;
            uiSL_WrongCount.Text = "错误：" + WrongCount;

            if(CurrentCount > 0)
                uiSBtn_Start.Text = "重新开始";
            else
                uiSBtn_Start.Text = "开始答题";

        }
        void reset()
        {
            clear_Ask();
            clear_Ans1();
            clear_Ans2();
            clear_SI();
            Ans_Si = new int[2, 4] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, } };

            TotalCount = 10;
            CurrentCount = 0;
            CorrectCount = 0;
            WrongCount = 0;

            clear_rabbit();
            clear_turtle();
            Update_Tips();
        }

        private void uiSl_Sign_Click(object sender, EventArgs e)
        {
            RevertSign(sender, ref Sign_Ans);
        }
        int chengeSymbol(object sender, EventArgs e)
        {
            int result = 0;
            if (((Sunny.UI.UISymbolLabel)sender).SymbolColor == Color.Transparent)
            {
                ((Sunny.UI.UISymbolLabel)sender).SymbolColor = Color.Black;
                result = 1;
            }
            else
            {
                ((Sunny.UI.UISymbolLabel)sender).SymbolColor = Color.Transparent;
                result = 0;
            }
            return result;
        }
        int GetSi(object sender)
        {
            int result = 0;
            if (((Sunny.UI.UISymbolLabel)sender).SymbolColor != Color.Transparent)
            {
                result = 1;
            }

            return result;
        }
        private void uiTB_Ans_M_2_Click(object sender, EventArgs e)
        {
            Ans_Si[0, 0] = chengeSymbol(sender, e);
        }

        private void uiTB_Ans_M_3_Click(object sender, EventArgs e)
        {
            Ans_Si[0,1] = chengeSymbol(sender, e);
        }

        private void uiTB_Ans_M_4_Click(object sender, EventArgs e)
        {
            Ans_Si[0,2] = chengeSymbol(sender, e);
        }

        private void uiTB_Ans_P_2_Click(object sender, EventArgs e)
        {
            Ans_Si[1, 0] = chengeSymbol(sender, e);
        }

        private void uiTB_Ans_P_3_Click(object sender, EventArgs e)
        {
            Ans_Si[1, 1] = chengeSymbol(sender, e);
        }

        private void uiTB_Ans_P_4_Click(object sender, EventArgs e)
        {
            Ans_Si[1, 2] = chengeSymbol(sender, e);
        }

        private void uiTB_Ans_P_5_Click(object sender, EventArgs e)
        {
            Ans_Si[1, 3] = chengeSymbol(sender, e);
        }

        private void uiSBtn_Start_Click(object sender, EventArgs e)
        {
            if (CurrentCount >= 0)
            {
                reset();
                switchMode(Mode);
            }

            GetQuestion();
        }

        private void uiSBtn_NextQuestion_Click(object sender, EventArgs e)
        {
            if (Mode == 1)
                CheckResult(CheckMod1_Ans());
            else
                CheckResult(CheckMod2_Ans());

            if (!isFixNeeded)
            {
                Update_Tips();

                if (Mode == 1)
                {
                    clear_Ans1();
                }
                else
                {
                    clear_SI();
                    clear_Ans2();
                }

                switchMode(Mode);

                GetQuestion();
            }
        }

        bool CheckMod1_Ans()
        {
            bool result = false;
            if (Sign_Question == 0)
            {
                if (Opt1 + Opt2 == uiTB_Ans.IntValue)
                    result = false;
                else
                    result = true;
            }
            else if (Sign_Question == 1)
            {
                if ((Opt1 - Opt2) == uiTB_Ans.IntValue)
                    result = false;
                else
                    result = true;
            }

            return !result;
        }
        void clear_SI()
        {
            uiTB_Ans_M_2.SymbolColor = Color.Transparent;
            uiTB_Ans_M_3.SymbolColor = Color.Transparent;
            uiTB_Ans_P_2.SymbolColor = Color.Transparent;
            uiTB_Ans_P_3.SymbolColor = Color.Transparent;
        }
        bool CheckMod2_Ans()
        {
            int tmp1 = Opt1, tmp2 = Opt2, tmp3 = 0, tmp4 = 0;
            int[,] ExpectedResult = new int[3, 5];
            int result = 0;
            int[,] ExpectedSi = new int[2, 4] { { 0, 0, 0, 0}, { 0, 0, 0, 0} };

            Ans_Si[0, 0] = GetSi(uiTB_Ans_M_2);
            Ans_Si[0, 1] = GetSi(uiTB_Ans_M_3);
            Ans_Si[0, 2] = GetSi(uiTB_Ans_M_4);
            Ans_Si[0, 3] = GetSi(uiTB_Ans_M_5);

            Ans_Si[1, 0] = GetSi(uiTB_Ans_P_2);
            Ans_Si[1, 1] = GetSi(uiTB_Ans_P_3);
            Ans_Si[1, 2] = GetSi(uiTB_Ans_P_4);
            Ans_Si[1, 3] = GetSi(uiTB_Ans_P_5);

            if (Sign_Question == 0)
            {
                tmp3 = Opt1 + Opt2;
            }
            else if (Sign_Question == 1)
            {
                tmp3 = Opt1 - Opt2;
            }
            tmp4 = tmp3;

            for (int i = 0; i < 5; i++)
            {
                ExpectedResult[0, i] = (tmp1 % 10);
                ExpectedResult[1, i] = (tmp2 % 10);
                ExpectedResult[2, i] = (tmp3 % 10);

                tmp1 /= 10;
                tmp2 /= 10;
                tmp3 /= 10;
            }

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    result += (ExpectedResult[i, j] != Ans[i,j]) ? 1:0;
                }
            }

            if (Sign_Question == 0)
            {
                if (ExpectedResult[0, 0] + ExpectedResult[1, 0] >= 10 ) ExpectedSi[1,0] = 1;
                if ((ExpectedResult[0, 1] + ExpectedResult[1, 1] + ExpectedSi[1, 0]) >= 10) ExpectedSi[1, 1] = 1;
                if ((ExpectedResult[0, 2] + ExpectedResult[1, 2] + ExpectedSi[1, 1]) >= 10) ExpectedSi[1, 2] = 1;
                if ((ExpectedResult[0, 3] + ExpectedResult[1, 3] + ExpectedSi[1, 2]) >= 10) ExpectedSi[1, 3] = 1;
            }
            else if (Sign_Question == 1)
            {
                if (ExpectedResult[0, 0] < ExpectedResult[1, 0] ) ExpectedSi[0, 0] = 1;
                if (ExpectedResult[0, 1] <(ExpectedResult[1, 1] + ExpectedSi[0, 0])) ExpectedSi[0, 1] = 1;
                if (ExpectedResult[0, 2] <(ExpectedResult[1, 2] + ExpectedSi[0, 1])) ExpectedSi[0, 2] = 1;
                if (ExpectedResult[0, 3] <(ExpectedResult[1, 3] + ExpectedSi[0, 2])) ExpectedSi[0, 3] = 1;
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result += (ExpectedSi[i, j] != Ans_Si[i, j]) ? 1 : 0;
                }
            }
            result += (uiSl_Sign.Symbol == uiSL_Sign_Question.Symbol? 0 : 1);
            return (result == 0);
        }

        bool CheckResult(bool isCorrect)
        {
            if (isNewQuestion || isFixNeeded)
            {
                if (!isFixNeeded)
                {
                    isNewQuestion = false;
                }
                if (isCorrect)
                {
                    if (!isFixNeeded)
                    {
                        CurrentCount++;
                        CorrectCount++;
                        if (uiIBtn_Rabit.Location.X <= uiIBtn_Flag.Location.X)
                            uiIBtn_Rabit.Location = new Point(uiIBtn_Rabit.Location.X + 160, uiIBtn_Rabit.Location.Y);

                        if (uiIBtn_Turtle.Location.X > uiIBtn_Rabit.Location.X + 500)
                        {
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Turtle, "不要以为你比我快很多！我马上就赶上你了", 6000);
                        }
                        else if (uiIBtn_Turtle.Location.X > uiIBtn_Rabit.Location.X)
                        {
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Rabit, "快赶上你了！哼哼！", 6000);
                        }
                        else if (uiIBtn_Turtle.Location.X <= uiIBtn_Rabit.Location.X - 500)
                        {
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Turtle, "等等我！不要走", 6000);
                        }
                        else if ((uiIBtn_Turtle.Location.X - uiIBtn_Rabit.Location.X) >= 600)
                        {
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Turtle, "神啊！请留步！请接受小弟的膝盖", 6000);
                        }
                    }
                    isFixNeeded = false;
                }                
                else
                {

                    if (!isFixNeeded)
                    {
                        CurrentCount++;
                        WrongCount++;
                        if (uiIBtn_Turtle.Location.X <= uiIBtn_Flag.Location.X)
                            uiIBtn_Turtle.Location = new Point(uiIBtn_Turtle.Location.X + 98, uiIBtn_Turtle.Location.Y);

                        if (uiIBtn_Turtle.Location.X > uiIBtn_Rabit.Location.X + 500)
                        {
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Rabit, "厉害！等一下我呗！", 6000);
                        }
                        else if (uiIBtn_Turtle.Location.X >= uiIBtn_Rabit.Location.X)
                        {
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Rabit, "不要走！我马上就赶上你！", 6000);
                        }
                        else if (uiIBtn_Turtle.Location.X <= uiIBtn_Rabit.Location.X - 500)
                        {
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Turtle, "嘿嘿！快追上你了。", 6000);
                        }
                        else if ((uiIBtn_Turtle.Location.X - uiIBtn_Rabit.Location.X) >= 600)
                        {
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Turtle, "神啊！请留步！小弟来了。", 6000);
                        }
                    }
                    isFixNeeded = true;
                    Sunny.UI.UIMessageTip.ShowOk(uiSBtn_NextQuestion, "有错误哦，不要放过它，赶紧订正完再做下一题！", 5000);
                }

                if (!isFixNeeded && CurrentCount >= TotalCount/2)
                {
                    if (uiIBtn_Turtle.Location.X > uiIBtn_Rabit.Location.X)
                    {
                        if (uiIBtn_Turtle.Location.X >= uiIBtn_Flag.Location.X - 200)
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Flag, "恭喜小乌龟获胜！", 6000);
                        else
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Flag, "虽然小乌龟领先，但是还没到终点。小兔子也不要气馁哦！你还有机会赢。", 3000);
                    }
                    else if (uiIBtn_Turtle.Location.X < uiIBtn_Rabit.Location.X)
                    {
                        if (uiIBtn_Rabit.Location.X >= uiIBtn_Flag.Location.X - 100)
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Flag, "恭喜小兔子获胜！", 6000);
                        else
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Flag, "虽然小兔子领先，但是还没到终点。小兔子再加把劲，小心被反超哦!", 3000);

                    }
                    else
                    {
                        if (uiIBtn_Rabit.Location.X >= uiIBtn_Flag.Location.X - 200)
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Flag, "恭喜小乌龟、小兔子并列获胜！", 6000);
                        else
                            Sunny.UI.UIMessageTip.ShowOk(uiIBtn_Flag, "哎呦，居然是齐头并进。", 6000);

                    }
                }
            }
            return isCorrect;
        }
        private void uiSBtn_Ok1_Click(object sender, EventArgs e)
        {
            if (Mode == 1)
                CheckResult(CheckMod1_Ans());
            else
                CheckResult(CheckMod2_Ans());

            Update_Tips();
        }

        private void uiSBtn_Ok2_Click(object sender, EventArgs e)
        {
        }
        private void uiTB_Click(object sender, EventArgs e)
        {
            ((Sunny.UI.UITextBox)sender).Text = "";
        }
        private void uiTB_Ans1_1_TextChanged(object sender, EventArgs e)
        {
            Ans[0, 0] = uiTB_Ans1_1.IntValue;
        }

        private void uiTB_Ans1_2_TextChanged(object sender, EventArgs e)
        {
            Ans[0, 1] = uiTB_Ans1_2.IntValue;
        }

        private void uiTB_Ans1_3_TextChanged(object sender, EventArgs e)
        {
            Ans[0, 2] = uiTB_Ans1_3.IntValue;
        }

        private void uiTB_Ans1_4_TextChanged(object sender, EventArgs e)
        {
            Ans[0, 3] = uiTB_Ans1_4.IntValue;
        }

        private void uiTB_Ans2_1_TextChanged(object sender, EventArgs e)
        {
            Ans[1, 0] = uiTB_Ans2_1.IntValue;
        }

        private void uiTB_Ans2_2_TextChanged(object sender, EventArgs e)
        {
            Ans[1, 1] = uiTB_Ans2_2.IntValue;
        }
        private void uiTB_Ans2_3_TextChanged(object sender, EventArgs e)
        {
            Ans[1, 2] = uiTB_Ans2_3.IntValue;
        }

        private void uiTB_Ans2_4_TextChanged(object sender, EventArgs e)
        {
            Ans[1, 3] = uiTB_Ans2_4.IntValue;
        }

        private void uiTB_Ans3_1_TextChanged(object sender, EventArgs e)
        {
            Ans[2, 0] = uiTB_Ans3_1.IntValue;
        }

        private void uiTB_Ans3_2_TextChanged(object sender, EventArgs e)
        {
            Ans[2, 1] = uiTB_Ans3_2.IntValue;
        }

        private void uiTB_Ans3_3_TextChanged(object sender, EventArgs e)
        {
            Ans[2, 2] = uiTB_Ans3_3.IntValue;
        }

        private void uiTB_Ans3_4_TextChanged(object sender, EventArgs e)
        {
            Ans[2, 3] = uiTB_Ans3_4.IntValue;
        }

        private void uiTB_Ans3_5_TextChanged(object sender, EventArgs e)
        {
            Ans[2, 4] = uiTB_Ans3_5.IntValue;
        }

        private void uiRBtn_Horizental_CheckedChanged(object sender, EventArgs e)
        {
            Mode = 1;
            switchMode(Mode);
        }

        private void uiRBtn_Vertical_CheckedChanged(object sender, EventArgs e)
        {
            Mode = 2;
            switchMode(Mode);
        }

        private void uiRBtn_Random_CheckedChanged(object sender, EventArgs e)
        {
        }

    }
}
