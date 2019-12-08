using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Library
{
    class IniFiles
    {
        string Path;    //Имя файла
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);    // Подключаем kernel32.dll и описываем его функцию WritePrivateProfilesString

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath); // Еще раз подключаем kernel32.dll, а теперь описываем функцию GetPrivateProfileString

        public IniFiles(string IniPath = null)  // С помощью конструктора записываем пусть до файла и его имя
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public void Write(string Key, string Value, string Section = null)  //Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }
    }
}
