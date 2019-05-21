using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XboxTurnOn.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = true;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(label1, "IP adress or hostname of Xbox one device");

            toolTip2.ToolTipIcon = ToolTipIcon.Info;
            toolTip2.IsBalloon = true;
            toolTip2.ShowAlways = true;

            toolTip2.SetToolTip(label2, "You can find in Settings->All Settings->Console Info & Updates->Console ID");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string host = "";
            try
            {
                var hosts = Dns.GetHostEntry(textBox1.Text);
                host = hosts.AddressList[0].ToString();
            }
            catch
            {
                host = textBox1.Text;
            }

            try
            {
                Switcher.StartClient(IPAddress.Parse(host), textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
