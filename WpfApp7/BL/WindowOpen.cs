using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp7.BL
{
    class WindowOpen
    {
        public static void OpenNewWindow(Window currentWindow, Window windowToOpem)
        {
            windowToOpem.Show();
            currentWindow.Close();
        }
    }
}
