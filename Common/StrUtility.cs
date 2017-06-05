using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class StrUtility
    {
        /// <summary>
        /// Method to calculating the length of a string
        /// </summary>
        /// <param name="text">User's Input</param>
        /// <param name="maxLength">Maximum length of input</param>
        /// <returns>The cleaned up version of the input</returns>
        public static int StrLength(string text)
        {
            return text.Length;
        }
    }
}
