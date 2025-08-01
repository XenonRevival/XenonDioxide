using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectXenonLauncher
{
    public partial class AdminForm: Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "rojectxeono 2025 open sesame.$%^#!")
            {
                GlobalVars.IsAdmin = true;
                pictureBox1.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "client11", "content", "textures") + @"\neutralemoji.png");
            }
        }
    }
}
