using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Objects;

namespace WinFormsApp2.Functions
{


    public class Convo_Eng
    {
        public string Con_Debug_CTE(Convo_Topic_Element cte)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(cte))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(cte);
                Console.WriteLine("{0}={1}", name, value);
            }
            return "a";
        }

    }
}



