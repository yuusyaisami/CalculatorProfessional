/*
 *      プログラムのアルゴリズム
 *  実行ボタンを押す
 *  ボックスが空じゃないか確認
 *  入力された文字を、1文字ずつ配列に入れる。
 *  配列の中の演算子や数値を、まとめる
 *  数式の中に変数が含まれていないか確認する
 *  含まれている場合
 *  数式の計算方法を変える
 *  含まれていない場合
 *  以下の処理
 *  計算の順番を決める、
 *  計算する
 *  文字が一つになったら終わる
 *  初期化
 *  変数ありの場合
 *  xを仮に1として考え、
 *  変数がある方とないほうに分けて、
 *  掛け算と割り算をする
 *  変数とかかわりのなかった数値を変数の存在しない方の式に移行する
 *  変数を数値の分だけ答えと割る
 *  変数が割り算のとき分母にあるか確認する
 *  
 *  あった場合は答えの分母と分子をひっくり返す
 *  
 *  
 *  
 *  
 */

using NAudio.Wave;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using NAudio.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculatorPro
{

    public partial class CalculatorForm : Form
    {

        string FirstFormulaString;
        int TryParseTempValue = 0;
        bool Error = false;
        private void Information_Click(object sender, EventArgs e)
        {
            if (CalculationMethodPicture.Visible == true)
            {
                CalculationMethodPicture.Visible = false;
                OpenTheMyGitHubText.Visible = false;
            }
            else if (CalculationMethodPicture.Visible == false && SettingControl.Visible == false)
            {
                CalculationMethodPicture.Visible = true;
                OpenTheMyGitHubText.Visible = true;
            }
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            CalculationMethodPicture.Visible = false;
            OpenTheMyGitHubText.Visible = false;
            if (SettingControl.Visible == true)
            {
                SettingControl.Visible = false;
            }

            else
            {
                SettingControl.Visible = true;
            }
                
        }

        private void CalculationFormula_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculationMethodPicture_Click(object sender, EventArgs e)
        {
            OpenUrl("https://github.com/yuusyaisami/CalculatorProfessional");
        }

        float audioVolume = 20f;
        private void SoundVolumeBar_Scroll(object sender, EventArgs e)
        {
            int value;
            value = SoundVolumeBar.Value;
            SoundValue.Text = value.ToString();
            audioVolume = SoundVolumeBar.Value;
        }

        private void CalculationFormulaText_Click(object sender, EventArgs e)
        {
            PlaySound("SoundFile/ououolu.wav");
        }

        public CalculatorForm()
        {
            InitializeComponent();
            for (int i = 0; i < 300; i++)
            {
                Formula[i] = new string[300];
                for (int j = 0; j < 300; j++)
                {
                    Formula[i][j] = null;
                }
            }
            //Error0 
        }
        private void ChengeLang(int L)
        {
            if (L == 0)
            {
                Setting.Text = "Setting";
                Information.Text = "information";
                Calculation.Text = "Calculation";
                display.Text = "Display";
                Settingtab.Text = "Setting";
                Infotab.Text = "Info";
                DecimalPoint.Text = "Round the answer";
                OutPutType.Text = "Output the formula you typed.";
                FormulaMethod.Text = "Output the calculation procedure";
                SoundVolume.Text = "Sound volume";
                LanguageText.Text = "Language";
                ArithmeticMenu.Text = "four arithmetic operators";
                SpecialMenu.Text = "Slightly special calculation";
                OpenTheMyGitHubText.Text = "↑ Open the my github! ↑";
            }
            else if(L == 1)
            {
                Setting.Text = "設定";
                Information.Text = "情報";
                Calculation.Text = "計算";
                display.Text = "表示";
                Settingtab.Text = "システム設定";
                Infotab.Text = "ヒント";
                DecimalPoint.Text = "小数点の位置";
                OutPutType.Text = "ユーザーの入力した計算式をそのまま出力する";
                FormulaMethod.Text = "途中式も出力する";
                SoundVolume.Text = "音量";
                LanguageText.Text = "言語";
                ArithmeticMenu.Text = "通常の演算子";
                SpecialMenu.Text = "特殊な演算子";
                OpenTheMyGitHubText.Text = "↑ クリックしてgithubを開こう! ↑";
            }
        }
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
        string[][] Formula = new string[300][];
        string[] StringTable = new string[300];
        private void RunBtn_Click(object sender, EventArgs e)
        {

            CheckTextBox();
            if (Error == false)
            {
                ArrayFormula();
                StringJoin();
                DetailSetting();
                if (Error == false)
                {
                    /*Debug.Text = Formula[0][0] + "|" + Formula[0][1] + "|" + Formula[0][2] + "|" + Formula[0][3] + "|" + Formula[0][4] + 
                        "|" + Formula[0][5] + "|" + Formula[0][6] + "|" + Formula[0][7] +  "|" + Formula[0][8] + "|" + Formula[0][9];   */
                    
                    Calculations.CalculationFunctions.MainCalculation(StringFormula, ref Formula);
                    OutPut();
                }
            }
            Format(false);
            
        }
        
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //関数
        

        private void sin_Click(object sender, EventArgs e)
        {
            
        }

        string[] StringFormula = new string[300];
        /// <summary>
        /// データをリセットする
        /// </summary>
        /// <param name="ErrorFormat">Errorをtrueにするかfalseにするか</param>
        void Format(bool ErrorFormat)
        {
            for(int i = 0; i < 300; i++)
            {
                for(int j = 0; j < 300;j++)
                {
                    Formula[i][j] = null;
                }
                StringFormula[i] = null;
                FirstFormulaString = null;
            }
            if (ErrorFormat)
            {
                Error = true;
            }
            else
            {
                Error = false;
            }
        }
        void OutPut()
        {
            ListViewItem ResultsItem = new ListViewItem();
            if (OutPutType.Checked)
            {
                ResultsItem = new ListViewItem(">>" + FirstFormulaString.ToString());
            }
            else
            {
                ResultsItem = new ListViewItem(">>");
                for(int i = 0; i < StringFormula.Length; i++)
                {
                    ResultsItem.Text += StringFormula[i];
                }
            }

            CalculationResult.Items.Add(ResultsItem);
            if (FormulaMethod.Checked)
            {
                for (int j = 0; ; j++)
                {
                    if (Formula[j][0] == ">")
                    {
                        ResultsItem = new ListViewItem(">");
                        if (DecimalPoint.Checked)
                        {
                            double value = Math.Round(Convert.ToSingle(Formula[j][1]), decimal.ToInt32(RoundUpDown.Value), MidpointRounding.AwayFromZero);
                            ResultsItem.Text += value;
                        }
                        else
                        {
                            ResultsItem.Text += Formula[j][1];
                        }
                        CalculationResult.Items.Add(ResultsItem);
                        break;
                    }
                    ResultsItem = new ListViewItem("->");
                    for (int i = 0; Formula[j][i] != null; i++)
                    {
                        ResultsItem.Text += Formula[j][i];
                    }
                    CalculationResult.Items.Add(ResultsItem);
                }
            }
            else
            {
                for (int j = 0; ; j++)
                {
                    if (Formula[j][0] == ">")
                    {
                        ResultsItem = new ListViewItem(">");
                        ResultsItem.Text += Formula[j][1].ToString();
                        CalculationResult.Items.Add(ResultsItem);
                        break;
                    }
                }
            }

        }
        bool ValueC, AddC, SubC, MultC, DivideC, PowerC, LeftParentC, RightParentC, EqualsC, DecimalPointC, SinC, CosC, TanC, RootC, CheckedC, VariableC, PaiC, logC,log10C,log2C;
        int Lang;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedItem = comboBox1.SelectedItem.ToString();
            if(SelectedItem == "English")
            {
                Lang = 0;
            }
            else if(SelectedItem == "Japanese")
            {
                Lang = 1;
            }
            ChengeLang(Lang);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CalculationResult.SelectedItems != null && CalculationResult.SelectedItems.Count > 0)
            {
                CalculationResult.Items.Remove(CalculationResult.SelectedItems[0]);
            }
        }

        /// <summary>
        /// FirstFormulaStringの内容を配列に入れる、その時入力された文字が有効か確かめる
        /// </summary>
        void ArrayFormula()
        {
            string TempFirstFormula;
            int FormulaColumn = 0;

            //これは初期値です、最初の演算子や数値の条件です
            ValueC = true;             // 0123456789
            AddC = true;               // +
            SubC = true;                // -
            MultC = false;              // x
            DivideC = false;            // ÷
            PowerC = false;             // ^
            LeftParentC = true;         // (
            RightParentC = false;       // )
            EqualsC = false;            // =
            DecimalPointC = false;      // .
            SinC = true;                // sin
            CosC = true;                // cos
            TanC = true;                // tan
            RootC = true;               // root
            VariableC = true;           // X or Y
            PaiC = true;                //π
            CheckedC = false;           // Ok
            for(; FormulaColumn < FirstFormulaString.Length; FormulaColumn++)
            {
                TempFirstFormula = FirstFormulaString[FormulaColumn].ToString();
                bool CheckValue = int.TryParse(TempFirstFormula, out TryParseTempValue);
                CheckedC = false;
                //数値だった場合
                if (CheckValue && ValueC )
                {
                    for(int Index = 0; Index < 10; Index++)
                    {
                        if(Index.ToString() == TempFirstFormula)
                        {
                            //次に許可される演算子
                            ValueC = true;             // 0123456789
                            AddC = true;               // +
                            SubC = true;                // -
                            MultC = true;              // x
                            DivideC = true;            // ÷
                            PowerC = true;             // ^
                            LeftParentC = true;         // (
                            RightParentC = true;       // )
                            EqualsC = true;            // =
                            DecimalPointC = true;      // .
                            SinC = true;                // sin
                            CosC = true;                // cos
                            TanC = true;                // tan
                            RootC = true;               // root
                            VariableC = true;           // X or Y
                            PaiC = true;                //π
                            CheckedC = true;           // Ok
                            StringFormula[FormulaColumn] = TempFirstFormula;
                        }
                    }
                }
                else if(AddC && TempFirstFormula == "+" || TempFirstFormula == "＋")
                {
                    ValueC = true;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = true;         // (
                    RightParentC = false;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = true;           // X or Y
                    EqualsC = false;            // =
                    PaiC = true;                //π
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "+";
                }
                else if(SubC && TempFirstFormula == "-" ||  TempFirstFormula == "ー")
                {
                    ValueC = true;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = true;         // (
                    RightParentC = false;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = true;           // X or Y
                    PaiC = true;                //π
                    CheckedC = true;           // Ok
                    EqualsC = false;            // =
                    StringFormula[FormulaColumn] = "-";
                }
                else if (MultC && TempFirstFormula == "*" ||  TempFirstFormula == "・")
                {
                    ValueC = true;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = true;         // (
                    RightParentC = false;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = true;           // X or Y
                    PaiC = true;                //π
                    EqualsC = false;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "*";
                }
                else if(DivideC && TempFirstFormula == "/" ||  TempFirstFormula == "÷")
                {
                    ValueC = true;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = true;         // (
                    RightParentC = true;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = true;           // X or Y
                    PaiC = true;                //π
                    EqualsC = false;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "/";
                }
                else if (DivideC && TempFirstFormula == "%" ||  TempFirstFormula == "％")
                {
                    ValueC = true;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = true;         // (
                    RightParentC = true;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = true;           // X or Y
                    PaiC = true;                //π
                    EqualsC = false;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "%";
                }
                else if(PowerC && TempFirstFormula == "^")
                {
                    ValueC = true;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = true;         // (
                    RightParentC = true;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = true;           // X or Y
                    PaiC = true;                //π
                    EqualsC = false;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "^";
                }
                else if(LeftParentC && TempFirstFormula == "（" || TempFirstFormula == "(")
                {
                    ValueC = true;             // 0123456789
                    AddC = true;               // +
                    SubC = true;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = true;         // (
                    RightParentC = true;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = true;           // X or Y
                    PaiC = true;                //π
                    EqualsC = false;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "(";
                }
                else if(RightParentC && TempFirstFormula == ")" ||  TempFirstFormula == "）")
                {
                    ValueC = false;             // 0123456789
                    AddC = true;               // +
                    SubC = true;                // -
                    MultC = true;              // x
                    DivideC = true;            // ÷
                    PowerC = true;             // ^
                    LeftParentC = true;         // (
                    RightParentC = true;       // )
                    DecimalPointC = false;      // .
                    SinC = false;                // sin
                    CosC = false;                // cos
                    TanC = false;                // tan
                    RootC = false;               // root
                    VariableC = false;           // X or Y
                    PaiC = true;                //π
                    EqualsC = true;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = ")";
                }
                else if(DecimalPointC && TempFirstFormula == ".")
                {
                    ValueC = true;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = false;         // (
                    RightParentC = false;       // )
                    DecimalPointC = false;      // .
                    SinC = false;                // sin
                    CosC = false;                // cos
                    TanC = false;                // tan
                    RootC = false;               // root
                    VariableC = false;           // X or Y
                    PaiC = false;                //π
                    EqualsC = false;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = ".";
                }
                else if(SinC && TempFirstFormula == "s" || TempFirstFormula == "S") 
                {
                    int TempData = FormulaColumn;
                    int Count = 0;
                    if (FirstFormulaString.Length >= FormulaColumn + 2) 
                    {
                        StringFormula[FormulaColumn] = "s";
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "i" || FirstFormulaString[FormulaColumn].ToString() == "I") 
                        {
                           StringFormula[FormulaColumn] = "i";
                            Count++;
                        }
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "n" || FirstFormulaString[FormulaColumn].ToString() == "N")
                        {
                            StringFormula[FormulaColumn] = "n";
                            Count++;
                        }
                    }
                    if (Count == 2)
                    {
                        ValueC = true;             // 0123456789
                        AddC = false;               // +
                        SubC = false;                // -
                        MultC = false;              // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParentC = true;         // (
                        RightParentC = false;       // )
                        DecimalPointC = false;      // .
                        SinC = true;                // sin
                        CosC = true;                // cos
                        TanC = true;                // tan
                        RootC = true;               // root
                        VariableC = true;           // X or Y
                        EqualsC = false;            // =
                        PaiC = true;                //π
                        CheckedC = true;           // Ok
                    }
                    
                }
                else if(CosC && TempFirstFormula == "c" || TempFirstFormula == "C")
                {
                    int Count = 0;
                    if (FirstFormulaString.Length >= FormulaColumn + 2)
                    {
                        StringFormula[FormulaColumn] = "c";
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "o" || FirstFormulaString[FormulaColumn].ToString() == "O")
                        {
                            StringFormula[FormulaColumn] = "o";
                            Count++;
                        }
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "s" || FirstFormulaString[FormulaColumn].ToString() == "S")
                        {
                            StringFormula[FormulaColumn] = "s";
                            Count++;
                        }
                    }
                    if (Count == 2)
                    {
                        ValueC = true;             // 0123456789
                        AddC = false;               // +
                        SubC = false;                // -
                        MultC = false;              // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParentC = true;         // (
                        RightParentC = false;       // )
                        DecimalPointC = false;      // .
                        SinC = true;                // sin
                        CosC = true;                // cos
                        TanC = true;                // tan
                        RootC = true;               // root
                        VariableC = true;           // X or Y
                        PaiC = true;                //π
                        EqualsC = false;            // =
                        CheckedC = true;           // Ok
                    }
                }
                else if(TanC && TempFirstFormula == "t" || TempFirstFormula == "T") 
                {
                    int Count = 0;
                    if (FirstFormulaString.Length >= FormulaColumn + 2)
                    {
                        StringFormula[FormulaColumn] = "t";
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "a" || FirstFormulaString[FormulaColumn].ToString() == "A")
                        {
                            StringFormula[FormulaColumn] = "a";
                            Count++;
                        }
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "n" || FirstFormulaString[FormulaColumn].ToString() == "N")
                        {
                            StringFormula[FormulaColumn] = "n";
                            Count++;
                        }
                    }
                    if (Count == 2)
                    {
                        ValueC = true;             // 0123456789
                        AddC = false;               // +
                        SubC = false;                // -
                        MultC = false;              // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParentC = true;         // (
                        RightParentC = false;       // )
                        DecimalPointC = false;      // .
                        SinC = true;                // sin
                        CosC = true;                // cos
                        TanC = true;                // tan
                        RootC = true;               // root
                        VariableC = true;           // X or Y
                        PaiC = true;                //π
                        EqualsC = false;            // =
                        CheckedC = true;           // Ok
                    }
                }
                else if(RootC && TempFirstFormula == "√")
                {
                    ValueC = false;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = false;             // ^
                    LeftParentC = true;         // (
                    RightParentC = false;       // )
                    DecimalPointC = false;      // .
                    SinC = false;                // sin
                    CosC = false;                // cos
                    TanC = false;                // tan
                    RootC = false;               // root
                    VariableC = false;           // X or Y
                    PaiC = true;                //π
                    EqualsC = false;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "√";
                }
                else if (TanC && TempFirstFormula == "R" || TempFirstFormula == "r")
                {
                    int Count = 0;
                    if (FirstFormulaString.Length >= FormulaColumn + 3)
                    {
                        
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "o" || FirstFormulaString[FormulaColumn].ToString() == "O")
                        {
                            Count++;
                        }
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "o" || FirstFormulaString[FormulaColumn].ToString() == "O")
                        {
                            Count++;
                        }
                        FormulaColumn++;
                        if (FirstFormulaString[FormulaColumn].ToString() == "t" || FirstFormulaString[FormulaColumn].ToString() == "T")
                        {
                            Count++;
                        }
                    }
                    if (Count == 3)
                    {
                        ValueC = true;             // 0123456789
                        AddC = false;               // +
                        SubC = false;                // -
                        MultC = false;              // x
                        DivideC = false;            // ÷
                        PowerC = false;             // ^
                        LeftParentC = true;         // (
                        RightParentC = false;       // )
                        DecimalPointC = false;      // .
                        SinC = true;                // sin
                        CosC = true;                // cos
                        TanC = true;                // tan
                        RootC = true;               // root
                        VariableC = true;           // X or Y
                        PaiC = true;                //π
                        EqualsC = false;            // =
                        CheckedC = true;           // Ok
                        StringFormula[FormulaColumn] = "√";
                    }
                }
                else if(VariableC &&  TempFirstFormula == "x" || TempFirstFormula == "X" || TempFirstFormula == "y" || TempFirstFormula == "Y")
                {
                    ValueC = false;             // 0123456789
                    AddC = true;               // +
                    SubC = true;                // -
                    MultC = true;              // x
                    DivideC = true;            // ÷
                    PowerC = true;             // ^
                    LeftParentC = true;         // (
                    RightParentC = true;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = false;           // X or Y
                    PaiC = true;                //π
                    EqualsC = true;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "x";
                }
                else if(EqualsC && TempFirstFormula == "=") 
                {
                    ValueC = true;             // 0123456789
                    AddC = false;               // +
                    SubC = false;                // -
                    MultC = false;              // x
                    DivideC = false;            // ÷
                    PowerC = true;             // ^
                    LeftParentC = true;         // (
                    RightParentC = true;       // )
                    DecimalPointC = false;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = false;           // X or Y
                    PaiC = true;                //π
                    EqualsC = true;            // =
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "=";
                }
                else if (PaiC && TempFirstFormula == "π" || TempFirstFormula == "Π" )
                {
                    ValueC = true;             // 0123456789
                    AddC = true;               // +
                    SubC = true;                // -
                    MultC = true;              // x
                    DivideC = true;            // ÷
                    PowerC = true;             // ^
                    LeftParentC = true;         // (
                    RightParentC = true;       // )
                    EqualsC = true;            // =
                    DecimalPointC = true;      // .
                    SinC = true;                // sin
                    CosC = true;                // cos
                    TanC = true;                // tan
                    RootC = true;               // root
                    VariableC = true;           // X or Y
                    PaiC = true;                //π
                    CheckedC = true;           // Ok
                    StringFormula[FormulaColumn] = "π";
                }
                else 
                {
                    //Error
                    FormulaColumn++;
                    if(Lang == 0)
                        MessageBox.Show("index " + FormulaColumn + " is an invalid character");
                    if(Lang == 1)
                        MessageBox.Show(FormulaColumn + "番目の値は有効ではありません!");
                    PlaySound("SoundFile/Erroron.wav");
                    Format(true);
                    break;
                }
                if(CheckedC == false)
                {
                    //Error
                    FormulaColumn++;
                    if (Lang == 0)
                        MessageBox.Show("index " + FormulaColumn + " is an invalid character");
                    if (Lang == 1)
                        MessageBox.Show(FormulaColumn + "番目の値は有効ではありません!");
                    PlaySound("SoundFile/Erroron.wav");
                    Format(true);
                    break;
                }
                
            }

        }
        /// <summary>
        /// 配列の細かな修正
        /// </summary>
        void DetailSetting()
        {
            for(int i = 0;i<StringFormula.Length - 2;i++)
            {
                bool CheckValue = int.TryParse(StringFormula[i], out TryParseTempValue);
                //sin
                if (StringFormula[i]  == "s" || StringFormula[i + 1]  == "i" || StringFormula[i + 2]  == "n")
                {
                    MoveArrayItem(1, i + 2, "string", "Left", StringFormula);
                    MoveArrayItem(1, i + 1, "string", "Left", StringFormula);
                    StringFormula[i] = "sin";
                }
                //cos
                if (StringFormula[i]  == "c" || StringFormula[i + 1]  == "o" || StringFormula[i + 2]  == "s")
                {
                    MoveArrayItem(1, i + 2, "string", "Left", StringFormula);
                    MoveArrayItem(1, i + 1, "string", "Left", StringFormula);
                    StringFormula[i] = "cos";
                }
                //tan
                if (StringFormula[i]  == "t" || StringFormula[i + 1]  == "a" || StringFormula[i + 2]  == "n")
                {
                    MoveArrayItem(1, i + 2, "string", "Left", StringFormula);
                    MoveArrayItem(1, i + 1, "string", "Left", StringFormula);
                    StringFormula[i] = "tan";
                }
                //2sin 2( などだった場合
                if (CheckValue) 
                {
                    if (StringFormula[i + 1] == "(" || StringFormula[i + 1] == "sin" || StringFormula[i + 1] == "cos" || StringFormula[i + 1] == "tan" || StringFormula[i + 1] == "√") 
                    {
                        MoveArrayItem(1, i + 1, "string", "Right", StringFormula);
                        StringFormula[i + 1] = "*";
                    }
                    
                }
                //()()だった時
                if (StringFormula[i] == ")")
                {
                    if (StringFormula[i + 1] == "(") 
                    {
                        MoveArrayItem(1, i + 1, "string", "Right", StringFormula);
                        StringFormula[i + 1] = "*";
                    }
                }
                //(- or (+だった時
                if (StringFormula[i] == "(")
                {
                    if (StringFormula[i + 1] == "-")
                    {
                        double dValue;
                        CheckValue = double.TryParse(StringFormula[i + 2], out dValue);
                        if (CheckValue)
                        {
                            StringFormula[i + 1] = StringFormula[i + 2].Insert(0, "-");

                            MoveArrayItem(1, i + 2, "string", "Left", StringFormula);
                            if (StringFormula[i + 2] == ")")
                            {
                                MoveArrayItem(1, i + 2, "string", "Left", StringFormula);
                                MoveArrayItem(1, i, "string", "Left", StringFormula);
                            }
                        }
                    }
                    
                    if (StringFormula[i + 1] == "+")
                    {
                        double dValue;
                        CheckValue = double.TryParse(StringFormula[i + 2], out dValue);
                        if (CheckValue)
                        {
                            StringFormula[i + 1] = StringFormula[i + 2];
                            MoveArrayItem(1, i + 2, "string", "Left", StringFormula);
                            if (StringFormula[i + 2] == ")")
                            {
                                MoveArrayItem(1, i + 2, "string", "Left", StringFormula);
                                MoveArrayItem(1, i, "string", "Left", StringFormula);
                            }
                        }
                    }

                }
                //sin cos tanの前に数値があったら、括弧をつける
                //通常は括弧をつけて記述するが、省略することもできるようにするためのコード
                if (StringFormula[i] == "sin"||StringFormula[i] == "cos"||StringFormula[i] == "tan")
                {
                    CheckValue = int.TryParse(StringFormula[i + 1], out TryParseTempValue);
                    if(CheckValue)
                    {
                        MoveArrayItem(1, i + 2, "string", "Right", StringFormula);
                        StringFormula[i + 2] = ")";
                        MoveArrayItem(1, i + 1, "string", "Right", StringFormula);
                        StringFormula[i + 1] = "(";
                    }
                }
                CheckValue = int.TryParse(StringFormula[i], out TryParseTempValue);
                //2πだったら
                if (StringFormula[i + 1] == "π" && CheckValue)
                {
                    MoveArrayItem(1, i + 1, "string", "Right", StringFormula);
                    StringFormula[i + 1] += "*";
                }

               

            }
        }
        /// <summary>
        /// 変数の有無を確認する,変数とイコールの数が会わなければ、エラー
        /// </summary>
        /// <returns>True : 変数在り　False : 変数無し</returns>
        bool IsTheVariablePresent()
        {
            int TrueValue = 0;
            for(int i = 0;i < StringFormula.Length;i++)
            {
                if (StringFormula[i] == "x")
                {
                    TrueValue++;
                }
                if (StringFormula[i] == "=") 
                {
                    TrueValue++;
                }
            }
            if(TrueValue == 2)
            {
                return true;
            }
            else if(TrueValue == 0) 
            {
                return false;
            }
            else
            {
                //Error
            }
            return false;
        }
        
        void Culculator(int PriorityValue, string[] Calculation, string Calculated) { }

        /// <summary>
        /// StringFormulaの数値を結合する
        /// </summary>
        void StringJoin()
        {
            //文字列の数値を結合する
            for(int i = 0; i < StringFormula.Length; i++)
            {
                bool CheckValue = int.TryParse(StringFormula[i], out TryParseTempValue);
                if (CheckValue)
                {
                    for(int j = i + 1; ;)
                    {
                        CheckValue = int.TryParse(StringFormula[j] , out TryParseTempValue);
                        if(CheckValue)
                        {
                            StringFormula[i] += StringFormula[j];
                            MoveArrayItem(1, j, "string", "Left", StringFormula);
                        }
                        else if (StringFormula[j] == ".")
                        {
                            StringFormula[i] += StringFormula[j];
                            MoveArrayItem(1, j, "string", "Left", StringFormula);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            //配列の先頭が演算子だったら
            if (StringFormula[0] == "+")
            {
                StringFormula[1] = StringFormula[1].Insert(0, "+");
                MoveArrayItem(1, 0, "string", "Left", StringFormula);
            }
            if (StringFormula[0] == "-")
            {
                StringFormula[1] = StringFormula[1].Insert(0, "-");
                MoveArrayItem(1, 0, "string", "Left", StringFormula);
            }
        }
        /// <summary>
        /// テキストボックスの中身をFirstFormulaStringに代入して、空か空でないか確認する
        /// </summary>
        /// <returns>空だったらfalse </returns>
        bool CheckTextBox()
        {
            FirstFormulaString = null; //フォーマット[
            for (int i = 0; CalculationFormula.Lines.Length > i; i++)
            {
                FirstFormulaString += CalculationFormula.Lines[i];
            }
            if (string.IsNullOrEmpty(FirstFormulaString))//rich text boxが空だった場合
            {
                //Error
                if(Lang == 0)
                MessageBox.Show("Textbox is empty");
                if(Lang == 1)
                    MessageBox.Show("テキストボックスが空です");
                PlaySound("SoundFile/Erroron.wav");
                Format(true);
            }
            else//でなかった場合
            {
                //スペースを抜く全角と半角
                FirstFormulaString = FirstFormulaString.Replace(" ", String.Empty);
                FirstFormulaString = FirstFormulaString.Replace("　", String.Empty);
                
                
                return true;
            }
            return false;

        }

        /// <summary>
        /// 配列の中身の操作
        /// </summary>
        /// <param name="Row"> 行の指定</param>
        /// <param name="Position"> 列の指定</param>
        /// <param name="array"> string が1次配列 Formulaが二次配列</param>
        /// <param name="direction"> 方向Left or Right </param>
        /// <param name="StringArray"> String形式の配列を指定</param>
        void MoveArrayItem(int Row , int Position, string array,string direction, string[] StringArray = null)
        {//配列のアイテムを詰めたり開けたりする関数
            
            if (array == "string" )
            {
                if (direction == "Left")
                {
                    for (int i = Position; i < 254; i++)
                    {
                        StringArray[i] = StringArray[i + 1];
                    }
                }
                if (direction == "Right")
                {
                    for (int i = 254; i != Position; i--)
                    {
                        StringArray[i] = StringArray[i - 1];
                    }
                }
            }
        }
        private System.Media.SoundPlayer player = null;
        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }
       
        private async void PlaySound(string filePath)
        {
            using (var audioFile = new AudioFileReader(filePath))
            using (var outputDevice = new WaveOutEvent())
            {
                audioFile.Volume = audioVolume / 100f;
                outputDevice.Init(audioFile);
                outputDevice.Play();
                await Task.Delay(audioFile.TotalTime);
            }
        }
        private Process OpenUrl(string url)
        {
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = url,
                UseShellExecute = true,
            };

            return Process.Start(pi);
        }

        
    }
}


