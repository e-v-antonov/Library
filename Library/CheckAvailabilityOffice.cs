using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace Library
{
    class CheckAvailabilityOffice
    {
        private const string RegKey = @"Software\Microsoft\Windows\CurrentVersion\App Paths";

        private static string GetComponentPath(string component)
        {
            string toReturn = string.Empty;
            string key = string.Empty;

            switch (component)
            {
                case "Word":
                    key = "winword.exe";
                    break;
                case "Excel":
                    key = "excel.exe";
                    break;
            }

            RegistryKey mainKey = Registry.CurrentUser;
            try
            {
                mainKey = mainKey.OpenSubKey(RegKey + "\\" + key, false);
                if (mainKey != null)
                {
                    toReturn = mainKey.GetValue(string.Empty).ToString();
                }
            }
            catch
            { }

            mainKey = Registry.LocalMachine;
            if (string.IsNullOrEmpty(toReturn))
            {
                try
                {
                    mainKey = mainKey.OpenSubKey(RegKey + "\\" + key, false);
                    if (mainKey != null)
                    {
                        toReturn = mainKey.GetValue(string.Empty).ToString();
                    }
                }
                catch
                {
                }
            }

            if (mainKey != null)
                mainKey.Close();

            return toReturn;
        }

        private static int GetMajorVersion(string path)
        {
            int toReturn = 0;
            if (File.Exists(path))
            {
                try
                {
                    FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(path);
                    toReturn = fileVersion.FileMajorPart;
                }
                catch
                { }
            }

            return toReturn;

        }

        public static bool CheckOffice()
        {
            string wordPath = GetComponentPath("Word");
            string excelPath = GetComponentPath("Excel");

            if ((GetMajorVersion(wordPath) >= 14) && (GetMajorVersion(excelPath) >= 14))
                return true;
            else
                return false;
        }
    }
}

