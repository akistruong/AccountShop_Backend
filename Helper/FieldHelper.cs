using System.Collections.Generic;
using System.Reflection;

namespace AccountShop.Helper
{
    public class FieldHelper
    {
        public static Object GetFieldInfo(HashSet<String> keys, Object obj)
        {
            var dic = new Dictionary<string,Object>();
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach(var key in keys)
            {
                foreach (PropertyInfo property in properties)
                {
                    if (property.Name == key)
                    {
                        dic.Add(property.Name, property.GetValue(obj, null));
                    }
                }
            }
          
            return dic;

        }
    }
}
