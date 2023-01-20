using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Functions
{
    public class PestRemover
    {
        public string Debug_Out_SimpleObj(object obj)
        {
            string output = string.Empty;
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                output = output + ("{" + name + "}={" + value + "}" + "\n");
            }
            return output;
        }
    }
}
