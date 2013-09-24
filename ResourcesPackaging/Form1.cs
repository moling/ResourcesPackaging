using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace xmlPackaging
{
    public partial class Form1 : Form
    {
        private string xmlurl;
        private string fname;
        private string key="C:/Windows/df.dll";
        private List<FileInfo> fileListData = new List<FileInfo>(); //保存所有的文件信息 
        public Form1()
        {
            InitializeComponent();
        }

        private void txt_xmlurl_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                txt_xmlurl.Text = fb.SelectedPath;
            }
        }

        private void btn_packing_Click(object sender, EventArgs e)
        {
            txt_output.Text = "";
            if (txt_xmlurl.Text.Length < 5 || txt_xmlurl.Text == "点击选择XML目录")
            {
                MessageBox.Show("请选择XML目录");
                return;
            }
            if(txt_fileName.Text.Length<1){
                MessageBox.Show("文件名不能为空");
                return;
            }
            int n = Convert.ToInt32(getNum());
            if (n < 1)
            {
                MessageBox.Show("SORRY,该软件免费使用已到期，如需要请联系QQ41203160购买！");
                return;
            }
            else
            {
                n = n - 1;
                setNum(n);
            }
            if (fname!=null) File.Delete(xmlurl+"/"+fname);
            fname = txt_fileName.Text;
            xmlurl = txt_xmlurl.Text;
            File.WriteAllText("xml.data", xmlurl);
            txt_output.Text += "正在读取文件列表。。。\r\n";
            getFile(xmlurl, true);
            txt_output.Text += "文件列表读取完毕。\r\n";
            packing();
            exec();
        }
        private void getFile(string url,Boolean contains)
        {
            if (!Directory.Exists(url))
            {
                MessageBox.Show("XML路径无效~！");
                return;
            }           
            DirectoryInfo directory = new DirectoryInfo(url);
            DirectoryInfo[] directoryArray = directory.GetDirectories();
            FileInfo[] fileInfoArray = directory.GetFiles();
            if (fileInfoArray.Length > 0) fileListData.AddRange(fileInfoArray);
            if (contains)
            {
                foreach (DirectoryInfo _directoryInfo in directoryArray)
                {//遍历子目录
                    getFile(_directoryInfo.FullName, contains);
                }
            }
        }
        private void packing()
        {
            txt_output.Text += "正在创建打包程序。。。\r\n";
            string str = "package  {	import flash.display.Sprite;	public class fl extends Sprite{";            
            foreach (FileInfo fi in fileListData)
            {
                if (checkFile(fi.Name) == 1)
                {
                    str += "[Embed(source=\"" + fi.Name + "\", mimeType=\"application/octet-stream\")]		public var " + fi.Name.Substring(0, fi.Name.IndexOf(".")) + ":Class;";
                }
                else if (checkFile(fi.Name) == 2) 
                {
                    str += "[Embed(source=\"" + fi.Name + "\")]		public var " + fi.Name.Substring(0, fi.Name.IndexOf(".")) + ":Class;";
                }
            }
            str += "		public function fl() {					}	}	}";
            File.WriteAllText(xmlurl+"/fl.as", str);
            txt_output.Text += "打包程序创建完毕，准备开始打包。。。\r\n";
        }
        private int checkFile(string f)
        {
            if (f.Length < 5) return 0;
            if (f.IndexOf(".") == -1) return 0;
            f = f.ToLower();
            f = f.Substring(f.Length - 5);
            if (f.IndexOf(".") == -1) return 0;
            if (f.IndexOf(".jpeg") == -1) return 0;
            else return 2;
            f = f.Substring(1);
            if (f==".xml") return 1;
            if (f==".jpg") return 2;
            if (f==".gif") return 2;
            if (f==".png") return 2;
            if (f==".bmp") return 2;
            return 0;
        }
        private void exec() {
            File.WriteAllText(xmlurl + "/p.bat","cd "+xmlurl + "\r\n mxmlc fl.as");
            txt_output.Text += "开始打包，请稍候。。。\r\n";
            string res = openFile(xmlurl + "/p.bat");
            txt_output.Text += "打包完毕，结果：\r\n" + res;
            release();
            if (res.IndexOf("fl.swf") != -1)
            {
                MessageBox.Show("打包完毕，资源已成功打包！");
            }
            else
            {
                MessageBox.Show("错误:资源未能成功打包，请检查输出结果！");
            }
        }
        private void release()
        {
            if (File.Exists(xmlurl + "/fl.as")) File.Delete(xmlurl + "/fl.as");
            if (File.Exists(xmlurl + "/p.bat")) File.Delete(xmlurl + "/p.bat");
            if (File.Exists(xmlurl + "/" + fname)) File.Delete(xmlurl + "/" + fname);
            File.Copy(xmlurl + "/fl.swf", xmlurl + "/" + fname);
            File.Delete(xmlurl + "/fl.swf");
        }
        private string openFile(string fileName)
        {
            string res="";
            Process p = new Process();
            int milliseconds = 30000;
            p.StartInfo.FileName = fileName;

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.CreateNoWindow = true;
            try
            {
                if (p.Start())       //开始进程
                {
                    if (milliseconds == 0)
                        p.WaitForExit();     //这里无限等待进程结束
                    else
                        p.WaitForExit(milliseconds);  //这里等待进程结束，等待时间为指定的毫秒
                    res = p.StandardOutput.ReadToEnd();//读取进程的输出
                }
            }
            catch
            {
            }
            finally
            {
                if (p != null)
                    p.Close();
            }
            return res;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("xml.data"))
            {
                txt_xmlurl.Text = File.ReadAllText("xml.data");
            }
            if (!File.Exists(key))
            {
                setNum(250);
            }
        }
        private void setNum(int n)
        {
            File.WriteAllText(key,DataSafe.DESEncrypt(n.ToString(),"56leacom"));
        }
        private string getNum(){
            string str="0";
            if (File.Exists(key))
            {
                str = DataSafe.DESDecrypt(File.ReadAllText(key),"56leacom");
            }
            return str;
        }
    }
}
