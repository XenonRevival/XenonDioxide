using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Diagnostics;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Xml;
using System.Globalization;
using System.Threading;
using System.Configuration;
using ProjectXenonLauncher.Properties;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Media;

namespace ProjectXenonLauncher
{
	public partial class MainForm : Form
	{
		private static readonly string[] DynamicMessages = new string[]
{
	"put cool text here",
	"we put the no into xenon",
	"do it before you think it",
	"Xoject prenon",
	"not affiliated with IUPAC",
	"take deep breaths",
	"whats that? you're gonna buy doritos instead?",
	"cry about it",
	"mom I'm on Xenon!",
	"Xerox it",
	"stdout -- Today at 6:50 PM: you make the Xenon",
	"bytecode exploit free!",
	"remember to claim your free 10 tix and 60 yuan",
	"you wouldn't steal a roblox 2016 source code leak",
	"open sauce",
	"awesome sauce",
	"TEH EPIK DUCK IS COMING!!!",
	"this splash text changed twice and you will never see it again >:)",
	"also check out sonic unleashed recompiled!",
	"don't crack your photoshop, kids!",
	"linux roblox when",
	"still waiting for 2040 revival",
	"remember to stay hydrated",
	"my humor is old - sharkle on a discord server about early 2010s roblox",
	"i like trains",
	"public static void main(string[] args)",
	"made with c#",
	"made in china",
	"getting banned by donald trump",
	"USAID cut our funding",
	"while True do print('hello world') end;",
	"intel inside",
	"RTX on",
	"powered by the Source Engine",
	"better than a cybertruck!",
	"gex",
	"only stupid drama here",
	"also check out inserttexthereblox!",
	"psst, hey kid... here... take some xenon",
	"fuck cryptos. ill only invest in future. xenon tix",
	"i hope you have a nightmare and shit the bed",
	"FLINT AND STEEEL",
	"project xenon before gta 6 real?!",
	"racing gta 6 to release since 2025",
	"54th on the periodic table!",
	"definetly approved by roblox"
};
		private static readonly string[] DynamicMessagesRU = new string[]
		{
			"удалю сервер если не получим 100 членов",
			"ксоект пренон",
			"да ты чо... БЛЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯ ой, мама пришла",
			"stdout -- Сегодня в 18:30: ты делаеш Ксенон",
			"№54ый элемент периодической таблици"
		};
		private static readonly string[] DynamicMessagesES = new string[]
		{
            "Borraremos el server si no llegamos a los 100 miembros",
            "¿Cliente del 2025 para cuando?",
            "¡Numero 54 en la tabla periódica!",
            "Apio",
            "Definitivamente aprobado por Roblox",
            "sudo rm -rf /*",
            "Nunca jueges al Projecto Xenón a las 3 de la mañana",
            "Como están muchahos",
            "Momazos Diego",
            "Viva España",
			"Viva latam"
        };
		private static readonly string[] DynamicMessagesESAR = new string[]
		{
            "Borraremos el server si no llegamos a 100 miembros >:(",
            "pa cuando el proyecto xenón para mi samsung?",
            "LAS ISLAS MALVINAS SON ARGENTINAS!",
            "Larga vida a Apio, España, Latinoamerica y ARGENTINA!!!"
        };
		private static readonly string[] DynamicMessagesIT = new string[] {
            "Cospargere di Xenon gli spaghetti!",
            "Unisciti alla mafia Xenon!"
        };

		private void LoadRandomAd()
		{
			string adsFolder = Path.Combine(Environment.CurrentDirectory, "Ads");

			if (Directory.Exists(adsFolder))
			{
				string[] adFiles = Directory.GetFiles(adsFolder, "*.*", SearchOption.TopDirectoryOnly)
					.Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
								   file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
								   file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
					.ToArray();

				if (adFiles.Length > 0)
				{
					Random random = new Random();
					string randomAd = adFiles[random.Next(adFiles.Length)];

					pictureBoxAd.Image = Image.FromFile(randomAd);
				}
				else
				{
					MessageBox.Show("No ad images found in the Ads folder.", "No Ads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				MessageBox.Show("Ads folder not found. Create a folder named 'Ads' in the launcher directory and add images.", "Missing Folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void SetDynamicMessage()
		{
            Random random = new Random();
			if (Thread.CurrentThread.CurrentUICulture.ToString() == "en-US")
			{
				int index = random.Next(DynamicMessages.Length);
				string message = DynamicMessages[index];
				labelUnderLogo.Text = message;
			}
			else if (Thread.CurrentThread.CurrentUICulture.ToString() == "ru")
			{
				int index = random.Next(DynamicMessagesRU.Length);
				string message = DynamicMessagesRU[index];
				labelUnderLogo.Text = message;
			}
			else if (Thread.CurrentThread.CurrentUICulture.ToString() == "es")
			{
				int index = random.Next(DynamicMessagesES.Length);
				string message = DynamicMessagesES[index];
				labelUnderLogo.Text = message;
			}
			else if (Thread.CurrentThread.CurrentUICulture.ToString() == "es-AR")
			{
				int index = random.Next(DynamicMessagesESAR.Length);
				string message = DynamicMessagesESAR[index];
				labelUnderLogo.Text = message;
			}
            else if (Thread.CurrentThread.CurrentUICulture.ToString() == "it")
            {
                int index = random.Next(DynamicMessagesIT.Length);
                string message = DynamicMessagesIT[index];
                labelUnderLogo.Text = message;
            }
        }
		public MainForm()
		{
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
			InitializeComponent();
            comboBox1.Text = "English";
            comboBox2.Text = "Oct 2010";
            this.textBoxUsername.TextChanged += new System.EventHandler(this.TextBoxUsernameTextChanged);
			this.textBoxUserID.TextChanged += new System.EventHandler(this.TextBoxUserIDTextChanged);
			this.checkBox1.CheckStateChanged += new System.EventHandler(this.KeepLauncherOpenChecked);

            var settings = new Properties.Settings();
            textBoxUsername.Text = settings.Username;
			GlobalVars.PlayerName = settings.Username;
            textBoxUserID.Text = settings.ID;
			GlobalVars.UserID = Convert.ToInt32(settings.ID);
            checkBox1.Checked = settings.KeepLauncherOpen;
			GlobalVars.CloseOnLaunch = settings.KeepLauncherOpen;
			GlobalVars.Hat1ID = settings.Hat1;
            GlobalVars.Hat2ID = settings.Hat2;
            GlobalVars.Hat3ID = settings.Hat3;
			GlobalVars.ShirtID = settings.Shirt;
			GlobalVars.PantsID = settings.Pants;
			GlobalVars.TshirtID = settings.Tshirt;
			GlobalVars.FaceID = settings.Face;

            // code modified from the DiscordRPC.NET thingamagig github because im too lazy to learn another API

            DiscordRpcClient client;

			// start client communication with discord app id
			client = new DiscordRpcClient("134783759130270517" + "2");

			// log shite
			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

			client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};

			// Send requests to discord rich presence api
			client.Initialize();

			// Set the rich presence
			client.SetPresence(new RichPresence()
			{
				Details = "XeO2 Release 1.0",
				State = "In the launcher",
				Assets = new Assets()
				{
					LargeImageKey = "release",
					LargeImageText = "Project Xenon"
				}
			});
		}

		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"]) {
                this.listBox1.Items.Clear();
                var settings = new Properties.Settings();
                GlobalVars.PlayerName = settings.Username;
                textBoxUserID.Text = settings.ID;
                GlobalVars.UserID = Convert.ToInt32(settings.ID);
                checkBox1.Checked = settings.KeepLauncherOpen;
                GlobalVars.CloseOnLaunch = settings.KeepLauncherOpen;
            }
			if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
			{
                string mapdir = Path.Combine(Environment.CurrentDirectory, "maps");
				DirectoryInfo dinfo = new DirectoryInfo(mapdir);
				FileInfo[] Files = dinfo.GetFiles("*.rbxl");
				foreach( FileInfo file in Files )
				{
					this.listBox1.Items.Add(file.Name);
				}
				this.listBox1.SelectedIndex = 0;
			}
			else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
			{
                this.listBox1.Items.Clear();
                var cc = new ProjectXenonLauncher.Properties.Settings(); // so the compiler doesnt shit itself, for info look at CS0120

				button9.BackColor = cc.HeadRGB;
				button6.BackColor = cc.TorsoRGB;
				button4.BackColor = cc.LeftArmRGB;
				button5.BackColor = cc.RightArmRGB;
				button7.BackColor = cc.LeftLegRGB;
				button8.BackColor = cc.RightLegRGB;

				if (cc.Hat1 != "0")
				{
					string currim = cc.Hat1;
					pictureBox5.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "hats") + @"\" + currim.Remove(currim.Length - 5) + ".png");
				}

                if (cc.Hat2 != "0")
                {
                    string currim = cc.Hat2;
                    pictureBox9.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "hats") + @"\" + currim.Remove(currim.Length - 5) + ".png");
                }

                if (cc.Hat3 != "0")
                {
                    string currim = cc.Hat3;
                    pictureBox10.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "hats") + @"\" + currim.Remove(currim.Length - 5) + ".png");
                }

                if (cc.Shirt != "0")
                {
                    string currim = cc.Shirt;
                    pictureBox16.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "shirts") + @"\" + currim.Remove(currim.Length - 5) + ".png");
                }

                if (cc.Pants != "0")
                {
                    string currim = cc.Pants;
                    pictureBox17.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "pants") + @"\" + currim.Remove(currim.Length - 5) + ".png");
                }

                if (cc.Tshirt != "0")
                {
                    string currim = cc.Tshirt;
                    pictureBox18.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "tshirts") + @"\" + currim.Remove(currim.Length - 5) + ".png");
                }

                if (cc.Face != "0")
                {
                    string currim = cc.Face;
                    pictureBox19.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "faces") + @"\" + currim.Remove(currim.Length - 5) + ".png");
                }

                string hatdir = Path.Combine(Environment.CurrentDirectory, "items", "hats");
				DirectoryInfo dinfo = new DirectoryInfo(hatdir);
                FileInfo[] Files = dinfo.GetFiles("*.rbxm");
                foreach (FileInfo file in Files)
                {
                    this.listBox2.Items.Add(file.Name);
                    this.listBox3.Items.Add(file.Name);
                    this.listBox4.Items.Add(file.Name);
                }

				string shirtdir = Path.Combine(Environment.CurrentDirectory, "items", "shirts");
				DirectoryInfo sdinfo = new DirectoryInfo(shirtdir);
				FileInfo[] SFiles = sdinfo.GetFiles("*.rbxm");
				foreach (FileInfo file in SFiles)
				{
					this.listBox5.Items.Add(file.Name);
				}

                string pantdir = Path.Combine(Environment.CurrentDirectory, "items", "pants");
                DirectoryInfo pdinfo = new DirectoryInfo(pantdir);
                FileInfo[] PFiles = pdinfo.GetFiles("*.rbxm");
                foreach (FileInfo file in PFiles)
                {
                    this.listBox6.Items.Add(file.Name);
                }

                string tshirtdir = Path.Combine(Environment.CurrentDirectory, "items", "tshirts");
                DirectoryInfo tdinfo = new DirectoryInfo(tshirtdir);
                FileInfo[] TFiles = tdinfo.GetFiles("*.rbxm");
                foreach (FileInfo file in TFiles)
                {
                    this.listBox7.Items.Add(file.Name);
                }

                string facedir = Path.Combine(Environment.CurrentDirectory, "items", "faces");
                DirectoryInfo fdinfo = new DirectoryInfo(facedir);
                FileInfo[] FFiles = fdinfo.GetFiles("*.rbxm");
                foreach (FileInfo file in FFiles)
                {
                    this.listBox8.Items.Add(file.Name);
                }
            }
			else
			{
				this.listBox1.Items.Clear();
			}
            if (tabControl1.SelectedTab != tabControl1.TabPages["tabPage3"])
            {
                this.listBox2.Items.Clear();
                this.listBox3.Items.Clear();
                this.listBox4.Items.Clear();
                this.listBox5.Items.Clear();
				this.listBox6.Items.Clear();
                this.listBox7.Items.Clear();
            }
        }

		void TextBoxUsernameTextChanged(object sender, EventArgs e)
		{
			GlobalVars.PlayerName = textBoxUsername.Text;

			var settings = new ProjectXenonLauncher.Properties.Settings();
			settings.Username = textBoxUsername.Text;
			settings.Save();
		}


		void TextBoxUserIDTextChanged(object sender, EventArgs e)
		{
			var settings = new Properties.Settings();
			int userID;
			if (int.TryParse(textBoxUserID.Text, out userID) && userID >= 0)
			{
				GlobalVars.UserID = userID;
				settings.ID = textBoxUserID.Text;
				settings.Save();
			}
			else
			{
				MessageBox.Show("Please enter a valid numeric User ID.", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBoxUserID.Text = GlobalVars.UserID.ToString();
			}
		}

		void KeepLauncherOpenChecked(object sender, EventArgs e)
		{
			var settings = new Properties.Settings();

			settings.KeepLauncherOpen = checkBox1.Checked;
			settings.Save();
		}

		void Button1Click(object sender, EventArgs e)
		{
			string luafile = "rbxasset://scripts/CSMPFunctions.lua";
			string rbxexe;
			if (GlobalVars.NewStyle == false)
			{
				rbxexe = GlobalVars.ClientDir + @"\\RobloxApp.exe";
			}
			else
			{
				rbxexe = GlobalVars.ClientDir + @"\\RobloxPlayer.exe";
			}
			string quote = "\"";

			if  (!File.Exists(rbxexe))
			{
				MessageBox.Show("Your RobloxApp.exe is missing.", "ERR: Client missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var bc = new ProjectXenonLauncher.Properties.Settings();
			string endstring;
			if (GlobalVars.IsAdmin == false)
			{
				endstring = "');";
			}
			else
			{
				endstring = "','im a VIP shirt :coolemoji: let me in');";
			}

            string args = "-script " + quote + "dofile('" + luafile + "'); _G.CSConnect(" + GlobalVars.UserID + ",'" + GlobalVars.IP + "'," + GlobalVars.RobloxPort + ",'" + GlobalVars.PlayerName + "'," + "'" + GlobalVars.Hat1ID + "','" + GlobalVars.Hat2ID + "','" + GlobalVars.Hat3ID + "'," + bc.HeadID.ToString() + "," + bc.TorsoID.ToString() + "," + bc.LeftArmID.ToString() + "," + bc.RightArmID.ToString() + "," + bc.LeftLegID.ToString() + "," + bc.RightLegID.ToString() + ",'" + GlobalVars.ShirtID + "','" + GlobalVars.PantsID + "','" + GlobalVars.TshirtID + "','" + GlobalVars.FaceID + endstring + quote;
			

			// depressed shirt implementing sharklebanan here: i havent updated this comment in a few months sorry

            // RobloxApp.exe -script "dofile(CSMPFunctions.lua); _G.CSConnect(0,'127.0.0.1',53640,'xenon',0,0,0,[bodycolors]);"
            // how elaborate, Redknight...

            // lua def for reference
            // function CSConnect(UserID,ServerIP,ServerPort,PlayerName,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,Ticket)

            System.Diagnostics.Process.Start(rbxexe, args);
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}






		void Button2Click(object sender, EventArgs e)
		{
			string luafile = "rbxasset://scripts/CSMPFunctions.lua";
			string mapfile = "rbxasset://../../maps/" + GlobalVars.Map;
			string rbxexe = GlobalVars.ClientDir + @"\\RobloxApp.exe";
			string quote = "\"";

            if (!File.Exists(rbxexe))
            {
                MessageBox.Show("Attempt to run missing RobloxApp.exe... check integrity?", "ERR: Client missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string args = "-script " + quote + "game:Load('" + mapfile + "');" + "dofile('" + luafile + "'); _G.CSServer(" + GlobalVars.RobloxPort + "," + GlobalVars.MaxPlayers + ");" + quote;

			System.Diagnostics.Process.Start(rbxexe, args);
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}




		void TextBox2TextChanged(object sender, EventArgs e)
		{
			int port;
			if (int.TryParse(textBox2.Text, out port) && port > 0 && port <= 65535)
			{
				GlobalVars.RobloxPort = port; 
			}
			else
			{
				MessageBox.Show("Please enter a valid port number (1-65535).", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox2.Text = GlobalVars.RobloxPort.ToString(); 
			}
		}

		void MainFormLoad(object sender, EventArgs e)
		{
			GlobalVars.ClientDir = Path.Combine(Environment.CurrentDirectory, @"client10");
			GlobalVars.ClientDir = GlobalVars.ClientDir.Replace(@"\", @"\\");

			textBox1.Text = GlobalVars.IP; 
			textBox2.Text = GlobalVars.RobloxPort.ToString(); 
			textBoxUsername.Text = GlobalVars.PlayerName; 
			textBoxUserID.Text = GlobalVars.UserID.ToString(); 

			SetDynamicMessage();

			LoadRandomAd();
		}


		void TextBox1TextChanged(object sender, EventArgs e)
		{
			GlobalVars.IP = textBox1.Text;
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			GlobalVars.Map = listBox1.SelectedItem.ToString();
		}

		// sorry for doing it like this but i tried doing it the one function for everything way and it didnt work as intended

		void HatsSelectedIndexChanged(object sender, EventArgs e)
        {
            var currim = listBox2.SelectedItem.ToString();

            PictureBox picbox = pictureBox5;

            picbox.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "hats") + @"\" + currim.Remove(currim.Length - 5) + ".png");

			GlobalVars.Hat1ID = currim;

			var sets = new ProjectXenonLauncher.Properties.Settings();
			sets.Hat1 = currim;
			sets.Save();
        }
        void Hat2SelectedIndexChanged(object sender, EventArgs e)
        {
            var currim = listBox3.SelectedItem.ToString();

            PictureBox picbox = pictureBox9;

            picbox.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "hats") + @"\" + currim.Remove(currim.Length - 5) + ".png");
            GlobalVars.Hat2ID = currim;

            var sets = new ProjectXenonLauncher.Properties.Settings();
            sets.Hat2 = currim;
            sets.Save();
        }
        void Hat3SelectedIndexChanged(object sender, EventArgs e)
        {
            var currim = listBox4.SelectedItem.ToString();

            PictureBox picbox = pictureBox10;

            picbox.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "hats") + @"\" + currim.Remove(currim.Length - 5) + ".png");
            GlobalVars.Hat3ID = currim;

            var sets = new ProjectXenonLauncher.Properties.Settings();
            sets.Hat3 = currim;
            sets.Save();
        }
        void ShirtSelectedIndexChanged(object sender, EventArgs e)
        {
            var currim = listBox5.SelectedItem.ToString();

            PictureBox picbox = pictureBox16;

            picbox.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "shirts") + @"\" + currim.Remove(currim.Length - 5) + ".png");
            GlobalVars.ShirtID = currim;

            var sets = new ProjectXenonLauncher.Properties.Settings();
            sets.Shirt = currim;
            sets.Save();
        }
        void PantsSelectedIndexChanged(object sender, EventArgs e)
        {
            var currim = listBox6.SelectedItem.ToString();

            PictureBox picbox = pictureBox17;

            picbox.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "pants") + @"\" + currim.Remove(currim.Length - 5) + ".png");
            GlobalVars.PantsID = currim;

            var sets = new ProjectXenonLauncher.Properties.Settings();
            sets.Pants = currim;
            sets.Save();
        }
        void TshirtSelectedIndexChanged(object sender, EventArgs e)
        {
            var currim = listBox7.SelectedItem.ToString();

            PictureBox picbox = pictureBox18;

            picbox.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "tshirts") + @"\" + currim.Remove(currim.Length - 5) + ".png");
            GlobalVars.TshirtID = currim;

            var sets = new ProjectXenonLauncher.Properties.Settings();
            sets.Tshirt = currim;
            sets.Save();
        }

        void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				GlobalVars.CloseOnLaunch = true;
			}
			else if (checkBox1.Checked == false)
			{
				GlobalVars.CloseOnLaunch = false;
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			string rbxexe = GlobalVars.ClientDir + @"\\RobloxApp.exe";

            if (!File.Exists(rbxexe))
            {
                MessageBox.Show("Attempt to run missing RobloxApp.exe... check integrity?", "ERR: Client missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process.Start(rbxexe);
			if (GlobalVars.CloseOnLaunch == true)
			{
				this.Close();
			}
		}


		// ok vuddy wtf.
		// delete this shit in MainForm.cs [Design] IMMEDIATELY!
		private void pictureBox2_Click(object sender, EventArgs e)
		{

		}

		private void textBoxUserID_TextChanged(object sender, EventArgs e)
		{

		}

		private async void labelUnderLogo_Click(object sender, EventArgs e)
		{
			var currentstr = labelUnderLogo.Text;
			labelUnderLogo.Text = "boop :3";
            SoundPlayer buttonwav = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "client11", "content", "sounds") + @"\button.wav");
            buttonwav.Play();
            await Task.Delay(1000);
			labelUnderLogo.Text = currentstr;
		}

		// sorry for doing multiple events for this, but it's to differentiate the body parts
		// i could've linked the same event to multiple buttons but that would be too cool
		public void button4_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.Button parentbtn = (System.Windows.Forms.Button)sender;
			ColorForm colform = new ColorForm("left arm");
			colform.ShowDialog();
			if (colform.DialogResult == DialogResult.OK && colform != null)
			{
				var storeRGB = colform.colRGB; // for the compiler to shut the fuck up, going 3 layers deep is illegal for some reason
				parentbtn.BackColor = storeRGB;
				var settings = new ProjectXenonLauncher.Properties.Settings();

				settings.LeftArmRGB = storeRGB;
				settings.LeftArmID = Convert.ToInt32(colform.colID);

				settings.Save();
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.Button head = (System.Windows.Forms.Button)sender;
			var colform = new ColorForm("head");
			colform.ShowDialog();
			if (colform.DialogResult == DialogResult.OK)
			{
                if (colform.DialogResult == DialogResult.OK && colform != null)
                {
                    var storeRGB = colform.colRGB; // for the compiler to shut the fuck up, going 3 layers deep is illegal for some reason
                    head.BackColor = storeRGB;
                    var settings = new ProjectXenonLauncher.Properties.Settings();

                    settings.HeadRGB = storeRGB;
                    settings.HeadID = Convert.ToInt32(colform.colID);

                    settings.Save();
                }
            }
		}

		private void button5_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.Button rightarm = (System.Windows.Forms.Button)sender;
			var colform = new ColorForm("right arm");
			colform.ShowDialog();
			if (colform.DialogResult == DialogResult.OK)
			{
                if (colform.DialogResult == DialogResult.OK && colform != null)
                {
                    var storeRGB = colform.colRGB; // for the compiler to shut the fuck up, going 3 layers deep is illegal for some reason
                    rightarm.BackColor = storeRGB;
                    var settings = new ProjectXenonLauncher.Properties.Settings();

                    settings.RightArmRGB = storeRGB;
                    settings.RightArmID = Convert.ToInt32(colform.colID);

                    settings.Save();
                }
            }
		}

		private void button8_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.Button rightleg = (System.Windows.Forms.Button)sender;
			var colform = new ColorForm("right leg");
			colform.ShowDialog();
			if (colform.DialogResult == DialogResult.OK)
			{
                if (colform.DialogResult == DialogResult.OK && colform != null)
                {
                    var storeRGB = colform.colRGB; // for the compiler to shut the fuck up, going 3 layers deep is illegal for some reason
                    rightleg.BackColor = storeRGB;
                    var settings = new ProjectXenonLauncher.Properties.Settings();

                    settings.RightLegRGB = storeRGB;
                    settings.RightLegID = Convert.ToInt32(colform.colID);

                    settings.Save();
                }
            }
		}

		private void button7_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.Button leftleg = (System.Windows.Forms.Button)sender;
			var colform = new ColorForm("left leg");
			colform.ShowDialog();
			if (colform.DialogResult == DialogResult.OK)
			{
                if (colform.DialogResult == DialogResult.OK && colform != null)
                {
                    var storeRGB = colform.colRGB; // for the compiler to shut the fuck up, going 3 layers deep is illegal for some reason
                    leftleg.BackColor = storeRGB;
                    var settings = new ProjectXenonLauncher.Properties.Settings();

                    settings.LeftLegRGB = storeRGB;
                    settings.LeftLegID = Convert.ToInt32(colform.colID);

                    settings.Save();
                }
            }
		}

		private void button6_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.Button torso = (System.Windows.Forms.Button)sender;
			var colform = new ColorForm("torso");
			colform.ShowDialog();
			if (colform.DialogResult == DialogResult.OK)
			{
                if (colform.DialogResult == DialogResult.OK && colform != null)
                {
                    var storeRGB = colform.colRGB; // for the compiler to shut the fuck up, going 3 layers deep is illegal for some reason
                    torso.BackColor = storeRGB;
                    var settings = new ProjectXenonLauncher.Properties.Settings();

                    settings.TorsoRGB = storeRGB;
                    settings.TorsoID = Convert.ToInt32(colform.colID);

                    settings.Save();
                }
            }
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// hehe look mother im smart i made function for thing i reuse often...
            if (comboBox1.SelectedItem.ToString() == "English") { chnglang("en-US"); }
            else if (comboBox1.SelectedItem.ToString() == "Русский") { chnglang("ru"); }
            else if (comboBox1.SelectedItem.ToString() == "Español") { chnglang("es"); }
            else if (comboBox1.SelectedItem.ToString() == "Español (AR)") { chnglang("es-AR"); }
            else if (comboBox1.SelectedItem.ToString() == "Português (BR)") { chnglang("pt-BR"); }
            else if (comboBox1.SelectedItem.ToString() == "Italiano") { chnglang("it"); }
        }
		private void chnglang(string lang)
		{
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            this.Controls.Clear();
            this.InitializeComponent();
            SetDynamicMessage();
            LoadRandomAd();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (comboBox2.SelectedItem.ToString() == "Oct 2010") { chngclient(@"client10"); GlobalVars.NewStyle = false; }
			else if (comboBox2.SelectedItem.ToString() == "Jul 2011") { chngclient(@"client11"); GlobalVars.NewStyle = false; }
            else if (comboBox2.SelectedItem.ToString() == "Dec 2012") { chngclient(@"client12"); GlobalVars.NewStyle = true; } // variable was for 2013 before reality struck
        }

		private void chngclient(string clientfolder)
		{
            GlobalVars.ClientDir = Path.Combine(Environment.CurrentDirectory, clientfolder);
            GlobalVars.ClientDir = GlobalVars.ClientDir.Replace(@"\", @"\\");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
			var admForm = new AdminForm();
			admForm.ShowDialog();
        }

        private void PlayerLimitChanged(object sender, EventArgs e)
        {
			var updowner = (NumericUpDown)sender;
			GlobalVars.MaxPlayers = Convert.ToInt32(updowner.Value);
        }

        private void FaceSelectedIndexChanged(object sender, EventArgs e)
        {
            var currim = listBox8.SelectedItem.ToString();

            PictureBox picbox = pictureBox19;

            picbox.Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "items", "faces") + @"\" + currim.Remove(currim.Length - 5) + ".png");
            GlobalVars.FaceID = currim;

            var sets = new ProjectXenonLauncher.Properties.Settings();
            sets.Face = currim;
            sets.Save();
        }
    }
}
