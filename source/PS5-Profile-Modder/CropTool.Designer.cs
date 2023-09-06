namespace PS5_Profile_Modder {
    partial class CropTool {
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
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnDone = new DevExpress.XtraEditors.SimpleButton();
            this.btnCrop = new DevExpress.XtraEditors.SimpleButton();
            this.btnChooseFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnTakePicture = new DevExpress.XtraEditors.SimpleButton();
            this.fileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::PS5_Profile_Modder.Properties.Resources.default_avatar;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Size = new System.Drawing.Size(250, 250);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.ImageEditorDialogShowing += new DevExpress.XtraEditors.ImageEditor.ImageEditorDialogShowingEventHandler(this.pictureEdit1_ImageEditorDialogShowing);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(178, 328);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(85, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Location = new System.Drawing.Point(192, 268);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(70, 23);
            this.btnCrop.TabIndex = 2;
            this.btnCrop.Text = "Crop";
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(12, 268);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(81, 23);
            this.btnChooseFile.TabIndex = 3;
            this.btnChooseFile.Text = "Choose a File";
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Location = new System.Drawing.Point(99, 268);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(62, 23);
            this.btnTakePicture.TabIndex = 4;
            this.btnTakePicture.Text = "Webcam";
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // fileOpenDialog
            // 
            this.fileOpenDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.tif;*.bmp";
            this.fileOpenDialog.RestoreDirectory = true;
            this.fileOpenDialog.Title = "Choose an Avatar";
            this.fileOpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.fileOpenDialog_FileOk);
            // 
            // CropTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 363);
            this.Controls.Add(this.btnTakePicture);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.btnCrop);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::PS5_Profile_Modder.Properties.Resources.default_avatar;
            
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CropTool";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crop Image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnDone;
        private DevExpress.XtraEditors.SimpleButton btnCrop;
        private DevExpress.XtraEditors.SimpleButton btnChooseFile;
        private DevExpress.XtraEditors.SimpleButton btnTakePicture;
        private System.Windows.Forms.OpenFileDialog fileOpenDialog;
    }
}