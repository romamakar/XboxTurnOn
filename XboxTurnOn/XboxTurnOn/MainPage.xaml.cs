using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XboxTurnOn
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            labelIp.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelIpClicked()),
            });
            labelLive.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelLiveClicked()),
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string host = "";
            try
            {
                var hosts = Dns.GetHostEntry(editIp.Text);
                host = hosts.AddressList[0].ToString();
            }
            catch
            {
                host = editIp.Text;
            }

            try
            {
                Switcher.StartClient(IPAddress.Parse(host), editLive.Text);
            }
            catch (Exception ex)
            {
                DisplayAlert("IP", ex.Message, "OK");
            }
        }

        private void OnLabelIpClicked()
        {
            DisplayAlert("IP", "Ip adress of Xbox one device.", "OK");
        }
        private void OnLabelLiveClicked()
        {
            DisplayAlert("Xbox Live Id", "You can find in Settings -> All Settings -> Console Info & Updates -> Console ID", "OK");
        }
    }
}
