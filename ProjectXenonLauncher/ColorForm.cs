using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectXenonLauncher
{
    public partial class ColorForm: Form
    {
        public string colID;
        public Color colRGB;

        public ColorForm(string partedit)
        {
            InitializeComponent();
            var locale = Thread.CurrentThread.CurrentUICulture.ToString();
            if (locale == "en-US")
            {
                Text = "Pick the color of your " + partedit;
            }
        }

        private void ColorForm_Load(object sender, EventArgs e)
        {
            
        }

        public void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            colID = btn.Text;
            colRGB = btn.BackColor;
        }
    }
}
