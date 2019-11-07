namespace DoneForTheDay
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSendWorkMail = new System.Windows.Forms.Button();
            this.btnRunCCleaner = new System.Windows.Forms.Button();
            this.btnLockPC = new System.Windows.Forms.Button();
            this.btnShutdownPC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendWorkMail
            // 
            this.btnSendWorkMail.Location = new System.Drawing.Point(63, 12);
            this.btnSendWorkMail.Name = "btnSendWorkMail";
            this.btnSendWorkMail.Size = new System.Drawing.Size(165, 48);
            this.btnSendWorkMail.TabIndex = 0;
            this.btnSendWorkMail.Text = "Send Work Mail";
            this.btnSendWorkMail.UseVisualStyleBackColor = true;
            this.btnSendWorkMail.Click += new System.EventHandler(this.btnSendWorkMail_Click);
            // 
            // btnRunCCleaner
            // 
            this.btnRunCCleaner.Location = new System.Drawing.Point(63, 76);
            this.btnRunCCleaner.Name = "btnRunCCleaner";
            this.btnRunCCleaner.Size = new System.Drawing.Size(165, 45);
            this.btnRunCCleaner.TabIndex = 1;
            this.btnRunCCleaner.Text = "Run CCleaner";
            this.btnRunCCleaner.UseVisualStyleBackColor = true;
            this.btnRunCCleaner.Click += new System.EventHandler(this.btnRunCCleaner_Click);
            // 
            // btnLockPC
            // 
            this.btnLockPC.Location = new System.Drawing.Point(12, 188);
            this.btnLockPC.Name = "btnLockPC";
            this.btnLockPC.Size = new System.Drawing.Size(133, 51);
            this.btnLockPC.TabIndex = 2;
            this.btnLockPC.Text = "Lock PC";
            this.btnLockPC.UseVisualStyleBackColor = true;
            this.btnLockPC.Click += new System.EventHandler(this.btnLockPC_Click);
            // 
            // btnShutdownPC
            // 
            this.btnShutdownPC.Location = new System.Drawing.Point(164, 188);
            this.btnShutdownPC.Name = "btnShutdownPC";
            this.btnShutdownPC.Size = new System.Drawing.Size(108, 51);
            this.btnShutdownPC.TabIndex = 3;
            this.btnShutdownPC.Text = "Shut Down PC";
            this.btnShutdownPC.UseVisualStyleBackColor = true;
            this.btnShutdownPC.Click += new System.EventHandler(this.btnShutdownPC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnShutdownPC);
            this.Controls.Add(this.btnLockPC);
            this.Controls.Add(this.btnRunCCleaner);
            this.Controls.Add(this.btnSendWorkMail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Done For The Day";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendWorkMail;
        private System.Windows.Forms.Button btnRunCCleaner;
        private System.Windows.Forms.Button btnLockPC;
        private System.Windows.Forms.Button btnShutdownPC;
    }
}

