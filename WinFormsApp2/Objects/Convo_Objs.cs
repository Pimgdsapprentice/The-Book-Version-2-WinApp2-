using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Objects
{
    public class Convo_Objs : S_TypeEntity
    {
        public Convo_Objs(string id, string b_type, string name) : base(id, name, b_type) { }

        public Dictionary<string, Convo_Objs> Convo_Obj_Dict = new Dictionary<string, Convo_Objs>() {

            {"1.1a",  new Convo_Objs("1.1a", "Greeting", "Hello" )},

        };
    }

    public class Convo_Generics : Entity
    {
        public Convo_Generics(int id, string name) : base(id, name) { }

        public Dictionary<string, Convo_Generics> Convo_Genj_Dict = new Dictionary<string, Convo_Generics>() {

            {"1.1a",  new Convo_Generics(1, "Greeting")},

        };

    }

    public class Convo_Topic_Element: ProcessEntity
    {
        public Convo_Topic_Element(int id, string name, Array array) : base(id, name, array) { }
    }


}
