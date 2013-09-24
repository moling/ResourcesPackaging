namespace xmlPackaging
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_xmlurl = new System.Windows.Forms.TextBox();
            this.btn_packing = new System.Windows.Forms.Button();
            this.txt_fileName = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_xmlurl
            // 
            this.txt_xmlurl.Location = new System.Drawing.Point(8, 7);
            this.txt_xmlurl.Name = "txt_xmlurl";
            this.txt_xmlurl.ReadOnly = true;
            this.txt_xmlurl.Size = new System.Drawing.Size(267, 21);
            this.txt_xmlurl.TabIndex = 0;
            this.txt_xmlurl.Text = "点击选择资源目录";
            this.txt_xmlurl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_xmlurl_MouseClick);
            // 
            // btn_packing
            // 
            this.btn_packing.Location = new System.Drawing.Point(171, 33);
            this.btn_packing.Name = "btn_packing";
            this.btn_packing.Size = new System.Drawing.Size(104, 23);
            this.btn_packing.TabIndex = 2;
            this.btn_packing.Text = "开 始 打 包";
            this.btn_packing.UseVisualStyleBackColor = true;
            this.btn_packing.Click += new System.EventHandler(this.btn_packing_Click);
            // 
            // txt_fileName
            // 
            this.txt_fileName.Location = new System.Drawing.Point(10, 33);
            this.txt_fileName.MaxLength = 12;
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(155, 21);
            this.txt_fileName.TabIndex = 4;
            this.txt_fileName.Text = "res.swf";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(26, 114);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(24, 20);
            this.webBrowser1.TabIndex = 5;
            this.webBrowser1.Url = new System.Uri("http://www.56lea.com", System.UriKind.Absolute);
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(6, 60);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output.Size = new System.Drawing.Size(272, 98);
            this.txt_output.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txt_fileName);
            this.Controls.Add(this.btn_packing);
            this.Controls.Add(this.txt_xmlurl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小菜flash资源打包工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_xmlurl;
        private System.Windows.Forms.Button btn_packing;
        private System.Windows.Forms.TextBox txt_fileName;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txt_output;
    }
}

