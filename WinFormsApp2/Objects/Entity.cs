using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Entity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Entity(int id, string name) {
            ID = id;
            Name = name;
        }

    }

    public class TypeEntity : Entity
    {
        public String B_Type { get; set; }
        public TypeEntity(int id, string name, string b_Type) : base(id, name) { 
            B_Type = b_Type;

        }
    }

    public class ProcessEntity : Entity
    {
        public Array EntityProcess { get; set; }
        public ProcessEntity(int id, string name, Array entityProcess) : base(id, name)
        {
            EntityProcess = entityProcess;

        }
    }


    public class S_Entity
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public S_Entity(string id, string name)
        {
            ID = id;
            Name = name;
        }

    }

    public class S_TypeEntity : S_Entity
    {
        public String B_Type { get; set; }
        public S_TypeEntity(string id, string name, string b_Type) : base(id, name)
        {
            B_Type = b_Type;

        }
    }





}
