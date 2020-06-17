using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using RunescapeAPI;

namespace API_Testing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var item = Beastiary.GetBeastData(99);
            //foreach (var result in item)
            //{
            //    var output = DisplayObjectInfo(result);

            Console.WriteLine(DisplayObjectInfo(item));
            //}
        }

        public static string DisplayObjectInfo(object o)
        {
            StringBuilder sb = new StringBuilder();

            // Include the type of the object
            System.Type type = o.GetType();
            sb.Append("Type: " + type.Name);

            // Include information for each Field
            sb.Append("\r\n\r\nFields:");
            System.Reflection.FieldInfo[] fi = type.GetFields();
            if (fi.Length > 0)
            {
                foreach (FieldInfo f in fi)
                {
                    sb.Append("\r\n " + f.Name + " = " + f.GetValue(o));
                }
            }
            else
                sb.Append("\r\n None");

            // Include information for each Property
            sb.Append("\r\n\r\nProperties:");
            System.Reflection.PropertyInfo[] pi = type.GetProperties();
            if (pi.Length > 0)
            {
                foreach (PropertyInfo p in pi)
                {
                    sb.Append("\r\n " + p.ToString() + " = " +
                              p.GetValue(o, null));
                }
            }
            else
                sb.Append("\r\n None");

            return sb.ToString();
        }
    }
}