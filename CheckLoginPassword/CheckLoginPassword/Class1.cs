using System.Text.RegularExpressions;

namespace CheckLoginPassword
{
    public class CheckClass
    {
        private static string constraintUpperLatin = @"[A-Z]";
        private static string constraintLowerLatin = @"[a-z]";
        private static string constraintUpperCyrill = @"[А-Я]";
        private static string constraintLowerCyrill = @"[а-я]";
        private static string constraintNumber = @"[0-9]";
        private static string constraintSymbol = @"[%!@#$%^&*()?№]";
        private static string constraintLoginCyrill = @"[аА-яЯ]";

        public static bool CheckPasswordUpperLatin(string checkString)  //проверка наличия заглавных английских букв
        {
            return Regex.IsMatch(checkString, constraintUpperLatin, RegexOptions.None) ? true : false;
        }

        public static bool CheckPasswordLowerLatin(string checkString)  //проверка наличия прописных английских букв
        {
            return Regex.IsMatch(checkString, constraintLowerLatin, RegexOptions.None) ? true : false;
        }

        public static bool CheckPasswordUpperCyrill(string checkString) //проверка наличия заглавных русских букв
        {
            return Regex.IsMatch(checkString, constraintUpperCyrill, RegexOptions.None) ? true : false;
        }

        public static bool CheckPasswordLowerCyrill(string checkString) //проверка наличия прописных русских букв
        {
            return Regex.IsMatch(checkString, constraintLowerCyrill, RegexOptions.None) ? true : false;
        }

        public static bool CheckPasswordNumber(string checkString)  //проверка наличия цифр
        {
            return Regex.IsMatch(checkString, constraintNumber, RegexOptions.None) ? true : false;
        }

        public static bool CheckPasswordSymbol(string checkString)   //проверка наличия символов
        {
            return Regex.IsMatch(checkString, constraintSymbol, RegexOptions.None) ? true : false;
        }

        public static bool CheckLoginCyrill(string checkString) //проверка наличия русских букв
        {
            return Regex.IsMatch(checkString, constraintLoginCyrill, RegexOptions.None) ? false : true;
        }
    }
}
