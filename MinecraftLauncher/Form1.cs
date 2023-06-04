using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Threading;
using System.Diagnostics;


namespace MinecraftLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public static string versiyon;
        private void path()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);

            foreach (var item in launcher.GetAllVersions())
            {
                comboBox1.Items.Add(item.Name);
            }

        }
        private void Launch()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.GetOfflineSession(textBox1.Text),
                ServerIp = "mega.rasbyte.net:25698",

            };
            versiyon = comboBox1.SelectedItem.ToString();
            var process = launcher.CreateProcess(versiyon, launchOption);

            process.Start();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            path();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Thread thread = new Thread(() => Launch());
            thread.IsBackground = true;
            thread.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=xAX1U4lqqbQ");
        }
    }
}
