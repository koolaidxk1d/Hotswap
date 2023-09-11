using DevExpress.DirectX.NativeInterop.Direct2D;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Design;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using System.IO;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System.Drawing.Imaging;

namespace PS5_Profile_Modder {
    public partial class Editor : DevExpress.XtraEditors.XtraForm {

        Image SelectedUserImage = null;
        FtpClient client;

        Image OpenedImage;
        Stream fs;
        MagickImage mi;

        Skin currentSkin;
        SkinElement element;

        public Editor(FtpClient ftpclient) {
            InitializeComponent();
            client = ftpclient;
            currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
            element = currentSkin[CommonSkins.SkinButton];

            if (!Connect.IsDarkMode()) { IconOptions.Image = PS5_Profile_Modder.Properties.Resources.other; }


            btnSave.Appearance.BackColor = currentSkin.SvgPalettes["DefaultSkinPalette"].
                GetColorByStyleName("Edit Background 0", "White");


            foreach (KeyValuePair<string, PS5User> entry in Users.UsersDict) {
                dropUsers.Properties.Items.Add(entry.Key);
            }
            dropUsers.SelectedIndex = 0;






        }
        private void panelAvatar_Paint(object sender, PaintEventArgs e) {
            // Show Person Picture using PS5User.Avatar (or default if null)
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Image image = new Bitmap(PS5_Profile_Modder.Properties.Resources.default_avatar, 98, 98);
            if (!Connect.IsDarkMode()) { image = new Bitmap(PS5_Profile_Modder.Properties.Resources.other, 98, 98); }
            try { image = new Bitmap(Users.UsersDict[dropUsers.SelectedItem.ToString()].Avatar.ToBitmap(), 98, 98); } catch { Console.WriteLine("No avatar found. Using default."); }
            TextureBrush tbrush = new TextureBrush(image, new RectangleF(0, 0, 98, 98));
            e.Graphics.FillEllipse(tbrush, new RectangleF(0, 0, 98, 98));

            if (Users.UsersDict[dropUsers.SelectedItem.ToString()].Changed == true) {
                btnSave.Enabled = true;
                btnSave.Appearance.BackColor = currentSkin.SvgPalettes["DefaultSkinPalette"].
                GetColorByStyleName("Primary Background 0", "White");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e) {

            Form CropToolWindow = new CropTool(SelectedUserImage, dropUsers.SelectedItem.ToString());
            CropToolWindow.ShowDialog();

            panelAvatar.Refresh();

        }
        private void btnSave_Click(object sender, EventArgs e) {
            try {
                MagickImage avatar = Users.UsersDict[dropUsers.SelectedItem.ToString()].Avatar;
                avatar.Format = MagickFormat.Png;

                IMagickGeometry g = new MagickGeometry(440, 440);
                g.FillArea = true;

                string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                Directory.CreateDirectory(tempDirectory);

                avatar.Resize(g);
                avatar.Crop(440, 440, Gravity.Center);
                avatar.Write(tempDirectory+"/avatar.png");
                avatar.Format = MagickFormat.Dds;
                avatar.Write(tempDirectory+"/avatar440.dds");
                avatar.Resize(260, 260);
                avatar.Write(tempDirectory+"/avatar260.dds");
                avatar.Resize(128, 128);
                avatar.Write(tempDirectory+"/avatar128.dds");
                avatar.Resize(64, 64);
                avatar.Write(tempDirectory+"/avatar64.dds");

                try { client.DeleteFile(string.Format("/system_data/priv/cache/profile/{0}/avatar.png", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper())); } catch { }
                try { client.DeleteFile(string.Format("/system_data/priv/cache/profile/{0}/avatar440.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper())); } catch { }
                try { client.DeleteFile(string.Format("/system_data/priv/cache/profile/{0}/avatar260.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper())); } catch { }
                try { client.DeleteFile(string.Format("/system_data/priv/cache/profile/{0}/avatar128.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper())); } catch { }
                try { client.DeleteFile(string.Format("/system_data/priv/cache/profile/{0}/avatar64.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper())); } catch { }


                client.UploadFile(tempDirectory+"/avatar.png", string.Format("/system_data/priv/cache/profile/{0}/avatar.png", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()), FtpRemoteExists.NoCheck);
                client.UploadFile(tempDirectory+"/avatar440.dds", string.Format("/system_data/priv/cache/profile/{0}/avatar440.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()), FtpRemoteExists.NoCheck);
                client.UploadFile(tempDirectory+"/avatar260.dds", string.Format("/system_data/priv/cache/profile/{0}/avatar260.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()), FtpRemoteExists.NoCheck);
                client.UploadFile(tempDirectory+"/avatar128.dds", string.Format("/system_data/priv/cache/profile/{0}/avatar128.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()), FtpRemoteExists.NoCheck);
                client.UploadFile(tempDirectory+"/avatar64.dds", string.Format("/system_data/priv/cache/profile/{0}/avatar64.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()), FtpRemoteExists.NoCheck);


                File.Delete(tempDirectory+"/avatar.png");
                File.Delete(tempDirectory+"/avatar440.dds");
                File.Delete(tempDirectory+"/avatar260.dds");
                File.Delete(tempDirectory+"/avatar128.dds");
                File.Delete(tempDirectory+"/avatar64.dds");



            } catch {
                XtraMessageBox.Show("Unknown issue while converting and uploading images.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Users.UsersDict[dropUsers.SelectedItem.ToString()].Changed = false;
            btnSave.Enabled = false;
            btnSave.Appearance.BackColor = currentSkin.SvgPalettes["DefaultSkinPalette"].
                GetColorByStyleName("Edit Background 0", "White");

        }



        private void dropUsers_SelectedIndexChanged(object sender, EventArgs e) {
            this.panelAvatar.Refresh();
            if (Users.UsersDict[dropUsers.SelectedItem.ToString()].Avatar == null) {
                btnGrabber.Enabled = false;
            } else {
                btnGrabber.Enabled = true;
            }

            if (Users.UsersDict[dropUsers.SelectedItem.ToString()].Changed == true) {
                btnSave.Enabled = true;
                btnSave.Appearance.BackColor = currentSkin.SvgPalettes["DefaultSkinPalette"].
                    GetColorByStyleName("Primary Background 0", "White");
            } else {
                btnSave.Enabled = false;
                btnSave.Appearance.BackColor = currentSkin.SvgPalettes["DefaultSkinPalette"].
                    GetColorByStyleName("Edit Background 0", "White");
            }



        }

        private void btnTrash_Click(object sender, EventArgs e) {
            if (XtraMessageBox.Show("This will delete all avatar cache files associated with this user. Are you sure?",
                "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                client.SetWorkingDirectory(string.Format("/system_data/priv/cache/profile/{0}", ("0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper())));
                try { client.DeleteFile("avatar.png"); } catch { }
                try { client.DeleteFile("avatar440.dds"); } catch { }
                try { client.DeleteFile("avatar260.dds"); } catch { }
                try { client.DeleteFile("avatar128.dds"); } catch { }
                try { client.DeleteFile("avatar64.dds"); } catch { }
                Users.UsersDict[dropUsers.SelectedItem.ToString()].Avatar = null;
                btnSave.Enabled = false;
                btnSave.Appearance.BackColor = currentSkin.SvgPalettes["DefaultSkinPalette"].
                    GetColorByStyleName("Edit Background 0", "White");

                //
                this.panelAvatar.Refresh();
            }
        }

        private void btnGrabber_Click(object sender, EventArgs e) {
            var dir = dropUsers.SelectedItem.ToString().Replace("\0", string.Empty);
            try {
                foreach (char c in System.IO.Path.GetInvalidFileNameChars()) {
                    dir = dir.Replace(c, '_');
                }
                Directory.CreateDirectory(dir);
                client.DownloadFile(dir + "/avatar.png", string.Format("/system_data/priv/cache/profile/{0}/avatar.png", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()));
                client.DownloadFile(dir + "/avatar440.dds", string.Format("/system_data/priv/cache/profile/{0}/avatar440.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()));
                client.DownloadFile(dir + "/avatar260.dds", string.Format("/system_data/priv/cache/profile/{0}/avatar260.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()));
                client.DownloadFile(dir + "/avatar128.dds", string.Format("/system_data/priv/cache/profile/{0}/avatar128.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()));
                client.DownloadFile(dir + "/avatar64.dds", string.Format("/system_data/priv/cache/profile/{0}/avatar64.dds", "0x" + Users.UsersDict[dropUsers.SelectedItem.ToString()].ID.ToUpper()));
            }
            catch {
                XtraMessageBox.Show("Unknown issue while downloading images.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            XtraMessageBox.Show(string.Format("The user's images have been downloaded and saved inside the \"{0}\" folder.", dir),
            "Avatar Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        }
    }
}