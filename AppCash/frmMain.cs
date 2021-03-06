﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace AppCash
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 检测要打开的tab
        /// </summary>
        /// <param name="tabName"></param>
        /// <returns></returns>
        private bool IsOpenTab(string tabName)
        {
            bool isOpened = false;

            foreach (TabItem tab in tabMain.Tabs)
            {
                if (tab.Name == tabName.Trim())
                {
                    isOpened = true;
                    tabMain.SelectedTab = tab;
                    break;
                }
            }
            return isOpened;
        }
        public void openWindow(Form frm, string Name)
        {
            DevComponents.DotNetBar.TabItem tp = new DevComponents.DotNetBar.TabItem();
            DevComponents.DotNetBar.TabControlPanel tcp = new DevComponents.DotNetBar.TabControlPanel();
            tp.MouseDown += new MouseEventHandler(tp_MouseDown);
            tcp.Dock = System.Windows.Forms.DockStyle.Fill;
            tcp.Location = new System.Drawing.Point(0, 0);

            frm.TopLevel = false;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tcp.Controls.Add(frm);
            tp.Text = frm.Text;
            tp.Name = Name;

            if (!IsOpenTab(Name))
            {
                tcp.TabItem = tp;
                tp.AttachedControl = tcp;
                tabMain.Controls.Add(tcp);
                tabMain.Tabs.Add(tp);
                tabMain.SelectedTab = tp;
            }
            tabMain.Refresh();
        }
        private void tp_MouseDown(object sender, MouseEventArgs e)
        {
            tabMain.SelectedTab = (TabItem)sender;
            if (e.Button == MouseButtons.Right && tabMain.SelectedTab != null)
            {
                this.tabMain.Select();
                cms.Show(this.tabMain, e.X, e.Y);
            }
        }

        private void tabMain_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            TabItem tb = tabMain.SelectedTab;
            tabMain.Tabs.Remove(tb);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            String ver = CommonUtility.ReadReader("ver.dll","0");
            this.Text = "嘟嘟收银系统" +ver+ "--【" + Dong.Model.GlobalsInfo.shopName + "】";
            lblDate.Text = DateTime.Now.Date.ToString("yyyy年MM月dd日");
            lblShopName.Text = Dong.Model.GlobalsInfo.shopName;
            lblUser.Text = Dong.Model.GlobalsInfo.UserName;
            lblAddr.Text = Dong.Model.GlobalsInfo.shopAddr;


            //当登录用户权限为营业员时，屏蔽高级别权限按钮
            
                if (Dong.Model.GlobalsInfo.role.Equals(1))
                {
                    ribbonBar2.Items.Remove("btnShop");
                    ribbonBar2.Items.Remove("btnUsers");
                    ribbonBar8.Items.Remove("btnJB");
                    ribbonBar8.Items.Remove("btnBF");
                    ribbonControl1.Items.Remove("ribbonTabItem4");
                    ribbonBar3.Items.Remove("btnInput");
                    ribbonBar3.Items.Remove("btnPD");
                    ribbonBar3.Items.Remove("btnCategory");
                    ribbonBar3.Items.Remove("btnUnit");
                    ribbonBar2.Items.Remove("btnSupp");
                }


            
            
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            //弹出商铺信息窗口
            frmShop frm = new frmShop();
            openWindow(frm, frm.Name);
        }
        private void btnSys_Click(object sender, EventArgs e)
        {
            frmCashSet frm = new frmCashSet();

            openWindow(frm, frm.Name);
        }
        private void btnHotKey_Click(object sender, EventArgs e)
        {
            frmHotKey frm = new frmHotKey();
            openWindow(frm, frm.Name);
        }

        private void btnVip_Click(object sender, EventArgs e)
        {
            frmVip frm = new frmVip();
            openWindow(frm, frm.Name);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            openWindow(frm, frm.Name);
        }

        private void btnSupp_Click(object sender, EventArgs e)
        {
            frmSup frm = new frmSup();
            openWindow(frm, frm.Name);
        }

        private void btnGoods_Click(object sender, EventArgs e)
        {
            frmGoods frm = new frmGoods();
            openWindow(frm, frm.Name);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmCategorytree frm = new frmCategorytree();
            openWindow(frm, frm.Name);
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            frmUnit frm = new frmUnit();
            openWindow(frm, frm.Name);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            frmInput frm = new frmInput();
            openWindow(frm, frm.Name);
        }

        private void btnPD_Click(object sender, EventArgs e)
        {
            //frmPD frm = new frmPD();
            //openWindow(frm, frm.Name);
            frmPD frmAdd = new frmPD();
            frmAdd.Owner = this;
            frmAdd.ShowDialog();
        }

        private void btnGoodsSearch_Click(object sender, EventArgs e)
        {
            frmGoodsSearch frm = new frmGoodsSearch();
            openWindow(frm, frm.Name);
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            frmCash frm = new frmCash();
            //openWindow(frm, frm.Name);
            frm.Show();
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            frmReport1 frm = new frmReport1();
            openWindow(frm, frm.Name);
        }

       // private void btnJB_Click(object sender, EventArgs e)
        //{
         //   frmJB frm = new frmJB();
          //  openWindow(frm, frm.Name);
        //}
         private void btnJB_Click(object sender, EventArgs e)
        {
            frmSafe frm = new frmSafe();
          openWindow(frm, frm.Name);
        }

        private void btnReportToDay_Click(object sender, EventArgs e)
        {
            frmToday frm = new frmToday();
            openWindow(frm, frm.Name);
        }

        private void btnReportDay_Click(object sender, EventArgs e)
        {
            frmReportDay frm = new frmReportDay();
            openWindow(frm, frm.Name);
        }

        private void btnReportMonth_Click(object sender, EventArgs e)
        {
            frmReportMonth frm = new frmReportMonth();
            openWindow(frm, frm.Name);
        }

        private void tabMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && tabMain.SelectedTab != null)
            {
                this.tabMain.Select();
                cms.Show(this.tabMain, e.X, e.Y);
            }
        }

        private void tabMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && tabMain.SelectedTab != null)
            {
                this.tabMain.Select();
                cms.Show(this.tabMain, e.X, e.Y);
            }
        }

        private void btnMCloseAll_Click(object sender, EventArgs e)
        {
            tabMain.Tabs.Clear();
        }

        private void btnMCloseOther_Click(object sender, EventArgs e)
        {

            do
            {
                if (tabMain.SelectedTab != tabMain.Tabs[0])
                {
                    tabMain.Tabs.RemoveAt(0);
                }
                else
                {
                    tabMain.Tabs.RemoveAt(1);
                }
                
            } while (tabMain.Tabs.Count!=1);

            tabMain.Refresh();
        }

        private void tabMain_Click(object sender, EventArgs e)
        {

        }

        private void ribbonPanel4_Click(object sender, EventArgs e)
        {

        }

        private void ribbonTabItem4_Click(object sender, EventArgs e)
        {

        }

        private void ribbonTabItem5_Click(object sender, EventArgs e)
        {

        }

        private void ribbonPanel2_Click(object sender, EventArgs e)
        {

        }

        private void btnGY_Click(object sender, EventArgs e)
        {
            frmGY frm = new frmGY();
            openWindow(frm, frm.Name);
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void btnSupp_Click_1(object sender, EventArgs e)
        {
            frmSup frm= new frmSup();
            openWindow(frm, frm.Name);
        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar3_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            frmDbBackup frm = new frmDbBackup();
            openWindow(frm, frm.Name);
            
        }

        private void ribbonPanel5_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem3_Click_1(object sender, EventArgs e)
        {
            frmChengben frm = new frmChengben();
            openWindow(frm, frm.Name);
        }
         
    }
    
}
