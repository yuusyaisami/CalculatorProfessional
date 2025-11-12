namespace CalculatorPro
{
    partial class CalculatorForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Result0", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Result1", System.Windows.Forms.HorizontalAlignment.Left);
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.Setting = new System.Windows.Forms.ToolStripButton();
            this.Information = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.OpenTheMyGitHubText = new System.Windows.Forms.Label();
            this.SettingControl = new System.Windows.Forms.TabControl();
            this.Calculation = new System.Windows.Forms.TabPage();
            this.RoundUpDown = new System.Windows.Forms.NumericUpDown();
            this.DecimalPoint = new System.Windows.Forms.CheckBox();
            this.display = new System.Windows.Forms.TabPage();
            this.FormulaMethod = new System.Windows.Forms.CheckBox();
            this.OutPutType = new System.Windows.Forms.CheckBox();
            this.Settingtab = new System.Windows.Forms.TabPage();
            this.LanguageText = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SoundValue = new System.Windows.Forms.Label();
            this.SoundVolumeBar = new System.Windows.Forms.TrackBar();
            this.SoundVolume = new System.Windows.Forms.Label();
            this.Infotab = new System.Windows.Forms.TabPage();
            this.Pie = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SpecialMenu = new System.Windows.Forms.Label();
            this.ArithmeticMenu = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddOp = new System.Windows.Forms.Label();
            this.Root = new System.Windows.Forms.Label();
            this.tan = new System.Windows.Forms.Label();
            this.cos = new System.Windows.Forms.Label();
            this.sin = new System.Windows.Forms.Label();
            this.CalculationMethodPicture = new System.Windows.Forms.PictureBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.CalculationFormulaText = new System.Windows.Forms.Label();
            this.CalculationFormula = new System.Windows.Forms.RichTextBox();
            this.CalculationResult = new System.Windows.Forms.ListView();
            this.FormulaResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Debug = new System.Windows.Forms.Label();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SettingControl.SuspendLayout();
            this.Calculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoundUpDown)).BeginInit();
            this.display.SuspendLayout();
            this.Settingtab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoundVolumeBar)).BeginInit();
            this.Infotab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculationMethodPicture)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Setting,
            this.Information});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip.Size = new System.Drawing.Size(1921, 42);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // Setting
            // 
            this.Setting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Setting.Image = ((System.Drawing.Image)(resources.GetObject("Setting.Image")));
            this.Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(91, 36);
            this.Setting.Text = "setting";
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // Information
            // 
            this.Information.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Information.Image = ((System.Drawing.Image)(resources.GetObject("Information.Image")));
            this.Information.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(143, 36);
            this.Information.Text = "information";
            this.Information.Click += new System.EventHandler(this.Information_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 42);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.OpenTheMyGitHubText);
            this.splitContainer1.Panel1.Controls.Add(this.SettingControl);
            this.splitContainer1.Panel1.Controls.Add(this.CalculationMethodPicture);
            this.splitContainer1.Panel1.Controls.Add(this.RunBtn);
            this.splitContainer1.Panel1.Controls.Add(this.CalculationFormulaText);
            this.splitContainer1.Panel1.Controls.Add(this.CalculationFormula);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CalculationResult);
            this.splitContainer1.Size = new System.Drawing.Size(1921, 1003);
            this.splitContainer1.SplitterDistance = 611;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 1;
            // 
            // OpenTheMyGitHubText
            // 
            this.OpenTheMyGitHubText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenTheMyGitHubText.AutoSize = true;
            this.OpenTheMyGitHubText.BackColor = System.Drawing.Color.Transparent;
            this.OpenTheMyGitHubText.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OpenTheMyGitHubText.Location = new System.Drawing.Point(1040, 397);
            this.OpenTheMyGitHubText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.OpenTheMyGitHubText.Name = "OpenTheMyGitHubText";
            this.OpenTheMyGitHubText.Size = new System.Drawing.Size(272, 24);
            this.OpenTheMyGitHubText.TabIndex = 8;
            this.OpenTheMyGitHubText.Text = "↑ Open the my github! ↑";
            this.OpenTheMyGitHubText.Visible = false;
            // 
            // SettingControl
            // 
            this.SettingControl.Controls.Add(this.Calculation);
            this.SettingControl.Controls.Add(this.display);
            this.SettingControl.Controls.Add(this.Settingtab);
            this.SettingControl.Controls.Add(this.Infotab);
            this.SettingControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingControl.Location = new System.Drawing.Point(1069, 0);
            this.SettingControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SettingControl.Name = "SettingControl";
            this.SettingControl.SelectedIndex = 0;
            this.SettingControl.Size = new System.Drawing.Size(850, 609);
            this.SettingControl.TabIndex = 7;
            this.SettingControl.TabStop = false;
            this.SettingControl.Visible = false;
            // 
            // Calculation
            // 
            this.Calculation.Controls.Add(this.RoundUpDown);
            this.Calculation.Controls.Add(this.DecimalPoint);
            this.Calculation.Location = new System.Drawing.Point(8, 39);
            this.Calculation.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Calculation.Name = "Calculation";
            this.Calculation.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Calculation.Size = new System.Drawing.Size(834, 562);
            this.Calculation.TabIndex = 0;
            this.Calculation.Text = "Calculation";
            this.Calculation.UseVisualStyleBackColor = true;
            // 
            // RoundUpDown
            // 
            this.RoundUpDown.Location = new System.Drawing.Point(341, 15);
            this.RoundUpDown.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.RoundUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RoundUpDown.Name = "RoundUpDown";
            this.RoundUpDown.Size = new System.Drawing.Size(72, 31);
            this.RoundUpDown.TabIndex = 2;
            this.RoundUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // DecimalPoint
            // 
            this.DecimalPoint.AutoSize = true;
            this.DecimalPoint.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecimalPoint.Location = new System.Drawing.Point(10, 9);
            this.DecimalPoint.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DecimalPoint.Name = "DecimalPoint";
            this.DecimalPoint.Size = new System.Drawing.Size(294, 40);
            this.DecimalPoint.TabIndex = 1;
            this.DecimalPoint.Text = "Round the answer";
            this.toolTip1.SetToolTip(this.DecimalPoint, "Number of specified numbers, round off");
            this.DecimalPoint.UseVisualStyleBackColor = true;
            // 
            // display
            // 
            this.display.AllowDrop = true;
            this.display.Controls.Add(this.FormulaMethod);
            this.display.Controls.Add(this.OutPutType);
            this.display.Location = new System.Drawing.Point(8, 39);
            this.display.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.display.Name = "display";
            this.display.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.display.Size = new System.Drawing.Size(834, 560);
            this.display.TabIndex = 1;
            this.display.Text = "Display";
            this.display.UseVisualStyleBackColor = true;
            // 
            // FormulaMethod
            // 
            this.FormulaMethod.AutoSize = true;
            this.FormulaMethod.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormulaMethod.Location = new System.Drawing.Point(10, 59);
            this.FormulaMethod.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.FormulaMethod.Name = "FormulaMethod";
            this.FormulaMethod.Size = new System.Drawing.Size(501, 40);
            this.FormulaMethod.TabIndex = 1;
            this.FormulaMethod.Text = "Output the calculation procedure";
            this.FormulaMethod.UseVisualStyleBackColor = true;
            // 
            // OutPutType
            // 
            this.OutPutType.AutoSize = true;
            this.OutPutType.Checked = true;
            this.OutPutType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OutPutType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutPutType.Location = new System.Drawing.Point(10, 9);
            this.OutPutType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.OutPutType.Name = "OutPutType";
            this.OutPutType.Size = new System.Drawing.Size(463, 40);
            this.OutPutType.TabIndex = 0;
            this.OutPutType.Text = "Output the formula you typed.";
            this.toolTip1.SetToolTip(this.OutPutType, "If off, use computer programming operators.");
            this.OutPutType.UseVisualStyleBackColor = true;
            // 
            // Settingtab
            // 
            this.Settingtab.Controls.Add(this.LanguageText);
            this.Settingtab.Controls.Add(this.comboBox1);
            this.Settingtab.Controls.Add(this.SoundValue);
            this.Settingtab.Controls.Add(this.SoundVolumeBar);
            this.Settingtab.Controls.Add(this.SoundVolume);
            this.Settingtab.Location = new System.Drawing.Point(8, 39);
            this.Settingtab.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Settingtab.Name = "Settingtab";
            this.Settingtab.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Settingtab.Size = new System.Drawing.Size(834, 560);
            this.Settingtab.TabIndex = 2;
            this.Settingtab.Text = "Setting";
            this.Settingtab.UseVisualStyleBackColor = true;
            // 
            // LanguageText
            // 
            this.LanguageText.AutoSize = true;
            this.LanguageText.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LanguageText.Location = new System.Drawing.Point(27, 159);
            this.LanguageText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LanguageText.Name = "LanguageText";
            this.LanguageText.Size = new System.Drawing.Size(150, 36);
            this.LanguageText.TabIndex = 4;
            this.LanguageText.Text = "Language";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "English",
            "Japanese"});
            this.comboBox1.Location = new System.Drawing.Point(34, 199);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 32);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "English";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SoundValue
            // 
            this.SoundValue.AutoSize = true;
            this.SoundValue.Font = new System.Drawing.Font("Microsoft JhengHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoundValue.Location = new System.Drawing.Point(612, 64);
            this.SoundValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.SoundValue.Name = "SoundValue";
            this.SoundValue.Size = new System.Drawing.Size(93, 67);
            this.SoundValue.TabIndex = 2;
            this.SoundValue.Text = "20";
            // 
            // SoundVolumeBar
            // 
            this.SoundVolumeBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SoundVolumeBar.LargeChange = 0;
            this.SoundVolumeBar.Location = new System.Drawing.Point(10, 64);
            this.SoundVolumeBar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SoundVolumeBar.Maximum = 100;
            this.SoundVolumeBar.Name = "SoundVolumeBar";
            this.SoundVolumeBar.Size = new System.Drawing.Size(578, 90);
            this.SoundVolumeBar.TabIndex = 1;
            this.SoundVolumeBar.TabStop = false;
            this.SoundVolumeBar.Value = 20;
            this.SoundVolumeBar.Scroll += new System.EventHandler(this.SoundVolumeBar_Scroll);
            // 
            // SoundVolume
            // 
            this.SoundVolume.AutoSize = true;
            this.SoundVolume.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoundVolume.Location = new System.Drawing.Point(27, 24);
            this.SoundVolume.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.SoundVolume.Name = "SoundVolume";
            this.SoundVolume.Size = new System.Drawing.Size(212, 36);
            this.SoundVolume.TabIndex = 0;
            this.SoundVolume.Text = "Sound volume";
            // 
            // Infotab
            // 
            this.Infotab.Controls.Add(this.Pie);
            this.Infotab.Controls.Add(this.label1);
            this.Infotab.Controls.Add(this.SpecialMenu);
            this.Infotab.Controls.Add(this.ArithmeticMenu);
            this.Infotab.Controls.Add(this.label9);
            this.Infotab.Controls.Add(this.label8);
            this.Infotab.Controls.Add(this.label7);
            this.Infotab.Controls.Add(this.label6);
            this.Infotab.Controls.Add(this.AddOp);
            this.Infotab.Controls.Add(this.Root);
            this.Infotab.Controls.Add(this.tan);
            this.Infotab.Controls.Add(this.cos);
            this.Infotab.Controls.Add(this.sin);
            this.Infotab.Location = new System.Drawing.Point(8, 39);
            this.Infotab.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Infotab.Name = "Infotab";
            this.Infotab.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Infotab.Size = new System.Drawing.Size(834, 560);
            this.Infotab.TabIndex = 3;
            this.Infotab.Text = "Info";
            this.Infotab.UseVisualStyleBackColor = true;
            // 
            // Pie
            // 
            this.Pie.AutoSize = true;
            this.Pie.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pie.Location = new System.Drawing.Point(299, 47);
            this.Pie.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Pie.Name = "Pie";
            this.Pie.Size = new System.Drawing.Size(37, 36);
            this.Pie.TabIndex = 12;
            this.Pie.Text = "Π";
            this.toolTip1.SetToolTip(this.Pie, "Please enter Π or π");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 36);
            this.label1.TabIndex = 11;
            this.label1.Text = "%";
            this.toolTip1.SetToolTip(this.label1, "remainder");
            // 
            // SpecialMenu
            // 
            this.SpecialMenu.AutoSize = true;
            this.SpecialMenu.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecialMenu.Location = new System.Drawing.Point(29, 81);
            this.SpecialMenu.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.SpecialMenu.Name = "SpecialMenu";
            this.SpecialMenu.Size = new System.Drawing.Size(373, 36);
            this.SpecialMenu.TabIndex = 10;
            this.SpecialMenu.Text = "Slightly special calculation";
            this.toolTip1.SetToolTip(this.SpecialMenu, "Slightly special calculation\r\n");
            // 
            // ArithmeticMenu
            // 
            this.ArithmeticMenu.AutoSize = true;
            this.ArithmeticMenu.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArithmeticMenu.Location = new System.Drawing.Point(29, 11);
            this.ArithmeticMenu.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ArithmeticMenu.Name = "ArithmeticMenu";
            this.ArithmeticMenu.Size = new System.Drawing.Size(358, 36);
            this.ArithmeticMenu.TabIndex = 9;
            this.ArithmeticMenu.Text = "four arithmetic operators";
            this.toolTip1.SetToolTip(this.ArithmeticMenu, "four arithmetic operators + power");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(202, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 36);
            this.label9.TabIndex = 8;
            this.label9.Text = "^";
            this.toolTip1.SetToolTip(this.label9, "power");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(155, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 36);
            this.label8.TabIndex = 7;
            this.label8.Text = "÷";
            this.toolTip1.SetToolTip(this.label8, "division Other writing /");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(114, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 36);
            this.label7.TabIndex = 6;
            this.label7.Text = "x";
            this.toolTip1.SetToolTip(this.label7, "multiplication Other writing *");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 36);
            this.label6.TabIndex = 5;
            this.label6.Text = "-";
            this.toolTip1.SetToolTip(this.label6, "subtraction");
            // 
            // AddOp
            // 
            this.AddOp.AutoSize = true;
            this.AddOp.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOp.Location = new System.Drawing.Point(29, 47);
            this.AddOp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.AddOp.Name = "AddOp";
            this.AddOp.Size = new System.Drawing.Size(36, 36);
            this.AddOp.TabIndex = 4;
            this.AddOp.Text = "+";
            this.toolTip1.SetToolTip(this.AddOp, "addition");
            // 
            // Root
            // 
            this.Root.AutoSize = true;
            this.Root.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Root.Location = new System.Drawing.Point(296, 117);
            this.Root.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(55, 36);
            this.Root.TabIndex = 3;
            this.Root.Text = "√()";
            this.toolTip1.SetToolTip(this.Root, "Route Calculation");
            // 
            // tan
            // 
            this.tan.AutoSize = true;
            this.tan.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tan.Location = new System.Drawing.Point(205, 117);
            this.tan.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tan.Name = "tan";
            this.tan.Size = new System.Drawing.Size(80, 36);
            this.tan.TabIndex = 2;
            this.tan.Text = "tan()";
            this.toolTip1.SetToolTip(this.tan, "Tangent Calculation");
            // 
            // cos
            // 
            this.cos.AutoSize = true;
            this.cos.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cos.Location = new System.Drawing.Point(114, 117);
            this.cos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.cos.Name = "cos";
            this.cos.Size = new System.Drawing.Size(80, 36);
            this.cos.TabIndex = 1;
            this.cos.Text = "cos()";
            this.toolTip1.SetToolTip(this.cos, "Cosine Calculation");
            // 
            // sin
            // 
            this.sin.AutoSize = true;
            this.sin.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sin.Location = new System.Drawing.Point(29, 117);
            this.sin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sin.Name = "sin";
            this.sin.Size = new System.Drawing.Size(74, 36);
            this.sin.TabIndex = 0;
            this.sin.Text = "sin()";
            this.toolTip1.SetToolTip(this.sin, "Sign Calculator");
            this.sin.Click += new System.EventHandler(this.sin_Click);
            // 
            // CalculationMethodPicture
            // 
            this.CalculationMethodPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculationMethodPicture.BackColor = System.Drawing.Color.MediumAquamarine;
            this.CalculationMethodPicture.Image = ((System.Drawing.Image)(resources.GetObject("CalculationMethodPicture.Image")));
            this.CalculationMethodPicture.Location = new System.Drawing.Point(1026, 87);
            this.CalculationMethodPicture.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CalculationMethodPicture.Name = "CalculationMethodPicture";
            this.CalculationMethodPicture.Size = new System.Drawing.Size(850, 305);
            this.CalculationMethodPicture.TabIndex = 6;
            this.CalculationMethodPicture.TabStop = false;
            this.CalculationMethodPicture.Visible = false;
            this.CalculationMethodPicture.Click += new System.EventHandler(this.CalculationMethodPicture_Click);
            // 
            // RunBtn
            // 
            this.RunBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RunBtn.Image = ((System.Drawing.Image)(resources.GetObject("RunBtn.Image")));
            this.RunBtn.Location = new System.Drawing.Point(785, 31);
            this.RunBtn.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(52, 51);
            this.RunBtn.TabIndex = 2;
            this.RunBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.RunBtn, "Run");
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // CalculationFormulaText
            // 
            this.CalculationFormulaText.AutoSize = true;
            this.CalculationFormulaText.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CalculationFormulaText.Location = new System.Drawing.Point(38, 17);
            this.CalculationFormulaText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.CalculationFormulaText.Name = "CalculationFormulaText";
            this.CalculationFormulaText.Size = new System.Drawing.Size(534, 64);
            this.CalculationFormulaText.TabIndex = 1;
            this.CalculationFormulaText.Text = "calculation formula";
            this.CalculationFormulaText.Click += new System.EventHandler(this.CalculationFormulaText_Click);
            // 
            // CalculationFormula
            // 
            this.CalculationFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculationFormula.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CalculationFormula.Location = new System.Drawing.Point(18, 87);
            this.CalculationFormula.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CalculationFormula.MaximumSize = new System.Drawing.Size(1622, 31997);
            this.CalculationFormula.MinimumSize = new System.Drawing.Size(850, 477);
            this.CalculationFormula.Name = "CalculationFormula";
            this.CalculationFormula.Size = new System.Drawing.Size(970, 482);
            this.CalculationFormula.TabIndex = 0;
            this.CalculationFormula.Text = "";
            this.toolTip1.SetToolTip(this.CalculationFormula, "Enter a formula");
            this.CalculationFormula.TextChanged += new System.EventHandler(this.CalculationFormula_TextChanged);
            // 
            // CalculationResult
            // 
            this.CalculationResult.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.CalculationResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalculationResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FormulaResult});
            this.CalculationResult.ContextMenuStrip = this.contextMenuStrip1;
            this.CalculationResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalculationResult.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            listViewGroup1.Header = "Result0";
            listViewGroup1.Name = "Result0";
            listViewGroup2.Header = "Result1";
            listViewGroup2.Name = "Result1";
            this.CalculationResult.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.CalculationResult.HideSelection = false;
            this.CalculationResult.Location = new System.Drawing.Point(0, 0);
            this.CalculationResult.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CalculationResult.Name = "CalculationResult";
            this.CalculationResult.Size = new System.Drawing.Size(1919, 383);
            this.CalculationResult.TabIndex = 0;
            this.CalculationResult.UseCompatibleStateImageBehavior = false;
            this.CalculationResult.View = System.Windows.Forms.View.List;
            // 
            // FormulaResult
            // 
            this.FormulaResult.Text = "Formula";
            this.FormulaResult.Width = 10000;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 42);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.deleteToolStripMenuItem.Text = "Delete (D)";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // Debug
            // 
            this.Debug.AutoSize = true;
            this.Debug.Location = new System.Drawing.Point(1412, 15);
            this.Debug.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(118, 24);
            this.Debug.TabIndex = 2;
            this.Debug.Text = "DebugText";
            this.toolTip1.SetToolTip(this.Debug, "Helloworld!!");
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1921, 1045);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MinimumSize = new System.Drawing.Size(1854, 1082);
            this.Name = "CalculatorForm";
            this.Text = "CalculatorPro";
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.SettingControl.ResumeLayout(false);
            this.Calculation.ResumeLayout(false);
            this.Calculation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoundUpDown)).EndInit();
            this.display.ResumeLayout(false);
            this.display.PerformLayout();
            this.Settingtab.ResumeLayout(false);
            this.Settingtab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoundVolumeBar)).EndInit();
            this.Infotab.ResumeLayout(false);
            this.Infotab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculationMethodPicture)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton Setting;
        private System.Windows.Forms.ToolStripButton Information;
        private System.Windows.Forms.Label CalculationFormulaText;
        private System.Windows.Forms.RichTextBox CalculationFormula;
        private System.Windows.Forms.ListView CalculationResult;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.ColumnHeader FormulaResult;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox CalculationMethodPicture;
        private System.Windows.Forms.TabControl SettingControl;
        private System.Windows.Forms.TabPage Calculation;
        private System.Windows.Forms.TabPage display;
        private System.Windows.Forms.CheckBox OutPutType;
        private System.Windows.Forms.Label Debug;
        private System.Windows.Forms.CheckBox FormulaMethod;
        private System.Windows.Forms.TabPage Settingtab;
        private System.Windows.Forms.TrackBar SoundVolumeBar;
        private System.Windows.Forms.Label SoundVolume;
        private System.Windows.Forms.Label SoundValue;
        private System.Windows.Forms.TabPage Infotab;
        private System.Windows.Forms.Label Root;
        private System.Windows.Forms.Label tan;
        private System.Windows.Forms.Label cos;
        private System.Windows.Forms.Label sin;
        private System.Windows.Forms.Label OpenTheMyGitHubText;
        private System.Windows.Forms.Label SpecialMenu;
        private System.Windows.Forms.Label ArithmeticMenu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AddOp;
        private System.Windows.Forms.CheckBox DecimalPoint;
        private System.Windows.Forms.NumericUpDown RoundUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Pie;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LanguageText;
    }
}

