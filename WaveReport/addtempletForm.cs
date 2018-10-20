using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;

namespace WaveReport
{
    public partial class addtempletForm : Form
    {
        XmlDocument xmldoc;
        //XmlNode xmlnode;
        XmlElement xmlelem;

        //extern public Boolean isAddTemplet;

        public addtempletForm()
        {
            InitializeComponent();
        }

        private void new_templet_button_Click(object sender, EventArgs e)
        {
            if (new_templet_richTextBox.Lines.Count() == 0)
            {
                MessageBox.Show("请输入正确的参数！");
                return;
            }

            xmldoc = new XmlDocument();
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>
            XmlDeclaration xmldecl;
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
            xmldoc.AppendChild(xmldecl);

            //加入一个根元素
            xmlelem = xmldoc.CreateElement("", "device", "");
            xmldoc.AppendChild(xmlelem);
            //加入另外一个元素

            XmlNode root = xmldoc.SelectSingleNode("device");       //查找<device> 
            XmlElement xe1 = xmldoc.CreateElement("model");     //创建一个<model>节点 
            xe1.SetAttribute("name", templet_name_textBox.Text);     //设置该节点name属性 

            for (int i = 0; i < new_templet_richTextBox.Lines.Count(); i++)
            {
                XmlElement xesub = xmldoc.CreateElement("pic" + (i + 1).ToString());
                xesub.InnerText = new_templet_richTextBox.Lines[i];    //设置文本节点 
                xe1.AppendChild(xesub);        //添加到<model>节点中 

                root.AppendChild(xe1);      //添加到<device>节点中 
            }
            //保存创建好的XML文档
            xmldoc.Save(Application.StartupPath + "\\templet\\" + templet_name_textBox.Text + ".xml");

            MessageBox.Show("添加模板完成！");

            main_Form.isAddTemplet = true;
        }

        private void new_templet_richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            templet_nownum_toolStripStatusLabel.Text = new_templet_richTextBox.Lines.Count().ToString();
        }

        private void edit_templet_button_Click(object sender, EventArgs e)
        {
            edit_templet_openFileDialog.InitialDirectory = Application.StartupPath + "\\templet";

            if (edit_templet_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(edit_templet_openFileDialog.FileName);
                XmlNode xn = xmlDoc.SelectSingleNode("device");     //得到根节点
                XmlNodeList xnl = xn.ChildNodes;       //得到根节点的所有子节点
                XmlNode xnf = xnl[0];
                XmlElement xe = (XmlElement)xnf;
                XmlNodeList xnf1 = xe.ChildNodes;

                new_templet_richTextBox.Clear();
                for (int i = 0; i < xnf1.Count; i++)
                {
                    if (i != xnf1.Count - 1)
                    {
                        new_templet_richTextBox.Text += xnf1[i].InnerText + "\n";
                    }
                    else
                    {
                        new_templet_richTextBox.Text += xnf1[i].InnerText;
                    }
                }
                templet_nownum_toolStripStatusLabel.Text = xnf1.Count.ToString();
                templet_name_textBox.Text = xe.GetAttribute("name").ToString();
            }
        }
    }
}
