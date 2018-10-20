using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Xml;
using System.Threading;

using MSWord = Microsoft.Office.Interop.Word;

namespace WaveReport
{
    public partial class main_Form : Form
    {
        public static Boolean isAddTemplet = false;
        public static Boolean isfreeselect = false;
        public static Boolean isCutPic = false;

        object output_path;      //文件路径变量
        
        public static int left_cut;
        public static int right_cut;
        public static int up_cut;
        public static int down_cut;
        string templet;

        string[] free_select_filename;
        int free_select_filename_num;

        public main_Form()      //程序加载时的初始化
        {
            InitializeComponent();

            if (Directory.Exists(Application.StartupPath + "\\templet") == false)  //如果不存在就创建文件夹
            {
                Directory.CreateDirectory(Application.StartupPath + "\\templet");
            }
            if (Directory.Exists(Application.StartupPath + "\\input") == false)  //如果不存在就创建文件夹
            {
                Directory.CreateDirectory(Application.StartupPath + "\\input");
            }
            if (Directory.Exists(Application.StartupPath + "\\output") == false)  //如果不存在就创建文件夹
            {
                Directory.CreateDirectory(Application.StartupPath + "\\output");
            }

            var templet_path = Application.StartupPath + "\\templet";      //模板文件夹路径 
            FileInfo[] fiList;

            System.IO.DirectoryInfo dir = new DirectoryInfo(templet_path);

            fiList = dir.GetFiles();

            templet_comboBox.Items.Add("无需模板");
            for (int i = 0; i < fiList.Count(); i++ )
            {
                string add_item = fiList[i].ToString().Substring(0, fiList[i].ToString().Length - 4);
                templet_comboBox.Items.Add(add_item);
            }

            templet_comboBox.Text = "无需模板";

            path_toolStripStatusLabel.Text = Application.StartupPath + "\\input";

            if (File.Exists(Application.StartupPath + "\\config.xml") == true)  //如果存在就读取参数
            {
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "\\config.xml");
                XmlNode xn = xmlDoc.SelectSingleNode("config");     //得到根节点
                XmlNodeList xnl = xn.ChildNodes;       //得到根节点的所有子节点
                XmlNode xnf = xnl[0];
                XmlElement xe = (XmlElement)xnf;
                XmlNodeList xnf1 = xe.ChildNodes;

                cutpic_up_textBox.Text = xnf1[0].InnerText;
                cutpic_down_textBox.Text = xnf1[1].InnerText;
                cutpic_left_textBox.Text = xnf1[2].InnerText;
                cutpic_right_textBox.Text = xnf1[3].InnerText;
                if (xnf1[4].InnerText == "1")
                {
                    pcontray_checkBox.Checked = true;
                }
                else
                {
                    pcontray_checkBox.Checked = false;
                }
                devnum_textBox.Text = xnf1[5].InnerText;
                templet_comboBox.Text = xnf1[6].InnerText;
                right_down_textBox1.Text = xnf1[7].InnerText;
                right_down_textBox2.Text = xnf1[8].InnerText;
                rd_textBox1.Text = xnf1[9].InnerText;   //2018.8.20由韩曦添加
                rd_textBox2.Text = xnf1[10].InnerText;  //2018.8.20由韩曦添加
            }

            left_cut = Convert.ToInt32(cutpic_left_textBox.Text);
            right_cut = Convert.ToInt32(cutpic_right_textBox.Text);
            up_cut = Convert.ToInt32(cutpic_up_textBox.Text);
            down_cut = Convert.ToInt32(cutpic_down_textBox.Text);
            templet = templet_comboBox.Text;
        }

        private void go_button_Click(object sender, EventArgs e)
        {
            output_path = Application.StartupPath + "\\output\\" + templet_comboBox.Text.ToString() + "_" + devnum_textBox.Text + ".docx";      //输出文件路径
            
            //判断重要参数是否输入
            if (cutpic_up_textBox.Text == "" || cutpic_down_textBox.Text == "" || 
                cutpic_left_textBox.Text == "" || cutpic_right_textBox.Text == "" ||
                templet_comboBox.Text == "")
            {
                MessageBox.Show("请输入完整的参数！");
                return;
            }
            
            var input_path = path_toolStripStatusLabel.Text;
            FileInfo[] fiList;
            System.IO.DirectoryInfo dir = new DirectoryInfo(input_path);
            fiList = dir.GetFiles();
            for (int i = 0; i < fiList.Count(); i++)
            {
                if (fiList[i].Extension != ".bmp" && fiList[i].Extension != ".jpg" && fiList[i].Extension != ".png" &&
                    fiList[i].Extension != ".BMP" && fiList[i].Extension != ".JPG" && fiList[i].Extension != ".PNG")
                {
                    MessageBox.Show("当前路径下存在非图片文件，请检查后再处理！");
                    return;
                }
            }

            if (File.Exists((string)output_path))   //如果已存在，则删除
            {
                try
                {
                    File.Delete((string)output_path);
                }
                catch (Exception e1)
                {
                    MessageBox.Show("删除文档失败，请确认同名文件是否关闭！\n\r错误信息：" + e1.Message.ToString());
                    return;
                }
            }

            left_cut = Convert.ToInt32(cutpic_left_textBox.Text);
            right_cut = Convert.ToInt32(cutpic_right_textBox.Text);
            up_cut = Convert.ToInt32(cutpic_up_textBox.Text);
            down_cut = Convert.ToInt32(cutpic_down_textBox.Text);
            templet = templet_comboBox.Text;

            Thread ptw = new Thread(PicToWord);     //创建生成线程
            ptw.Start();
        }

        private void dir_list_button_Click(object sender, EventArgs e)
        {
            //var input_path = Application.StartupPath + "\\input";      //输入文件夹路径 
            
            var input_path = path_toolStripStatusLabel.Text;
            FileInfo[] fiList;

            System.IO.DirectoryInfo dir = new DirectoryInfo(input_path);

            fiList = dir.GetFiles();

            if (isfreeselect == false)
            {
                MessageBox.Show("波形图数量：" + fiList.Count().ToString());
            }
            else
            {
                MessageBox.Show("已选波形图数量：" + free_select_filename_num.ToString() + "     " + "该目录下总波形图数量：" + fiList.Count().ToString());
            }
        }

        private void templet_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(templet_comboBox.Text != "无需模板")
            {
                //var input_path = Application.StartupPath + "\\input";      //输入文件夹路径 
                var input_path = path_toolStripStatusLabel.Text;
                FileInfo[] fiList;
                System.IO.DirectoryInfo dir = new DirectoryInfo(input_path);
                fiList = dir.GetFiles();

                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "\\templet\\" + templet_comboBox.Text.ToString() + ".xml");
                XmlNode xn = xmlDoc.SelectSingleNode("device");     //得到根节点
                XmlNodeList xnl = xn.ChildNodes;       //得到根节点的所有子节点
                XmlNode xnf = xnl[0];
                XmlElement xe = (XmlElement)xnf;
                XmlNodeList xnf1 = xe.ChildNodes;

                if (xnf1.Count != fiList.Count())
                {
                    //templet_comboBox.Text = "无需模板";
                    MessageBox.Show("输入波形图的数量与所选模板中波形图的数量不相等！");
                }
            }
        }

        private void new_templet_button_Click(object sender, EventArgs e)   //打开添加模板窗体
        {
            addtempletForm add_form = new addtempletForm();
            add_form.Show(this);
        }

        private void cutpic_up_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')      //这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))     //这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void cutpic_down_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')      //这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))     //这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void cutpic_left_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')      //这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))     //这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void cutpic_right_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')      //这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))     //这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void main_Form_Activated(object sender, EventArgs e)
        {
            //string last_templet_select = templet_comboBox.Text;
            if (isAddTemplet == false && isCutPic == false)
            {
                return;
            }

            isAddTemplet = false;
            isCutPic = false;

            templet_comboBox.Items.Clear();

            var templet_path = Application.StartupPath + "\\templet";      //模板文件夹路径 
            FileInfo[] fiList;

            System.IO.DirectoryInfo dir = new DirectoryInfo(templet_path);

            fiList = dir.GetFiles();

            templet_comboBox.Items.Add("无需模板");
            for (int i = 0; i < fiList.Count(); i++)
            {
                string add_item = fiList[i].ToString().Substring(0, fiList[i].ToString().Length - 4);
                templet_comboBox.Items.Add(add_item);
            }

            //templet_comboBox.Text = last_templet_select;
            templet_comboBox.Text = "无需模板";

            cutpic_up_textBox.Text = up_cut.ToString();
            cutpic_down_textBox.Text = down_cut.ToString();
            cutpic_left_textBox.Text = left_cut.ToString();
            cutpic_right_textBox.Text = right_cut.ToString();
        }

        //生成线程
        private void PicToWord()
        {
            //禁用输入控件，等待生成
            this.Invoke(new EventHandler(delegate
            {
                dir_list_button.Enabled = false;
                go_button.Enabled = false;
                right_down_textBox1.Enabled = false;
                right_down_textBox2.Enabled = false;
                rd_textBox1.Enabled = false; //2018.8.20由韩曦添加
                rd_textBox2.Enabled = false; //2018.8.20由韩曦添加
                cutpic_up_textBox.Enabled = false;
                cutpic_down_textBox.Enabled = false;
                cutpic_left_textBox.Enabled = false;
                cutpic_right_textBox.Enabled = false;
                devnum_textBox.Enabled = false;
                templet_comboBox.Enabled = false;
                pcontray_checkBox.Enabled = false;
                new_templet_button.Enabled = false;
                set_dir_button.Enabled = false;
                select_button.Enabled = false;
                vcut_button.Enabled = false;
            }));

            //加载所选择的模板
            XmlNodeList xnf1 = null;
            if (templet != "无需模板")
            {
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "\\templet\\" + templet + ".xml");
                XmlNode xn = xmlDoc.SelectSingleNode("device");     //得到根节点
                XmlNodeList xnl = xn.ChildNodes;       //得到根节点的所有子节点
                XmlNode xnf = xnl[0];
                XmlElement xe = (XmlElement)xnf;
                xnf1 = xe.ChildNodes;
            }

            //由于使用的是COM库，因此有许多变量需要用Missing.Value代替
            Object Nothing = Missing.Value;

            MSWord._Application wordApp;        //Word应用程序变量
            MSWord._Document wordDoc;       //Word文档变量

            const int tableRow = 6;       //设置表格的行数和列数
            const int tableColumn = 2;
            
            int pic_num = 0;

            //var input_path = Application.StartupPath + "\\input";      //输入文件夹路径
            var input_path = path_toolStripStatusLabel.Text;
            FileInfo[] fiList;
            String[] filina;

            System.IO.DirectoryInfo dir = new DirectoryInfo(input_path);

            if (isfreeselect == false)
            {
                fiList = dir.GetFiles();

                string[] filina_temp = new string[fiList.Count()];
                filina = filina_temp;

                for (int i = 0; i < fiList.Count();i++ )
                {
                    filina[i] = fiList[i].Name;
                }
            }
            else
            {
                string[] filina_temp = new string[free_select_filename_num];
                filina = filina_temp;

                for (int i = 0; i < free_select_filename_num; i++)
                {
                    filina[i] = free_select_filename[i].ToString();
                }
            }

            this.Invoke(new EventHandler(delegate
            {
                load_progressBar.Maximum = filina.Count() + 2;
                load_progressBar.PerformStep();
            }));

            wordApp = new MSWord.ApplicationClass();    //初始化

            wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

            wordDoc.PageSetup.Orientation = MSWord.WdOrientation.wdOrientLandscape;     //设置页面为横向

            wordDoc.PageSetup.TopMargin = wordApp.CentimetersToPoints(float.Parse("1.30"));     //上边距
            wordDoc.PageSetup.BottomMargin = wordApp.CentimetersToPoints(float.Parse("1.10"));      //下边距
            wordDoc.PageSetup.LeftMargin = wordApp.CentimetersToPoints(float.Parse("2.17"));       //左边距
            wordDoc.PageSetup.RightMargin = wordApp.CentimetersToPoints(float.Parse("2.17"));       //右边距

            MSWord.Table table;
            Object unite = MSWord.WdUnits.wdStory;

            int page_num;
            if (filina.Count() % 4 > 0)     //判断页面数量
            {
                page_num = (filina.Count() / 4) + 1;
            }
            else
            {
                page_num = filina.Count() / 4;
            }

            for (int p = 1; p <= page_num; p++)     //页面循环生成
            {
                string filename;
                object LinkToFile = false;
                object SaveWithDocument = true;
                object Anchor;

                table = wordDoc.Tables.Add(wordApp.Selection.Range, tableRow, tableColumn, ref Nothing, ref Nothing);

                wordDoc.Tables[p].Cell(5, 2).Split(1, 2);   //2018.8.20由韩曦添加
                wordDoc.Tables[p].Cell(6, 2).Split(1, 2);   //2018.8.20由韩曦添加

                //table.Borders.Enable = 5;
                wordDoc.Tables[p].Cell(3, 1).Height = 213;
                wordDoc.Tables[p].Cell(4, 1).Height = 21;
                wordDoc.Tables[p].Cell(5, 1).Height = 21;

                wordDoc.Tables[p].Cell(2, 1).Range.Font.Name = "宋体";
                wordDoc.Tables[p].Cell(2, 2).Range.Font.Name = "宋体";
                wordDoc.Tables[p].Cell(4, 1).Range.Font.Name = "宋体";
                wordDoc.Tables[p].Cell(4, 2).Range.Font.Name = "宋体";
                wordDoc.Tables[p].Cell(5, 2).Range.Font.Name = "宋体";
                wordDoc.Tables[p].Cell(6, 2).Range.Font.Name = "宋体";

                wordDoc.Content.InsertAfter("\n");
                wordApp.Selection.EndKey(ref unite, ref Nothing);

                this.Invoke(new EventHandler(delegate
                {
                    load_progressBar.PerformStep();
                }));

                if (pic_num <= filina.Count() - 1)      //每页第一张图片处理
                {
                    if (pcontray_checkBox.Checked == true)    //反色处理
                    {
                        Bitmap src_bmp = new Bitmap(input_path + "\\" + filina[pic_num].ToString());
                        src_bmp = function.Cut(src_bmp, left_cut, up_cut, src_bmp.Width - (left_cut + right_cut), src_bmp.Height - (up_cut + down_cut));
                        Bitmap dst_bmp = function.PContray(src_bmp);
                        dst_bmp.Save(Application.StartupPath + "\\input" + "\\p_" + filina[pic_num].ToString());
                        filename = Application.StartupPath + "\\input" + "\\p_" + filina[pic_num].ToString();
                    }
                    else
                    {
                        Bitmap src_bmp = new Bitmap(input_path + "\\" + filina[pic_num].ToString());
                        src_bmp = function.Cut(src_bmp, left_cut, up_cut, src_bmp.Width - (left_cut + right_cut), src_bmp.Height - (up_cut + down_cut));
                        src_bmp.Save(Application.StartupPath + "\\input" + "\\c_" + filina[pic_num].ToString());
                        filename = Application.StartupPath + "\\input" + "\\c_" + filina[pic_num].ToString();
                    }
                    Anchor = table.Cell(1, 1).Range;//选中要添加图片的单元格
                    wordDoc.Application.ActiveDocument.InlineShapes.AddPicture(filename, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                    wordDoc.Application.ActiveDocument.InlineShapes[pic_num + 1].Width = 322;//图片宽度
                    wordDoc.Application.ActiveDocument.InlineShapes[pic_num + 1].Height = 213;//图片高度

                    File.Delete(filename);      //删除临时图片

                    if (templet == "无需模板" || pic_num > xnf1.Count - 1)
                    {
                        wordDoc.Tables[p].Cell(2, 1).Range.Text = filina[pic_num].ToString();
                    }
                    else
                    {
                        wordDoc.Tables[p].Cell(2, 1).Range.Text = devnum_textBox.Text + "    " + xnf1.Item(pic_num).InnerText;
                    }

                    pic_num++;
                    this.Invoke(new EventHandler(delegate
                    {
                        load_progressBar.PerformStep();
                    }));
                }

                if (pic_num <= filina.Count() - 1)      //每页第二张图片处理
                {
                    if (pcontray_checkBox.Checked == true)    //反色处理
                    {
                        Bitmap src_bmp = new Bitmap(input_path + "\\" + filina[pic_num].ToString());
                        src_bmp = function.Cut(src_bmp, left_cut, up_cut, src_bmp.Width - (left_cut + right_cut), src_bmp.Height - (up_cut + down_cut));
                        Bitmap dst_bmp = function.PContray(src_bmp);
                        dst_bmp.Save(Application.StartupPath + "\\input" + "\\p_" + filina[pic_num].ToString());
                        filename = Application.StartupPath + "\\input" + "\\p_" + filina[pic_num].ToString();
                    }
                    else
                    {
                        Bitmap src_bmp = new Bitmap(input_path + "\\" + filina[pic_num].ToString());
                        src_bmp = function.Cut(src_bmp, left_cut, up_cut, src_bmp.Width - (left_cut + right_cut), src_bmp.Height - (up_cut + down_cut));
                        src_bmp.Save(Application.StartupPath + "\\input" + "\\c_" + filina[pic_num].ToString());
                        filename = Application.StartupPath + "\\input" + "\\c_" + filina[pic_num].ToString();
                    }
                    Anchor = table.Cell(1, 2).Range;//选中要添加图片的单元格
                    wordDoc.Application.ActiveDocument.InlineShapes.AddPicture(filename, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                    wordDoc.Application.ActiveDocument.InlineShapes[pic_num + 1].Width = 322;//图片宽度
                    wordDoc.Application.ActiveDocument.InlineShapes[pic_num + 1].Height = 213;//图片高度

                    File.Delete(filename);      //删除临时图片

                    if (templet == "无需模板" || pic_num > xnf1.Count - 1)
                    {
                        wordDoc.Tables[p].Cell(2, 2).Range.Text = filina[pic_num].ToString();
                    }
                    else
                    {
                        wordDoc.Tables[p].Cell(2, 2).Range.Text = devnum_textBox.Text + "    " + xnf1.Item(pic_num).InnerText;
                    }

                    pic_num++;
                    this.Invoke(new EventHandler(delegate
                    {
                        load_progressBar.PerformStep();
                    }));
                }

                if (pic_num <= filina.Count() - 1)      //每页第三张图片处理
                {
                    if (pcontray_checkBox.Checked == true)    //反色处理
                    {
                        Bitmap src_bmp = new Bitmap(input_path + "\\" + filina[pic_num].ToString());
                        src_bmp = function.Cut(src_bmp, left_cut, up_cut, src_bmp.Width - (left_cut + right_cut), src_bmp.Height - (up_cut + down_cut));
                        Bitmap dst_bmp = function.PContray(src_bmp);
                        dst_bmp.Save(Application.StartupPath + "\\input" + "\\p_" + filina[pic_num].ToString());
                        filename = Application.StartupPath + "\\input" + "\\p_" + filina[pic_num].ToString();
                    }
                    else
                    {
                        Bitmap src_bmp = new Bitmap(input_path + "\\" + filina[pic_num].ToString());
                        src_bmp = function.Cut(src_bmp, left_cut, up_cut, src_bmp.Width - (left_cut + right_cut), src_bmp.Height - (up_cut + down_cut));
                        src_bmp.Save(Application.StartupPath + "\\input" + "\\c_" + filina[pic_num].ToString());
                        filename = Application.StartupPath + "\\input" + "\\c_" + filina[pic_num].ToString();
                    }
                    Anchor = table.Cell(3, 1).Range;//选中要添加图片的单元格
                    wordDoc.Application.ActiveDocument.InlineShapes.AddPicture(filename, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                    wordDoc.Application.ActiveDocument.InlineShapes[pic_num + 1].Width = 322;//图片宽度
                    wordDoc.Application.ActiveDocument.InlineShapes[pic_num + 1].Height = 213;//图片高度

                    File.Delete(filename);      //删除临时图片

                    if (templet == "无需模板" || pic_num > xnf1.Count - 1)
                    {
                        wordDoc.Tables[p].Cell(4, 1).Range.Text = filina[pic_num].ToString();
                    }
                    else
                    {
                        wordDoc.Tables[p].Cell(4, 1).Range.Text = devnum_textBox.Text + "    " + xnf1.Item(pic_num).InnerText;
                    }

                    pic_num++;
                    this.Invoke(new EventHandler(delegate
                    {
                        load_progressBar.PerformStep();
                    }));
                }

                if (pic_num <= filina.Count() - 1)      //每页第四张图片处理
                {
                    if (pcontray_checkBox.Checked == true)    //反色处理
                    {
                        Bitmap src_bmp = new Bitmap(input_path + "\\" + filina[pic_num].ToString());
                        src_bmp = function.Cut(src_bmp, left_cut, up_cut, src_bmp.Width - (left_cut + right_cut), src_bmp.Height - (up_cut + down_cut));
                        Bitmap dst_bmp = function.PContray(src_bmp);
                        dst_bmp.Save(Application.StartupPath + "\\input" + "\\p_" + filina[pic_num].ToString());
                        filename = Application.StartupPath + "\\input" + "\\p_" + filina[pic_num].ToString();
                    }
                    else
                    {
                        Bitmap src_bmp = new Bitmap(input_path + "\\" + filina[pic_num].ToString());
                        src_bmp = function.Cut(src_bmp, left_cut, up_cut, src_bmp.Width - (left_cut + right_cut), src_bmp.Height - (up_cut + down_cut));
                        src_bmp.Save(Application.StartupPath + "\\input" + "\\c_" + filina[pic_num].ToString());
                        filename = Application.StartupPath + "\\input" + "\\c_" + filina[pic_num].ToString();
                    }
                    Anchor = table.Cell(3, 2).Range;//选中要添加图片的单元格
                    wordDoc.Application.ActiveDocument.InlineShapes.AddPicture(filename, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                    wordDoc.Application.ActiveDocument.InlineShapes[pic_num + 1].Width = 322;//图片宽度
                    wordDoc.Application.ActiveDocument.InlineShapes[pic_num + 1].Height = 213;//图片高度

                    File.Delete(filename);      //删除临时图片

                    if (templet == "无需模板" || pic_num > xnf1.Count - 1)
                    {
                        wordDoc.Tables[p].Cell(4, 2).Range.Text = filina[pic_num].ToString();
                    }
                    else
                    {
                        wordDoc.Tables[p].Cell(4, 2).Range.Text = devnum_textBox.Text + "    " + xnf1.Item(pic_num).InnerText;
                    }

                    pic_num++;
                    this.Invoke(new EventHandler(delegate
                    {
                        load_progressBar.PerformStep();
                    }));
                }

                //wordDoc.Tables[p].Cell(5, 2).Range.Text = "                             " + right_down_textBox1.Text;     //2018.8.20由韩曦删掉
                //wordDoc.Tables[p].Cell(6, 2).Range.Text = "                             " + right_down_textBox2.Text;     //2018.8.20由韩曦删掉

                wordDoc.Tables[p].Cell(5, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight;   //2018.8.20由韩曦添加
                wordDoc.Tables[p].Cell(6, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight;   //2018.8.20由韩曦添加

                wordDoc.Tables[p].Cell(5, 2).Range.Text = right_down_textBox1.Text;     //2018.8.20由韩曦添加
                wordDoc.Tables[p].Cell(6, 2).Range.Text = right_down_textBox2.Text;     //2018.8.20由韩曦添加

                wordDoc.Tables[p].Cell(5, 3).Range.Font.Underline = MSWord.WdUnderline.wdUnderlineSingle;       //2018.8.20由韩曦添加
                wordDoc.Tables[p].Cell(6, 3).Range.Font.Underline = MSWord.WdUnderline.wdUnderlineSingle;       //2018.8.20由韩曦添加

                wordDoc.Tables[p].Cell(5, 3).Range.Text = rd_textBox1.Text;     //2018.8.20由韩曦添加
                wordDoc.Tables[p].Cell(6, 3).Range.Text = rd_textBox2.Text;     //2018.8.20由韩曦添加

            }

            //WdSaveFormat为Word 2007文档的保存格式
            object format = MSWord.WdSaveFormat.wdFormatDocumentDefault;

            //将wordDoc文档对象的内容保存为DOCX文档
            try
            {
                wordDoc.SaveAs(ref output_path, ref format, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            }
            catch (Exception e2)
            {
                MessageBox.Show("生成文档失败，请确认同名文件是否关闭！\n\r错误信息：" + e2.Message.ToString());
            }
            finally
            {
                //输入控件重新启用
                this.Invoke(new EventHandler(delegate
                {
                    dir_list_button.Enabled = true;
                    go_button.Enabled = true;
                    right_down_textBox1.Enabled = true;
                    right_down_textBox2.Enabled = true;
                    rd_textBox1.Enabled = true; //2018.8.20由韩曦添加
                    rd_textBox2.Enabled = true; //2018.8.20由韩曦添加
                    cutpic_up_textBox.Enabled = true;
                    cutpic_down_textBox.Enabled = true;
                    cutpic_left_textBox.Enabled = true;
                    cutpic_right_textBox.Enabled = true;
                    devnum_textBox.Enabled = true;
                    templet_comboBox.Enabled = true;
                    pcontray_checkBox.Enabled = true;
                    new_templet_button.Enabled = true;
                    set_dir_button.Enabled = true;
                    select_button.Enabled = true;
                    vcut_button.Enabled = true;
                }));

                this.Invoke(new EventHandler(delegate
                {
                    load_progressBar.PerformStep();
                }));
            }

            //关闭wordDoc文档对象
            //wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);

            //关闭wordApp组件对象
            //wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);

            //打开新生成的word文档
            Object doc_filename = devnum_textBox.Text + ".docx";
            Object filefullname = output_path;
            Object confirmConversions = Type.Missing;
            Object readOnly = Type.Missing;
            Object addToRecentFiles = Type.Missing;
            Object passwordDocument = Type.Missing;
            Object passwordTemplate = Type.Missing;
            Object revert = Type.Missing;
            Object writePasswordDocument = Type.Missing;
            Object writePasswordTemplate = Type.Missing;
            Object open_format = Type.Missing;
            Object encoding = Type.Missing;
            Object visible = Type.Missing;
            Object openConflictDocument = Type.Missing;
            Object openAndRepair = Type.Missing;
            Object documentDirection = Type.Missing;
            Object noEncodingDialog = Type.Missing;
            wordApp.Documents.Open(ref filefullname,
                        ref confirmConversions, ref readOnly, ref addToRecentFiles,
                        ref passwordDocument, ref passwordTemplate, ref revert,
                        ref writePasswordDocument, ref writePasswordTemplate,
                        ref format, ref encoding, ref visible, ref openConflictDocument,
                        ref openAndRepair, ref documentDirection, ref noEncodingDialog
                        );

            //输入控件重新启用
            this.Invoke(new EventHandler(delegate
            {
                dir_list_button.Enabled = true;
                go_button.Enabled = true;
                right_down_textBox1.Enabled = true;
                right_down_textBox2.Enabled = true;
                rd_textBox1.Enabled = true; //2018.8.20由韩曦添加
                rd_textBox2.Enabled = true; //2018.8.20由韩曦添加
                cutpic_up_textBox.Enabled = true;
                cutpic_down_textBox.Enabled = true;
                cutpic_left_textBox.Enabled = true;
                cutpic_right_textBox.Enabled = true;
                devnum_textBox.Enabled = true;
                templet_comboBox.Enabled = true;
                pcontray_checkBox.Enabled = true;
                new_templet_button.Enabled = true;
                set_dir_button.Enabled = true;
                select_button.Enabled = true;
                vcut_button.Enabled = true;
            }));

            this.Invoke(new EventHandler(delegate
            {
                load_progressBar.Value = 0;
            }));
        }

        private void main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlElement xesub;
            
            XmlDocument xmldoc = new XmlDocument();
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>
            XmlDeclaration xmldecl;
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
            xmldoc.AppendChild(xmldecl);

            //加入一个根元素
            XmlElement xmlelem = xmldoc.CreateElement("", "config", "");
            xmldoc.AppendChild(xmlelem);
            //加入另外一个元素

            XmlNode root = xmldoc.SelectSingleNode("config");       //查找<config> 
            XmlElement xe1 = xmldoc.CreateElement("main_config");     //创建一个<main_config>节点 
            xe1.SetAttribute("name", "main_config");     //设置该节点name属性 

            //添加9个配置项
            xesub = xmldoc.CreateElement("cut_up");
            xesub.InnerText = cutpic_up_textBox.Text;    //设置文本节点 
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("cut_down");
            xesub.InnerText = cutpic_down_textBox.Text;    //设置文本节点 
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("cut_left");
            xesub.InnerText = cutpic_left_textBox.Text;    //设置文本节点 
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("cut_right");
            xesub.InnerText = cutpic_right_textBox.Text;    //设置文本节点 
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("pcontray");
            if (pcontray_checkBox.Checked == true)
            {
                xesub.InnerText = "1";    //设置文本节点 
            }
            else
            {
                xesub.InnerText = "0";
            }
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("dev_num");
            xesub.InnerText = devnum_textBox.Text;    //设置文本节点 
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("templet");
            xesub.InnerText = templet_comboBox.Text;    //设置文本节点 
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("right_down1");
            xesub.InnerText = right_down_textBox1.Text;    //设置文本节点 
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("right_down2");
            xesub.InnerText = right_down_textBox2.Text;    //设置文本节点 
            xe1.AppendChild(xesub);        //添加到<main_config>节点中 
            root.AppendChild(xe1);      //添加到<config>节点中 

            xesub = xmldoc.CreateElement("rd1");    //2018.8.20由韩曦添加
            xesub.InnerText = rd_textBox1.Text;    //2018.8.20由韩曦添加
            xe1.AppendChild(xesub);        //2018.8.20由韩曦添加
            root.AppendChild(xe1);      //2018.8.20由韩曦添加

            xesub = xmldoc.CreateElement("rd2");    //2018.8.20由韩曦添加
            xesub.InnerText = rd_textBox2.Text;    //2018.8.20由韩曦添加
            xe1.AppendChild(xesub);        //2018.8.20由韩曦添加
            root.AppendChild(xe1);      //2018.8.20由韩曦添加
            
            //保存创建好的XML文档
            xmldoc.Save(Application.StartupPath + "\\config.xml");
        }

        private void set_dir_button_Click(object sender, EventArgs e)
        {
            if (path_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path_toolStripStatusLabel.Text = path_folderBrowserDialog.SelectedPath;
                isfreeselect = false;
            }
        }

        private void select_button_Click(object sender, EventArgs e)
        {
            if (free_select_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                free_select_filename = free_select_openFileDialog.SafeFileNames;
                free_select_filename_num = free_select_openFileDialog.FileNames.Count();

                isfreeselect = true;

                path_toolStripStatusLabel.Text = free_select_openFileDialog.FileName.Substring(0, free_select_openFileDialog.FileName.Length - free_select_openFileDialog.SafeFileName.Length - 1);
            }
        }

        private void vcut_button_Click(object sender, EventArgs e)
        {
            cutpicForm add_form = new cutpicForm();
            add_form.Show(this);
        }
    }
}
