namespace AppCash
{
    partial class frmGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoods));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnReturnBack = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.tbCategory = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnAll = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.tbKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnFirst = new DevComponents.DotNetBar.ButtonItem();
            this.btnPre = new DevComponents.DotNetBar.ButtonItem();
            this.btnNext = new DevComponents.DotNetBar.ButtonItem();
            this.btnLast = new DevComponents.DotNetBar.ButtonItem();
            this.cbPage = new DevComponents.DotNetBar.ComboBoxItem();
            this.btnGoto = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lblCounts = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.lbl = new DevComponents.DotNetBar.LabelItem();
            this.cbPageSize = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.gvList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.IdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factoryCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supperCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price1Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price2Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price3Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnReturnBack);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.tbCategory);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.tbCode);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.btnAll);
            this.panelEx1.Controls.Add(this.btnAdd);
            this.panelEx1.Controls.Add(this.btnDel);
            this.panelEx1.Controls.Add(this.btnEdit);
            this.panelEx1.Controls.Add(this.btnSearch);
            this.panelEx1.Controls.Add(this.tbKey);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1318, 72);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Click += new System.EventHandler(this.panelEx1_Click);
            // 
            // btnReturnBack
            // 
            this.btnReturnBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReturnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReturnBack.Location = new System.Drawing.Point(1202, 20);
            this.btnReturnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnReturnBack.Name = "btnReturnBack";
            this.btnReturnBack.Size = new System.Drawing.Size(92, 34);
            this.btnReturnBack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReturnBack.TabIndex = 28;
            this.btnReturnBack.Text = "进货退货";
            this.btnReturnBack.Click += new System.EventHandler(this.btnReturnBack_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(661, 20);
            this.buttonX1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(69, 34);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 27;
            this.buttonX1.Text = "选择";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // tbCategory
            // 
            // 
            // 
            // 
            this.tbCategory.Border.Class = "TextBoxBorder";
            this.tbCategory.ForeColor = System.Drawing.Color.DarkBlue;
            this.tbCategory.Location = new System.Drawing.Point(507, 20);
            this.tbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.ReadOnly = true;
            this.tbCategory.Size = new System.Drawing.Size(146, 28);
            this.tbCategory.TabIndex = 26;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.Location = new System.Drawing.Point(450, 18);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(66, 32);
            this.labelX3.TabIndex = 11;
            this.labelX3.Text = "类别:";
            // 
            // tbCode
            // 
            // 
            // 
            // 
            this.tbCode.Border.Class = "TextBoxBorder";
            this.tbCode.Location = new System.Drawing.Point(59, 20);
            this.tbCode.Margin = new System.Windows.Forms.Padding(4);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(171, 28);
            this.tbCode.TabIndex = 8;
            this.tbCode.TextChanged += new System.EventHandler(this.tbCode_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Location = new System.Drawing.Point(10, 20);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(61, 32);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "条码:";
            // 
            // btnAll
            // 
            this.btnAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAll.Location = new System.Drawing.Point(854, 20);
            this.btnAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(91, 34);
            this.btnAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAll.TabIndex = 6;
            this.btnAll.Text = "显示全部";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(961, 20);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 34);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDel.Location = new System.Drawing.Point(1039, 20);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(70, 34);
            this.btnDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Location = new System.Drawing.Point(1119, 20);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 34);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(768, 20);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 34);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbKey
            // 
            // 
            // 
            // 
            this.tbKey.Border.Class = "TextBoxBorder";
            this.tbKey.Location = new System.Drawing.Point(301, 20);
            this.tbKey.Margin = new System.Windows.Forms.Padding(4);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(142, 28);
            this.tbKey.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(236, 20);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(57, 32);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "名称:";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnFirst,
            this.btnPre,
            this.btnNext,
            this.btnLast,
            this.cbPage,
            this.btnGoto,
            this.labelItem1,
            this.lblCounts,
            this.labelItem3,
            this.lbl,
            this.cbPageSize,
            this.labelItem2});
            this.bar1.Location = new System.Drawing.Point(0, 72);
            this.bar1.Margin = new System.Windows.Forms.Padding(4);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(1318, 35);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnFirst
            // 
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Text = "首  页";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPre
            // 
            this.btnPre.Name = "btnPre";
            this.btnPre.Text = "上一页";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Name = "btnNext";
            this.btnNext.Text = "下一页";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Name = "btnLast";
            this.btnLast.Text = "尾  页";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // cbPage
            // 
            this.cbPage.DropDownHeight = 106;
            this.cbPage.ItemHeight = 24;
            this.cbPage.Name = "cbPage";
            // 
            // btnGoto
            // 
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Text = "Go";
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "共有记录";
            // 
            // lblCounts
            // 
            this.lblCounts.Name = "lblCounts";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "条";
            // 
            // lbl
            // 
            this.lbl.Name = "lbl";
            this.lbl.Text = "每页显示";
            // 
            // cbPageSize
            // 
            this.cbPageSize.DropDownHeight = 106;
            this.cbPageSize.ItemHeight = 24;
            this.cbPageSize.Name = "cbPageSize";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "条";
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
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
            this.IdCol,
            this.codeCol,
            this.nameCol,
            this.cateCol,
            this.unitCol,
            this.factoryCol,
            this.supperCol,
            this.price1Col,
            this.price2Col,
            this.price3Col,
            this.countCol});
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
            this.gvList.Location = new System.Drawing.Point(0, 107);
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
            this.gvList.Size = new System.Drawing.Size(1318, 451);
            this.gvList.TabIndex = 4;
            this.gvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellContentClick);
            this.gvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellDoubleClick);
            // 
            // IdCol
            // 
            this.IdCol.DataPropertyName = "Id";
            this.IdCol.HeaderText = "序号";
            this.IdCol.Name = "IdCol";
            this.IdCol.ReadOnly = true;
            this.IdCol.Visible = false;
            // 
            // codeCol
            // 
            this.codeCol.DataPropertyName = "Code";
            this.codeCol.HeaderText = "编号";
            this.codeCol.Name = "codeCol";
            this.codeCol.ReadOnly = true;
            // 
            // nameCol
            // 
            this.nameCol.DataPropertyName = "GoodName";
            this.nameCol.HeaderText = "名称";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // cateCol
            // 
            this.cateCol.DataPropertyName = "CategoryName";
            this.cateCol.HeaderText = "类别";
            this.cateCol.Name = "cateCol";
            this.cateCol.ReadOnly = true;
            // 
            // unitCol
            // 
            this.unitCol.DataPropertyName = "UnitName";
            this.unitCol.HeaderText = "单位";
            this.unitCol.Name = "unitCol";
            this.unitCol.ReadOnly = true;
            // 
            // factoryCol
            // 
            this.factoryCol.DataPropertyName = "Factory";
            this.factoryCol.HeaderText = "生产厂家";
            this.factoryCol.Name = "factoryCol";
            this.factoryCol.ReadOnly = true;
            // 
            // supperCol
            // 
            this.supperCol.DataPropertyName = "SupplierName";
            this.supperCol.HeaderText = "供应商名称";
            this.supperCol.Name = "supperCol";
            this.supperCol.ReadOnly = true;
            // 
            // price1Col
            // 
            this.price1Col.DataPropertyName = "Price0";
            this.price1Col.HeaderText = " 零售价";
            this.price1Col.Name = "price1Col";
            this.price1Col.ReadOnly = true;
            // 
            // price2Col
            // 
            this.price2Col.DataPropertyName = "price1";
            this.price2Col.HeaderText = "进货价";
            this.price2Col.Name = "price2Col";
            this.price2Col.ReadOnly = true;
            // 
            // price3Col
            // 
            this.price3Col.DataPropertyName = "Price2";
            this.price3Col.HeaderText = "成本价";
            this.price3Col.Name = "price3Col";
            this.price3Col.ReadOnly = true;
            // 
            // countCol
            // 
            this.countCol.DataPropertyName = "Counts";
            this.countCol.HeaderText = "数量";
            this.countCol.Name = "countCol";
            this.countCol.ReadOnly = true;
            // 
            // frmGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 558);
            this.Controls.Add(this.gvList);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.panelEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGoods";
            this.Text = "商品档案";
            this.Load += new System.EventHandler(this.frmGoods_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbKey;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnAll;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnFirst;
        private DevComponents.DotNetBar.Controls.DataGridViewX gvList;
        private DevComponents.DotNetBar.ButtonItem btnPre;
        private DevComponents.DotNetBar.ButtonItem btnNext;
        private DevComponents.DotNetBar.ButtonItem btnLast;
        private DevComponents.DotNetBar.ComboBoxItem cbPage;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem lblCounts;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.ButtonItem btnGoto;
        private DevComponents.DotNetBar.LabelItem lbl;
        private DevComponents.DotNetBar.ComboBoxItem cbPageSize;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCode;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn factoryCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn supperCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn price1Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn price2Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn price3Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCol;
        private DevComponents.DotNetBar.ButtonX btnReturnBack;
    }
}