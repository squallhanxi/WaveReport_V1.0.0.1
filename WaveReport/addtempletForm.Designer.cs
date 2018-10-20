namespace WaveReport
{
    partial class addtempletForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addtempletForm));
            this.new_templet_richTextBox = new System.Windows.Forms.RichTextBox();
            this.new_templet_button = new System.Windows.Forms.Button();
            this.templet_name_label = new System.Windows.Forms.Label();
            this.templet_name_textBox = new System.Windows.Forms.TextBox();
            this.templet_num_statusStrip = new System.Windows.Forms.StatusStrip();
            this.templet_num_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.templet_nownum_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.edit_templet_button = new System.Windows.Forms.Button();
            this.edit_templet_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.templet_num_statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // new_templet_richTextBox
            // 
            this.new_templet_richTextBox.Location = new System.Drawing.Point(12, 12);
            this.new_templet_richTextBox.Name = "new_templet_richTextBox";
            this.new_templet_richTextBox.Size = new System.Drawing.Size(260, 176);
            this.new_templet_richTextBox.TabIndex = 2;
            this.new_templet_richTextBox.Text = "";
            this.new_templet_richTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.new_templet_richTextBox_KeyPress);
            // 
            // new_templet_button
            // 
            this.new_templet_button.Location = new System.Drawing.Point(12, 226);
            this.new_templet_button.Name = "new_templet_button";
            this.new_templet_button.Size = new System.Drawing.Size(123, 46);
            this.new_templet_button.TabIndex = 1;
            this.new_templet_button.Text = "添加";
            this.new_templet_button.UseVisualStyleBackColor = true;
            this.new_templet_button.Click += new System.EventHandler(this.new_templet_button_Click);
            // 
            // templet_name_label
            // 
            this.templet_name_label.AutoSize = true;
            this.templet_name_label.Location = new System.Drawing.Point(10, 202);
            this.templet_name_label.Name = "templet_name_label";
            this.templet_name_label.Size = new System.Drawing.Size(65, 12);
            this.templet_name_label.TabIndex = 2;
            this.templet_name_label.Text = "设备型号：";
            // 
            // templet_name_textBox
            // 
            this.templet_name_textBox.Location = new System.Drawing.Point(81, 199);
            this.templet_name_textBox.Name = "templet_name_textBox";
            this.templet_name_textBox.Size = new System.Drawing.Size(191, 21);
            this.templet_name_textBox.TabIndex = 3;
            this.templet_name_textBox.Text = "XXX-XXX";
            // 
            // templet_num_statusStrip
            // 
            this.templet_num_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templet_num_toolStripStatusLabel,
            this.templet_nownum_toolStripStatusLabel});
            this.templet_num_statusStrip.Location = new System.Drawing.Point(0, 285);
            this.templet_num_statusStrip.Name = "templet_num_statusStrip";
            this.templet_num_statusStrip.Size = new System.Drawing.Size(284, 22);
            this.templet_num_statusStrip.SizingGrip = false;
            this.templet_num_statusStrip.TabIndex = 10;
            // 
            // templet_num_toolStripStatusLabel
            // 
            this.templet_num_toolStripStatusLabel.Name = "templet_num_toolStripStatusLabel";
            this.templet_num_toolStripStatusLabel.Size = new System.Drawing.Size(44, 17);
            this.templet_num_toolStripStatusLabel.Text = "数量：";
            // 
            // templet_nownum_toolStripStatusLabel
            // 
            this.templet_nownum_toolStripStatusLabel.Name = "templet_nownum_toolStripStatusLabel";
            this.templet_nownum_toolStripStatusLabel.Size = new System.Drawing.Size(15, 17);
            this.templet_nownum_toolStripStatusLabel.Text = "0";
            // 
            // edit_templet_button
            // 
            this.edit_templet_button.Location = new System.Drawing.Point(149, 226);
            this.edit_templet_button.Name = "edit_templet_button";
            this.edit_templet_button.Size = new System.Drawing.Size(123, 46);
            this.edit_templet_button.TabIndex = 4;
            this.edit_templet_button.Text = "编辑";
            this.edit_templet_button.UseVisualStyleBackColor = true;
            this.edit_templet_button.Click += new System.EventHandler(this.edit_templet_button_Click);
            // 
            // edit_templet_openFileDialog
            // 
            this.edit_templet_openFileDialog.FileName = "openFileDialog1";
            this.edit_templet_openFileDialog.Filter = "模板文件|*.xml";
            this.edit_templet_openFileDialog.InitialDirectory = "\\templet";
            // 
            // addtempletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 307);
            this.Controls.Add(this.edit_templet_button);
            this.Controls.Add(this.templet_num_statusStrip);
            this.Controls.Add(this.templet_name_textBox);
            this.Controls.Add(this.templet_name_label);
            this.Controls.Add(this.new_templet_button);
            this.Controls.Add(this.new_templet_richTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "addtempletForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加模板";
            this.templet_num_statusStrip.ResumeLayout(false);
            this.templet_num_statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox new_templet_richTextBox;
        private System.Windows.Forms.Button new_templet_button;
        private System.Windows.Forms.Label templet_name_label;
        private System.Windows.Forms.TextBox templet_name_textBox;
        private System.Windows.Forms.StatusStrip templet_num_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel templet_num_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel templet_nownum_toolStripStatusLabel;
        private System.Windows.Forms.Button edit_templet_button;
        private System.Windows.Forms.OpenFileDialog edit_templet_openFileDialog;
    }
}