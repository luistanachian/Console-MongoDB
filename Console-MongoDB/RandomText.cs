using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_MongoDB
{
    public static class RandomText
    {
        public static string RandomName()
        {
            var array = new string[] { "Kim", "Ivo", "Kendra", "Aron" };
            return RandomString(array);
        }
        public static string RandomSex()
        {
            var array = new string[] { "Male", "Female", "Other" };
            return RandomString(array);
        }

        private static string RandomString(string[] array)
        {
            return array[new Random().Next(0, array.Count())];
        }
    }
}
