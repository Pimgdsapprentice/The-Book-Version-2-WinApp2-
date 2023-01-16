using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using WinFormsApp2.Functions;
using WinFormsApp2.Objects;

namespace WinFormsApp2
{

    public partial class Form1 : Form
    {
        public PestRemover pestR;

        private NPC nPC;
        private Memory mem;
        private Trait trait;
        private NPC_Funcs nFuncs = new NPC_Funcs();

        private Convo_Eng con_eng;
        private Convo_Objs con_obj;
        public Convo_Topic_Element con_T_E;

        public Form1()
        {
            InitializeComponent();
            nPC = new NPC(1, "Jane");
            nFuncs.add_To_N_Dict(nPC);

            trait = new Trait(1, "Beauty");
            nFuncs.npcDict[1].Trait_Dict.Add(trait.ID, trait);

            nPC = new NPC(2, "Joe");
            nFuncs.add_To_N_Dict(nPC);
        }

        private string encouter(int npc1, int npc2)
        {
            if (nFuncs.npcDict[npc1].NPC_PhBk.ContainsKey(npc2) == true
                && nFuncs.npcDict[npc1].NPC_PhBk[npc2].MemDict.ContainsKey(1) == true
                && nFuncs.npcDict[npc1].NPC_PhBk[npc2].MemDict[1] == "know")
                {
                return nFuncs.npcDict[npc1].Name + " met " + nFuncs.npcDict[npc2].Name + " again.";
                }
            else
                {
                mem = new Memory(nFuncs.npcDict[npc2].ID);
                mem.MemDict.Add(1, "know");
                nFuncs.npcDict[1].NPC_PhBk.Add(nFuncs.npcDict[npc2].ID, mem);
                return nFuncs.npcDict[npc1].Name + " met " + nFuncs.npcDict[npc2].Name + " for the first time.";
            }
        }

        private string enc_Obs(int npc1, int npc2)
        {
            if (nFuncs.npcDict[npc2].Trait_Dict.Count >= 1)
            {
                return nFuncs.npcDict[npc2].Trait_Dict.First().Value.Name;
            }
            else
            {
                return nFuncs.npcDict[npc2].Name + " is basic asf";
            }
            
        }

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

        private void outter(string outStr)
        {
            richTextBox1.AppendText(outStr + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            outter(encouter(1, 2));
            outter(enc_Obs(2, 1));
            int npc2 = 2;

            con_T_E = new Convo_Topic_Element(1, "Greeting", new Array[1, 1]);


            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(con_T_E))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(con_T_E);
                outter("{" + name + "}={" + value + "}");
            }

            outter(Debug_Out_SimpleObj(con_T_E));
            outter(con_T_E.GetType().ToString());

            ///pestR.Debug_Out_SimpleObj(con_T_E);
            ///outter();



            ///for (int i = 0; i < Globals.debug_Dict.Count; i++) { }
            ///
        }
    }
}