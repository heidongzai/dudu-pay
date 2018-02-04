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
    public partial class frmChengben : Form
    {

        

        #region ------窗体实例化------
        public frmChengben()
        {
            InitializeComponent();
        }
        #endregion

        #region ------窗体加载------
        private void frmChengben_Load(object sender, EventArgs e)
        {
            //设置DataGridView的显示样式
            gvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gvList.AutoGenerateColumns = false;
            fillGVList();
        }
        #endregion



        #region ------搜索------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            
               // if (!string.IsNullOrEmpty(startTime))
               // {
               //     strSql += " and IDate = #" + startTime + "# ";
               //     time1 = startTime;
               // }
               // if (!string.IsNullOrEmpty(endTime))
               // {
               //     strSql += "  and IDate=#" + endTime + " 23:59:59# ";
                //    time1 = endTime;
               // }
           
          
        }
        #endregion



        #region ------填出datagridview------
        private void fillGVList()
        {

            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt = bll.getChengBenList();
            dt1 = bll.getChengBen();
            dt2 = bll.getKCZS();
            gvList.DataSource = dt;
            String Code;
            String GoodName;
            String CategoryName;
            int Counts = 0;
            double Price2 = 0;
            double CostsAll = 0;
            String sum_ = dt1.Rows[0][0].ToString();
            String kczs = dt2.Rows[0][0].ToString();
           
            double CostsAllSum = 0;
            if (!string.IsNullOrEmpty(sum_))
            {
                try { 
                CostsAllSum = double.Parse(sum_);}catch(Exception e){

                }
            }
           
            foreach (DataRow dr in dt.Rows)
            {
                Code=dr[0].ToString();
                GoodName=dr[1].ToString();
                CategoryName=dr[2].ToString();
                Counts += int.Parse(dr[3].ToString());
                Price2 += double.Parse(dr[4].ToString());
                CostsAll += double.Parse(dr[5].ToString());
                
            }

            lblCBZE.Text = string.Format("{0:F2}", CostsAllSum);
            lblZSL.Text = kczs;
            
        }
        #endregion

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelEx2_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillGVList();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }






    }
}
