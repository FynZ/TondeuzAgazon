using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TondeuzAgazon.Parser
{
    public interface IParser<T>
    {
        T Parse(FileInfo fi);
    }

    public interface IParse<T, U>
    {
        T Parse(U input);
    }

    public static class EnumHelper
    {
        public static T GetPreviousValue<T>(T obj)
        {
            List<T> values = Enum.GetValues(typeof(T)).Cast<T>().ToList();;

            if (values[0].Equals(obj))
            {
                return values[^1];
            }

            var index = values.IndexOf(obj);

            return values[--index];
        }
    }

}
