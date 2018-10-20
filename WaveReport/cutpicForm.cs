using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WaveReport
{
    public partial class cutpicForm : Form
    {
        Image cut_pic;
        
        public cutpicForm()
        {
            InitializeComponent();
        }

        private void open_cutpic_button_Click(object sender, EventArgs e)
        {
            if (cutpic_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cut_pic = Image.FromFile(cutpic_openFileDialog.FileName);
                cutpic_pictureBox.Image = cut_pic;
            }
        }

        private void cutpicForm_Resize(object sender, EventArgs e)
        {
            cutpic_pictureBox.Size = new Size(this.Size.Width - 40 , this.Size.Height - 83);
        }

        private void cutpic_pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (leftup_radioButton.Checked == true)
                {
                    Point cutpicpoint = cutpic_pictureBox.PointToClient(Control.MousePosition);

                    main_Form.left_cut = Convert.ToInt32(Convert.ToDouble(cut_pic.Width) * (Convert.ToDouble(cutpicpoint.X) / Convert.ToDouble(cutpic_pictureBox.Width)));
                    main_Form.up_cut = Convert.ToInt32(Convert.ToDouble(cut_pic.Height) * (Convert.ToDouble(cutpicpoint.Y) / Convert.ToDouble(cutpic_pictureBox.Height)));
                    rightdown_radioButton.Checked = true;

                    leftup_textBox.Text = main_Form.left_cut.ToString() + "," + main_Form.up_cut.ToString();
                }
                else
                {
                    Point cutpicpoint = cutpic_pictureBox.PointToClient(Control.MousePosition);

                    main_Form.right_cut = Convert.ToInt32(Convert.ToDouble(cut_pic.Width) * (Convert.ToDouble((cutpic_pictureBox.Width - cutpicpoint.X)) / Convert.ToDouble(cutpic_pictureBox.Width)));
                    main_Form.down_cut = Convert.ToInt32(Convert.ToDouble(cut_pic.Height) * (Convert.ToDouble((cutpic_pictureBox.Height - cutpicpoint.Y)) / Convert.ToDouble(cutpic_pictureBox.Height)));
                    leftup_radioButton.Checked = true;

                    rightdown_textBox.Text = main_Form.right_cut.ToString() + "," + main_Form.down_cut.ToString();
                }
            }
            catch
            {
                MessageBox.Show("请打开一张图片后再选点！");
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            main_Form.isCutPic = true;
            this.Close();
        }
    }
}
