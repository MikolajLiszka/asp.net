using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalnia_gier.Models;

namespace wypozyczalniaGierTest
{
    class MemoryGryRepository : ICrudGryRepository
    {
        private Dictionary<int, Gra> grySlownik = new Dictionary<int, Gra>();
        private int index = 1;

        private int nextIndex()
        {
            return index++;
        }

        public Gra Add(Gra gra)
        {
            gra.Id = nextIndex();
            grySlownik.Add(gra.Id, gra);
            return gra;
        }


    }
}
