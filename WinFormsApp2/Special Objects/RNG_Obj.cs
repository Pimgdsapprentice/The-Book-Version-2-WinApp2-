using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static WinFormsApp2.Objects.Convo_Objs;

namespace WinFormsApp2.Special_Objects
{
    public  class RNG_Obj
    {
        Random rand = new Random();
        public RNG_Pair RNG_Pair_ListLoad(List<int> ids, List<int> weights)
        {
            int total = 0;
            List<int> wei_max = new List<int>();
            for (int i = 0; i < ids.Count; i++)
            {
                total += weights[i];
                wei_max.Add(total);
            }
            return new RNG_Pair(ids, weights, total, wei_max);
        }

        public int RNG_Pair_Out(RNG_Pair rNG_Pair)
        {
            int i = rand.Next(rNG_Pair.Total);
            for (int j = 0; j < rNG_Pair.Weights_Maxium.Count; j++)
            {
                if (i < rNG_Pair.Weights_Maxium[j])
                {
                    return rNG_Pair.Ids[j];
                }
            }
            return 999;
        }
    }
    public class RNG_Pair
    {
        public List<int> Ids = new List<int>();
        public List<int> Weights = new List<int>();
        public int Total = 0;
        public List<int> Weights_Maxium = new List<int>();
        public RNG_Pair(List<int> ids, List<int> weights, int total, List<int> weights_Maxium) { 
            Weights = weights;
            Total = total;
            Weights_Maxium= weights_Maxium;
            Ids = ids;
        }
        

    }     

}
