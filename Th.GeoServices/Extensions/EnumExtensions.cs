using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Th.GeoServices.Extensions {
    public static class EnumExtensions {

        public static string DisplayName(this Enum value) {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DisplayAttribute), false);
            return attributes.Length == 0
                ? value.ToString()
                : ((DisplayAttribute)attributes[0]).Name;
        }
    }
}
