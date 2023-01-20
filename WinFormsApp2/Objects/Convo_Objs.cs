using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Special_Objects;

namespace WinFormsApp2.Objects
{
    public class Convo_Objs
    {
        RNG_Obj rng_Obj = new RNG_Obj();
        public int targetid { get; set; }
        public Dictionary<int, int> genericDict = new Dictionary<int, int>();

        public class Convo_Objs2 : S_TypeEntity
        {
            public Convo_Objs2(string id, string b_type, string name) : base(id, name, b_type) { }

            public Dictionary<string, Convo_Objs2> Convo_Obj_Dict = new Dictionary<string, Convo_Objs2>() {

            {"1.1a",  new Convo_Objs2("1.1a", "Greeting", "Hello" )},

        };
        }

        public class Convo_Generics : WeightedEntity
        {
            public Convo_Generics(int id, string name, int weight) : base(id, name, weight) { }
        };

        public Dictionary<string, Convo_Generics> Convo_Gen_Dict = new Dictionary<string, Convo_Generics>() {
            {"1",  new Convo_Generics(1, "Greeting", 100)},
            {"2",  new Convo_Generics(2, "Topic", 100)},
        };

        public List<int> CGD_ID_Out()
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<string, Convo_Generics> i in Convo_Gen_Dict)
            {
                list.Add(i.Value.ID);
            }
            return list;
        }
        
        public List<int> CGD_Weight_Out()
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<string, Convo_Generics> i in Convo_Gen_Dict)
            {
                list.Add(i.Value.Weight);
            }
            return list;
        }

        /*
        public class Convo_Topic_Element : ProcessEntity
        {
            public Convo_Topic_Element(int id, string name, int entityProcessCurrent) : base(id, name, entityProcessCurrent) { }
        }
        */
    }
}
