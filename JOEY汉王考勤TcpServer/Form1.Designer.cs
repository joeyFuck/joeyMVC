namespace Splash
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxPassiveEncryption = new System.Windows.Forms.CheckBox();
            this.comboBoxServerIP = new System.Windows.Forms.ComboBox();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStartListener = new System.Windows.Forms.Button();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.checkBoxPostPhoto = new System.Windows.Forms.CheckBox();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.buttonExecuteCommand = new System.Windows.Forms.Button();
            this.textBoxDevicePort = new System.Windows.Forms.TextBox();
            this.textBoxDeviceIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSecretKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCommandHelp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxPassiveEncryption);
            this.groupBox1.Controls.Add(this.comboBoxServerIP);
            this.groupBox1.Controls.Add(this.textBoxServerPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonStartListener);
            this.groupBox1.Controls.Add(this.checkBoxPostPhoto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 156);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接设备";
            // 
            // checkBoxPassiveEncryption
            // 
            this.checkBoxPassiveEncryption.AutoSize = true;
            this.checkBoxPassiveEncryption.Location = new System.Drawing.Point(120, 94);
            this.checkBoxPassiveEncryption.Name = "checkBoxPassiveEncryption";
            this.checkBoxPassiveEncryption.Size = new System.Drawing.Size(108, 16);
            this.checkBoxPassiveEncryption.TabIndex = 12;
            this.checkBoxPassiveEncryption.Text = "通信强制加密？";
            this.checkBoxPassiveEncryption.UseVisualStyleBackColor = true;
            // 
            // comboBoxServerIP
            // 
            this.comboBoxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServerIP.FormattingEnabled = true;
            this.comboBoxServerIP.Location = new System.Drawing.Point(120, 25);
            this.comboBoxServerIP.Name = "comboBoxServerIP";
            this.comboBoxServerIP.Size = new System.Drawing.Size(202, 20);
            this.comboBoxServerIP.TabIndex = 11;
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(120, 58);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(202, 21);
            this.textBoxServerPort.TabIndex = 8;
            this.textBoxServerPort.Text = "9900";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "服务器端口";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "服务器地址";
            // 
            // buttonStartListener
            // 
            this.buttonStartListener.Location = new System.Drawing.Point(295, 104);
            this.buttonStartListener.Name = "buttonStartListener";
            this.buttonStartListener.Size = new System.Drawing.Size(75, 39);
            this.buttonStartListener.TabIndex = 9;
            this.buttonStartListener.Text = "开启侦听";
            this.buttonStartListener.UseVisualStyleBackColor = true;
            this.buttonStartListener.Click += new System.EventHandler(this.buttonStartListener_Click);
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Location = new System.Drawing.Point(12, 419);
            this.textBoxAnswer.Multiline = true;
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.ReadOnly = true;
            this.textBoxAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAnswer.Size = new System.Drawing.Size(370, 174);
            this.textBoxAnswer.TabIndex = 10;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 283);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 39);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "清空";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // checkBoxPostPhoto
            // 
            this.checkBoxPostPhoto.AutoSize = true;
            this.checkBoxPostPhoto.Checked = true;
            this.checkBoxPostPhoto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPostPhoto.Location = new System.Drawing.Point(120, 116);
            this.checkBoxPostPhoto.Name = "checkBoxPostPhoto";
            this.checkBoxPostPhoto.Size = new System.Drawing.Size(108, 16);
            this.checkBoxPostPhoto.TabIndex = 11;
            this.checkBoxPostPhoto.Text = "是否上传照片？";
            this.checkBoxPostPhoto.UseVisualStyleBackColor = true;
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(12, 328);
            this.textBoxCommand.Multiline = true;
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCommand.Size = new System.Drawing.Size(370, 56);
            this.textBoxCommand.TabIndex = 19;
            this.textBoxCommand.Text = "GetDeviceInfo()";
            // 
            // buttonExecuteCommand
            // 
            this.buttonExecuteCommand.Location = new System.Drawing.Point(307, 282);
            this.buttonExecuteCommand.Name = "buttonExecuteCommand";
            this.buttonExecuteCommand.Size = new System.Drawing.Size(75, 40);
            this.buttonExecuteCommand.TabIndex = 20;
            this.buttonExecuteCommand.Text = "执行命令";
            this.buttonExecuteCommand.UseVisualStyleBackColor = true;
            this.buttonExecuteCommand.Click += new System.EventHandler(this.buttonExecuteCommand_Click);
            // 
            // textBoxDevicePort
            // 
            this.textBoxDevicePort.Location = new System.Drawing.Point(128, 221);
            this.textBoxDevicePort.Name = "textBoxDevicePort";
            this.textBoxDevicePort.ReadOnly = true;
            this.textBoxDevicePort.Size = new System.Drawing.Size(206, 21);
            this.textBoxDevicePort.TabIndex = 24;
            this.textBoxDevicePort.Text = "9922";
            // 
            // textBoxDeviceIP
            // 
            this.textBoxDeviceIP.Location = new System.Drawing.Point(128, 187);
            this.textBoxDeviceIP.Name = "textBoxDeviceIP";
            this.textBoxDeviceIP.Size = new System.Drawing.Size(206, 21);
            this.textBoxDeviceIP.TabIndex = 23;
            this.textBoxDeviceIP.Text = "192.168.2.59";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "设备端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "设备地址";
            // 
            // textBoxSecretKey
            // 
            this.textBoxSecretKey.Location = new System.Drawing.Point(128, 248);
            this.textBoxSecretKey.Name = "textBoxSecretKey";
            this.textBoxSecretKey.Size = new System.Drawing.Size(206, 21);
            this.textBoxSecretKey.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "通信密码";
            // 
            // buttonCommandHelp
            // 
            this.buttonCommandHelp.Location = new System.Drawing.Point(307, 390);
            this.buttonCommandHelp.Name = "buttonCommandHelp";
            this.buttonCommandHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonCommandHelp.TabIndex = 27;
            this.buttonCommandHelp.Text = "命令帮助";
            this.buttonCommandHelp.UseVisualStyleBackColor = true;
            this.buttonCommandHelp.Click += new System.EventHandler(this.buttonCommandHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 605);
            this.Controls.Add(this.buttonCommandHelp);
            this.Controls.Add(this.textBoxSecretKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDevicePort);
            this.Controls.Add(this.textBoxDeviceIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExecuteCommand);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.buttonClear);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "汉王考勤Tcp Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxServerIP;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Button buttonStartListener;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.CheckBox checkBoxPostPhoto;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.CheckBox checkBoxPassiveEncryption;
        private System.Windows.Forms.Button buttonExecuteCommand;
        private System.Windows.Forms.TextBox textBoxDevicePort;
        private System.Windows.Forms.TextBox textBoxDeviceIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSecretKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCommandHelp;
    }
}

