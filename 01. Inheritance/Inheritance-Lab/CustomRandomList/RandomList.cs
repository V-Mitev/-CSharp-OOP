using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random rnd = new Random();

        public string RandomString()
        {
            if (Count == 0)
            {
                return null;
            }

            var index = rnd.Next(0, this.Count);
            var element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
