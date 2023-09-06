using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using FluentFTP;
using ImageMagick;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PS5_Profile_Modder {
    public partial class Connect : DevExpress.XtraEditors.XtraForm {

        FtpClient client;


        public Connect() {
            InitializeComponent();
            DevExpress.XtraEditors.WindowsFormsSettings.AllowRoundedWindowCorners = DevExpress.Utils.DefaultBoolean.True;
            if (IsDarkMode())
                this.LookAndFeel.SetSkinStyle(SkinStyle.WXI, SkinSvgPalette.WXI.Darkness);
            else
                this.LookAndFeel.SetSkinStyle(SkinStyle.WXI, SkinSvgPalette.WXI.Clearness);

            if (!Connect.IsDarkMode()) { IconOptions.Image = PS5_Profile_Modder.Properties.Resources.other; }

            Skin currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);
            SkinElement element = currentSkin[CommonSkins.SkinButton];
            btnConnect.Appearance.BackColor = currentSkin.SvgPalettes["DefaultSkinPalette"].GetColorByStyleName("Primary Background 0", "White");
        }


        public static bool IsDarkMode() {
            string keyPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            string valueName = "AppsUseLightTheme";
            object testValue = Registry.GetValue(keyPath, valueName, null);
            switch (testValue) {
                case 0:
                    return true;
                case 1:
                    return false;
                default:
                    return false;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e) {
            submitInput();
        }
        private void inputIP_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                submitInput();
            }
        }
        private void inputPort_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                submitInput();
            }
        }


        private string InputIsValid() {
            if (!IPAddress.TryParse(inputIP.Text, out _)) {
                return "invalid_ip";
            } else if (!(int.TryParse(inputPort.Text, out int result) && result < 65536 && result > 0)) {
                return "invalid_port";
            }

            return "OK";
        }

        private void submitInput() {

            switch (InputIsValid()) {
                case "invalid_ip":
                    XtraMessageBox.Show("Enter a valid IP address.", "Invalid IP", MessageBoxButtons.OK);
                    break;
                case "invalid_port":
                    XtraMessageBox.Show("Enter a valid port between 1 and 65536.", "Invalid Port", MessageBoxButtons.OK);
                    break;
                case "OK":
                RETRY:
                    this.client = new FtpClient(inputIP.Text, int.Parse(inputPort.Text));
                    try {
                        client.AutoConnect();

                        //Console.WriteLine("Success");
                        //this.Close();
                    } catch {
                        if (XtraMessageBox.Show("Unable to connect. Is FTP running on the console?", "Connection Failed",
                           MessageBoxButtons.RetryCancel) == DialogResult.Retry) {
                            goto RETRY;
                        }
                    }

                    FtpGetUsers(inputIP.Text, inputPort.Text);
                    break;
            }
        }

        private void Connect_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void FtpGetUsers(string ip, string port) {
            client.SetWorkingDirectory("/user/home");
            FtpListItem[] UserListItems = client.GetListing();
            byte[] NameBuffer = new byte[17];
            byte[] AvatarBuffer = new byte[100000000];


            foreach (FtpListItem item in UserListItems) {
                Array.Clear(NameBuffer, 0, NameBuffer.Length);
                Array.Clear(AvatarBuffer, 0, AvatarBuffer.Length);
                MagickImage Avatar = null;

                //download name
                client.DownloadBytes(out NameBuffer, string.Format("/user/home/{0}/username.dat", item.Name));
                //download avatar if possible
                try {
                    client.DownloadBytes(out AvatarBuffer, string.Format("/system_data/priv/cache/profile/{0}/avatar.png", ("0x" + item.Name.ToUpper())));
                    Avatar = new MagickImage(AvatarBuffer);
                } catch {
                    Console.WriteLine("Could not load the image or the image did not exist.");
                    AvatarBuffer = new byte[100000000];
                }

                Users.UsersDict.Add(System.Text.Encoding.Default.GetString(NameBuffer), new PS5User(item.Name, Avatar));
            }

            Editor editorWindow = new Editor(client);
            editorWindow.ShowDialog();
            this.Close();


        }

        private void hyperlinkLabelControl1_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e) {
            System.Diagnostics.Process.Start("https://" + e.Link);

        }
    }
}
