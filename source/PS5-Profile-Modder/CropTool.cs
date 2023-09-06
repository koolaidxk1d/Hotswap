using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraEditors.ImageEditor;

namespace PS5_Profile_Modder {
    public partial class CropTool : DevExpress.XtraEditors.XtraForm {

        String SelectedUser;
        public CropTool(Image selected_user_image, String selected_user) {
            InitializeComponent();
            SelectedUser = selected_user;
            pictureEdit1.Image = selected_user_image;
            if (!Connect.IsDarkMode()) { this.IconOptions.Image = global::PS5_Profile_Modder.Properties.Resources.other; }





        }

        private void btnChooseFile_Click(object sender, EventArgs e) {
            fileOpenDialog.ShowDialog();

        }

        // if file is opened
        private void fileOpenDialog_FileOk(object sender, CancelEventArgs e) {
            try {
                pictureEdit1.Image = Bitmap.FromStream(fileOpenDialog.OpenFile());

            } catch {
                XtraMessageBox.Show("Image is corrupt/unsupported ;__;", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void btnTakePicture_Click(object sender, EventArgs e) {
            pictureEdit1.ShowTakePictureDialog();
        }


        private void btnCrop_Click(object sender, EventArgs e) {
            pictureEdit1.ShowImageEditorDialog();
        }

        private void btnDone_Click(object sender, EventArgs e) {
            try {
                
                var ms = new MemoryStream();
                pictureEdit1.Image.Save(ms, ImageFormat.Png);
                byte[] i = ms.ToArray();
                Users.UsersDict[SelectedUser].Avatar = new MagickImage(i);
                Users.UsersDict[SelectedUser].Changed = true;

            } catch { }

            this.Close();

        }

        private void pictureEdit1_ImageEditorDialogShowing(object sender, DevExpress.XtraEditors.ImageEditor.ImageEditorDialogShowingEventArgs e) {
            e.Form.CustomizeCropOptions += CustomizeCropOptions;
        }

        void CustomizeCropOptions(object sender, CustomizeCropOptionsEventArgs e) {
            var Square = new AspectRatioInfo(AspectRatioMode.Square, "Square");
            var Manual = new AspectRatioInfo(AspectRatioMode.Manual, "Manual");
            e.AspectRatios.Clear();
            e.AspectRatios.Add(Square);
            e.AspectRatios.Add(Manual); 
            e.DefaultAspectRatio = Square;
            e.CropRegionToImageRatio = 100;

        }


    }
}
