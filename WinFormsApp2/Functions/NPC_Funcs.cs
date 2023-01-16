using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Objects;

namespace WinFormsApp2.Functions
{
    public class NPC_Funcs
    {
        public Dictionary<int, NPC> npcDict = new Dictionary<int, NPC>();

        public void add_To_N_Dict(NPC npc)
        {
            npcDict.Add(npc.ID, npc);
        }

    }
}
