namespace AmaneroFlash
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_CPLD = new System.Windows.Forms.ComboBox();
            this.comboBox_CPU = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_FlashCPLD = new System.Windows.Forms.Button();
            this.btn_FlashCPU = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel = new System.Windows.Forms.Panel();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 8, 5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPLD Firmware:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox_CPLD
            // 
            this.comboBox_CPLD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CPLD.FormattingEnabled = true;
            this.comboBox_CPLD.IntegralHeight = false;
            this.comboBox_CPLD.Location = new System.Drawing.Point(145, 16);
            this.comboBox_CPLD.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.comboBox_CPLD.MaxDropDownItems = 10;
            this.comboBox_CPLD.Name = "comboBox_CPLD";
            this.comboBox_CPLD.Size = new System.Drawing.Size(300, 28);
            this.comboBox_CPLD.TabIndex = 1;
            // 
            // comboBox_CPU
            // 
            this.comboBox_CPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CPU.FormattingEnabled = true;
            this.comboBox_CPU.IntegralHeight = false;
            this.comboBox_CPU.Location = new System.Drawing.Point(145, 67);
            this.comboBox_CPU.MaxDropDownItems = 10;
            this.comboBox_CPU.Name = "comboBox_CPU";
            this.comboBox_CPU.Size = new System.Drawing.Size(300, 28);
            this.comboBox_CPU.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 8, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPU Firmware:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_FlashCPLD
            // 
            this.btn_FlashCPLD.Location = new System.Drawing.Point(465, 16);
            this.btn_FlashCPLD.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btn_FlashCPLD.Name = "btn_FlashCPLD";
            this.btn_FlashCPLD.Size = new System.Drawing.Size(100, 28);
            this.btn_FlashCPLD.TabIndex = 4;
            this.btn_FlashCPLD.Tag = "CPLD";
            this.btn_FlashCPLD.Text = "Flash";
            this.btn_FlashCPLD.UseVisualStyleBackColor = true;
            this.btn_FlashCPLD.Click += new System.EventHandler(this.btn_Flash_Click);
            // 
            // btn_FlashCPU
            // 
            this.btn_FlashCPU.Location = new System.Drawing.Point(465, 67);
            this.btn_FlashCPU.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btn_FlashCPU.Name = "btn_FlashCPU";
            this.btn_FlashCPU.Size = new System.Drawing.Size(100, 28);
            this.btn_FlashCPU.TabIndex = 5;
            this.btn_FlashCPU.Tag = "CPU";
            this.btn_FlashCPU.Text = "Flash";
            this.btn_FlashCPU.UseVisualStyleBackColor = true;
            this.btn_FlashCPU.Click += new System.EventHandler(this.btn_Flash_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 139);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 28);
            this.progressBar.TabIndex = 9;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.linkLabel);
            this.panel.Controls.Add(this.progressBar);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.comboBox_CPLD);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.comboBox_CPU);
            this.panel.Controls.Add(this.btn_FlashCPU);
            this.panel.Controls.Add(this.btn_FlashCPLD);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(584, 181);
            this.panel.TabIndex = 10;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.linkLabel.Location = new System.Drawing.Point(418, 109);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(154, 20);
            this.linkLabel.TabIndex = 10;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Github: AmaneroFlash";
            this.linkLabel.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 181);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Combo384 Flash Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_CPLD;
        private System.Windows.Forms.ComboBox comboBox_CPU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_FlashCPLD;
        private System.Windows.Forms.Button btn_FlashCPU;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.LinkLabel linkLabel;
    }
}

