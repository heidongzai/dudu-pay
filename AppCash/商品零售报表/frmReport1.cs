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
    public partial class frmReport1 : Form
    {
        private string categoryId = "";
        private string categoryName = "";
        #region ------初始化变量------
        private string strSql = "";                 //查询条件
        private int intPage = 1;                    //当前页码
        private int intPageSize = 20;               //默认每页显示条数
        private int pageCounts = 0;                 //总计路数
        #endregion
        public frmReport1()
        {
            InitializeComponent();
        }

        #region ------搜索------
        private void btnSearch_Click(object sender, EventArgs e)
        {

            strSql = "";
            if (cbCasher.Text.Trim() != "")
            {
                string key = Maticsoft.Common.StringPlus.GetText(cbCasher.Text);
                strSql += " and Oper = '" + key + "'";
                //intPage = 1;
                //fillGVList(strSql, intPageSize, 1);

            }
            if (tbCode.Text.Trim() != "")
            {
                string key = Maticsoft.Common.StringPlus.GetText(tbCode.Text);
                strSql += "and  GoodsCode like '%" + key + "%'";


            }
            if (!string.IsNullOrEmpty(categoryId))
            {

                strSql += " and  Category =" + categoryId + " ";
            }
            
            string startTime = txtStart.Text.Trim();
            string endTime = txtEnd.Text.Trim();

            if (!string.IsNullOrEmpty(startTime))
            {
                strSql += " and IDate >= #" + startTime + "# ";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql += "  and IDate<=#" + endTime + " 23:59:59# ";
            }


            intPage = 1;
            fillGVList(strSql, intPageSize, 1);
        }
        #endregion


        #region ------填出datagridview------
        private void fillGVList(string key, int pageSize, int page)
        {
            strSql = key;
            intPage = page;
            Dong.BLL.SaleInfo bll = new Dong.BLL.SaleInfo();
            DataSet ds = new DataSet();
            ds = bll.GetListPage(key, pageSize, page);

            gvList.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                intPages();
            }
            else
            {
                MessageBoxEx.Show("对不起，没有您搜索的记录!");
            }

        }
        #endregion

        #region ------分页代码------
        private void intPages()
        {
            Dong.BLL.SaleInfo bVip = new Dong.BLL.SaleInfo();
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

        private void frmReport1_Load(object sender, EventArgs e)
        {

            //绑定收银员
            Dong.BLL.OperInfo bOper = new Dong.BLL.OperInfo();
            //Dong.BLL.Category catebll = new Dong.BLL.Category();

            DataTable dt = bOper.GetAllList().Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = "0";
            //dr[1] = "全部";
            //dr[4] = "全部";
            dt.Rows.InsertAt(dr, 0);

            cbCasher.DataSource = dt;
            cbCasher.DisplayMember = "Code";
            cbCasher.ValueMember = "Name";
            //设置DataGridView的显示样式
            gvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvList.AutoGenerateColumns = false;
            fillGVList("", intPageSize, intPage);
            intPage = 1;
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
        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPre_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLast_Click_1(object sender, EventArgs e)
        {

        }

        private void cbPageSize_Click(object sender, EventArgs e)
        {

        }

        private void btnGoto_Click_1(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click_1(object sender, EventArgs e)
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
    }
}
