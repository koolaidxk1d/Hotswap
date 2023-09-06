using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS5_Profile_Modder {
    public class PS5User {
        public readonly string ID;
        public int[] TrophieCounts = new int[4];
        public MagickImage Avatar;
        public bool Changed = false;

        public PS5User(string id, MagickImage avatar) {
            this.ID = id;
            this.Avatar = avatar;


        }
    }
}
