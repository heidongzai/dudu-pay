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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //Dong.BLL.Dictionary bAccountNo = new Dong.BLL.Dictionary();
            //Dong.Model.Dictionary mAccountNo = new Dong.Model.Dictionary();

            Dong.BLL.Dictionary bPreBeginDate = new Dong.BLL.Dictionary();
            Dong.Model.Dictionary mPreBeginDate = new Dong.Model.Dictionary();

            Dong.BLL.Dictionary bPreEndDate = new Dong.BLL.Dictionary();
            Dong.Model.Dictionary mPreEndDate = new Dong.Model.Dictionary();

            Dong.BLL.Dictionary bPreTimes = new Dong.BLL.Dictionary();
            Dong.Model.Dictionary mPreTimes = new Dong.Model.Dictionary();


            //序列号
           
            //试用开始时间
            string strSql_PreBeginDate = "KeyStr = 'PreBeginDate'";

            List<Dong.Model.Dictionary> PreBeginDateList = bPreBeginDate.GetModelList(strSql_PreBeginDate);
            String PreBeginDate="";
            if (PreBeginDateList.Count != 0)
            {
                mPreBeginDate = PreBeginDateList[0];
                if (!string.IsNullOrEmpty(mPreBeginDate.ValueStr))
                {
                    PreBeginDate = mPreBeginDate.ValueStr;
                }
            }
            //试用结束时间
            string strSql_PreEndDate = "KeyStr = 'PreEndDate'";
            List<Dong.Model.Dictionary> PreEndDateList = bPreEndDate.GetModelList(strSql_PreEndDate);

             String PreEndDate="";
             if (PreEndDateList.Count != 0)
            {
                mPreEndDate = PreEndDateList[0];
                if (!string.IsNullOrEmpty(mPreEndDate.ValueStr))
                {
                    PreEndDate = mPreEndDate.ValueStr;
                }
            }
            //试用次数
              String PreTimes="";


            //获取授权密文s
           string key=CommonUtility.ReadReader("duduCasherDB/hlx.dll","2");
           Dong.Model.GlobalsInfo.key = key;
            //试用次数
            PreTimes = CommonUtility.ReadReader("duduCasherDB/sycs.dll","2");
           // string jiqima = "cpuid:" + Computer.Instance().CpuID + "|diskId:" + Computer.Instance().DiskID + "|macAddress:" + Computer.Instance().MacAddress + "|LoginUserName:" + Computer.Instance().LoginUserName + "|IpAddress:" + Computer.Instance().IpAddress;
           //     string info = CommonUtility.TestDecry(key, null);
            //如果授权密文为空或者序列号为空或授权验证失败 ，说明该产品为试用版
            string shiyong="1";//默认试用版
            //默认使用侧数为0次
            int shengyuTimes = 0;
            if (!string.IsNullOrEmpty(PreTimes))
            {
                shengyuTimes = 60 - Convert.ToInt32(PreTimes);
            }
            if (!CommonUtility.TestReg().Equals("1"))
            {
                    //如果使用次数为空 使用开始时间或结束时间为空，认定为首次试用，则将次数设定为1, 则将开始时间设定为当前时间，将结束时间设定为+30天
                    if (string.IsNullOrEmpty(PreTimes) || string.IsNullOrEmpty(PreBeginDate) || string.IsNullOrEmpty(PreEndDate))
                    {
                        PreTimes = "1";
                        PreBeginDate = DateTime.Today.ToString("yyyy-MM-dd");
                        DateTime d = DateTime.Now;
                        d = d.AddDays(30);
                        PreEndDate = d.ToString("yyyy-MM-dd");
                        shengyuTimes = 60;
                    }
                    else 
                    {
                        //如果次数超过60，或者当前时间晚于试用期结束时间
                        if (Convert.ToInt32(PreTimes) >= 60 || DateTime.Compare(DateTime.ParseExact(PreEndDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),DateTime.Today)<0)
                        {
                            MessageBoxEx.Show("您的试用期已结束!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }
                        //未超试用期，将当前次数+1,计算客户到期日期和剩余使用次数
                        else
                        {
                            //将当前使用次数+1
                            int sum1=Convert.ToInt32(PreTimes) + 1;
                            PreTimes = Convert.ToString(sum1);
                            //计算客户到期日期和剩余使用次数
                            shengyuTimes = 60 - sum1;
                        }
                        

                    }
              
             
            }else{
                //不是使用版
                shiyong="0";
            }


            //登录
            if (tbPwd.Text == "" || cbUserid.Text == "")
            {
                MessageBoxEx.Show("请输入登录口令!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dong.BLL.OperInfo bOper = new Dong.BLL.OperInfo();
            Dong.Model.OperInfo oi=bOper.GetModel(cbUserid.Text);
            //当登录用户权限为营业员时，屏蔽高级别权限按钮
            //默认为营业员权限
            int r = 1;
            if (oi != null)
            {
                if (oi.Role.Equals(0))
                {
                    r = 0;
                }
               

            }
            Dong.Model.GlobalsInfo.role = r;
            if (bOper.CheckUser(cbUserid.Text, tbPwd.Text))
            {
                
                Dong.Model.GlobalsInfo.UserName = cbUserid.Text;
                frmMain frm = new frmMain();
                //如果是试用版，则提醒软件剩余使用次数和到期时间
                if (shiyong.Equals("1")){
                    MessageBoxEx.Show("您的软件到期时间为" + PreEndDate+",剩余使用次数为"+shengyuTimes+"次", "使用", MessageBoxButtons.OK);

                    //保存剩余次数，试用开始时间，试用结束时间
                    mPreBeginDate.KeyStr="PreBeginDate";
                    mPreBeginDate.ValueStr = PreBeginDate;
                    mPreEndDate.KeyStr = "PreEndDate";
                    mPreEndDate.ValueStr = PreEndDate;
                    mPreTimes.KeyStr = "PreTimes";
                    mPreTimes.ValueStr = PreTimes;
                    
                    bPreBeginDate.Update(mPreBeginDate);
                    bPreEndDate.Update(mPreEndDate);
                    bPreTimes.Update(mPreTimes);
                    CommonUtility.WriteWriter("duduCasherDB/sycs.dll", PreTimes,"2");
                
                }
                frm.Show();
                this.Visible = false;

            }
            else
            {
                MessageBoxEx.Show("您输入的口令不正确!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //从本地路径获取远程主机地址，如果远程主机地址存在，则用远程模式连接，否则用本地模式连接

            String hostIp=CommonUtility.ReadReader("hostIp.dll","2");
            if (string.IsNullOrEmpty(hostIp))
            {
                string str = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/duduSoft/duduCasher/duduCasherDB/MarketDB.mdb";
                CommonUtility.SetValue("ConnectionString", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str);

            }
            else
            {
                string str = "\\\\" + hostIp + "/duduCasherDB/MarketDB.mdb";
                CommonUtility.SetValue("ConnectionString", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str);

            }
            
            try
            {
                //初始化界面信息
                //提取用户列表
                DataSet ds = new DataSet();
                Dong.BLL.OperInfo mOper = new Dong.BLL.OperInfo();
                ds = mOper.GetAllList();
                cbUserid.ValueMember = "Code";
                cbUserid.DisplayMember = "Code";
                cbUserid.DataSource = ds.Tables[0];

                //提取配置信息
                Dong.BLL.ShopInfo bShop = new Dong.BLL.ShopInfo();
                Dong.Model.ShopInfo mShop = new Dong.Model.ShopInfo();
                mShop = bShop.GetModel(1);
                Dong.Model.GlobalsInfo.shopName = mShop.Name;
                //this.Text = this.Text + " --【" + mShop.Name + "】";

                Dong.Model.GlobalsInfo.shopAddr = mShop.Addr;


                if (CommonUtility.TestReg().Equals("1"))
                {
                    this.labelX3.Visible = false;
                }
                //版本号
                String ver = CommonUtility.ReadReader("ver.dll","0");
                this.Text = "嘟嘟收银系统" + ver;


                Dong.Model.GlobalsInfo.hostIp = hostIp;
            }
            catch (Exception e1)
            {
                
           
            if (string.IsNullOrEmpty(hostIp)) { 
                MessageBoxEx.Show("您当前为单机模式，查询数据库出错，请联系管理员!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBoxEx.Show("您当前为联机模式，查询数据库出错，请配置正确的主机ip地址!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Application.Exit();
                    return true;
                case Keys.Enter:
                    btnLogin_Click(null, null);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmReg frmReg = new frmReg();
            frmReg.Show();
            //this.Visible = false;
            return;
        }

        private void labelX3_Click(object sender, EventArgs e)
        {
            
            frmReg frmReg = new frmReg();
            frmReg.Show();
            this.Visible = false;
            return;
        
        }

        private void cbUserid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

            frmHostConfig frmHostConfig = new frmHostConfig();
            frmHostConfig.Show();
            this.Visible = false;
            return;
        }
    }
}
