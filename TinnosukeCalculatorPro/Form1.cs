using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
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
        int FormulaRow = 0;
        //Calculation Results
        double Results;
        bool ValueC, AddC, SubtractC, MultiplyC, DivideC, PowerC, LeftParenthesisC, RightParenthesisC, EqualsC, DecimalPointC, SinC, CosC, TanC,rootC, OkC;
        //Determine whether or not the numerical value
        Regex isInteger = new Regex(@"^\d+$");
        Regex isDecimal = new Regex(@"^\d+\.\d+$");

        private void Information_Click(object sender, EventArgs e)
        {

            if (CalculationMethodPicture.Visible == true)
            {
                CalculationMethodPicture.Visible = false;
            }
            else if (CalculationMethodPicture.Visible == false && SettingControl.Visible == false)
            {
                CalculationMethodPicture.Visible = true;
            }
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            CalculationMethodPicture.Visible = false;
            if (SettingControl.Visible == true)
                SettingControl.Visible = false;
            else
                SettingControl.Visible = true;
        }

        private void CalculationFormula_TextChanged(object sender, EventArgs e)
        {

        }
        //Calculation Priority.
        // The higher the number, the higher priority is given to the calculation.
        const int AddSubV = 1, MulDivV = 2, ParenthesesAddSubV = 8, ParenthesisMulDivV = 9, PowerV = 10,SinCosTanV = 11,rootV = 12;
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
            if (string.IsNullOrEmpty(TempFormula) == false)
            {
                TempFormula = TempFormula.Replace(" ", String.Empty);
                TempFormula = TempFormula.Replace("　", String.Empty);

                //Data Validity
                JudgmentFormulas();
                
                CombiningNumberString();
                
                //secondary check --For easier debugging
                CheckAndCorrect();
                
                //prioritize Variables are priority
                //The bottom two functions are not necessary.
                Priortize();
                //calculation --Core of this code
                MainCalculation();
            }

        }




        //--------------------------------------------self-made function----------------------------------------
        //This is the very spaghetti code!
        ListViewItem ResultsItem = new ListViewItem();
        void MainCalculation()
        {   //operator or not.

            ResultsItem = new ListViewItem();
            if (OutPutType.Checked == true)
                ResultsItem.Text = ">>" + TempFormula;
            else
            {
                ResultsItem.Text = ">>";
                for (int e = 0; Output[e] != null; e++) ResultsItem.Text += Output[e];
            }
            CalculationResult.Items.Add(ResultsItem);
            //string to double
            double[] FormulaValue = new double[255];
            int[] FirstPriority = new int[255];
            Complex[] complex = new Complex[100];
            for (int q = 0; Formula[FormulaRow][q] != null; q++) Output[q] = Formula[FormulaRow][q];
            int MostValue = 0, MostValueIndex = 0;
            
            bool AddSubVB = false, MulDivVB = false, PowerVB = false,SinCosTanVB = false,rootVB = false;
            bool AddSubPVB = false, MulDivPVB = false, PowerPVB = false, SinCosTanPVB = false, rootPVB = false;


            
            for (int MainLoop; ;)
            {
                
                //I don't want only the parentheses to exist.
                CheckAndCorrect();
                Priortize();
                for (int b = 0; Formula[FormulaRow][b] != null; b++)
                {

                    if (isDecimal.IsMatch(Formula[FormulaRow][b]) || isInteger.IsMatch(Formula[FormulaRow][b]))
                        FormulaValue[b] = Convert.ToDouble(Formula[FormulaRow][b]);
                }
                
                MostValueIndex = 0;
                MostValue = 0;
                for (int a = 0; a < 255; a++)
                {
                    if (MostValue < priority[a])
                    {
                        MostValueIndex = a;
                        MostValue = priority[a];
                    }
                }
                
                //calculation
                bool NomalOperator = false;
                if (Formula[FormulaRow][MostValueIndex] =="+")
                {
                    FormulaValue[MostValueIndex - 1] = FormulaValue[MostValueIndex - 1] + FormulaValue[MostValueIndex + 1];
                    if (FormulaMethod.Checked)
                    {
                        FormulaRow++;
                        for (int a = 0; a < 255; a++)
                        {
                            Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                        }
                    }
                    Debug.Text = Formula[FormulaRow][MostValueIndex] + "|" + MostValueIndex + "|" + priority[2] + "|" + priority[3] + "|"
                        + priority[4] + "|" + priority[5] + "|" + priority[6] + "|" + priority[7] + "|" + priority[8];
                    Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();

                    

                    NomalOperator = true;
                }
                else if (Formula[FormulaRow][MostValueIndex] =="-")
                {
                    FormulaValue[MostValueIndex - 1] = FormulaValue[MostValueIndex - 1] - FormulaValue[MostValueIndex + 1];
                    if (FormulaMethod.Checked)
                    {
                        FormulaRow++;
                        for (int a = 0; a < 255; a++)
                        {
                            Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                        }
                    }
                    Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();

                    

                    NomalOperator = true;
                }
                else if (Formula[FormulaRow][MostValueIndex] =="*")
                {
                    FormulaValue[MostValueIndex - 1] = FormulaValue[MostValueIndex - 1] * FormulaValue[MostValueIndex + 1];
                    if (FormulaMethod.Checked)
                    {
                        FormulaRow++;
                        for (int a = 0; a < 255; a++)
                        {
                            Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                        }
                    }
                    Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();

                   

                    NomalOperator = true;
                }
                else if (Formula[FormulaRow][MostValueIndex] == "/")
                {
                    if (FormulaValue[MostValueIndex + 1] != 0)
                    {
                        FormulaValue[MostValueIndex - 1] = FormulaValue[MostValueIndex - 1] / FormulaValue[MostValueIndex + 1];
                        if (FormulaMethod.Checked)
                        {
                            FormulaRow++;
                            for (int a = 0; a < 255; a++)
                            {
                                Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                            }
                        }
                        Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();

                       

                    }
                    else
                    {
                        //Error
                        for (int i = 0; i < FormulaValue.Length; i++)
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
                    if (FormulaMethod.Checked)
                    {
                        FormulaRow++;
                        for (int a = 0; a < 255; a++)
                        {
                            Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                        }
                    }
                    Formula[FormulaRow][MostValueIndex - 1] = FormulaValue[MostValueIndex - 1].ToString();

                    NomalOperator = true;
                }
                else if (Formula[FormulaRow][MostValueIndex] == "sin")
                {
                    
                    FormulaValue[MostValueIndex] = Math.Sin(Math.PI * FormulaValue[MostValueIndex + 2] / 180.0);
                    if (FormulaMethod.Checked)
                    {
                        FormulaRow++;
                        for (int a = 0; a < 255; a++)
                        {
                            Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                        }
                    }
                    Formula[FormulaRow][MostValueIndex] = FormulaValue[MostValueIndex].ToString();
                    MoveToArrayItem(FormulaRow, MostValueIndex + 3, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, MostValueIndex + 2, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, MostValueIndex + 1, "Formula", "Left");

                    MoveToArrayItem(FormulaRow, MostValueIndex + 3, "FormulaValue", "Left", FormulaValue);
                    MoveToArrayItem(FormulaRow, MostValueIndex + 2, "FormulaValue", "Left", FormulaValue);
                    MoveToArrayItem(FormulaRow, MostValueIndex + 1, "FormulaValue", "Left", FormulaValue);

                    if (FormulaMethod.Checked)
                    {
                        ResultsItem = new ListViewItem();
                        ResultsItem.Text = "->";
                        for (int c = 0; c < 255; c++) ResultsItem.Text += Formula[FormulaRow][c];
                        CalculationResult.Items.Add(ResultsItem);
                    }
                }
                else if (Formula[FormulaRow][MostValueIndex] == "cos")
                {
                    FormulaValue[MostValueIndex] = Math.Cos(Math.PI * FormulaValue[MostValueIndex + 2] / 180.0);
                    if (FormulaMethod.Checked)
                    {
                        FormulaRow++;
                        for (int a = 0; a < 255; a++)
                        {
                            Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                        }
                    }
                    Formula[FormulaRow][MostValueIndex] = FormulaValue[MostValueIndex].ToString();
                    MoveToArrayItem(FormulaRow, MostValueIndex + 3, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, MostValueIndex + 2, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, MostValueIndex + 1, "Formula", "Left");

                    MoveToArrayItem(FormulaRow, MostValueIndex + 3, "FormulaValue", "Left", FormulaValue);
                    MoveToArrayItem(FormulaRow, MostValueIndex + 2, "FormulaValue", "Left", FormulaValue);
                    MoveToArrayItem(FormulaRow, MostValueIndex + 1, "FormulaValue", "Left", FormulaValue);

                    if (FormulaMethod.Checked)
                    {
                        ResultsItem = new ListViewItem();
                        ResultsItem.Text = "->";
                        for (int c = 0; c < 255; c++) ResultsItem.Text += Formula[FormulaRow][c];
                        CalculationResult.Items.Add(ResultsItem);
                    }
                }
                else if (Formula[FormulaRow][MostValueIndex] == "tan")
                {
                    FormulaValue[MostValueIndex] = Math.Tan(Math.PI * FormulaValue[MostValueIndex + 2] / 180.0);
                    if (FormulaMethod.Checked)
                    {
                        FormulaRow++;
                        for (int a = 0; a < 255; a++)
                        {
                            Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                        }
                    }
                    Formula[FormulaRow][MostValueIndex] = FormulaValue[MostValueIndex].ToString();
                    MoveToArrayItem(FormulaRow, MostValueIndex + 3, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, MostValueIndex + 2, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, MostValueIndex + 1, "Formula", "Left");

                    MoveToArrayItem(FormulaRow, MostValueIndex + 3, "FormulaValue", "Left", FormulaValue);
                    MoveToArrayItem(FormulaRow, MostValueIndex + 2, "FormulaValue", "Left", FormulaValue);
                    MoveToArrayItem(FormulaRow, MostValueIndex + 1, "FormulaValue", "Left", FormulaValue);

                    if (FormulaMethod.Checked)
                    {
                        ResultsItem = new ListViewItem();
                        ResultsItem.Text = "->";
                        for (int c = 0; c < 255; c++) ResultsItem.Text += Formula[FormulaRow][c];
                        CalculationResult.Items.Add(ResultsItem);
                    }
                }
                else if (Formula[FormulaRow][MostValueIndex] == "√")
                {
                    FormulaValue[MostValueIndex] = Math.Sqrt(FormulaValue[MostValueIndex + 2]);
                    if (FormulaMethod.Checked)
                    {
                        FormulaRow++;
                        for (int a = 0; a < 255; a++)
                        {
                            Formula[FormulaRow][a] = Formula[FormulaRow - 1][a];
                        }
                    }
                    Formula[FormulaRow][MostValueIndex] = FormulaValue[MostValueIndex].ToString();

                    MoveToArrayItem(FormulaRow, MostValueIndex + 3, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, MostValueIndex + 2, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, MostValueIndex + 1, "Formula", "Left");

                    MoveToArrayItem(FormulaRow, MostValueIndex + 3, "FormulaValue", "Left", FormulaValue);
                    MoveToArrayItem(FormulaRow, MostValueIndex + 2, "FormulaValue", "Left", FormulaValue);
                    MoveToArrayItem(FormulaRow, MostValueIndex + 1, "FormulaValue", "Left", FormulaValue);
                    if (FormulaMethod.Checked)
                    {
                        ResultsItem = new ListViewItem();
                        ResultsItem.Text = "->";
                        for (int c = 0; c < 255; c++) ResultsItem.Text += Formula[FormulaRow][c];
                        CalculationResult.Items.Add(ResultsItem);
                    }
                    
                }
                else
                {
                    
                    if(Formula[FormulaRow][0] == "(")
                    {
                        Formula[FormulaRow][0] = Formula[FormulaRow][1];
                        FormulaValue[0] = FormulaValue[1];
                    }
                    //finish!



                    ResultsItem = new ListViewItem(">" + FormulaValue[0].ToString());
                    CalculationResult.Items.Add(ResultsItem);
                    Results = FormulaValue[0];

                    
                    for (int i = 0; i < FormulaValue.Length; i++)
                    {
                        for (FormulaRow = 0; FormulaRow < 255; FormulaRow++) Formula[FormulaRow][i] = null;
                        FormulaValue[i] = 0;
                        priority[i] = 0;
                        Output[i] = null;

                    }
                    FormulaRow = 0;
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
                    for (int i = MostValueIndex; i < 252; i += 2)
                    {
                        Formula[FormulaRow][i] = Formula[FormulaRow][i + 2];
                        Formula[FormulaRow][i + 1] = Formula[FormulaRow][i + 3];

                        FormulaValue[i] = FormulaValue[i + 2];
                        FormulaValue[i + 1] = FormulaValue[i + 3];

                        
                    }
                    if (FormulaMethod.Checked && Formula[FormulaRow][1] != null)
                    {
                        ResultsItem = new ListViewItem();
                        ResultsItem.Text = "->";
                        for (int c = 0; c < 255; c++) ResultsItem.Text += Formula[FormulaRow][c];
                        CalculationResult.Items.Add(ResultsItem);
                    }
                }


            }


        }
        /*void ParenthesesFanction()
        {
            for (int i = 0; i < Formula.Length; i++)
            {
                if (Formula[FormulaRow][i] == "(")
                {
                    if (Formula[FormulaRow][i + 1] == ")")
                    {
                        for (int a = i; a < 253; a += 2)
                        {
                            Formula[FormulaRow][a]     = Formula[FormulaRow][a + 2];
                            Formula[FormulaRow][a + 1] = Formula[FormulaRow][a + 3];
                        }
                    }
                    if (Formula[FormulaRow][i + 2] == ")")
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
        }*/
        int LeftParenthesisValue;
        void Priortize()
        {
            for (int i = 0; i < Formula.Length; i++) priority[i] = 0;

            LeftParenthesisValue = 0;
            for (int i = 0; i < 252; i++)
            {
                if (Formula[FormulaRow][i] == "(") LeftParenthesisValue += 20;
                if (Formula[FormulaRow][i] == ")") LeftParenthesisValue -= 20;
                if (Formula[FormulaRow][i] == "+" || Formula[FormulaRow][i] == "-") priority[i] = AddSubV + LeftParenthesisValue;
                if (Formula[FormulaRow][i] == "*" || Formula[FormulaRow][i] == "/") priority[i] = MulDivV + LeftParenthesisValue;
                if (Formula[FormulaRow][i] == "^") priority[i] = PowerV + LeftParenthesisValue;
                if (Formula[FormulaRow][i + 1] == "(" && Formula[FormulaRow][i + 3] == ")" )
                {
                    if(Formula[FormulaRow][i] == "sin" || Formula[FormulaRow][i] == "cos" || Formula[FormulaRow][i] == "tan")
                        priority[i] = SinCosTanV + LeftParenthesisValue;
                    if (Formula[FormulaRow][i] == "√")
                        priority[i] = rootV + LeftParenthesisValue;
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
            SinC = true;
            CosC = true;
            TanC = true;
            rootC = true;
            OkC = false;

            for (int d = 0; d < TempFormula.Length; d++)
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
                        SinC = true;
                        CosC = true;
                        TanC = true;
                        rootC = true;
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
                        SinC = true;
                        CosC = true;
                        TanC = true;
                        rootC = true;
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
                        SinC = true;
                        CosC = true;
                        TanC = true;
                        rootC = true;
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
                        SinC = true;
                        CosC = true;
                        TanC = true;
                        rootC = true;
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
                        SinC = true;
                        CosC = true;
                        TanC = true;
                        rootC = true;
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
                        LeftParenthesisC = true;   // (
                        RightParenthesisC = false;  // )
                        EqualsC = false;            // =
                        DecimalPointC = false;      // .
                        SinC = true;
                        CosC = true;
                        TanC = true;
                        OkC = true;
                        rootC = true;
                        Formula[FormulaRow][FormulaColumn] = "^";
                    }
                }
                else if (CTF == "(" || CTF == "（")
                {
                    if (LeftParenthesisC)
                    {
                        ValueC = true;              // 0123456789
                        AddC = true;               // +
                        SubtractC = true;          // -
                        MultiplyC = false;          // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParenthesisC = false;   // (
                        RightParenthesisC = true;   // )
                        EqualsC = false;            // =
                        DecimalPointC = false;      // .
                        OkC = true;
                        SinC = true;
                        CosC = true;
                        TanC = true;
                        rootC = true;
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
                        PowerC = true ;             // ^
                        LeftParenthesisC = false;   // (
                        RightParenthesisC = true;  // )
                        EqualsC = true;             // =
                        DecimalPointC = false;      // .
                        SinC = true;
                        CosC = true;
                        TanC = true;
                        rootC = true;
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
                        SinC = false;
                        CosC = false;
                        TanC = false;
                        rootC = false;
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = ".";
                    }
                }
                else if (CTF == "s" || CTF == "S")
                {
                    if (SinC)
                    {
                        ValueC = false;               // 0123456789
                        AddC = false;                // +
                        SubtractC = false;           // -
                        MultiplyC = false;           // x
                        DivideC = false;             // ÷
                        PowerC = false;              // ^
                        LeftParenthesisC = true;    // (
                        RightParenthesisC = false;   // )
                        EqualsC = false;             // =
                        DecimalPointC = false;       // .[
                        SinC = false;
                        CosC = false;
                        TanC = false;
                        rootC = false;
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "s";
                        if (TempFormulaArray[FormulaColumn + 1] =="i" || TempFormulaArray[FormulaColumn + 1] =="I")
                        {
                            FormulaColumn++;
                            Formula[FormulaRow][FormulaColumn] = "i";
                        }
                        if (TempFormulaArray[FormulaColumn + 1] =="n" || TempFormulaArray[FormulaColumn + 1] =="N")
                        {
                            FormulaColumn++;
                            Formula[FormulaRow][FormulaColumn] = "n";
                        }
                        
                    }
                }
                else if (CTF == "c" || CTF == "C")
                {
                    if (CosC)
                    {
                        ValueC = false;               // 0123456789
                        AddC = false;                // +
                        SubtractC = false;           // -
                        MultiplyC = false;           // x
                        DivideC = false;             // ÷
                        PowerC = false;              // ^
                        LeftParenthesisC = true;    // (
                        RightParenthesisC = false;   // )
                        EqualsC = false;             // =
                        DecimalPointC = false;       // .[
                        SinC = false;
                        CosC = false;
                        TanC = false;
                        rootC = false;
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "c";
                        if (TempFormulaArray[FormulaColumn + 1] =="o" || TempFormulaArray[FormulaColumn + 1] =="O")
                        {
                            FormulaColumn++;
                            Formula[FormulaRow][FormulaColumn] = "o";
                        }
                        if (TempFormulaArray[FormulaColumn + 1] =="s" || TempFormulaArray[FormulaColumn + 1] =="S")
                        {
                            FormulaColumn++;
                            Formula[FormulaRow][FormulaColumn] = "s";
                        }
                    }
                }
                else if (CTF == "t" || CTF == "T")
                {
                    if (TanC)
                    {
                        ValueC = false;               // 0123456789
                        AddC = false;                // +
                        SubtractC = false;           // -
                        MultiplyC = false;           // x
                        DivideC = false;             // ÷
                        PowerC = false;              // ^
                        LeftParenthesisC = true;    // (
                        RightParenthesisC = false;   // )
                        EqualsC = false;             // =
                        DecimalPointC = false;       // .[
                        SinC = false;
                        CosC = false;
                        TanC = false;
                        rootC = false;
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "t";
                        if (TempFormulaArray[FormulaColumn + 1] =="a" || TempFormulaArray[FormulaColumn + 1] =="A")
                        {
                            FormulaColumn++;
                            Formula[FormulaRow][FormulaColumn] = "a";
                        }
                        if (TempFormulaArray[FormulaColumn + 1] =="n" || TempFormulaArray[FormulaColumn + 1] =="N")
                        {
                            FormulaColumn++;
                            Formula[FormulaRow][FormulaColumn] = "n";
                        }
                    }
                }
                else if (CTF == "√" || CTF == "√")
                {
                    if (rootC)
                    {
                        ValueC = false;               // 0123456789
                        AddC = false;                // +
                        SubtractC = false;           // -
                        MultiplyC = false;           // x
                        DivideC = false;             // ÷
                        PowerC = false;              // ^
                        LeftParenthesisC = true;    // (
                        RightParenthesisC = false;   // )
                        EqualsC = false;             // =
                        DecimalPointC = false;       // .[
                        SinC = false;
                        CosC = false;
                        TanC = false;
                        rootC = false;
                        OkC = true;
                        Formula[FormulaRow][FormulaColumn] = "√";
                    }
                }
                
                if (OkC == false && CTF != null)
                {
                    MessageBox.Show("There is an error --If this is a puzzling error, please let the author know!");
                    
                    /*for (int errorvalue = 0; errorvalue < 255; errorvalue++) Debug.Text += Formula[FormulaRow][errorvalue];*/
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
            
            if (Formula[FormulaRow][0] == "+" || Formula[FormulaRow][0] == "-")
            {
                if (Formula[FormulaRow][0] == "+") Formula[FormulaRow][1] = null;
                if (Formula[FormulaRow][0] == "-") Formula[FormulaRow][1] = "-" + Formula[FormulaRow][1];

                for (int i = 0; i < TempFormula.Length + 1; i++)
                {
                        Formula[FormulaRow][i] = Formula[FormulaRow][i + 1];
                }
            }
            for (int i = 0; i < TempFormula.Length; i++)
            {
                
                
                //もし括弧だったら
                if (Formula[FormulaRow][i] == "(")
                {
                    //もし括弧の次が-または＋だったら
                    if (Formula[FormulaRow][i + 1] == "-")
                    {
                        //-Vの形にします V = Value
                        Formula[FormulaRow][i + 1] += Formula[FormulaRow][i + 2];
                        MoveToArrayItem(FormulaRow, i + 2, "Formula", "Left");
                    }
                    else if (Formula[FormulaRow][i + 1] == "+")
                    {
                        //+Vの形にします V = Value
                        Formula[FormulaRow][i + 1] = Formula[FormulaRow][i + 2];
                        MoveToArrayItem(FormulaRow, i + 2, "Formula", "Left");
                    }

                }
                //もしsだったらsinにする その他同じ
                if (Formula[FormulaRow][i] == "s" && Formula[FormulaRow][i + 1] == "i")
                {
                    MoveToArrayItem(FormulaRow, i + 2, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, i + 1, "Formula", "Left");
                    Formula[FormulaRow][i] += "i";
                    Formula[FormulaRow][i] += "n";

                }
                else if (Formula[FormulaRow][i] == "c" && Formula[FormulaRow][i + 1] == "o")
                {
                    MoveToArrayItem(FormulaRow, i + 2, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, i + 1, "Formula", "Left");
                    Formula[FormulaRow][i] += "o";
                    Formula[FormulaRow][i] += "s";
                }
                else if (Formula[FormulaRow][i] == "t" && Formula[FormulaRow][i + 1] == "a")
                {
                    MoveToArrayItem(FormulaRow, i + 2, "Formula", "Left");
                    MoveToArrayItem(FormulaRow, i + 1, "Formula", "Left");
                    Formula[FormulaRow][i] += "a";
                    Formula[FormulaRow][i] += "n";
                }
                //もしsincostanのどれかの後ろが数値だったら*を入れる
                if (Formula[FormulaRow][i + 4] != null)//i + 4で配列に触るのでnullになる危険性がある
                    if (Formula[FormulaRow][i] == "sin" || Formula[FormulaRow][i] == "cos" || Formula[FormulaRow][i] == "tan")
                    {
                        if (Formula[FormulaRow][i + 4].All(char.IsDigit) && Formula[FormulaRow][i + 3] == ")")
                        {
                            MoveToArrayItem(FormulaRow, i + 4 , "Formula", "Right");
                            Formula[FormulaRow][i + 4] = "*";
                        }
                    }
                if (i != 0)//i - 1で配列に触るので0はインデックス外となる
                    if (Formula[FormulaRow][i] == "sin" || Formula[FormulaRow][i] == "cos" || Formula[FormulaRow][i] == "tan")
                    {
                        if (Formula[FormulaRow][i - 1].All(char.IsDigit) && Formula[FormulaRow][i + 3] == ")")
                        {
                            MoveToArrayItem(FormulaRow, i, "Formula", "Right");
                            Formula[FormulaRow][i] = "*";
                        }
                    }
                //もし)の次が数値だったら" ) * V "にする
                if (Formula[FormulaRow][i + 1] != null)
                    if (isDecimal.IsMatch(Formula[FormulaRow][i + 1]) || isInteger.IsMatch(Formula[FormulaRow][i + 1]))
                    {
                        if (Formula[FormulaRow][i] == ")")
                        {
                            MoveToArrayItem(FormulaRow, i + 1, "Formula", "Right");
                            Formula[FormulaRow][i + 1] = "*";
                        }

                    }
                //もし(または√の前が数値だったら
                if (i != 0 && Formula[FormulaRow][i - 1] != null) //i - 1で配列に触るので0はインデックス外となる
                    if (isDecimal.IsMatch(Formula[FormulaRow][i - 1]) || isInteger.IsMatch(Formula[FormulaRow][i - 1]))
                    {
                        if (Formula[FormulaRow][i] == "(")
                        {
                            MoveToArrayItem(FormulaRow, i, "Formula", "Right");
                            Formula[FormulaRow][i] = "*";
                        }
                        if (Formula[FormulaRow][i] == "√")
                        {
                            MoveToArrayItem(FormulaRow, i, "Formula", "Right");
                            Formula[FormulaRow][i] = "*";
                        }
                    }
                
                //------------------------------------------Check関数の後ろにあるコードたち-----------------------------------------------------
                //もし()が数値しか入っていなかったら
                if (Formula[FormulaRow][i] == "(" && Formula[FormulaRow][i + 2] == ")" )
                {
                    if(i != 0)
                    {
                        if(Formula[FormulaRow][i - 1] == "sin" || Formula[FormulaRow][i - 1] == "cos" || Formula[FormulaRow][i - 1] == "tan")
                        {
                            //Nothing
                        }
                        else if(Formula[FormulaRow][i - 1] == "√")
                        {
                            //Nothing
                        }
                        else
                        {
                            Formula[FormulaRow][i] = Formula[FormulaRow][i + 1];
                            MoveToArrayItem(FormulaRow, i + 2, "Formula", "Left");
                            MoveToArrayItem(FormulaRow, i + 1, "Formula", "Left");
                        }
                    }
                    else
                    {
                        Formula[FormulaRow][i] = Formula[FormulaRow][i + 1];
                        MoveToArrayItem(FormulaRow, i + 2, "Formula", "Left");
                        MoveToArrayItem(FormulaRow, i + 1, "Formula", "Left");
                    }
                        
                }

            
                //for(i)の終わり
                }
            


        }
        void CombiningNumberString()
        {
            
            int j = 1, b;
            for (int i = 0; i<230; i++)
            {
                if (Formula[FormulaRow][i] != null)
                {
                    if (Formula[FormulaRow][i + 1] != null)
                    {
                        
                        if (isInteger.IsMatch(Formula[FormulaRow][i]) && isInteger.IsMatch(Formula[FormulaRow][i + 1]))
                        {
                            
                            for (j = 1; ; j++)
                            {
                                if (Formula[FormulaRow][j + i] != null)
                                {
                                    
                                    if (isInteger.IsMatch(Formula[FormulaRow][i + j]))
                                        Formula[FormulaRow][i] += Formula[FormulaRow][i + j];
                                    else break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            for (int a = j - 1; a != 0; a--)
                            {
                                MoveToArrayItem(FormulaRow, a + i, "Formula", "Left");
                            }
                        }
                    }
                }
                if (Formula[FormulaRow][i] != null) { 
                    if (isInteger.IsMatch(Formula[FormulaRow][i]) && Formula[FormulaRow][i + 1] == ".")
                    {
                        Formula[FormulaRow][i] += Formula[FormulaRow][i + 1];
                        for (b = 2; ; b++)
                        {
                            if (Formula[FormulaRow][i + b] != null)
                            {
                                if (isInteger.IsMatch(Formula[FormulaRow][i + b]))
                                    Formula[FormulaRow][i] += Formula[FormulaRow][i + b];
                                else break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int a = b - 1; a != 0; a--)
                        {
                            MoveToArrayItem(FormulaRow, a + i, "Formula", "Left");
                        }
                    }
                }
            }
            
        }
        /// <summary>
        /// 配列の行、列、配列名、方向を入れてください
        /// データを入力した列から一行ずつ左に詰めます Formula FormulaValue
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Position"></param>
        /// <param name="array"></param>
        void MoveToArrayItem(int Row , int Position, string array,string direction, double[] ValueArray = null)
        {//配列のアイテムを詰めたり開けたりする関数
            if(array == "Formula")
            {
                if(direction == "Left")
                {
                    for (int i = Position; i < 254; i++)
                    {
                        Formula[Row][i] = Formula[Row][i + 1];
                    }
                }
                if(direction == "Right")
                {
                    for(int i = 254; i != Position ; i--)
                    {
                        Formula[Row][i] = Formula[Row][i - 1];
                    }
                }
            }
            if(array == "FormulaValue")
            {
                if(direction == "Left")
                {
                    for (int i = Position; i < 254; i++)
                    {
                        ValueArray[i] = ValueArray[i + 1];
                    }
                }
                if(direction == "Right")
                {
                    for (int i = 254; i != Position || i != 0; i--)
                    {
                        ValueArray[i] = ValueArray[i - 1];
                    }
                }
            }
        }

    }
}


