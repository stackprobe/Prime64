namespace WPrime64
{
	partial class UlamSpiralOutputDlg
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UlamSpiralOutputDlg));
			this.MainPBar = new System.Windows.Forms.ProgressBar();
			this.MainMessage = new System.Windows.Forms.Label();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// MainPBar
			// 
			this.MainPBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainPBar.Location = new System.Drawing.Point(13, 75);
			this.MainPBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MainPBar.Maximum = 1000000000;
			this.MainPBar.Name = "MainPBar";
			this.MainPBar.Size = new System.Drawing.Size(564, 30);
			this.MainPBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.MainPBar.TabIndex = 1;
			// 
			// MainMessage
			// 
			this.MainMessage.AutoSize = true;
			this.MainMessage.Location = new System.Drawing.Point(30, 30);
			this.MainMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.MainMessage.Name = "MainMessage";
			this.MainMessage.Size = new System.Drawing.Size(195, 20);
			this.MainMessage.TabIndex = 0;
			this.MainMessage.Text = "BMPデータを作成しています...";
			// 
			// BtnCancel
			// 
			this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCancel.Location = new System.Drawing.Point(451, 122);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(127, 39);
			this.BtnCancel.TabIndex = 2;
			this.BtnCancel.Text = "中止";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// MainTimer
			// 
			this.MainTimer.Enabled = true;
			this.MainTimer.Interval = 300;
			this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
			// 
			// UlamSpiralOutputDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 173);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.MainMessage);
			this.Controls.Add(this.MainPBar);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "UlamSpiralOutputDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Prime64";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BusyDlg_FormClosed);
			this.Load += new System.EventHandler(this.BusyDlg_Load);
			this.Shown += new System.EventHandler(this.BusyDlg_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar MainPBar;
		private System.Windows.Forms.Label MainMessage;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Timer MainTimer;

	}
}
