using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace WebView2Frontend
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class WebViewEx
    {

        public string ReadHTML(string path)
        {
            return FileReadAllText($"./frontend/{path}");
        }

        public string FileReadAllText(string path)
        {
            if(!File.Exists(path))
            {
                return "";
            }
            return File.ReadAllText(path);
        }
    }
}
