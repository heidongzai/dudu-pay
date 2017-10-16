namespace AppCash
{
    partial class frmCVip
    { 
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbVipCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbVipName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbVipCode
            // 
            this.tbVipCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbVipCode.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbVipCode.Location = new System.Drawing.Point(204, 97);
            this.tbVipCode.Margin = new System.Windows.Forms.Padding(4);
            this.tbVipCode.Name = "tbVipCode";
            this.tbVipCode.Size = new System.Drawing.Size(366, 45);
            this.tbVipCode.TabIndex = 11;
            this.tbVipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVipCode.TextChanged += new System.EventHandler(this.tbVipCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 42);
            this.label1.TabIndex = 13;
            this.label1.Text = "会员姓名:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(20, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 42);
            this.label10.TabIndex = 12;
            this.label10.Text = "会员手机号:";
            // 
            // tbVipName
            // 
            this.tbVipName.BackColor = System.Drawing.SystemColors.Highlight;
            this.tbVipName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbVipName.ForeColor = System.Drawing.SystemColors.Info;
            this.tbVipName.Location = new System.Drawing.Point(204, 184);
            this.tbVipName.Margin = new System.Windows.Forms.Padding(4);
            this.tbVipName.Name = "tbVipName";
            this.tbVipName.ReadOnly = true;
            this.tbVipName.Size = new System.Drawing.Size(366, 45);
            this.tbVipName.TabIndex = 14;
            this.tbVipName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVipName.TextChanged += new System.EventHandler(this.tbVipName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(217, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 42);
            this.label2.TabIndex = 15;
            this.label2.Text = "会员信息";
            // 
            // frmCVip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(616, 263);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbVipName);
            this.Controls.Add(this.tbVipCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCVip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmVip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbVipCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbVipName;
        private System.Windows.Forms.Label label2;
    }
}