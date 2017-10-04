using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Easycomtec.Lib.Extension
{
    public static class StringExtension
    {
        public static bool IsEmail(this string value) => Regex.IsMatch(
            value ?? string.Empty,
            @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            RegexOptions.IgnoreCase
        );
        

        public static bool IsPhoneNumber(this string value)
        {
            if (value == null)
                return false;
            var newValue = value.Replace('(', '\0').Replace(')', '\0').Replace('-', '\0').Replace(' ', '\0');
            return newValue.Where(w => w != '\0').All(a => char.IsNumber(a));
        }
    }
}
