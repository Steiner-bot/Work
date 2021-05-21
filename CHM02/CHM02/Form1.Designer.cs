
namespace CHM02
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnSolve2 = new System.Windows.Forms.Button();
            this.btnSolve1 = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSolve2
            // 
            this.btnSolve2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSolve2.Location = new System.Drawing.Point(377, 371);
            this.btnSolve2.Margin = new System.Windows.Forms.Padding(2);
            this.btnSolve2.Name = "btnSolve2";
            this.btnSolve2.Size = new System.Drawing.Size(142, 33);
            this.btnSolve2.TabIndex = 2;
            this.btnSolve2.Text = "2 Способ";
            this.btnSolve2.UseVisualStyleBackColor = true;
            this.btnSolve2.Click += new System.EventHandler(this.btnSolve2_Click);
            // 
            // btnSolve1
            // 
            this.btnSolve1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSolve1.Location = new System.Drawing.Point(233, 371);
            this.btnSolve1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSolve1.Name = "btnSolve1";
            this.btnSolve1.Size = new System.Drawing.Size(140, 34);
            this.btnSolve1.TabIndex = 3;
            this.btnSolve1.Text = "1 Способ";
            this.btnSolve1.UseVisualStyleBackColor = true;
            this.btnSolve1.Click += new System.EventHandler(this.btnSolve1_Click);
            // 
            // lbLog
            // 
            this.lbLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 20;
            this.lbLog.Location = new System.Drawing.Point(11, 64);
            this.lbLog.Margin = new System.Windows.Forms.Padding(2);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(728, 284);
            this.lbLog.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Начальный X";
            // 
            // nudX
            // 
            this.nudX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudX.DecimalPlaces = 1;
            this.nudX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudX.Location = new System.Drawing.Point(233, 37);
            this.nudX.Margin = new System.Windows.Forms.Padding(2);
            this.nudX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(99, 20);
            this.nudX.TabIndex = 7;
            this.nudX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudX.ValueChanged += new System.EventHandler(this.nudX_ValueChanged);
            // 
            // nudY
            // 
            this.nudY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudY.DecimalPlaces = 1;
            this.nudY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudY.Location = new System.Drawing.Point(360, 37);
            this.nudY.Margin = new System.Windows.Forms.Padding(2);
            this.nudY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(99, 20);
            this.nudY.TabIndex = 9;
            this.nudY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Начальный Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 510);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btnSolve1);
            this.Controls.Add(this.btnSolve2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Лабараторная работа №2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnSolve2;
		private System.Windows.Forms.Button btnSolve1;
		private System.Windows.Forms.ListBox lbLog;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudX;
		private System.Windows.Forms.NumericUpDown nudY;
		private System.Windows.Forms.Label label5;
	}
}

