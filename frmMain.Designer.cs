namespace JavaClassReader
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.rxtxtInfo = new System.Windows.Forms.RichTextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(912, 21);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(131, 26);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "选择Class文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // rxtxtInfo
            // 
            this.rxtxtInfo.BackColor = System.Drawing.Color.Black;
            this.rxtxtInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rxtxtInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.rxtxtInfo.Location = new System.Drawing.Point(12, 66);
            this.rxtxtInfo.Name = "rxtxtInfo";
            this.rxtxtInfo.Size = new System.Drawing.Size(1031, 628);
            this.rxtxtInfo.TabIndex = 1;
            this.rxtxtInfo.Text = "";
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPath.Location = new System.Drawing.Point(12, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(894, 26);
            this.txtPath.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 715);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.rxtxtInfo);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "frmMain";
            this.Text = "JavaClassReader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.RichTextBox rxtxtInfo;
        private System.Windows.Forms.TextBox txtPath;
    }
}

