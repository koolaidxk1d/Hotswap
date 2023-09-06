namespace PS5_Profile_Modder {
    partial class Connect {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connect));
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inputPort = new DevExpress.XtraEditors.TextEdit();
            this.inputIP = new DevExpress.XtraEditors.TextEdit();
            this.hyperlinkLabelControl1 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputIP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(184, 46);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 28);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // inputPort
            // 
            this.inputPort.EditValue = "";
            this.inputPort.Location = new System.Drawing.Point(113, 46);
            this.inputPort.Name = "inputPort";
            this.inputPort.Properties.NullValuePrompt = "Port";
            this.inputPort.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            this.inputPort.Properties.ValidateOnEnterKey = true;
            this.inputPort.Size = new System.Drawing.Size(65, 28);
            this.inputPort.TabIndex = 2;
            this.inputPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputPort_KeyPress);
            // 
            // inputIP
            // 
            this.inputIP.EditValue = "";
            this.inputIP.Location = new System.Drawing.Point(113, 12);
            this.inputIP.Name = "inputIP";
            this.inputIP.Properties.NullValuePrompt = "IP Address";
            this.inputIP.Properties.ValidateOnEnterKey = true;
            this.inputIP.Size = new System.Drawing.Size(151, 28);
            this.inputIP.TabIndex = 1;
            this.inputIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputIP_KeyPress);
            // 
            // hyperlinkLabelControl1
            // 
            this.hyperlinkLabelControl1.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.hyperlinkLabelControl1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.hyperlinkLabelControl1.Location = new System.Drawing.Point(184, 92);
            this.hyperlinkLabelControl1.Name = "hyperlinkLabelControl1";
            this.hyperlinkLabelControl1.Size = new System.Drawing.Size(74, 13);
            this.hyperlinkLabelControl1.TabIndex = 9;
            this.hyperlinkLabelControl1.Text = "<href=github.com/koolaidxk1d>@koolaidxk1d</href>";
            this.hyperlinkLabelControl1.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.hyperlinkLabelControl1_HyperlinkClick);
            // 
            // Connect
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 117);
            this.Controls.Add(this.hyperlinkLabelControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.inputPort);
            this.Controls.Add(this.inputIP);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::PS5_Profile_Modder.Properties.Resources.default_avatar;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connect";
            this.Text = "Connect to PS5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Connect_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputIP.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit inputIP;
        private DevExpress.XtraEditors.TextEdit inputPort;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControl1;
    }
}

