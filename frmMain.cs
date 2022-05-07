using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JavaClassReader
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            string file = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;      //该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";     //弹窗的标题
            //dialog.InitialDirectory = "D:\\";       //默认打开的文件夹的位置
            dialog.Filter = "Java Class文件(*.class)|*.class";       //筛选文件
            //dialog.ShowHelp = true;     //是否显示“帮助”按钮
            
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = dialog.FileName;
                rxtxtInfo.Text = "";
                rxtxtInfo.Text=ClassReader.read(file);
            }

            
        }
    }
}
