using Learun.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learun.Dev.Tool
{
    public partial class 力软开发小工具 : Form
    {
        public 力软开发小工具()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 同步bin文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string formPath = Config.GetValue("FormPath");//来源文件目录
            string toPath = Config.GetValue("ToPath");    //目标文件目录
            string[] filePaths = DirFileHelper.GetFileNames(formPath,"*",true);

            textBox1.AppendText("开始复制文件\r\n");
            int num = 0;

            foreach (string filePath in filePaths)
            {
                if (filePath.IndexOf("\\bin\\Release") != -1)
                {
                    textBox1.AppendText(num + ":" + filePath + "\r\n");
                    string path = toPath + filePath.Replace(formPath, "");
                    FileInfo fi = new FileInfo(path);
                    if (!Directory.Exists( fi.DirectoryName))
                        Directory.CreateDirectory(fi.DirectoryName);
                    System.IO.File.Copy(filePath, path, true);
                    num++;
                }
            }
            textBox1.AppendText("结束复制文件\r\n");
        }
    }
}
