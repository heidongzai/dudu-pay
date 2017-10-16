namespace AppCash
{
    partial class frmMoney
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
            this.tbYS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbSSJE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbZL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPayWay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPayCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbYS
            // 
            this.tbYS.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbYS.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbYS.Location = new System.Drawing.Point(194, 35);
            this.tbYS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbYS.Name = "tbYS";
            this.tbYS.Size = new System.Drawing.Size(265, 45);
            this.tbYS.TabIndex = 0;
            this.tbYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(32, 35);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 42);
            this.label10.TabIndex = 4;
            this.label10.Text = "应收金额:";
            // 
            // tbSSJE
            // 
            this.tbSSJE.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbSSJE.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSSJE.Location = new System.Drawing.Point(194, 120);
            this.tbSSJE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSSJE.Name = "tbSSJE";
            this.tbSSJE.Size = new System.Drawing.Size(265, 45);
            this.tbSSJE.TabIndex = 1;
            this.tbSSJE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSSJE.TextChanged += new System.EventHandler(this.tbSSJE_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "实收金额:";
            // 
            // tbZL
            // 
            this.tbZL.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbZL.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbZL.Location = new System.Drawing.Point(194, 209);
            this.tbZL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbZL.Name = "tbZL";
            this.tbZL.ReadOnly = true;
            this.tbZL.Size = new System.Drawing.Size(265, 45);
            this.tbZL.TabIndex = 2;
            this.tbZL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(32, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 42);
            this.label2.TabIndex = 8;
            this.label2.Text = "找零金额:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(32, 299);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 42);
            this.label3.TabIndex = 11;
            this.label3.Text = "支付方式:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbPayWay
            // 
            this.cbPayWay.DisplayMember = "0";
            this.cbPayWay.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbPayWay.FormattingEnabled = true;
            this.cbPayWay.Items.AddRange(new object[] {
            "现金",
            "微信",
            "支付宝"});
            this.cbPayWay.Location = new System.Drawing.Point(194, 300);
            this.cbPayWay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPayWay.Name = "cbPayWay";
            this.cbPayWay.Size = new System.Drawing.Size(265, 47);
            this.cbPayWay.TabIndex = 3;
            this.cbPayWay.Text = "现金";
            this.cbPayWay.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.WindowText;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(36, 386);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 42);
            this.label4.TabIndex = 13;
            this.label4.Text = "付 款 码:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbPayCode
            // 
            this.tbPayCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbPayCode.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPayCode.Location = new System.Drawing.Point(194, 386);
            this.tbPayCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPayCode.Name = "tbPayCode";
            this.tbPayCode.Size = new System.Drawing.Size(265, 45);
            this.tbPayCode.TabIndex = 4;
            this.tbPayCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPayCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // frmMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(530, 469);
            this.ControlBox = false;
            this.Controls.Add(this.tbYS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbSSJE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbZL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPayWay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPayCode);
            this.Controls.Add(this.label4);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmMoney_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbYS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSSJE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbZL;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.ComboBox cbPayWay;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox tbPayCode;
        private System.Windows.Forms.Label label4;

        private double yishou=0;
        private double syyf = 0;
        private double Weixin_=0;
        private double Alipay_=0;
        private double Cash_ = 0;
        private int payTimes = 0;
    }
}