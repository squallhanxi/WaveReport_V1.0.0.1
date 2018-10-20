namespace WaveReport
{
    partial class main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_Form));
            this.load_progressBar = new System.Windows.Forms.ProgressBar();
            this.right_down_label1 = new System.Windows.Forms.Label();
            this.right_down_label2 = new System.Windows.Forms.Label();
            this.right_down_textBox1 = new System.Windows.Forms.TextBox();
            this.right_down_textBox2 = new System.Windows.Forms.TextBox();
            this.go_button = new System.Windows.Forms.Button();
            this.dir_list_button = new System.Windows.Forms.Button();
            this.pcontray_checkBox = new System.Windows.Forms.CheckBox();
            this.templet_comboBox = new System.Windows.Forms.ComboBox();
            this.templet_label = new System.Windows.Forms.Label();
            this.cutpic_label = new System.Windows.Forms.Label();
            this.cutpic_up_textBox = new System.Windows.Forms.TextBox();
            this.cutpic_down_textBox = new System.Windows.Forms.TextBox();
            this.cutpic_left_textBox = new System.Windows.Forms.TextBox();
            this.cutpic_right_textBox = new System.Windows.Forms.TextBox();
            this.devnum_textBox = new System.Windows.Forms.TextBox();
            this.devnum_label = new System.Windows.Forms.Label();
            this.new_templet_button = new System.Windows.Forms.Button();
            this.vcut_button = new System.Windows.Forms.Button();
            this.set_dir_button = new System.Windows.Forms.Button();
            this.select_button = new System.Windows.Forms.Button();
            this.mainform_statusStrip = new System.Windows.Forms.StatusStrip();
            this.path_label_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.path_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.path_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.free_select_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.rd_textBox1 = new System.Windows.Forms.TextBox();
            this.rd_textBox2 = new System.Windows.Forms.TextBox();
            this.mainform_statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // load_progressBar
            // 
            this.load_progressBar.Location = new System.Drawing.Point(12, 12);
            this.load_progressBar.Name = "load_progressBar";
            this.load_progressBar.Size = new System.Drawing.Size(448, 23);
            this.load_progressBar.Step = 1;
            this.load_progressBar.TabIndex = 7;
            // 
            // right_down_label1
            // 
            this.right_down_label1.AutoSize = true;
            this.right_down_label1.Location = new System.Drawing.Point(16, 210);
            this.right_down_label1.Name = "right_down_label1";
            this.right_down_label1.Size = new System.Drawing.Size(113, 12);
            this.right_down_label1.TabIndex = 1;
            this.right_down_label1.Text = "右下方文字（上）：";
            // 
            // right_down_label2
            // 
            this.right_down_label2.AutoSize = true;
            this.right_down_label2.Location = new System.Drawing.Point(244, 210);
            this.right_down_label2.Name = "right_down_label2";
            this.right_down_label2.Size = new System.Drawing.Size(113, 12);
            this.right_down_label2.TabIndex = 2;
            this.right_down_label2.Text = "右下方文字（下）：";
            // 
            // right_down_textBox1
            // 
            this.right_down_textBox1.Location = new System.Drawing.Point(18, 225);
            this.right_down_textBox1.Name = "right_down_textBox1";
            this.right_down_textBox1.Size = new System.Drawing.Size(80, 21);
            this.right_down_textBox1.TabIndex = 10;
            this.right_down_textBox1.Text = "军 代 表：";
            // 
            // right_down_textBox2
            // 
            this.right_down_textBox2.Location = new System.Drawing.Point(246, 225);
            this.right_down_textBox2.Name = "right_down_textBox2";
            this.right_down_textBox2.Size = new System.Drawing.Size(80, 21);
            this.right_down_textBox2.TabIndex = 11;
            this.right_down_textBox2.Text = "检验人员：";
            // 
            // go_button
            // 
            this.go_button.Location = new System.Drawing.Point(246, 272);
            this.go_button.Name = "go_button";
            this.go_button.Size = new System.Drawing.Size(212, 121);
            this.go_button.TabIndex = 1;
            this.go_button.Text = "生成";
            this.go_button.UseVisualStyleBackColor = true;
            this.go_button.Click += new System.EventHandler(this.go_button_Click);
            // 
            // dir_list_button
            // 
            this.dir_list_button.Location = new System.Drawing.Point(131, 272);
            this.dir_list_button.Name = "dir_list_button";
            this.dir_list_button.Size = new System.Drawing.Size(96, 54);
            this.dir_list_button.TabIndex = 13;
            this.dir_list_button.Text = "图片数量查询";
            this.dir_list_button.UseVisualStyleBackColor = true;
            this.dir_list_button.Click += new System.EventHandler(this.dir_list_button_Click);
            // 
            // pcontray_checkBox
            // 
            this.pcontray_checkBox.AutoSize = true;
            this.pcontray_checkBox.Location = new System.Drawing.Point(257, 109);
            this.pcontray_checkBox.Name = "pcontray_checkBox";
            this.pcontray_checkBox.Size = new System.Drawing.Size(162, 16);
            this.pcontray_checkBox.TabIndex = 7;
            this.pcontray_checkBox.Text = "反色处理（BMP/JPG/PNG）";
            this.pcontray_checkBox.UseVisualStyleBackColor = true;
            // 
            // templet_comboBox
            // 
            this.templet_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templet_comboBox.FormattingEnabled = true;
            this.templet_comboBox.Location = new System.Drawing.Point(246, 176);
            this.templet_comboBox.Name = "templet_comboBox";
            this.templet_comboBox.Size = new System.Drawing.Size(207, 20);
            this.templet_comboBox.TabIndex = 9;
            this.templet_comboBox.SelectedIndexChanged += new System.EventHandler(this.templet_comboBox_SelectedIndexChanged);
            // 
            // templet_label
            // 
            this.templet_label.AutoSize = true;
            this.templet_label.Location = new System.Drawing.Point(244, 159);
            this.templet_label.Name = "templet_label";
            this.templet_label.Size = new System.Drawing.Size(65, 12);
            this.templet_label.TabIndex = 9;
            this.templet_label.Text = "设备模板：";
            // 
            // cutpic_label
            // 
            this.cutpic_label.AutoSize = true;
            this.cutpic_label.Location = new System.Drawing.Point(21, 92);
            this.cutpic_label.Name = "cutpic_label";
            this.cutpic_label.Size = new System.Drawing.Size(65, 12);
            this.cutpic_label.TabIndex = 10;
            this.cutpic_label.Text = "图片裁剪：";
            // 
            // cutpic_up_textBox
            // 
            this.cutpic_up_textBox.Location = new System.Drawing.Point(131, 51);
            this.cutpic_up_textBox.Name = "cutpic_up_textBox";
            this.cutpic_up_textBox.Size = new System.Drawing.Size(37, 21);
            this.cutpic_up_textBox.TabIndex = 2;
            this.cutpic_up_textBox.Text = "0";
            this.cutpic_up_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cutpic_up_textBox_KeyPress);
            // 
            // cutpic_down_textBox
            // 
            this.cutpic_down_textBox.Location = new System.Drawing.Point(131, 124);
            this.cutpic_down_textBox.Name = "cutpic_down_textBox";
            this.cutpic_down_textBox.Size = new System.Drawing.Size(37, 21);
            this.cutpic_down_textBox.TabIndex = 5;
            this.cutpic_down_textBox.Text = "0";
            this.cutpic_down_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cutpic_down_textBox_KeyPress);
            // 
            // cutpic_left_textBox
            // 
            this.cutpic_left_textBox.Location = new System.Drawing.Point(92, 89);
            this.cutpic_left_textBox.Name = "cutpic_left_textBox";
            this.cutpic_left_textBox.Size = new System.Drawing.Size(37, 21);
            this.cutpic_left_textBox.TabIndex = 3;
            this.cutpic_left_textBox.Text = "0";
            this.cutpic_left_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cutpic_left_textBox_KeyPress);
            // 
            // cutpic_right_textBox
            // 
            this.cutpic_right_textBox.Location = new System.Drawing.Point(170, 89);
            this.cutpic_right_textBox.Name = "cutpic_right_textBox";
            this.cutpic_right_textBox.Size = new System.Drawing.Size(37, 21);
            this.cutpic_right_textBox.TabIndex = 4;
            this.cutpic_right_textBox.Text = "0";
            this.cutpic_right_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cutpic_right_textBox_KeyPress);
            // 
            // devnum_textBox
            // 
            this.devnum_textBox.Location = new System.Drawing.Point(18, 176);
            this.devnum_textBox.Name = "devnum_textBox";
            this.devnum_textBox.Size = new System.Drawing.Size(207, 21);
            this.devnum_textBox.TabIndex = 8;
            this.devnum_textBox.Text = "A1700001";
            // 
            // devnum_label
            // 
            this.devnum_label.AutoSize = true;
            this.devnum_label.Location = new System.Drawing.Point(16, 159);
            this.devnum_label.Name = "devnum_label";
            this.devnum_label.Size = new System.Drawing.Size(65, 12);
            this.devnum_label.TabIndex = 16;
            this.devnum_label.Text = "设备编号：";
            // 
            // new_templet_button
            // 
            this.new_templet_button.Location = new System.Drawing.Point(18, 272);
            this.new_templet_button.Name = "new_templet_button";
            this.new_templet_button.Size = new System.Drawing.Size(96, 54);
            this.new_templet_button.TabIndex = 12;
            this.new_templet_button.Text = "模板管理";
            this.new_templet_button.UseVisualStyleBackColor = true;
            this.new_templet_button.Click += new System.EventHandler(this.new_templet_button_Click);
            // 
            // vcut_button
            // 
            this.vcut_button.Location = new System.Drawing.Point(246, 66);
            this.vcut_button.Name = "vcut_button";
            this.vcut_button.Size = new System.Drawing.Size(173, 27);
            this.vcut_button.TabIndex = 6;
            this.vcut_button.Text = "可视化裁剪";
            this.vcut_button.UseVisualStyleBackColor = true;
            this.vcut_button.Click += new System.EventHandler(this.vcut_button_Click);
            // 
            // set_dir_button
            // 
            this.set_dir_button.Location = new System.Drawing.Point(18, 339);
            this.set_dir_button.Name = "set_dir_button";
            this.set_dir_button.Size = new System.Drawing.Size(96, 54);
            this.set_dir_button.TabIndex = 14;
            this.set_dir_button.Text = "设置波形文件夹";
            this.set_dir_button.UseVisualStyleBackColor = true;
            this.set_dir_button.Click += new System.EventHandler(this.set_dir_button_Click);
            // 
            // select_button
            // 
            this.select_button.Location = new System.Drawing.Point(131, 339);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(96, 54);
            this.select_button.TabIndex = 15;
            this.select_button.Text = "自由选择波形文件";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.select_button_Click);
            // 
            // mainform_statusStrip
            // 
            this.mainform_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.path_label_toolStripStatusLabel,
            this.path_toolStripStatusLabel});
            this.mainform_statusStrip.Location = new System.Drawing.Point(0, 409);
            this.mainform_statusStrip.Name = "mainform_statusStrip";
            this.mainform_statusStrip.Size = new System.Drawing.Size(470, 22);
            this.mainform_statusStrip.SizingGrip = false;
            this.mainform_statusStrip.TabIndex = 20;
            this.mainform_statusStrip.Text = "statusStrip1";
            // 
            // path_label_toolStripStatusLabel
            // 
            this.path_label_toolStripStatusLabel.Name = "path_label_toolStripStatusLabel";
            this.path_label_toolStripStatusLabel.Size = new System.Drawing.Size(68, 17);
            this.path_label_toolStripStatusLabel.Text = "当前路径：";
            // 
            // path_toolStripStatusLabel
            // 
            this.path_toolStripStatusLabel.Name = "path_toolStripStatusLabel";
            this.path_toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // free_select_openFileDialog
            // 
            this.free_select_openFileDialog.FileName = "openFileDialog1";
            this.free_select_openFileDialog.Filter = "BMP文件|*.bmp|JPG文件|*.jpg|PNG文件|*.png";
            this.free_select_openFileDialog.Multiselect = true;
            // 
            // rd_textBox1
            // 
            this.rd_textBox1.Location = new System.Drawing.Point(104, 225);
            this.rd_textBox1.Name = "rd_textBox1";
            this.rd_textBox1.Size = new System.Drawing.Size(123, 21);
            this.rd_textBox1.TabIndex = 21;
            // 
            // rd_textBox2
            // 
            this.rd_textBox2.Location = new System.Drawing.Point(332, 225);
            this.rd_textBox2.Name = "rd_textBox2";
            this.rd_textBox2.Size = new System.Drawing.Size(121, 21);
            this.rd_textBox2.TabIndex = 22;
            // 
            // main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 431);
            this.Controls.Add(this.rd_textBox2);
            this.Controls.Add(this.rd_textBox1);
            this.Controls.Add(this.mainform_statusStrip);
            this.Controls.Add(this.select_button);
            this.Controls.Add(this.set_dir_button);
            this.Controls.Add(this.vcut_button);
            this.Controls.Add(this.new_templet_button);
            this.Controls.Add(this.devnum_label);
            this.Controls.Add(this.devnum_textBox);
            this.Controls.Add(this.cutpic_right_textBox);
            this.Controls.Add(this.cutpic_left_textBox);
            this.Controls.Add(this.cutpic_down_textBox);
            this.Controls.Add(this.cutpic_up_textBox);
            this.Controls.Add(this.cutpic_label);
            this.Controls.Add(this.templet_label);
            this.Controls.Add(this.templet_comboBox);
            this.Controls.Add(this.load_progressBar);
            this.Controls.Add(this.pcontray_checkBox);
            this.Controls.Add(this.dir_list_button);
            this.Controls.Add(this.go_button);
            this.Controls.Add(this.right_down_textBox2);
            this.Controls.Add(this.right_down_textBox1);
            this.Controls.Add(this.right_down_label2);
            this.Controls.Add(this.right_down_label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "波形图汇总 V1.0.0.1";
            this.Activated += new System.EventHandler(this.main_Form_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_Form_FormClosed);
            this.mainform_statusStrip.ResumeLayout(false);
            this.mainform_statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label right_down_label1;
        private System.Windows.Forms.Label right_down_label2;
        private System.Windows.Forms.TextBox right_down_textBox1;
        private System.Windows.Forms.TextBox right_down_textBox2;
        private System.Windows.Forms.Button go_button;
        private System.Windows.Forms.Button dir_list_button;
        private System.Windows.Forms.ProgressBar load_progressBar;
        private System.Windows.Forms.CheckBox pcontray_checkBox;
        private System.Windows.Forms.ComboBox templet_comboBox;
        private System.Windows.Forms.Label templet_label;
        private System.Windows.Forms.Label cutpic_label;
        private System.Windows.Forms.TextBox cutpic_up_textBox;
        private System.Windows.Forms.TextBox cutpic_down_textBox;
        private System.Windows.Forms.TextBox cutpic_left_textBox;
        private System.Windows.Forms.TextBox cutpic_right_textBox;
        private System.Windows.Forms.TextBox devnum_textBox;
        private System.Windows.Forms.Label devnum_label;
        private System.Windows.Forms.Button new_templet_button;
        private System.Windows.Forms.Button vcut_button;
        private System.Windows.Forms.Button set_dir_button;
        private System.Windows.Forms.Button select_button;
        private System.Windows.Forms.StatusStrip mainform_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel path_label_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel path_toolStripStatusLabel;
        private System.Windows.Forms.FolderBrowserDialog path_folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog free_select_openFileDialog;
        private System.Windows.Forms.TextBox rd_textBox1;
        private System.Windows.Forms.TextBox rd_textBox2;
    }
}

