using System.ComponentModel;
using System.Threading.Tasks;

namespace RubiksCubeMover.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class EnumHelper
    {
        public static string GetDescription<TEnum>(TEnum value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var enumMember = value.GetType().GetMember(value.ToString()).First();

            var attribute = (DescriptionAttribute)enumMember.GetCustomAttributes(false).First();

            return attribute.Description;
        }
    }
}
