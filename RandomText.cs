using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_MongoDB
{
    public static class RandomText
    {
        private static readonly string[] _nameArray = new string[] { "Eva", "Ivo", "Kim", "John" };
        private static readonly string[] _lastNameArray = new string[] { "White", "Carrey", "Smith", "Wick" };
        private static readonly Func<string[], string> RandomString = (array) => array[new Random().Next(0, array.Count())];

        public static Func<string> Name = () => RandomString(_nameArray);
        public static Func<string> LastName = () => RandomString(_lastNameArray);

    }
}
