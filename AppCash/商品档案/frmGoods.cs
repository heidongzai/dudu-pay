using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace AppCash
{
    public partial class frmGoods : Form
    {
        private string categoryId="";
        private string categoryName = "";
        #region ------初始化变量------
        private string strSql = "";                 //查询条件
        private int intPage = 1;                    //当前页码
        private int intPageSize = 20;               //默认每页显示条数
        private int pageCounts = 0;                 //总计路数
        #endregion

        #region ------窗体实例化------
        public frmGoods()
        {
            InitializeComponent();
        }
        #endregion

        #region ------窗体加载------
        private void frmGoods_Load(object sender, EventArgs e)
        {
            //设置DataGridView的显示样式
            gvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvList.AutoGenerateColumns = false;
            fillGVList("", intPageSize, 1);         //填充数据
            //提取供应商列表

            DataSet ds = new DataSet();
            Dong.BLL.Supplier supplier = new Dong.BLL.Supplier();
            
            ds = supplier.GetAllList();
            //cbSupplier.Items.Insert(0, "请选择");
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    cbSupplier.Items.Add(row["Id"].ToString(), row["name"].ToString());
            //}

            DataRow dr = ds.Tables[0].NewRow();
            dr["Id"] = -1;
            dr["Name"] = "请选择";

            ds.Tables[0].Rows.InsertAt(dr,0);

            cbSupplier.ValueMember = "Id";
            cbSupplier.DisplayMember = "Name";
            cbSupplier.DataSource = ds.Tables[0];
            
            cbSupplier.SelectedIndex = 0; 

            //分页
            //初始页面显示条数选择框
            for (int i = 1; i < 6; i++)
            {
                int j = i * 10;
                cbPageSize.Items.Add(j.ToString());
            }
            cbPageSize.Text = "20";                 //页面条数显示框默认显示为20条

            //绑定页面显示条数设置控件的TextChanged事件
            cbPageSize.TextChanged += new EventHandler(cbPageSize_TextChanged);
            //权限控制 商品增加删除修改功能对普通营业员不可见
            if (Dong.Model.GlobalsInfo.role.Equals(1))
            {
                this.btnAdd.Visible = false;
                this.btnDel.Visible = false;
                this.btnEdit.Visible = false;
                this.price2Col.DataPropertyName = "";
                this.price3Col.DataPropertyName = "";
            }

            

        }
        #endregion

        #region ------弹出添加窗孔------
        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmAddGoods frmAdd = new frmAddGoods();
            frmAdd.Owner = this;
            frmAdd.ShowDialog();
        }
        #endregion

        #region ------搜索------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            strSql = "";
            if (tbKey.Text.Trim() != "")
            {
                string key = Maticsoft.Common.StringPlus.GetText(tbKey.Text);
                strSql = " and  GoodName like '%" + key + "%'";
               

            }
            if (tbCode.Text.Trim() != "")
            {
                string key = Maticsoft.Common.StringPlus.GetText(tbCode.Text);
                strSql += "and  Code like '%" + key + "%'";
                

            }
            if (!string.IsNullOrEmpty(categoryId))
            {
                
                strSql += " and  Category =" + categoryId + " ";
            }
            if (null!=cbSupplier.SelectedValue)
            {
                try
                {
                    int i = (int)cbSupplier.SelectedValue;

                    if (i != -1)
                    {
                        strSql += " and  Supplier =" + cbSupplier.SelectedValue + " ";
                    }
                }
                catch (Exception e2)
                {

                }
            }
            
            if (!string.IsNullOrEmpty(tbKuCunMin.Text)) {
                int minNum ;
                if ( !int.TryParse(tbKuCunMin.Text, out minNum))
                {
                    MessageBoxEx.Show("库存数量必须为整数!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbKuCunMin.Focus();
                    return;
                }
                else
                {
                    strSql += " and  Counts >=" + minNum + " ";
                }
            }
            
            if (!string.IsNullOrEmpty(tbKuCunMin.Text)) {
                int maxNum ;
                if ( !int.TryParse(tbKuCunMax.Text, out maxNum))
                {
                    MessageBoxEx.Show("库存数量必须为整数!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbKuCunMax.Focus();
                    return;
                }
                {
                   
                        strSql += " and  Counts <=" + maxNum + " ";
                   
                }
            }
            intPage = 1;
            fillGVList(strSql, intPageSize, 1);
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string jdkj= this.ActiveControl.Name;
            switch (keyData)
            {
              
                case Keys.Enter:
                    if (jdkj.Equals(tbCode.Name) || jdkj.Equals(tbKey.Name))
                    {
                        btnSearch_Click(null, null);
                    }
                    
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #region ------共用刷新方法------
        public void refreshData()
        {
            fillGVList(strSql, intPageSize, intPage);
        }
        #endregion

        #region ------填出datagridview------
        private void fillGVList(string key, int pageSize, int page)
        {
            strSql = key;
            intPage = page;
            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            DataSet ds = new DataSet();
            ds = bll.GetListPage(key, pageSize, page);

            gvList.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                intPages();
            }
            

        }
        #endregion

        #region ------显示所有数据------
        private void btnAll_Click(object sender, EventArgs e)
        {
            fillGVList("", intPageSize, intPage);
            intPage = 1;


        }
        #endregion

        #region ------单条删除记录------
        private void btnDel_Click(object sender, EventArgs e)
        {
            //删除商品
            string id = gvList.SelectedRows[0].Cells[0].Value.ToString();
            if (id != "")
            {
                if (MessageBoxEx.Show("确定删除该记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    String strSql2 = "1=1 and PCode=";
                    Dong.BLL.InGoods bl = new Dong.BLL.InGoods();
                    DataSet ds = new DataSet();
                    ds = bl.GetList(strSql2);

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }


                    Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
                    bll.Delete(int.Parse(id));
                    this.gvList.Rows[0].Selected = true;
                    fillGVList(strSql, intPageSize, intPage);
                }
            }
            else
            {
                MessageBoxEx.Show("请选择要删除的行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ------弹出编辑窗口------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            string id = gvList.SelectedRows[0].Cells[0].Value.ToString();
            if (id != "")
            {
                frmEditGoods frmEdit = new frmEditGoods();
                frmEdit.Owner = this;
                frmEdit.Tag = id.ToString();
                frmEdit.ShowDialog();

            }
            else
            {
                MessageBoxEx.Show("请选择要修改的行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ------双击行弹出编辑界面------
        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //如果是普通用户，双击没有反应。
            if (Dong.Model.GlobalsInfo.role.Equals(1))
            {
                return;
            }
            string id = gvList.SelectedRows[0].Cells[0].Value.ToString();
            if (id != "")
            {
                frmEditGoods frmEdit = new frmEditGoods();
                frmEdit.Owner = this;
                frmEdit.Tag = id.ToString();
                frmEdit.ShowDialog();
            }
        }
        #endregion

        #region ------分页代码------
        private void intPages()
        {
            Dong.BLL.GoodsInfo bVip = new Dong.BLL.GoodsInfo();
            int counts = bVip.GetRecordCount(strSql);
            lblCounts.Text = counts.ToString();
            if (counts % intPageSize == 0)
            {
                pageCounts = counts / intPageSize;

            }
            else
            {
                pageCounts = (counts / intPageSize) + 1;

            }

            cbPage.Items.Clear();
            for (int i = 1; i <= pageCounts; i++)
            {
                cbPage.Items.Add(i.ToString());
            }
            cbPage.SelectedIndex = intPage - 1;
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            //转移到第一页
            fillGVList(strSql, intPageSize, 1);

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            intPage--;
            if (intPage >= 1)
            {
                fillGVList(strSql, intPageSize, intPage);
            }
            else
            {
                intPage++;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPage++;
            if (intPage <= pageCounts)
            {
                fillGVList(strSql, intPageSize, intPage);
            }
            else
            {
                intPage--;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            fillGVList(strSql, intPageSize, pageCounts);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            int cPage = int.Parse(cbPage.Text);
            fillGVList(strSql, intPageSize, cPage);
        }

        private void cbPageSize_TextChanged(object sender, EventArgs e)
        {
            if (cbPageSize.Text != "")
            {
                int cPageSize = int.Parse(cbPageSize.Text);
                intPageSize = cPageSize;
                fillGVList(strSql, cPageSize, 1);
            }
        }

        #endregion

        private void tbCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //点击弹出方法
            frmCategorySelected frmChild = new frmCategorySelected();
            frmChild.ShowDialog();
            if (frmChild.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                categoryId = frmChild.CategoryId;
                categoryName = frmChild.CategoryName;
                this.tbCategory.Text = categoryName;
            }
        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void btnReturnBack_Click(object sender, EventArgs e)
        {

            string id = gvList.SelectedRows[0].Cells[0].Value.ToString();
            if (id != "")
            {

                frmJinhuoReturnBack frmBack = new frmJinhuoReturnBack();
                frmBack.Owner = this;
                frmBack.Tag = id.ToString();
                frmBack.ShowDialog();
                
            }
            else
            {
                MessageBoxEx.Show("请选择要退货的行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbUserid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTiaojia_Click(object sender, EventArgs e)
        {

            string id = gvList.SelectedRows[0].Cells[0].Value.ToString();
            if (id != "")
            {

                frmJinhuoTiaojia frmTiaojia = new frmJinhuoTiaojia();
                frmTiaojia.Owner = this;
                frmTiaojia.Tag = id.ToString();
                frmTiaojia.ShowDialog();

            }
            else
            {
                MessageBoxEx.Show("请选择要调价的行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
