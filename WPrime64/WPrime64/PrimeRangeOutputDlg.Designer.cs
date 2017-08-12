namespace WPrime64
{
	partial class PrimeRangeOutputDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimeRangeOutputDlg));
			this.MainPBar = new System.Windows.Forms.ProgressBar();
			this.MainMessage = new System.Windows.Forms.Label();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する = new System.Windows.Forms.CheckBox();
			this.TTip = new System.Windows.Forms.ToolTip(this.components);
			this.LblNote = new System.Windows.Forms.Label();
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
			this.MainPBar.Size = new System.Drawing.Size(634, 30);
			this.MainPBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.MainPBar.TabIndex = 1;
			// 
			// MainMessage
			// 
			this.MainMessage.AutoSize = true;
			this.MainMessage.Location = new System.Drawing.Point(30, 30);
			this.MainMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.MainMessage.Name = "MainMessage";
			this.MainMessage.Size = new System.Drawing.Size(115, 20);
			this.MainMessage.TabIndex = 0;
			this.MainMessage.Text = "準備しています...";
			// 
			// BtnCancel
			// 
			this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCancel.Location = new System.Drawing.Point(521, 155);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(127, 39);
			this.BtnCancel.TabIndex = 3;
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
			// Chk出力先ドライブの空き領域が逼迫してきたら中止する
			// 
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.AutoSize = true;
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Checked = true;
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.CheckState = System.Windows.Forms.CheckState.Checked;
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Location = new System.Drawing.Point(34, 127);
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Name = "Chk出力先ドライブの空き領域が逼迫してきたら中止する";
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Size = new System.Drawing.Size(353, 24);
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.TabIndex = 2;
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Text = "出力先ドライブの空き領域が逼迫してきたら中止する。";
			this.TTip.SetToolTip(this.Chk出力先ドライブの空き領域が逼迫してきたら中止する, "準備しています...");
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.UseVisualStyleBackColor = true;
			// 
			// LblNote
			// 
			this.LblNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblNote.AutoSize = true;
			this.LblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LblNote.Location = new System.Drawing.Point(50, 154);
			this.LblNote.Name = "LblNote";
			this.LblNote.Size = new System.Drawing.Size(427, 40);
			this.LblNote.TabIndex = 4;
			this.LblNote.Text = "チェックを入れると、出力先ドライブの空き領域が $F MB 未満\r\n且つ $P % 未満になったとき、中止ボタン押下と同じ動作を行います。";
			// 
			// PrimeRangeOutputDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 206);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.LblNote);
			this.Controls.Add(this.Chk出力先ドライブの空き領域が逼迫してきたら中止する);
			this.Controls.Add(this.MainMessage);
			this.Controls.Add(this.MainPBar);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "PrimeRangeOutputDlg";
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
		private System.Windows.Forms.CheckBox Chk出力先ドライブの空き領域が逼迫してきたら中止する;
		private System.Windows.Forms.ToolTip TTip;
		private System.Windows.Forms.Label LblNote;

	}
}
