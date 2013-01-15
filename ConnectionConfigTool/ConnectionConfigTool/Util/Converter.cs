using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace TopConfigTool.Util
{
    internal static class Converter
    {
        public static string TryToString(object value, string defValue = null)
        {
            if (value != null && value != DBNull.Value)
            {
                return value.ToString();
            }
            return defValue;
        }

        public static int ToInt(object value, int defaultValue = 0)
        {
            int result;
            if (null != value && int.TryParse(value.ToString(), out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static double ToDouble(object value, double defaultValue = 0)
        {
            double result;
            if (null != value && double.TryParse(value.ToString(), out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static SolidColorBrush ToSolidBrush(object value, SolidColorBrush defaultValue)
        {
            Color color;
            if (null != value &&
                (color = (Color)ColorConverter.ConvertFromString(value.ToString())) != null)
            {
                return new SolidColorBrush(color);
            }
            return defaultValue;
        }

        public static TResult ToEnum<TResult>(object o) where TResult : struct
        {
            if (null != o)
            {
                Type type = typeof(TResult);
                if (!type.IsEnum)
                {
                    throw new NotSupportedException("TResult must be an Enum.");
                }

                TResult result;
                if (Enum.TryParse(o.ToString(), out result))
                {
                    return (TResult)System.Convert.ChangeType(result, type);
                }
            }
            return default(TResult);
        }
    }
}
