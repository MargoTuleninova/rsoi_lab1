using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace rsoi_lab1
{
    public partial class AutForm : Form
    {
        private bool _isInitialized = false;
        public AutForm(string uri)
        {
            InitializeComponent();
            webBrowser.Navigate(uri);
        //    webBrowser.Navigate("https://github.com/logout");
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (_isInitialized)
            {
                Program.Code = Regex.Match(webBrowser.Url.AbsoluteUri, "(?<=code=)[\\da-z]+").ToString();
                Close();
            }
            _isInitialized = true;
        }
    }
}
