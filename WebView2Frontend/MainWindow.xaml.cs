using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace WebView2Frontend
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StartBackend();

            InitWebView();
        }

        private void StartBackend()
        {
            var startInfo = new ProcessStartInfo();
#if DEBUG
            startInfo.FileName = @"C:\Work\Project\WebView2Backend\backend\backend.exe";
#else
            startInfo.FileName = @".\backend\backend.exe";
#endif
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;

            var backendP = Process.Start(startInfo);
            backendP.OutputDataReceived += (send, e) =>
            {

            };
            backendP.BeginOutputReadLine();
        }

        async void InitWebView()
        {
            await webView.EnsureCoreWebView2Async();
            webView.CoreWebView2.AddHostObjectToScript("webviewex", new WebViewEx());
#if DEBUG
            webView.CoreWebView2.SetVirtualHostNameToFolderMapping("frontend.com", @"C:\Work\Project\WebView2Backend\frontend", Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);
#else
            webView.CoreWebView2.SetVirtualHostNameToFolderMapping("frontend.com", "./frontend", Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);
#endif
            webView.Source = new Uri("http://frontend.com/index.html");
        }
    }
}
