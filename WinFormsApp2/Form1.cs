using System;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using WinFormsApp2.Functions;
using WinFormsApp2.Objects;

using System.Collections;
using System.Reflection;
using System.Xml.Linq;
using WinFormsApp2.Special_Objects;
using static WinFormsApp2.Objects.Convo_Objs;

namespace WinFormsApp2
{


    public partial class Form1 : Form
    {
        public PestRemover pestR = new PestRemover();

        private NPC nPC;
        private Memory mem;
        private Trait trait;
        private NPC_Funcs nFuncs = new NPC_Funcs();

        private Convo_Objs con_obj = new Convo_Objs();

        private RNG_Obj rNG_Obj = new RNG_Obj();
        
        private Random rand;

        public static float[] mapESet = new float[] { 10, 0.0036F, 1.5F, 2400, 10 };
        public static float[] mapMSet = new float[] { 10, 0.005F, 1.7F, 0, 100 };
        public static float[] mapEVal = new float[] { 0.4F, 0.42F, 0.8F, 0.7F, 0.6F };
        public static float[] mapMVal = new float[] { 0.1F, 0.2F, 0.5F, 0.33F, 0.66F, 0.16F, 0.50F, 0.83F, 0.16F, 0.33F, 0.66F };
        public Form1()
        {
            InitializeComponent();
            nPC = new NPC(1, "Jane");
            nFuncs.add_To_N_Dict(nPC);

            trait = new Trait(1, "Beauty");
            nFuncs.npcDict[1].Trait_Dict.Add(trait.ID, trait);

            nPC = new NPC(2, "Joe");
            nFuncs.add_To_N_Dict(nPC);

            /*
            ConversationController con_obj2 = new ConversationController();
            con_obj2.targetid = 2;
            //con_obj.genericDict.Add(1, 1);
            nFuncs.npcDict[1].NPC_ConvoDict.Add(2, con_obj2);
            */

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

        private void outter(object outStr)
        {
            richTextBox1.AppendText(outStr.ToString() + Environment.NewLine);
        }

        /*
        public string test(int npc1, int npc2)
        {
            if (nFuncs.npcDict[npc1].NPC_ConvoDict[npc2].genericDict.ContainsKey(1) == false
                || nFuncs.npcDict[npc1].NPC_ConvoDict[npc2].genericDict[1] == 0)
            {
                nFuncs.npcDict[npc1].NPC_ConvoDict[2].genericDict[1] = 1;
                return "Greeting";
            }
            else
            {
                return "Topic";
            }

        }
        */




        private void button1_Click(object sender, EventArgs e)
        {

            outter(encouter(1, 2));
            outter(enc_Obs(2, 1));
            int npc2 = 2;
            ///outter(test(1, 2));
            rand = new Random();

            RNG_Pair rngPai = rNG_Obj.RNG_Pair_ListLoad(con_obj.CGD_ID_Out(), con_obj.CGD_Weight_Out());
            outter(con_obj.Convo_Gen_Dict[rNG_Obj.RNG_Pair_Out(rngPai).ToString()].Name);
            
            //RNG_Pair_Populate(con_obj.Convo_Gen_Dict);




            /*
            rng_pair = new RNG_Pair();
            rng_pair.ids = new List<int> { };
            rng_pair.weights = new List<int> {};
            rng_pair.weights_Maxium = new List<int> { };


            foreach (KeyValuePair<string, Convo_Generics> i in con_obj.Convo_Gen_Dict)
            {
                rng_pair.ids.Add(i.Value.ID);
                rng_pair.weights.Add(i.Value.Weight);
                rng_pair.total += i.Value.Weight;
                rng_pair.weights_Maxium.Add(rng_pair.total);
            }

            int rand_Num = rand.Next(rng_pair.total + 1);
            int indexw = 0;
            outter(rand_Num);

            foreach (int i in rng_pair.weights_Maxium)
            { 
                indexw++;
                if (i >= rand_Num)
                {
                    outter(indexw);
                    break;
                }
            }



            /*
            foreach (KeyValuePair<string, Convo_Generics> i in Convo_Generics.Convo_Gen_Dict)
            {

            }
            */

            //con_obj.genericDict.Add(1,1);






            /*
            con_T_E = new Convo_Topic_Element(1, "Greeting", 0);
            outter(pestR.Debug_Out_SimpleObj(con_T_E));
            */
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                richTextBox1.Show();
            }
            else
            {
                richTextBox1.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int mapX_Max = 1300;
            int mapY_Max = 700;
            Size size = new Size(mapX_Max, mapY_Max);
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            for (int x = 0; x < mapX_Max; x++)
            {
                for (int y = 0; y < mapY_Max; y++)
                {
                    float CalcE = (float)(MapEngine.SimplexNoise.GenerateO(x, y, (int)mapESet[0], mapESet[1], mapESet[2], mapESet[3], mapESet[4]));
                    float CalcM = (float)(MapEngine.SimplexNoise.GenerateO(x, y, (int)mapMSet[0], mapMSet[1], mapMSet[2], mapMSet[3], mapMSet[4]));

                    // shading
                    if (CalcE < mapEVal[0])
                    {
                        //Ocean
                        bmp.SetPixel(x, y, Color.FromArgb(67, 67, 122));
                    }
                    else if (CalcE < mapEVal[1])
                    {
                        //Beach
                        bmp.SetPixel(x, y, Color.FromArgb(160, 145, 119));
                    }
                    else if (CalcE > mapEVal[2])
                    {
                        if (CalcM < mapMVal[0])
                        {
                            //return SCORCHED;
                            bmp.SetPixel(x, y, Color.FromArgb(85, 85, 85));
                        }
                        else if (CalcM < mapMVal[1])
                        {
                            //return BARE;
                            bmp.SetPixel(x, y, Color.FromArgb(136, 136, 136));
                        }
                        else if (CalcM < mapMVal[2])
                        {
                            //return TUNDRA;
                            bmp.SetPixel(x, y, Color.FromArgb(188, 188, 171));
                        }
                        else
                        {
                            //return SNOW;
                            bmp.SetPixel(x, y, Color.FromArgb(221, 221, 228));
                        }
                    }
                    else if (CalcE > mapEVal[3])
                    {
                        if (CalcM < mapMVal[3])
                        {
                            //return TEMPERATE_DESERT;
                            bmp.SetPixel(x, y, Color.FromArgb(201, 210, 155));
                        }
                        else if (CalcM < mapMVal[4])
                        {
                            // RETURN SHRUBLAND;
                            bmp.SetPixel(x, y, Color.FromArgb(136, 153, 119));
                        }
                        else
                        {
                            // RETURN TAIGA;
                            bmp.SetPixel(x, y, Color.FromArgb(153, 171, 119));
                        }
                    }
                    else if (CalcE > mapEVal[4])
                    {
                        if (CalcM < mapMVal[5])
                        {
                            // RETURN TEMPERATE_DESERT;
                            bmp.SetPixel(x, y, Color.FromArgb(201, 210, 155));
                        }
                        else if (CalcM < mapMVal[6])
                        {
                            // RETURN GRASSLAND;
                            bmp.SetPixel(x, y, Color.FromArgb(136, 171, 86));
                        }
                        else if (CalcM < mapMVal[7])
                        {
                            // RETURN TEMPERATE_DECIDUOUS_FOREST;
                            bmp.SetPixel(x, y, Color.FromArgb(103, 147, 89));
                        }
                        else
                        {
                            // RETURN TEMPERATE_RAIN_FOREST;
                            //bmp.SetPixel(x, y, Color.FromArgb(201, 210, 155);
                            bmp.SetPixel(x, y, Color.FromArgb(67, 136, 85));
                        }
                    }
                    else
                    {
                        if (CalcM < mapMVal[8])
                        {
                            // RETURN SUBTROPICAL_DESERT;
                            //bmp.SetPixel(x, y, Color.FromArgb(136, 171, 86);
                            bmp.SetPixel(x, y, Color.FromArgb(210, 186, 139));
                        }
                        else if (CalcM < mapMVal[9])
                        {
                            // RETURN GRASSLAND;
                            bmp.SetPixel(x, y, Color.FromArgb(136, 171, 85));
                        }

                        else if (CalcM < mapMVal[10])
                        {
                            // RETURN TROPICAL_SEASONAL_FOREST;
                            bmp.SetPixel(x, y, Color.FromArgb(86, 153, 68));
                        }
                        else
                        {
                            // RETURN TROPICAL_RAIN_FOREST;
                            bmp.SetPixel(x, y, Color.FromArgb(51, 119, 65));
                        }
                    }

                }
            }

            pictureBox1.ClientSize = size;
            pictureBox1.Image = (Image)bmp;

        }
    }
}