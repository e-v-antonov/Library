using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var regWord = Registry.ClassesRoot.OpenSubKey("Word.Application"))
            {
                if (regWord == null)
                {
                    MessageBox.Show(MessageUser.ErrorOffice, MessageUser.TitleLibrary, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
            }

            if (!File.Exists(Application.StartupPath.ToString() + "\\CheckLoginPassword.dll"))
            {
                MessageBox.Show(MessageUser.ErrorDLL, MessageUser.TitleLibrary, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            if (!CheckAvailabilityOffice.CheckOffice())
            {
                MessageBox.Show(MessageUser.ErrorOffice, MessageUser.TitleLibrary, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }           
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScreenSaver());
        }        
    }
}
