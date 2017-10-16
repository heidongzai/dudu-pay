namespace AppCash
{
    partial class frmReportMonth
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportMonth));
            this.lblGain = new DevComponents.DotNetBar.LabelX();
            this.gvList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.timeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weixinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alipayCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GainCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lblXSZE = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.lblCount = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblAlipay = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.lblWeixin = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.lblCash = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cbYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGain
            // 
            // 
            // 
            // 
            this.lblGain.BackgroundStyle.Class = "";
            this.lblGain.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblGain.ForeColor = System.Drawing.Color.Red;
            this.lblGain.Location = new System.Drawing.Point(848, 39);
            this.lblGain.Margin = new System.Windows.Forms.Padding(4);
            this.lblGain.Name = "lblGain";
            this.lblGain.Size = new System.Drawing.Size(204, 26);
            this.lblGain.TabIndex = 6;
            this.lblGain.Text = "0";
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
            this.gvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.gvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeCol,
            this.countCol,
            this.priceCol,
            this.cashCol,
            this.weixinCol,
            this.alipayCol,
            this.GainCol});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvList.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gvList.Location = new System.Drawing.Point(0, 72);
            this.gvList.Margin = new System.Windows.Forms.Padding(4);
            this.gvList.MultiSelect = false;
            this.gvList.Name = "gvList";
            this.gvList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvList.RowTemplate.Height = 30;
            this.gvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvList.Size = new System.Drawing.Size(1077, 336);
            this.gvList.TabIndex = 12;
            this.gvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellContentClick);
            // 
            // timeCol
            // 
            this.timeCol.DataPropertyName = "IDate1";
            this.timeCol.HeaderText = "购买月份";
            this.timeCol.Name = "timeCol";
            this.timeCol.ReadOnly = true;
            // 
            // countCol
            // 
            this.countCol.DataPropertyName = "Counts1";
            this.countCol.HeaderText = "数量";
            this.countCol.Name = "countCol";
            this.countCol.ReadOnly = true;
            // 
            // priceCol
            // 
            this.priceCol.DataPropertyName = "Price1";
            this.priceCol.HeaderText = "销售额";
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            // 
            // cashCol
            // 
            this.cashCol.DataPropertyName = "Price_Cash";
            this.cashCol.HeaderText = "现金";
            this.cashCol.Name = "cashCol";
            this.cashCol.ReadOnly = true;
            // 
            // weixinCol
            // 
            this.weixinCol.DataPropertyName = "Price_Weixin";
            this.weixinCol.HeaderText = "微信";
            this.weixinCol.Name = "weixinCol";
            this.weixinCol.ReadOnly = true;
            // 
            // alipayCol
            // 
            this.alipayCol.DataPropertyName = "Price_Alipay";
            this.alipayCol.HeaderText = "支付宝";
            this.alipayCol.Name = "alipayCol";
            this.alipayCol.ReadOnly = true;
            // 
            // GainCol
            // 
            this.GainCol.DataPropertyName = "Gain";
            this.GainCol.HeaderText = "盈利";
            this.GainCol.Name = "GainCol";
            this.GainCol.ReadOnly = true;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.Location = new System.Drawing.Point(774, 39);
            this.labelX6.Margin = new System.Windows.Forms.Padding(4);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(82, 26);
            this.labelX6.TabIndex = 5;
            this.labelX6.Text = "总盈利：";
            // 
            // lblXSZE
            // 
            // 
            // 
            // 
            this.lblXSZE.BackgroundStyle.Class = "";
            this.lblXSZE.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblXSZE.Location = new System.Drawing.Point(175, 54);
            this.lblXSZE.Margin = new System.Windows.Forms.Padding(4);
            this.lblXSZE.Name = "lblXSZE";
            this.lblXSZE.Size = new System.Drawing.Size(252, 26);
            this.lblXSZE.TabIndex = 4;
            this.lblXSZE.Text = "0";
            this.lblXSZE.Click += new System.EventHandler(this.lblXSZE_Click);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.Location = new System.Drawing.Point(83, 54);
            this.labelX5.Margin = new System.Windows.Forms.Padding(4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(113, 26);
            this.labelX5.TabIndex = 3;
            this.labelX5.Text = "销售总额：";
            // 
            // lblCount
            // 
            // 
            // 
            // 
            this.lblCount.BackgroundStyle.Class = "";
            this.lblCount.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCount.Location = new System.Drawing.Point(175, 15);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(226, 26);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "0";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.Location = new System.Drawing.Point(82, 18);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(99, 26);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "销售商数：";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(20, 39);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(76, 26);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "合计：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Location = new System.Drawing.Point(54, 18);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(94, 32);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "统计年份:";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(315, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 34);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "统计";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.lblAlipay);
            this.panelEx2.Controls.Add(this.labelX11);
            this.panelEx2.Controls.Add(this.lblWeixin);
            this.panelEx2.Controls.Add(this.labelX9);
            this.panelEx2.Controls.Add(this.lblCash);
            this.panelEx2.Controls.Add(this.labelX7);
            this.panelEx2.Controls.Add(this.lblGain);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.lblXSZE);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.lblCount);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 408);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1077, 99);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 11;
            // 
            // lblAlipay
            // 
            // 
            // 
            // 
            this.lblAlipay.BackgroundStyle.Class = "";
            this.lblAlipay.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAlipay.Location = new System.Drawing.Point(542, 69);
            this.lblAlipay.Margin = new System.Windows.Forms.Padding(4);
            this.lblAlipay.Name = "lblAlipay";
            this.lblAlipay.Size = new System.Drawing.Size(219, 26);
            this.lblAlipay.TabIndex = 12;
            this.lblAlipay.Text = "0";
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.Location = new System.Drawing.Point(451, 69);
            this.labelX11.Margin = new System.Windows.Forms.Padding(4);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(83, 26);
            this.labelX11.TabIndex = 11;
            this.labelX11.Text = "支付宝：";
            // 
            // lblWeixin
            // 
            // 
            // 
            // 
            this.lblWeixin.BackgroundStyle.Class = "";
            this.lblWeixin.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblWeixin.Location = new System.Drawing.Point(542, 39);
            this.lblWeixin.Margin = new System.Windows.Forms.Padding(4);
            this.lblWeixin.Name = "lblWeixin";
            this.lblWeixin.Size = new System.Drawing.Size(206, 26);
            this.lblWeixin.TabIndex = 10;
            this.lblWeixin.Text = "0";
            this.lblWeixin.Click += new System.EventHandler(this.lblWeixin_Click);
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.Location = new System.Drawing.Point(451, 39);
            this.labelX9.Margin = new System.Windows.Forms.Padding(4);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(83, 26);
            this.labelX9.TabIndex = 9;
            this.labelX9.Text = "微信：";
            // 
            // lblCash
            // 
            // 
            // 
            // 
            this.lblCash.BackgroundStyle.Class = "";
            this.lblCash.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCash.Location = new System.Drawing.Point(542, 8);
            this.lblCash.Margin = new System.Windows.Forms.Padding(4);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(219, 26);
            this.lblCash.TabIndex = 8;
            this.lblCash.Text = "0";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.Location = new System.Drawing.Point(451, 8);
            this.labelX7.Margin = new System.Windows.Forms.Padding(4);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(83, 26);
            this.labelX7.TabIndex = 7;
            this.labelX7.Text = "现金：";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cbYear);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.btnSearch);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1077, 72);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 10;
            this.panelEx1.Click += new System.EventHandler(this.panelEx1_Click);
            // 
            // cbYear
            // 
            this.cbYear.DisplayMember = "Text";
            this.cbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.ItemHeight = 15;
            this.cbYear.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8,
            this.comboItem9,
            this.comboItem10,
            this.comboItem11,
            this.comboItem12,
            this.comboItem13});
            this.cbYear.Location = new System.Drawing.Point(144, 15);
            this.cbYear.Margin = new System.Windows.Forms.Padding(4);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(160, 21);
            this.cbYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbYear.TabIndex = 11;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "2013";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2014";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "2015";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "2016";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "2017";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "2018";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "2019";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "2020";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "2021";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "2022";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "2023";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "2024";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "2015";
            // 
            // frmReportMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 507);
            this.Controls.Add(this.gvList);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReportMonth";
            this.Text = "营收月报";
            this.Load += new System.EventHandler(this.frmReportMonth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblGain;
        private DevComponents.DotNetBar.Controls.DataGridViewX gvList;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lblXSZE;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX lblCount;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbYear;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.DotNetBar.LabelX lblAlipay;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX lblWeixin;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX lblCash;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn weixinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn alipayCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn GainCol;
    }
}