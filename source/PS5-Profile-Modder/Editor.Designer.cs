namespace PS5_Profile_Modder {
    partial class Editor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.panelAvatar = new System.Windows.Forms.Panel();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.btnTrash = new DevExpress.XtraEditors.SimpleButton();
            this.dropUsers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnGrabber = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropUsers.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(185, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save User";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(22, 217);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(157, 28);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panelAvatar
            // 
            this.panelAvatar.Location = new System.Drawing.Point(22, 12);
            this.panelAvatar.Name = "panelAvatar";
            this.panelAvatar.Size = new System.Drawing.Size(100, 100);
            this.panelAvatar.TabIndex = 10;
            this.panelAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAvatar_Paint);
            // 
            // btnTrash
            // 
            this.btnTrash.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTrash.ImageOptions.Image")));
            this.btnTrash.Location = new System.Drawing.Point(22, 118);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(26, 28);
            this.btnTrash.TabIndex = 11;
            this.btnTrash.ToolTip = "Wipe this user\'s avatar cache";
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // dropUsers
            // 
            this.dropUsers.Location = new System.Drawing.Point(138, 12);
            this.dropUsers.Name = "dropUsers";
            this.dropUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dropUsers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dropUsers.Size = new System.Drawing.Size(142, 28);
            this.dropUsers.TabIndex = 1;
            this.dropUsers.SelectedIndexChanged += new System.EventHandler(this.dropUsers_SelectedIndexChanged);
            // 
            // btnGrabber
            // 
            this.btnGrabber.Appearance.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnGrabber.Appearance.Options.UseForeColor = true;
            this.btnGrabber.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnGrabber.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnGrabber.Location = new System.Drawing.Point(96, 118);
            this.btnGrabber.Name = "btnGrabber";
            this.btnGrabber.Size = new System.Drawing.Size(26, 28);
            this.btnGrabber.TabIndex = 12;
            this.btnGrabber.ToolTip = "Download this avatar\'s files to your PC";
            this.btnGrabber.Click += new System.EventHandler(this.btnGrabber_Click);
            // 
            // Editor
            // 
            this.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 266);
            this.Controls.Add(this.btnGrabber);
            this.Controls.Add(this.btnTrash);
            this.Controls.Add(this.panelAvatar);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dropUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Editor.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "Editor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropUsers.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit dropUsers;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private System.Windows.Forms.Panel panelAvatar;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton btnTrash;
        private DevExpress.XtraEditors.SimpleButton btnGrabber;
    }
}