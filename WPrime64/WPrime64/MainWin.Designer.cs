namespace WPrime64
{
	partial class MainWin
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
			this.MainTab = new System.Windows.Forms.TabControl();
			this.Tab出力 = new System.Windows.Forms.TabPage();
			this.Chkファイルを分割して出力 = new System.Windows.Forms.CheckBox();
			this.BtnDo出力 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.MaxValue = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.MinValue = new System.Windows.Forms.TextBox();
			this.Tab判定 = new System.Windows.Forms.TabPage();
			this.BtnFindNearPrime = new System.Windows.Forms.Button();
			this.IsPrimeOutput = new System.Windows.Forms.TextBox();
			this.BtnIsPrime = new System.Windows.Forms.Button();
			this.IsPrimeInputValue = new System.Windows.Forms.TextBox();
			this.Tab素因数分解 = new System.Windows.Forms.TabPage();
			this.Chk改行しない = new System.Windows.Forms.CheckBox();
			this.CheckFactorizeBekijou = new System.Windows.Forms.CheckBox();
			this.FactorizeOutput = new System.Windows.Forms.TextBox();
			this.BtnFactorize = new System.Windows.Forms.Button();
			this.FactorizeInputValue = new System.Windows.Forms.TextBox();
			this.Tab個数 = new System.Windows.Forms.TabPage();
			this.BtnPrimeCount = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.PrimeCountMaxval = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.PrimeCountMinval = new System.Windows.Forms.TextBox();
			this.Tabウラムの螺旋 = new System.Windows.Forms.TabPage();
			this.SizeInfo = new System.Windows.Forms.Label();
			this.BtnCenterColor = new System.Windows.Forms.Button();
			this.BtnNotPrimeColor = new System.Windows.Forms.Button();
			this.BtnPrimeColor = new System.Windows.Forms.Button();
			this.US_R = new System.Windows.Forms.TextBox();
			this.US_Y軸 = new System.Windows.Forms.Label();
			this.US_X軸 = new System.Windows.Forms.Label();
			this.US_L = new System.Windows.Forms.TextBox();
			this.US_B = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.US_T = new System.Windows.Forms.TextBox();
			this.Btn_US = new System.Windows.Forms.Button();
			this.Chkミラーラビン法を使う = new System.Windows.Forms.CheckBox();
			this.MainTab.SuspendLayout();
			this.Tab出力.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.Tab判定.SuspendLayout();
			this.Tab素因数分解.SuspendLayout();
			this.Tab個数.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.Tabウラムの螺旋.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainTab
			// 
			this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainTab.Controls.Add(this.Tab出力);
			this.MainTab.Controls.Add(this.Tab判定);
			this.MainTab.Controls.Add(this.Tab素因数分解);
			this.MainTab.Controls.Add(this.Tab個数);
			this.MainTab.Controls.Add(this.Tabウラムの螺旋);
			this.MainTab.Location = new System.Drawing.Point(12, 12);
			this.MainTab.Name = "MainTab";
			this.MainTab.SelectedIndex = 0;
			this.MainTab.Size = new System.Drawing.Size(534, 272);
			this.MainTab.TabIndex = 0;
			this.MainTab.SelectedIndexChanged += new System.EventHandler(this.MainTab_SelectedIndexChanged);
			// 
			// Tab出力
			// 
			this.Tab出力.Controls.Add(this.Chkファイルを分割して出力);
			this.Tab出力.Controls.Add(this.BtnDo出力);
			this.Tab出力.Controls.Add(this.groupBox1);
			this.Tab出力.Location = new System.Drawing.Point(4, 29);
			this.Tab出力.Name = "Tab出力";
			this.Tab出力.Padding = new System.Windows.Forms.Padding(3);
			this.Tab出力.Size = new System.Drawing.Size(526, 239);
			this.Tab出力.TabIndex = 0;
			this.Tab出力.Text = "出力";
			this.Tab出力.UseVisualStyleBackColor = true;
			// 
			// Chkファイルを分割して出力
			// 
			this.Chkファイルを分割して出力.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Chkファイルを分割して出力.AutoSize = true;
			this.Chkファイルを分割して出力.Location = new System.Drawing.Point(20, 193);
			this.Chkファイルを分割して出力.Name = "Chkファイルを分割して出力";
			this.Chkファイルを分割して出力.Size = new System.Drawing.Size(171, 24);
			this.Chkファイルを分割して出力.TabIndex = 1;
			this.Chkファイルを分割して出力.Text = "ファイルを分割して出力";
			this.Chkファイルを分割して出力.UseVisualStyleBackColor = true;
			// 
			// BtnDo出力
			// 
			this.BtnDo出力.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnDo出力.Location = new System.Drawing.Point(215, 185);
			this.BtnDo出力.Name = "BtnDo出力";
			this.BtnDo出力.Size = new System.Drawing.Size(294, 39);
			this.BtnDo出力.TabIndex = 2;
			this.BtnDo出力.Text = "指定された範囲の素数をファイルに出力";
			this.BtnDo出力.UseVisualStyleBackColor = true;
			this.BtnDo出力.Click += new System.EventHandler(this.BtnDo出力_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.MaxValue);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.MinValue);
			this.groupBox1.Location = new System.Drawing.Point(20, 18);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(489, 151);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "出力する範囲";
			// 
			// MaxValue
			// 
			this.MaxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MaxValue.Location = new System.Drawing.Point(69, 81);
			this.MaxValue.MaxLength = 30;
			this.MaxValue.Name = "MaxValue";
			this.MaxValue.Size = new System.Drawing.Size(406, 27);
			this.MaxValue.TabIndex = 3;
			this.MaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MaxValue.TextChanged += new System.EventHandler(this.MaxValue_TextChanged);
			this.MaxValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaxValue_KeyPress);
			this.MaxValue.Leave += new System.EventHandler(this.MaxValue_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "最小値";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "最大値";
			// 
			// MinValue
			// 
			this.MinValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MinValue.Location = new System.Drawing.Point(69, 34);
			this.MinValue.MaxLength = 30;
			this.MinValue.Name = "MinValue";
			this.MinValue.Size = new System.Drawing.Size(406, 27);
			this.MinValue.TabIndex = 1;
			this.MinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MinValue.TextChanged += new System.EventHandler(this.MinValue_TextChanged);
			this.MinValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MinValue_KeyPress);
			this.MinValue.Leave += new System.EventHandler(this.MinValue_Leave);
			// 
			// Tab判定
			// 
			this.Tab判定.Controls.Add(this.BtnFindNearPrime);
			this.Tab判定.Controls.Add(this.IsPrimeOutput);
			this.Tab判定.Controls.Add(this.BtnIsPrime);
			this.Tab判定.Controls.Add(this.IsPrimeInputValue);
			this.Tab判定.Location = new System.Drawing.Point(4, 29);
			this.Tab判定.Name = "Tab判定";
			this.Tab判定.Padding = new System.Windows.Forms.Padding(3);
			this.Tab判定.Size = new System.Drawing.Size(526, 239);
			this.Tab判定.TabIndex = 1;
			this.Tab判定.Text = "判定";
			this.Tab判定.UseVisualStyleBackColor = true;
			// 
			// BtnFindNearPrime
			// 
			this.BtnFindNearPrime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnFindNearPrime.Location = new System.Drawing.Point(349, 48);
			this.BtnFindNearPrime.Name = "BtnFindNearPrime";
			this.BtnFindNearPrime.Size = new System.Drawing.Size(160, 39);
			this.BtnFindNearPrime.TabIndex = 2;
			this.BtnFindNearPrime.Text = "最寄りの素数を探す";
			this.BtnFindNearPrime.UseVisualStyleBackColor = true;
			this.BtnFindNearPrime.Click += new System.EventHandler(this.BtnFindNearPrime_Click);
			// 
			// IsPrimeOutput
			// 
			this.IsPrimeOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IsPrimeOutput.Location = new System.Drawing.Point(15, 93);
			this.IsPrimeOutput.Multiline = true;
			this.IsPrimeOutput.Name = "IsPrimeOutput";
			this.IsPrimeOutput.ReadOnly = true;
			this.IsPrimeOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.IsPrimeOutput.Size = new System.Drawing.Size(494, 133);
			this.IsPrimeOutput.TabIndex = 3;
			this.IsPrimeOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsPrimeOutput_KeyPress);
			// 
			// BtnIsPrime
			// 
			this.BtnIsPrime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnIsPrime.Location = new System.Drawing.Point(172, 48);
			this.BtnIsPrime.Name = "BtnIsPrime";
			this.BtnIsPrime.Size = new System.Drawing.Size(171, 39);
			this.BtnIsPrime.TabIndex = 1;
			this.BtnIsPrime.Text = "素数かどうか判定する";
			this.BtnIsPrime.UseVisualStyleBackColor = true;
			this.BtnIsPrime.Click += new System.EventHandler(this.BtnIsPrime_Click);
			// 
			// IsPrimeInputValue
			// 
			this.IsPrimeInputValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IsPrimeInputValue.Location = new System.Drawing.Point(15, 15);
			this.IsPrimeInputValue.MaxLength = 30;
			this.IsPrimeInputValue.Name = "IsPrimeInputValue";
			this.IsPrimeInputValue.Size = new System.Drawing.Size(494, 27);
			this.IsPrimeInputValue.TabIndex = 0;
			this.IsPrimeInputValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.IsPrimeInputValue.TextChanged += new System.EventHandler(this.IsPrimeInputValue_TextChanged);
			this.IsPrimeInputValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsPrimeInputValue_KeyPress);
			this.IsPrimeInputValue.Leave += new System.EventHandler(this.IsPrimeInputValue_Leave);
			// 
			// Tab素因数分解
			// 
			this.Tab素因数分解.Controls.Add(this.Chk改行しない);
			this.Tab素因数分解.Controls.Add(this.CheckFactorizeBekijou);
			this.Tab素因数分解.Controls.Add(this.FactorizeOutput);
			this.Tab素因数分解.Controls.Add(this.BtnFactorize);
			this.Tab素因数分解.Controls.Add(this.FactorizeInputValue);
			this.Tab素因数分解.Location = new System.Drawing.Point(4, 29);
			this.Tab素因数分解.Name = "Tab素因数分解";
			this.Tab素因数分解.Size = new System.Drawing.Size(526, 239);
			this.Tab素因数分解.TabIndex = 2;
			this.Tab素因数分解.Text = "素因数分解";
			this.Tab素因数分解.UseVisualStyleBackColor = true;
			// 
			// Chk改行しない
			// 
			this.Chk改行しない.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Chk改行しない.AutoSize = true;
			this.Chk改行しない.Checked = true;
			this.Chk改行しない.CheckState = System.Windows.Forms.CheckState.Checked;
			this.Chk改行しない.Location = new System.Drawing.Point(213, 56);
			this.Chk改行しない.Name = "Chk改行しない";
			this.Chk改行しない.Size = new System.Drawing.Size(93, 24);
			this.Chk改行しない.TabIndex = 1;
			this.Chk改行しない.Text = "数式っぽく";
			this.Chk改行しない.UseVisualStyleBackColor = true;
			// 
			// CheckFactorizeBekijou
			// 
			this.CheckFactorizeBekijou.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CheckFactorizeBekijou.AutoSize = true;
			this.CheckFactorizeBekijou.Checked = true;
			this.CheckFactorizeBekijou.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckFactorizeBekijou.Location = new System.Drawing.Point(312, 56);
			this.CheckFactorizeBekijou.Name = "CheckFactorizeBekijou";
			this.CheckFactorizeBekijou.Size = new System.Drawing.Size(67, 24);
			this.CheckFactorizeBekijou.TabIndex = 2;
			this.CheckFactorizeBekijou.Text = "べき乗";
			this.CheckFactorizeBekijou.UseVisualStyleBackColor = true;
			// 
			// FactorizeOutput
			// 
			this.FactorizeOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FactorizeOutput.Location = new System.Drawing.Point(15, 93);
			this.FactorizeOutput.Multiline = true;
			this.FactorizeOutput.Name = "FactorizeOutput";
			this.FactorizeOutput.ReadOnly = true;
			this.FactorizeOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.FactorizeOutput.Size = new System.Drawing.Size(494, 133);
			this.FactorizeOutput.TabIndex = 4;
			this.FactorizeOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FactorizeOutput_KeyPress);
			// 
			// BtnFactorize
			// 
			this.BtnFactorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnFactorize.Location = new System.Drawing.Point(385, 48);
			this.BtnFactorize.Name = "BtnFactorize";
			this.BtnFactorize.Size = new System.Drawing.Size(124, 39);
			this.BtnFactorize.TabIndex = 3;
			this.BtnFactorize.Text = "素因数分解";
			this.BtnFactorize.UseVisualStyleBackColor = true;
			this.BtnFactorize.Click += new System.EventHandler(this.BtnFactorize_Click);
			// 
			// FactorizeInputValue
			// 
			this.FactorizeInputValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FactorizeInputValue.Location = new System.Drawing.Point(15, 15);
			this.FactorizeInputValue.MaxLength = 30;
			this.FactorizeInputValue.Name = "FactorizeInputValue";
			this.FactorizeInputValue.Size = new System.Drawing.Size(494, 27);
			this.FactorizeInputValue.TabIndex = 0;
			this.FactorizeInputValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.FactorizeInputValue.TextChanged += new System.EventHandler(this.FactorizeInputValue_TextChanged);
			this.FactorizeInputValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FactorizeInputValue_KeyPress);
			this.FactorizeInputValue.Leave += new System.EventHandler(this.FactorizeInputValue_Leave);
			// 
			// Tab個数
			// 
			this.Tab個数.Controls.Add(this.BtnPrimeCount);
			this.Tab個数.Controls.Add(this.groupBox2);
			this.Tab個数.Location = new System.Drawing.Point(4, 29);
			this.Tab個数.Name = "Tab個数";
			this.Tab個数.Padding = new System.Windows.Forms.Padding(3);
			this.Tab個数.Size = new System.Drawing.Size(526, 239);
			this.Tab個数.TabIndex = 3;
			this.Tab個数.Text = "個数";
			this.Tab個数.UseVisualStyleBackColor = true;
			// 
			// BtnPrimeCount
			// 
			this.BtnPrimeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnPrimeCount.Location = new System.Drawing.Point(160, 185);
			this.BtnPrimeCount.Name = "BtnPrimeCount";
			this.BtnPrimeCount.Size = new System.Drawing.Size(348, 39);
			this.BtnPrimeCount.TabIndex = 1;
			this.BtnPrimeCount.Text = "指定された範囲の素数の「個数」をファイルに出力";
			this.BtnPrimeCount.UseVisualStyleBackColor = true;
			this.BtnPrimeCount.Click += new System.EventHandler(this.BtnPrimeCount_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.PrimeCountMaxval);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.PrimeCountMinval);
			this.groupBox2.Location = new System.Drawing.Point(20, 18);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(488, 151);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "検索する範囲";
			// 
			// PrimeCountMaxval
			// 
			this.PrimeCountMaxval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PrimeCountMaxval.Location = new System.Drawing.Point(69, 81);
			this.PrimeCountMaxval.MaxLength = 30;
			this.PrimeCountMaxval.Name = "PrimeCountMaxval";
			this.PrimeCountMaxval.Size = new System.Drawing.Size(405, 27);
			this.PrimeCountMaxval.TabIndex = 3;
			this.PrimeCountMaxval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.PrimeCountMaxval.TextChanged += new System.EventHandler(this.PrimeCountMaxval_TextChanged);
			this.PrimeCountMaxval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrimeCountMaxval_KeyPress);
			this.PrimeCountMaxval.Leave += new System.EventHandler(this.PrimeCountMaxval_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "最小値";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "最大値";
			// 
			// PrimeCountMinval
			// 
			this.PrimeCountMinval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PrimeCountMinval.Location = new System.Drawing.Point(69, 34);
			this.PrimeCountMinval.MaxLength = 30;
			this.PrimeCountMinval.Name = "PrimeCountMinval";
			this.PrimeCountMinval.Size = new System.Drawing.Size(405, 27);
			this.PrimeCountMinval.TabIndex = 1;
			this.PrimeCountMinval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.PrimeCountMinval.TextChanged += new System.EventHandler(this.PrimeCountMinval_TextChanged);
			this.PrimeCountMinval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrimeCountMinval_KeyPress);
			this.PrimeCountMinval.Leave += new System.EventHandler(this.PrimeCountMinval_Leave);
			// 
			// Tabウラムの螺旋
			// 
			this.Tabウラムの螺旋.Controls.Add(this.SizeInfo);
			this.Tabウラムの螺旋.Controls.Add(this.BtnCenterColor);
			this.Tabウラムの螺旋.Controls.Add(this.BtnNotPrimeColor);
			this.Tabウラムの螺旋.Controls.Add(this.BtnPrimeColor);
			this.Tabウラムの螺旋.Controls.Add(this.US_R);
			this.Tabウラムの螺旋.Controls.Add(this.US_Y軸);
			this.Tabウラムの螺旋.Controls.Add(this.US_X軸);
			this.Tabウラムの螺旋.Controls.Add(this.US_L);
			this.Tabウラムの螺旋.Controls.Add(this.US_B);
			this.Tabウラムの螺旋.Controls.Add(this.label5);
			this.Tabウラムの螺旋.Controls.Add(this.label6);
			this.Tabウラムの螺旋.Controls.Add(this.US_T);
			this.Tabウラムの螺旋.Controls.Add(this.Btn_US);
			this.Tabウラムの螺旋.Location = new System.Drawing.Point(4, 29);
			this.Tabウラムの螺旋.Name = "Tabウラムの螺旋";
			this.Tabウラムの螺旋.Size = new System.Drawing.Size(526, 239);
			this.Tabウラムの螺旋.TabIndex = 4;
			this.Tabウラムの螺旋.Text = "ウラムの螺旋";
			this.Tabウラムの螺旋.UseVisualStyleBackColor = true;
			// 
			// SizeInfo
			// 
			this.SizeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SizeInfo.AutoSize = true;
			this.SizeInfo.Location = new System.Drawing.Point(20, 174);
			this.SizeInfo.Name = "SizeInfo";
			this.SizeInfo.Size = new System.Drawing.Size(220, 60);
			this.SizeInfo.TabIndex = 12;
			this.SizeInfo.Text = "幅: 2100000000\r\n高さ: 2100000000\r\n幅×高さ: 4410000000000000000";
			// 
			// BtnCenterColor
			// 
			this.BtnCenterColor.Location = new System.Drawing.Point(87, 140);
			this.BtnCenterColor.Name = "BtnCenterColor";
			this.BtnCenterColor.Size = new System.Drawing.Size(208, 31);
			this.BtnCenterColor.TabIndex = 10;
			this.BtnCenterColor.Text = "中心の色 = ff0000";
			this.BtnCenterColor.UseVisualStyleBackColor = true;
			this.BtnCenterColor.Click += new System.EventHandler(this.BtnCenterColor_Click);
			// 
			// BtnNotPrimeColor
			// 
			this.BtnNotPrimeColor.Location = new System.Drawing.Point(301, 103);
			this.BtnNotPrimeColor.Name = "BtnNotPrimeColor";
			this.BtnNotPrimeColor.Size = new System.Drawing.Size(208, 31);
			this.BtnNotPrimeColor.TabIndex = 9;
			this.BtnNotPrimeColor.Text = "合成数の色 = ffffff";
			this.BtnNotPrimeColor.UseVisualStyleBackColor = true;
			this.BtnNotPrimeColor.Click += new System.EventHandler(this.BtnNotPrimeColor_Click);
			// 
			// BtnPrimeColor
			// 
			this.BtnPrimeColor.Location = new System.Drawing.Point(87, 103);
			this.BtnPrimeColor.Name = "BtnPrimeColor";
			this.BtnPrimeColor.Size = new System.Drawing.Size(208, 31);
			this.BtnPrimeColor.TabIndex = 8;
			this.BtnPrimeColor.Text = "素数の色 = 000000";
			this.BtnPrimeColor.UseVisualStyleBackColor = true;
			this.BtnPrimeColor.Click += new System.EventHandler(this.BtnPrimeColor_Click);
			// 
			// US_R
			// 
			this.US_R.Location = new System.Drawing.Point(87, 70);
			this.US_R.MaxLength = 16;
			this.US_R.Name = "US_R";
			this.US_R.Size = new System.Drawing.Size(208, 27);
			this.US_R.TabIndex = 6;
			this.US_R.Text = "5000";
			this.US_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.US_R.TextChanged += new System.EventHandler(this.US_R_TextChanged);
			this.US_R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.US_R_KeyPress);
			this.US_R.Leave += new System.EventHandler(this.US_R_Leave);
			// 
			// US_Y軸
			// 
			this.US_Y軸.AutoSize = true;
			this.US_Y軸.Location = new System.Drawing.Point(304, 14);
			this.US_Y軸.Name = "US_Y軸";
			this.US_Y軸.Size = new System.Drawing.Size(30, 20);
			this.US_Y軸.TabIndex = 1;
			this.US_Y軸.Text = "Y軸";
			// 
			// US_X軸
			// 
			this.US_X軸.AutoSize = true;
			this.US_X軸.Location = new System.Drawing.Point(90, 14);
			this.US_X軸.Name = "US_X軸";
			this.US_X軸.Size = new System.Drawing.Size(31, 20);
			this.US_X軸.TabIndex = 0;
			this.US_X軸.Text = "X軸";
			// 
			// US_L
			// 
			this.US_L.Location = new System.Drawing.Point(87, 37);
			this.US_L.MaxLength = 16;
			this.US_L.Name = "US_L";
			this.US_L.Size = new System.Drawing.Size(208, 27);
			this.US_L.TabIndex = 3;
			this.US_L.Text = "-5000";
			this.US_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.US_L.TextChanged += new System.EventHandler(this.US_L_TextChanged);
			this.US_L.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.US_L_KeyPress);
			this.US_L.Leave += new System.EventHandler(this.US_L_Leave);
			// 
			// US_B
			// 
			this.US_B.Location = new System.Drawing.Point(301, 70);
			this.US_B.MaxLength = 16;
			this.US_B.Name = "US_B";
			this.US_B.Size = new System.Drawing.Size(208, 27);
			this.US_B.TabIndex = 7;
			this.US_B.Text = "5000";
			this.US_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.US_B.TextChanged += new System.EventHandler(this.US_B_TextChanged);
			this.US_B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.US_B_KeyPress);
			this.US_B.Leave += new System.EventHandler(this.US_B_Leave);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 20);
			this.label5.TabIndex = 2;
			this.label5.Text = "左上座標";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 73);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 20);
			this.label6.TabIndex = 5;
			this.label6.Text = "右下座標";
			// 
			// US_T
			// 
			this.US_T.Location = new System.Drawing.Point(301, 37);
			this.US_T.MaxLength = 16;
			this.US_T.Name = "US_T";
			this.US_T.Size = new System.Drawing.Size(208, 27);
			this.US_T.TabIndex = 4;
			this.US_T.Text = "-5000";
			this.US_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.US_T.TextChanged += new System.EventHandler(this.US_T_TextChanged);
			this.US_T.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.US_T_KeyPress);
			this.US_T.Leave += new System.EventHandler(this.US_T_Leave);
			// 
			// Btn_US
			// 
			this.Btn_US.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Btn_US.Location = new System.Drawing.Point(300, 185);
			this.Btn_US.Name = "Btn_US";
			this.Btn_US.Size = new System.Drawing.Size(208, 39);
			this.Btn_US.TabIndex = 11;
			this.Btn_US.Text = "BMPファイル出力";
			this.Btn_US.UseVisualStyleBackColor = true;
			this.Btn_US.Click += new System.EventHandler(this.Btn_US_Click);
			// 
			// Chkミラーラビン法を使う
			// 
			this.Chkミラーラビン法を使う.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Chkミラーラビン法を使う.AutoSize = true;
			this.Chkミラーラビン法を使う.Location = new System.Drawing.Point(16, 298);
			this.Chkミラーラビン法を使う.Name = "Chkミラーラビン法を使う";
			this.Chkミラーラビン法を使う.Size = new System.Drawing.Size(249, 24);
			this.Chkミラーラビン法を使う.TabIndex = 1;
			this.Chkミラーラビン法を使う.Text = "ミラー・ラビン素数判定法を使用する";
			this.Chkミラーラビン法を使う.UseVisualStyleBackColor = true;
			this.Chkミラーラビン法を使う.CheckedChanged += new System.EventHandler(this.Chkミラーラビン法を使う_CheckedChanged);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 334);
			this.Controls.Add(this.Chkミラーラビン法を使う);
			this.Controls.Add(this.MainTab);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MainWin";
			this.Text = "Prime64";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.Resize += new System.EventHandler(this.MainWin_Resize);
			this.MainTab.ResumeLayout(false);
			this.Tab出力.ResumeLayout(false);
			this.Tab出力.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.Tab判定.ResumeLayout(false);
			this.Tab判定.PerformLayout();
			this.Tab素因数分解.ResumeLayout(false);
			this.Tab素因数分解.PerformLayout();
			this.Tab個数.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.Tabウラムの螺旋.ResumeLayout(false);
			this.Tabウラムの螺旋.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl MainTab;
		private System.Windows.Forms.TabPage Tab出力;
		private System.Windows.Forms.Button BtnDo出力;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox MaxValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox MinValue;
		private System.Windows.Forms.TabPage Tab判定;
		private System.Windows.Forms.TabPage Tab素因数分解;
		private System.Windows.Forms.Button BtnFindNearPrime;
		private System.Windows.Forms.TextBox IsPrimeOutput;
		private System.Windows.Forms.Button BtnIsPrime;
		private System.Windows.Forms.TextBox IsPrimeInputValue;
		private System.Windows.Forms.TextBox FactorizeOutput;
		private System.Windows.Forms.Button BtnFactorize;
		private System.Windows.Forms.TextBox FactorizeInputValue;
		private System.Windows.Forms.CheckBox CheckFactorizeBekijou;
		private System.Windows.Forms.TabPage Tab個数;
		private System.Windows.Forms.Button BtnPrimeCount;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox PrimeCountMaxval;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox PrimeCountMinval;
		private System.Windows.Forms.TabPage Tabウラムの螺旋;
		private System.Windows.Forms.Button BtnCenterColor;
		private System.Windows.Forms.Button BtnNotPrimeColor;
		private System.Windows.Forms.Button BtnPrimeColor;
		private System.Windows.Forms.TextBox US_R;
		private System.Windows.Forms.Label US_Y軸;
		private System.Windows.Forms.Label US_X軸;
		private System.Windows.Forms.TextBox US_L;
		private System.Windows.Forms.TextBox US_B;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox US_T;
		private System.Windows.Forms.Button Btn_US;
		private System.Windows.Forms.Label SizeInfo;
		private System.Windows.Forms.CheckBox Chk改行しない;
		private System.Windows.Forms.CheckBox Chkファイルを分割して出力;
		private System.Windows.Forms.CheckBox Chkミラーラビン法を使う;
	}
}

