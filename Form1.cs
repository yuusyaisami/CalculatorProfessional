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
using CalculatorPro.Core;

namespace CalculatorPro
{

    public partial class CalculatorForm : Form
    {
        private readonly ICalculatorEngine _engine = new CalculatorEngine();

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
        bool ValueC, AddC, SubC, MultC, DivideC, PowerC, LeftParentC, RightParentC, EqualsC, DecimalPointC, SinC, CosC, TanC, RootC, CheckedC, VariableC, PaiC, logC,log10C,log2C;
        int Lang;

        private void RunBtn_Click(object sender, EventArgs e)
        {

            // 入力
            var input = CalculationFormula.Text;

            // オプション構築
            var options = new CalculatorOptions
            {
                RoundResult = DecimalPoint.Checked,
                RoundDigits = (int)RoundUpDown.Value,
                CaptureSteps = FormulaMethod.Checked,
                AngleUnit = AngleUnit.Degree
            };

            var result = _engine.Evaluate(input, options);

            if (result.HasError)
            {
                var msg = Lang == 0 ? "Error: " + result.ErrorMessage : "エラー: " + result.ErrorMessage;
                MessageBox.Show(msg);
                PlaySound("SoundFile/Erroron.wav");
                return;
            }

            // ListView 追加
            var headerItem = OutPutType.Checked
                ? new ListViewItem($">>{result.InputExpression}")
                : new ListViewItem($">>{result.NormalizedExpression}");

            CalculationResult.Items.Add(headerItem);

            // 途中式
            if (FormulaMethod.Checked && result.Steps.Any())
            {
                foreach (var step in result.Steps)
                {
                    CalculationResult.Items.Add(new ListViewItem("->" + step));
                }
            }

            // 最終結果
            string answerText;
            if (result.NumericResult.HasValue)
            {
                var v = result.NumericResult.Value;
                if (options.RoundResult)
                {
                    v = Math.Round(v, options.RoundDigits, MidpointRounding.AwayFromZero);
                }
                answerText = v.ToString();
            }
            else
            {
                answerText = "NaN";
            }

            CalculationResult.Items.Add(new ListViewItem(">" + answerText));
        }
        
        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //関数
        

        private void sin_Click(object sender, EventArgs e)
        {
            
        }

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
       
        private void PlaySound(string filePath)
        {
            Task.Run(() =>
            {
                try
                {
                    using (var audioFile = new AudioFileReader(filePath))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        audioFile.Volume = audioVolume / 100f;
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        System.Threading.Thread.Sleep((int)audioFile.TotalTime.TotalMilliseconds);
                    }
                }
                catch
                {
                    // 音声ファイルの再生に失敗した場合、無視
                }
            });
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

