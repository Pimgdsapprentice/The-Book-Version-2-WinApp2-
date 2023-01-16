using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Objects
{
    
    public class NPC : Entity
    {
        public Dictionary<int, Trait> Trait_Dict = new Dictionary<int, Trait>();
        public Dictionary<int, Memory> NPC_PhBk = new Dictionary<int, Memory>();

        public NPC(int id, string name) : base(id, name) { }

    }
}
