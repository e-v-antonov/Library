using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IniFiles
{
    public class WorkIniFiles
    {
        static string Path;    //Имя файла
        static string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);    // Подключаем kernel32.dll и описываем его функцию WritePrivateProfilesString

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath); // Еще раз подключаем kernel32.dll, а теперь описываем функцию GetPrivateProfileString

        public static void IniFiles(string IniPath = null)  // С помощью конструктора записываем пусть до файла и его имя
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public static string Read(string Key, string Section = null)   //Читаем ini-файл и возвращаем значение указного ключа из заданной секции
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public static void Write(string Key, string Value, string Section = null)  //Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public static void DeleteKey(string Key, string Section = null)    //Удаляем ключ из выбранной секции.
        {
            Write(Key, null, Section ?? EXE);
        }

        public static void DeleteSection(string Section = null)    //Удаляем выбранную секцию
        {
            Write(null, null, Section ?? EXE);
        }

        public static bool KeyExists(string Key, string Section = null)    //Проверяем, есть ли такой ключ, в этой секции
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
