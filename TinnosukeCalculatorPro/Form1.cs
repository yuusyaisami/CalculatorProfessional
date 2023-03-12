using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculatorPro
{
    
    public partial class CalculatorForm : Form
    {
        //declaration
        //in Rich text box --About Row 
        //I would like to add this in a future version, so I have made extra data for this purpose.
        //                   Extra data ↓
        string[][] Formula = new string[255][];
        int[] priority = new int[255];
        string[] Output = new string[255];
        string[] TempFormulaArray = new string[255];
        string TempFormula;
        int FormulaRow=0;
        //Calculation Results
        double Results;
        bool ValueC, AddC, SubtractC, MultiplyC, DivideC, PowerC, LeftParenthesisC, RightParenthesisC, EqualsC, DecimalPointC, OkC;
        //Determine whether or not the numerical value
        Regex isInteger = new Regex(@"^\d+$");
        Regex isDecimal = new Regex(@"^\d+\.\d+$");

        private void Information_Click(object sender, EventArgs e)
        {

            if (CalculationMethodPicture.Visible == true)
            {
                CalculationMethodPicture.Visible = false;
            }
            else if(CalculationMethodPicture.Visible == false && SettingControl.Visible == false)
            {
                CalculationMethodPicture.Visible = true;
            }
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            CalculationMethodPicture.Visible = false;
            if(SettingControl.Visible == true)
            SettingControl.Visible = false;
            else
                SettingControl.Visible = true;
        }

        private void CalculationFormula_TextChanged(object sender, EventArgs e)
        {

        }
        //Calculation Priority.
        // The higher the number, the higher priority is given to the calculation.
        const int AddSubV = 1, MulDivV = 2, ParenthesesAddSubV = 8, ParenthesisMulDivV = 9, PowerV = 10;
        public CalculatorForm()
        {
            InitializeComponent();
            // Formula 255 * 255 
            for (int a = 0; a<Formula.Length; a++)
            {
                Formula[a] = new string[255];
                for (int b = 0; b < Formula[a].Length; b++)
                {
                    Formula[a][b] = null;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            //RunBotton
            //in TempFormula
            TempFormula = null;
            for (int i = 0; CalculationFormula.Lines.Length > i; i++)
            {
                TempFormula += CalculationFormula.Lines[i];
            }
            if(string.IsNullOrEmpty(TempFormula) == false)
            {
                TempFormula = TempFormula.Replace(" ", String.Empty);
                TempFormula = TempFormula.Replace("　", String.Empty);

                //Data Validity
                JudgmentFormulas();
                //secondary check --For easier debugging
                CheckAndCorrect();
                //prioritize Variables are priority
                //The bottom two functions are not necessary.
                Priortize();
                //parentheses
                ParenthesesFanction();
                //calculation --Core of this code
                MainCalculation();
            }
            
        }




        //--------------------------------------------self-made function----------------------------------------
        //This is the very spaghetti code!

        void MainCalculation()
        {   //operator or not.
            AddC = false;               // +
            SubtractC = false;          // -
            MultiplyC = false;          // x
            DivideC = false;            // ÷
            PowerC = false;             // ^
            LeftParenthesisC = false;   // (
            RightParenthesisC = false;  // )
            EqualsC = false;            // =
            DecimalPointC = false;      // .
            //string to double
            double[] FormulaValue = new double[255];
            int[] FirstPriority = new int[255];
            for (int q = 0; Formula[FormulaRow][q] != null; q++) Output[q] = Formula[FormulaRow][q];
            int MostValue = 0, MostValueIndex = 0;
            
            bool AddSubVB = false, MulDivVB = false, ParenthesesAddSubVB = false, ParenthesisMulDivVB = false, PowerVB = false;
            for (int MainLoop; ;)
            {

                //I don't want only the parentheses to exist.
                Priortize();
                ParenthesesFanction();
                for (int b = 0; Formula[FormulaRow][b] != null; b++)
                {

                    if(isDecimal.IsMatch(Formula[FormulaRow][b]) || isInteger.IsMatch(Formula[FormulaRow][b]))
                        FormulaValue[b] = Convert.ToDouble(Formula[FormulaRow][b]) ;
                }
                AddSubVB = false;
                MulDivVB = false;
                ParenthesesAddSubVB = false;
                ParenthesisMulDivVB = false;
                PowerVB = false;
                
                for (int B = 0; B < 255; B++) FirstPriority[B] = 0;
                for (int i = 0; i < 255; i++)
                {
                    if (priority[i] == AddSubV && AddSubVB == false)
                    {
                        AddSubVB = true;
                        FirstPriority[i] = priority[i];
                    }
                    else if (priority[i] == MulDivV && MulDivVB == false)
                    {
                        MulDivVB = true;
                        FirstPriority[i] = priority[i];
                    }
                    else if (priority[i] == ParenthesesAddSubV && ParenthesesAddSubVB == false)
                    {
                        ParenthesesAddSubVB = true;
                        FirstPriority[i] = priority[i];
                    }
                    else if (priority[i] == ParenthesisMulDivV && ParenthesisMulDivVB == false)
                    {
                        ParenthesisMulDivVB = true;
                        FirstPriority[i] = priority[i];
                    }
                    else if (priority[i] == PowerV && PowerVB == false)
                    {
                        PowerVB = true;
                        FirstPriority[i] = priority[i];
                    }
                }
                MostValueIndex = 0;
                for (int a = 0; a < 255; a++)
                {
                    if (MostValueIndex < FirstPriority[a])
                        MostValueIndex = a;
                }

                //calculation
                bool NomalOperator = false;
                if (Formula[FormulaRow][MostValueIndex] =="+")
                {
                    FormulaValue[MostValueIndex - 1] = FormulaValue[MostValueIndex - 1] + FormulaValue[MostValueIndex + 1];
                    Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();
                    NomalOperator = true;
                }
                else if (Formula[FormulaRow][MostValueIndex] =="-")
                {
                    FormulaValue[MostValueIndex - 1] = FormulaValue[MostValueIndex - 1] - FormulaValue[MostValueIndex + 1];
                    Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();
                    NomalOperator = true;
                }
                else if (Formula[FormulaRow][MostValueIndex] =="*")
                {
                    FormulaValue[MostValueIndex - 1] = FormulaValue[MostValueIndex - 1] * FormulaValue[MostValueIndex + 1];
                    Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();
                    NomalOperator = true;
                }
                else if (Formula[FormulaRow][MostValueIndex] == "/")
                {
                    if (FormulaValue[MostValueIndex + 1] != 0)
                    {
                        FormulaValue[MostValueIndex - 1] = FormulaValue[MostValueIndex - 1] / FormulaValue[MostValueIndex + 1];
                        Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();
                    }
                    else
                    {
                        //Error
                        for(int i = 0; i < FormulaValue.Length; i++)
                        {
                            Formula[FormulaRow][i] = null;
                            FormulaValue[i] = 0;
                            priority[i] = 0;
                        }
                    }
                    NomalOperator = true;
                }
                else if (Formula[FormulaRow][MostValueIndex] == "^")
                {
                    FormulaValue[MostValueIndex - 1] =  Math.Pow(FormulaValue[MostValueIndex - 1], FormulaValue[MostValueIndex + 1]);
                    Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();
                    NomalOperator = true;
                }
                else
                {
                    ListViewItem ResultsItem = new ListViewItem();
                    //finish!
                    if (OutPutType.Checked == true)
                        ResultsItem.Text = TempFormula;
                    else for (int e = 0; Output[e] != null; e++) ResultsItem.Text += Output[e];
                    CalculationResult.Items.Add(ResultsItem);
                    ResultsItem = new ListViewItem(">" + FormulaValue[0].ToString());
                    CalculationResult.Items.Add(ResultsItem);
                    Results = FormulaValue[0];


                    for (int i = 0; i < FormulaValue.Length; i++)
                    {
                        Formula[FormulaRow][i] = null;
                        FormulaValue[i] = 0;
                        priority[i] = 0;
                    }

                    break;
                }
                //Use Array 
                //  ↓
                //Formula
                //FormulaValue
                //priority
                
                //Various other calculations will be added 
                //We will implement this in a future version.XD

                if (NomalOperator)
                {
                    for(int i = MostValueIndex; i < 252; i += 2)
                    {
                        Formula[FormulaRow][i] = Formula[FormulaRow][i + 2];
                        Formula[FormulaRow][i + 1] = Formula[FormulaRow][i + 3];

                        FormulaValue[i] = FormulaValue[i + 2];
                        FormulaValue[i + 1] = FormulaValue[i + 3];
                    }
                }
                

            }


        }
        void ParenthesesFanction()
        {
            for (int i = 0; i < Formula.Length; i++)
            {
                if (Formula[FormulaRow][i] == "(")
                {
                    if(Formula[FormulaRow][i + 1] == ")")
                    {
                        for(int a = i; a < 253; a += 2)
                        {
                            Formula[FormulaRow][a]     = Formula[FormulaRow][a + 2];
                            Formula[FormulaRow][a + 1] = Formula[FormulaRow][a + 3];
                        }
                    }
                    if(Formula[FormulaRow][i + 2] == ")")
                    {
                        Formula[FormulaRow][i] =  Formula[FormulaRow][i + 1];
                        for (int a = i + 1; a < 249; a += 2)
                        {
                            Formula[FormulaRow][a]     = Formula[FormulaRow][a + 2];
                            Formula[FormulaRow][a + 1] = Formula[FormulaRow][a + 3];
                        }
                    }
                }
            }
        }
        void Priortize()
        {
            for (int i = 0; i < Formula.Length; i++) priority[i] = 0;
            bool LeftParenthesisB = false;
            for (int i = 0; i < 255; i++)
            {
                if(Formula[FormulaRow][i] == "(")
                {
                    LeftParenthesisB = true;
                }
                else if(Formula[FormulaRow][i] == ")")
                {
                    LeftParenthesisB = false;
                }

                if(LeftParenthesisB == true)
                {
                    if (Formula[FormulaRow][i] == "+" || Formula[FormulaRow][i] == "-")
                    {
                        priority[i] = ParenthesesAddSubV;
                    }
                    else if(Formula[FormulaRow][i] == "*" || Formula[FormulaRow][i] == "/")
                    {
                        priority[i] = ParenthesisMulDivV;
                    }
                }
                else
                {
                    if (Formula[FormulaRow][i] == "+" || Formula[FormulaRow][i] == "-")
                    {
                        priority[i] = AddSubV;
                    }
                    else if (Formula[FormulaRow][i] == "*" || Formula[FormulaRow][i] == "/")
                    {
                        priority[i] = MulDivV;
                    }
                }

                if(Formula[FormulaRow][i] == "^")
                {
                    priority[i] = PowerV;
                }
                
            }

        }
        void JudgmentFormulas()
        {
            string CTF;
            int FormulaColumn;
            ValueC = true;             // 0123456789
            AddC = true;               // +
            SubtractC = true;          // -
            MultiplyC = false;          // x
            DivideC = false;            // ÷
            PowerC = false;             // ^
            LeftParenthesisC = true;   // (
            RightParenthesisC = false;  // )
            EqualsC = false;            // =
            DecimalPointC = false;      // .
            OkC = false;

            for(int d = 0; d < TempFormula.Length; d++)
            {
                TempFormulaArray[d] = TempFormula[d].ToString();
            }
            for (FormulaColumn = 0; FormulaColumn <  TempFormula.Length; FormulaColumn++)
            {//Data Validity
                CTF = TempFormulaArray[FormulaColumn];
                OkC = false;
                //if value
                for (int a = 0; a < 10; a++)
                {
                    
                    if (a.ToString() == CTF && ValueC)
                    {
                        
                        
                        Formula[FormulaRow][FormulaColumn] = a.ToString();

                        ValueC = true;             // 0123456789
                        AddC = true;               // +
                        SubtractC = true;          // -
                        MultiplyC = true;          // x
                        DivideC = true;            // ÷
                        PowerC = true;             // ^
                        LeftParenthesisC = true;   // (
                        RightParenthesisC = true;  // )
                        EqualsC = true;            // =
                        DecimalPointC = true;      // .
                        OkC = true;
                        
                    }
                }
                if (CTF == "+" || CTF == "＋")
                {
                    if (AddC)
                    {
                        ValueC = true;              // 0123456789
                        AddC = false;               // +
                        SubtractC = false;          // -
                        MultiplyC = false;          // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParenthesisC = true;    // (
                        RightParenthesisC = false;  // )
                        EqualsC = false;            // =
                        DecimalPointC = false;      // .
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "+";
                    }
                }
                else if (CTF == "-" || CTF == "－")
                {
                    if (SubtractC)
                    {
                        ValueC = true;             // 0123456789
                        AddC = false;               // +
                        SubtractC = false;          // -
                        MultiplyC = false;          // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParenthesisC = true;   // (
                        RightParenthesisC = false;  // )
                        EqualsC = false;            // =
                        DecimalPointC = false;      // .
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "-";
                    }
                }
                else if (CTF == "x" || CTF == "ｘ" || CTF == "*")
                {
                    if (MultiplyC)
                    {
                        ValueC = true;             // 0123456789
                        AddC = false;               // +
                        SubtractC = false;          // -
                        MultiplyC = false;          // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParenthesisC = true;   // (
                        RightParenthesisC = false;  // )
                        EqualsC = false;            // =
                        DecimalPointC = false;      // .
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "*";
                    }
                }
                else if (CTF == "/" || CTF == "÷" || CTF == "／")
                {
                    if (DivideC)
                    {
                        ValueC = true;              // 0123456789
                        AddC = false;               // +
                        SubtractC = false;          // -
                        MultiplyC = false;          // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParenthesisC = true;    // (
                        RightParenthesisC = false;  // )
                        EqualsC = false;            // =
                        DecimalPointC = false;      // .
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "/";
                    }
                }
                else if (CTF == "^" || CTF == "＾")
                {
                    if (PowerC)
                    {
                        ValueC = true;              // 0123456789
                        AddC = false;               // +
                        SubtractC = false;          // -
                        MultiplyC = false;          // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParenthesisC = false;   // (
                        RightParenthesisC = false;  // )
                        EqualsC = false;            // =
                        DecimalPointC = false;      // .
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "^";
                    }
                }
                else if (CTF == "(" || CTF == "（")
                {
                    if (LeftParenthesisC)
                    {
                            ValueC = true;              // 0123456789
                            AddC = false;               // +
                            SubtractC = false;          // -
                            MultiplyC = false;          // x
                            DivideC = false;            // ÷
                            PowerC = false;             // ^
                            LeftParenthesisC = false;   // (
                            RightParenthesisC = true;   // )
                            EqualsC = false;            // =
                            DecimalPointC = false;      // .
                            OkC = true;
                            Formula[FormulaRow][FormulaColumn] = "(";
                        
                    }
                }
            
                else if (CTF == ")" || CTF == "）")
                {
                    if (RightParenthesisC)
                    {
                        ValueC = true;             // 0123456789
                        AddC = true;                // +
                        SubtractC = true;           // -
                        MultiplyC = true;           // x
                        DivideC = true;             // ÷
                        PowerC = false;             // ^
                        LeftParenthesisC = false;   // (
                        RightParenthesisC = false;  // )
                        EqualsC = true;             // =
                        DecimalPointC = false;      // .
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = ")";
                    }
                }
                //Not implemented yet
                /* if(CTF == "=" || CTF == "＝" && EqualsC)
                {

                }
                */
                else if (CTF == "." || CTF == "．")
                {
                    if (DecimalPointC)
                    {
                        ValueC = true;               // 0123456789
                        AddC = false;                // +
                        SubtractC = false;           // -
                        MultiplyC = false;           // x
                        DivideC = false;             // ÷
                        PowerC = false;              // ^
                        LeftParenthesisC = false;    // (
                        RightParenthesisC = false;   // )
                        EqualsC = false;             // =
                        DecimalPointC = false;       // .
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = ".";
                    }
                }
                if (OkC == false && CTF != null)
                {
                    MessageBox.Show("There is an error --If this is a puzzling error, please let the author know!");
                    for (int errorvalue = 0; errorvalue < 255; errorvalue++) Formula[FormulaRow][errorvalue] = null;
                    break;
                }

            }
            string STFNew = Formula[FormulaRow][FormulaColumn];
            if (STFNew == "+" || STFNew == "-" || STFNew == "*" || STFNew == "/" || STFNew == "^" || STFNew == ".")
            {
                MessageBox.Show("There is an error --The last part of the equation is incorrect.");
                for (int errorvalue = 0; errorvalue < 255; errorvalue++) Formula[FormulaRow][errorvalue] = null;
            }
        }

        void CheckAndCorrect()
        {
            if (Formula[FormulaRow][0] == "+" ||Formula[FormulaRow][0] == "-")
            {
                if (Formula[FormulaRow][0] == "+") Formula[FormulaRow][1] = null;
                if (Formula[FormulaRow][0] == "-") Formula[FormulaRow][1] = "-" + Formula[FormulaRow][1];

                for (int i = 0; i < TempFormula.Length + 1; i++)
                {
                    Formula[FormulaRow][i] = Formula[FormulaRow][i + 1];
                }
            }
            for(int i = 0; i < TempFormula.Length; i++)
            {
               for (int a = 0; a < 9; a++)
                {
                    if(Formula[FormulaRow][i] == a.ToString())
                    {
                        for(int b = 0; b < 9; b++)
                        {
                            if (Formula[FormulaRow][i + 1] == b.ToString())
                            {
                                Formula[FormulaRow][i] += Formula[FormulaRow][i + 1];
                                for(int c = 0; c < TempFormula.Length - i - 1; c++)
                                {
                                    Formula[FormulaRow][i + 1 + c] = Formula[FormulaRow][i + 2 + c];
                                    b = 0;
                                }
                            }
                        }
                        if (Formula[FormulaRow][i + 1] == "(")
                        {
                            for(int d = 254; d > i; d--)
                            {
                                Formula[FormulaRow][d] = Formula[FormulaRow][d - 1];
                            }
                            Formula[FormulaRow][i + 1] = "*";
                        }
                        if( Formula[FormulaRow][i] == ")")
                        {
                            for (int d = 254; d > i - 1; d--)
                            {
                                Formula[FormulaRow][d + 1] = Formula[FormulaRow][d];
                            }
                            Formula[FormulaRow][i - 1] = "*";
                        }
                        int data = 1;
                        bool Okdata = false;
                        if (Formula[FormulaRow][i + 1] == ".")
                        {
                            Formula[FormulaRow][i] += Formula[FormulaRow][i + 1];
                            
                                for (int d = i + 2; d < 254; d++)
                                {
                                    for (int b = 0; b < 9; b++)
                                    {
                                        if(Formula[FormulaRow][d] == b.ToString())
                                        {
                                            Formula[FormulaRow][i] += Formula[FormulaRow][d];
                                            data++;
                                            Okdata = true;
                                        }
                                    }
                                    if (Okdata)
                                    {
                                        Okdata = false;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            int e = 0, f;
                            for(; e != data;)
                            {
                                for (f = i + 1; f < 240; f++)
                                {
                                    Formula[FormulaRow][f] = Formula[FormulaRow][f + 1];
                                }
                                e++;
                            }
                            
                        }
                    }

                }  
            }
            
        }

      
    }
}

