namespace WaveReport
{
    partial class cutpicForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cutpicForm));
            this.open_cutpic_button = new System.Windows.Forms.Button();
            this.cutpic_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.leftup_radioButton = new System.Windows.Forms.RadioButton();
            this.rightdown_radioButton = new System.Windows.Forms.RadioButton();
            this.leftup_textBox = new System.Windows.Forms.TextBox();
            this.rightdown_textBox = new System.Windows.Forms.TextBox();
            this.ok_button = new System.Windows.Forms.Button();
            this.cutpic_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cutpic_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // open_cutpic_button
            // 
            this.open_cutpic_button.Location = new System.Drawing.Point(12, 3);
            this.open_cutpic_button.Name = "open_cutpic_button";
            this.open_cutpic_button.Size = new System.Drawing.Size(75, 23);
            this.open_cutpic_button.TabIndex = 1;
            this.open_cutpic_button.Text = "打开";
            this.open_cutpic_button.UseVisualStyleBackColor = true;
            this.open_cutpic_button.Click += new System.EventHandler(this.open_cutpic_button_Click);
            // 
            // cutpic_openFileDialog
            // 
            this.cutpic_openFileDialog.FileName = "openFileDialog1";
            this.cutpic_openFileDialog.Filter = "BMP文件|*.bmp|JPG文件|*.jpg|PNG文件|*.png";
            // 
            // leftup_radioButton
            // 
            this.leftup_radioButton.AutoSize = true;
            this.leftup_radioButton.Checked = true;
            this.leftup_radioButton.Location = new System.Drawing.Point(133, 6);
            this.leftup_radioButton.Name = "leftup_radioButton";
            this.leftup_radioButton.Size = new System.Drawing.Size(59, 16);
            this.leftup_radioButton.TabIndex = 2;
            this.leftup_radioButton.TabStop = true;
            this.leftup_radioButton.Text = "左上角";
            this.leftup_radioButton.UseVisualStyleBackColor = true;
            // 
            // rightdown_radioButton
            // 
            this.rightdown_radioButton.AutoSize = true;
            this.rightdown_radioButton.Location = new System.Drawing.Point(327, 6);
            this.rightdown_radioButton.Name = "rightdown_radioButton";
            this.rightdown_radioButton.Size = new System.Drawing.Size(59, 16);
            this.rightdown_radioButton.TabIndex = 3;
            this.rightdown_radioButton.Text = "右下角";
            this.rightdown_radioButton.UseVisualStyleBackColor = true;
            // 
            // leftup_textBox
            // 
            this.leftup_textBox.Location = new System.Drawing.Point(198, 5);
            this.leftup_textBox.Name = "leftup_textBox";
            this.leftup_textBox.ReadOnly = true;
            this.leftup_textBox.Size = new System.Drawing.Size(100, 21);
            this.leftup_textBox.TabIndex = 4;
            // 
            // rightdown_textBox
            // 
            this.rightdown_textBox.Location = new System.Drawing.Point(392, 5);
            this.rightdown_textBox.Name = "rightdown_textBox";
            this.rightdown_textBox.ReadOnly = true;
            this.rightdown_textBox.Size = new System.Drawing.Size(100, 21);
            this.rightdown_textBox.TabIndex = 5;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(538, 3);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 6;
            this.ok_button.Text = "确定";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // cutpic_pictureBox
            // 
            this.cutpic_pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.cutpic_pictureBox.Image = global::WaveReport.Properties.Resources.logo;
            this.cutpic_pictureBox.Location = new System.Drawing.Point(12, 32);
            this.cutpic_pictureBox.Name = "cutpic_pictureBox";
            this.cutpic_pictureBox.Size = new System.Drawing.Size(645, 387);
            this.cutpic_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cutpic_pictureBox.TabIndex = 0;
            this.cutpic_pictureBox.TabStop = false;
            this.cutpic_pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cutpic_pictureBox_MouseClick);
            // 
            // cutpicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 431);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.rightdown_textBox);
            this.Controls.Add(this.leftup_textBox);
            this.Controls.Add(this.rightdown_radioButton);
            this.Controls.Add(this.leftup_radioButton);
            this.Controls.Add(this.open_cutpic_button);
            this.Controls.Add(this.cutpic_pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cutpicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "波形图裁剪";
            this.Resize += new System.EventHandler(this.cutpicForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.cutpic_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox cutpic_pictureBox;
        private System.Windows.Forms.Button open_cutpic_button;
        private System.Windows.Forms.OpenFileDialog cutpic_openFileDialog;
        private System.Windows.Forms.RadioButton leftup_radioButton;
        private System.Windows.Forms.RadioButton rightdown_radioButton;
        private System.Windows.Forms.TextBox leftup_textBox;
        private System.Windows.Forms.TextBox rightdown_textBox;
        private System.Windows.Forms.Button ok_button;
    }
}