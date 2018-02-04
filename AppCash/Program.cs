using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace AppCash
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //
            
            
            try { 
                //if (checkUpdateLoad())
                //{
                    
                   // Environment.Exit(0);
                    
                    //return;
                //}
               // else
                //{
                    Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);

                    Application.Run(new frmLogin());
                //}  
                }
            catch (Exception e)
            {
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new frmLogin());
            }
            
        }
        public static bool checkUpdateLoad()
        {
            bool result = false;
            SoftUpdate app = new SoftUpdate(Application.ExecutablePath, "AppCash");
            try
            {
                if (app.IsUpdate && MessageBox.Show("检查到新版本，是否更新？（建议安装！安装新版本不会修改和删除您的任何注册信息和经营数据）", "版本检查", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string path = Application.StartupPath.Replace("program", "");
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "autoUpdate.exe";
                    process.StartInfo.WorkingDirectory = path;//要掉用得exe路径例如:"C:\windows";                 
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                result = false;
            }
            return result;
        }  
    }
}
