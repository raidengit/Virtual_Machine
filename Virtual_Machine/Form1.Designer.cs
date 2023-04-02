namespace Virtual_Machine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMachineName = new TextBox();
            cmbOsType = new ComboBox();
            cmbGraphicsController = new ComboBox();
            cmbNetworkMode = new ComboBox();
            btnCreate = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            cmbOsVersion = new ComboBox();
            cmbVmLocation = new ComboBox();
            radioButton1 = new RadioButton();
            comboBox1 = new ComboBox();
            cmbRAM = new ComboBox();
            comboBox3 = new ComboBox();
            cmbVideo = new ComboBox();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            SuspendLayout();
            // 
            // txtMachineName
            // 
            txtMachineName.Location = new Point(113, 96);
            txtMachineName.Name = "txtMachineName";
            txtMachineName.Size = new Size(244, 27);
            txtMachineName.TabIndex = 0;
            // 
            // cmbOsType
            // 
            cmbOsType.FormattingEnabled = true;
            cmbOsType.Location = new Point(113, 189);
            cmbOsType.Name = "cmbOsType";
            cmbOsType.Size = new Size(245, 28);
            cmbOsType.TabIndex = 1;
            cmbOsType.SelectedIndexChanged += cmbOsType_SelectedIndexChanged;
            // 
            // cmbGraphicsController
            // 
            cmbGraphicsController.FormattingEnabled = true;
            cmbGraphicsController.Location = new Point(644, 253);
            cmbGraphicsController.Name = "cmbGraphicsController";
            cmbGraphicsController.Size = new Size(151, 28);
            cmbGraphicsController.TabIndex = 9;
            cmbGraphicsController.SelectedIndexChanged += cmbGraphicsController_SelectedIndexChanged;
            // 
            // cmbNetworkMode
            // 
            cmbNetworkMode.FormattingEnabled = true;
            cmbNetworkMode.Location = new Point(644, 302);
            cmbNetworkMode.Name = "cmbNetworkMode";
            cmbNetworkMode.Size = new Size(151, 28);
            cmbNetworkMode.TabIndex = 10;
            cmbNetworkMode.SelectedIndexChanged += cmbNetworkMode_SelectedIndexChanged;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(1113, 495);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(139, 53);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 12;
            label1.Text = "VM Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 151);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 13;
            label2.Text = "OsVersion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 253);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 14;
            label3.Text = "VMLocation";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(485, 103);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 17;
            label6.Text = "RAM";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(485, 151);
            label7.Name = "label7";
            label7.Size = new Size(46, 20);
            label7.TabIndex = 18;
            label7.Text = "Cores";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(485, 197);
            label8.Name = "label8";
            label8.Size = new Size(73, 20);
            label8.TabIndex = 19;
            label8.Text = "VMemory";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 197);
            label9.Name = "label9";
            label9.Size = new Size(57, 20);
            label9.TabIndex = 20;
            label9.Text = "OsType";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(485, 258);
            label10.Name = "label10";
            label10.Size = new Size(126, 20);
            label10.TabIndex = 21;
            label10.Text = "GraphicController";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(485, 310);
            label11.Name = "label11";
            label11.Size = new Size(106, 20);
            label11.TabIndex = 22;
            label11.Text = "NetWorkMode";
            // 
            // cmbOsVersion
            // 
            cmbOsVersion.FormattingEnabled = true;
            cmbOsVersion.Location = new Point(113, 143);
            cmbOsVersion.Name = "cmbOsVersion";
            cmbOsVersion.Size = new Size(245, 28);
            cmbOsVersion.TabIndex = 23;
            cmbOsVersion.SelectedIndexChanged += txtOsVersion_SelectedIndexChanged;
            // 
            // cmbVmLocation
            // 
            cmbVmLocation.FormattingEnabled = true;
            cmbVmLocation.Location = new Point(113, 250);
            cmbVmLocation.Name = "cmbVmLocation";
            cmbVmLocation.Size = new Size(245, 28);
            cmbVmLocation.TabIndex = 24;
            cmbVmLocation.SelectedIndexChanged += txtVmLocation_SelectedIndexChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(12, 342);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(189, 24);
            radioButton1.TabIndex = 25;
            radioButton1.TabStop = true;
            radioButton1.Text = "Create Virtual Hard Disk";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(246, 338);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 28);
            comboBox1.TabIndex = 26;
            // 
            // cmbRAM
            // 
            cmbRAM.FormattingEnabled = true;
            cmbRAM.Location = new Point(644, 100);
            cmbRAM.Name = "cmbRAM";
            cmbRAM.Size = new Size(151, 28);
            cmbRAM.TabIndex = 27;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(644, 148);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 28;
            // 
            // cmbVideo
            // 
            cmbVideo.FormattingEnabled = true;
            cmbVideo.Location = new Point(644, 197);
            cmbVideo.Name = "cmbVideo";
            cmbVideo.Size = new Size(151, 28);
            cmbVideo.TabIndex = 29;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(877, 104);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(198, 24);
            radioButton2.TabIndex = 30;
            radioButton2.TabStop = true;
            radioButton2.Text = "Download and install ISO";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(877, 152);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(176, 24);
            radioButton3.TabIndex = 31;
            radioButton3.TabStop = true;
            radioButton3.Text = "Install ISO from my pc";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 570);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(cmbVideo);
            Controls.Add(comboBox3);
            Controls.Add(cmbRAM);
            Controls.Add(comboBox1);
            Controls.Add(radioButton1);
            Controls.Add(cmbVmLocation);
            Controls.Add(cmbOsVersion);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCreate);
            Controls.Add(cmbNetworkMode);
            Controls.Add(cmbGraphicsController);
            Controls.Add(cmbOsType);
            Controls.Add(txtMachineName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMachineName;
        private ComboBox cmbOsType;
        private ComboBox cmbGraphicsController;
        private ComboBox cmbNetworkMode;
        private Button btnCreate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private ComboBox cmbOsVersion;
        private ComboBox cmbVmLocation;
        private RadioButton radioButton1;
        private ComboBox comboBox1;
        private ComboBox cmbRAM;
        private ComboBox comboBox3;
        private ComboBox cmbVideo;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
    }
}