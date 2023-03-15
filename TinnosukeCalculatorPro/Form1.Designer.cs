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
            this.BasicBtn = new System.Windows.Forms.ToolStripButton();
            this.Normal = new System.Windows.Forms.ToolStripButton();
            this.Setting = new System.Windows.Forms.ToolStripButton();
            this.Information = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SettingControl = new System.Windows.Forms.TabControl();
            this.Calculation = new System.Windows.Forms.TabPage();
            this.display = new System.Windows.Forms.TabPage();
            this.OutPutType = new System.Windows.Forms.CheckBox();
            this.CalculationMethodPicture = new System.Windows.Forms.PictureBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.CalculationFormulaText = new System.Windows.Forms.Label();
            this.CalculationFormula = new System.Windows.Forms.RichTextBox();
            this.CalculationResult = new System.Windows.Forms.ListView();
            this.FormulaResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Debug = new System.Windows.Forms.Label();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SettingControl.SuspendLayout();
            this.display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculationMethodPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BasicBtn,
            this.Normal,
            this.Setting,
            this.Information});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip.Size = new System.Drawing.Size(1182, 27);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // BasicBtn
            // 
            this.BasicBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BasicBtn.Image = ((System.Drawing.Image)(resources.GetObject("BasicBtn.Image")));
            this.BasicBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BasicBtn.Name = "BasicBtn";
            this.BasicBtn.Size = new System.Drawing.Size(47, 24);
            this.BasicBtn.Text = "Basic";
            // 
            // Normal
            // 
            this.Normal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Normal.Image = ((System.Drawing.Image)(resources.GetObject("Normal.Image")));
            this.Normal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(60, 24);
            this.Normal.Text = "normal";
            // 
            // Setting
            // 
            this.Setting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Setting.Image = ((System.Drawing.Image)(resources.GetObject("Setting.Image")));
            this.Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(58, 24);
            this.Setting.Text = "setting";
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // Information
            // 
            this.Information.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Information.Image = ((System.Drawing.Image)(resources.GetObject("Information.Image")));
            this.Information.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(91, 24);
            this.Information.Text = "information";
            this.Information.Click += new System.EventHandler(this.Information_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SettingControl);
            this.splitContainer1.Panel1.Controls.Add(this.CalculationMethodPicture);
            this.splitContainer1.Panel1.Controls.Add(this.RunBtn);
            this.splitContainer1.Panel1.Controls.Add(this.CalculationFormulaText);
            this.splitContainer1.Panel1.Controls.Add(this.CalculationFormula);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CalculationResult);
            this.splitContainer1.Size = new System.Drawing.Size(1182, 626);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 1;
            // 
            // SettingControl
            // 
            this.SettingControl.Controls.Add(this.Calculation);
            this.SettingControl.Controls.Add(this.display);
            this.SettingControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingControl.Location = new System.Drawing.Point(657, 0);
            this.SettingControl.Name = "SettingControl";
            this.SettingControl.SelectedIndex = 0;
            this.SettingControl.Size = new System.Drawing.Size(523, 382);
            this.SettingControl.TabIndex = 7;
            this.SettingControl.Visible = false;
            // 
            // Calculation
            // 
            this.Calculation.Location = new System.Drawing.Point(4, 25);
            this.Calculation.Name = "Calculation";
            this.Calculation.Padding = new System.Windows.Forms.Padding(3);
            this.Calculation.Size = new System.Drawing.Size(515, 353);
            this.Calculation.TabIndex = 0;
            this.Calculation.Text = "Calculation";
            this.Calculation.UseVisualStyleBackColor = true;
            // 
            // display
            // 
            this.display.AllowDrop = true;
            this.display.Controls.Add(this.OutPutType);
            this.display.Location = new System.Drawing.Point(4, 25);
            this.display.Name = "display";
            this.display.Padding = new System.Windows.Forms.Padding(3);
            this.display.Size = new System.Drawing.Size(515, 353);
            this.display.TabIndex = 1;
            this.display.Text = "Display";
            this.display.UseVisualStyleBackColor = true;
            // 
            // OutPutType
            // 
            this.OutPutType.AutoSize = true;
            this.OutPutType.Checked = true;
            this.OutPutType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OutPutType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutPutType.Location = new System.Drawing.Point(6, 6);
            this.OutPutType.Name = "OutPutType";
            this.OutPutType.Size = new System.Drawing.Size(286, 26);
            this.OutPutType.TabIndex = 0;
            this.OutPutType.Text = "Output the formula you typed.";
            this.toolTip1.SetToolTip(this.OutPutType, "If off, use computer programming operators.");
            this.OutPutType.UseVisualStyleBackColor = true;
            // 
            // CalculationMethodPicture
            // 
            this.CalculationMethodPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculationMethodPicture.BackColor = System.Drawing.Color.MediumAquamarine;
            this.CalculationMethodPicture.Image = ((System.Drawing.Image)(resources.GetObject("CalculationMethodPicture.Image")));
            this.CalculationMethodPicture.Location = new System.Drawing.Point(630, 54);
            this.CalculationMethodPicture.Name = "CalculationMethodPicture";
            this.CalculationMethodPicture.Size = new System.Drawing.Size(523, 192);
            this.CalculationMethodPicture.TabIndex = 6;
            this.CalculationMethodPicture.TabStop = false;
            this.CalculationMethodPicture.Visible = false;
            // 
            // RunBtn
            // 
            this.RunBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RunBtn.Image = ((System.Drawing.Image)(resources.GetObject("RunBtn.Image")));
            this.RunBtn.Location = new System.Drawing.Point(483, 19);
            this.RunBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(32, 32);
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
            this.CalculationFormulaText.Location = new System.Drawing.Point(23, 11);
            this.CalculationFormulaText.Name = "CalculationFormulaText";
            this.CalculationFormulaText.Size = new System.Drawing.Size(327, 40);
            this.CalculationFormulaText.TabIndex = 1;
            this.CalculationFormulaText.Text = "calculation formula";
            // 
            // CalculationFormula
            // 
            this.CalculationFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculationFormula.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CalculationFormula.Location = new System.Drawing.Point(11, 54);
            this.CalculationFormula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CalculationFormula.MaximumSize = new System.Drawing.Size(1000, 20000);
            this.CalculationFormula.MinimumSize = new System.Drawing.Size(525, 300);
            this.CalculationFormula.Name = "CalculationFormula";
            this.CalculationFormula.Size = new System.Drawing.Size(598, 303);
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
            this.CalculationResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CalculationResult.Name = "CalculationResult";
            this.CalculationResult.Size = new System.Drawing.Size(1180, 236);
            this.CalculationResult.TabIndex = 0;
            this.CalculationResult.UseCompatibleStateImageBehavior = false;
            this.CalculationResult.View = System.Windows.Forms.View.List;
            // 
            // FormulaResult
            // 
            this.FormulaResult.Text = "Formula";
            this.FormulaResult.Width = 10000;
            // 
            // Debug
            // 
            this.Debug.AutoSize = true;
            this.Debug.Location = new System.Drawing.Point(910, 9);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(43, 15);
            this.Debug.TabIndex = 2;
            this.Debug.Text = "label1";
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1150, 700);
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
            this.display.ResumeLayout(false);
            this.display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculationMethodPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton BasicBtn;
        private System.Windows.Forms.ToolStripButton Normal;
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
    }
}

