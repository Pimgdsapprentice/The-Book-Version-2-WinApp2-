using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Objects
{
    public class Memory
    {
        public int ID { get; set; }
        public Dictionary<int, string> MemDict = new Dictionary<int, string>();

        public Memory(int id)
        {
            ID = id;
        }
    }
}
