using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalnia_gier.Models;

namespace wypozyczalniaGierTest
{
    class MemoryGryRepository : ICrudGraRepository
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

        public Gra Find(int id)
        {
            if (this.grySlownik.TryGetValue(id, out var gra))
                return gra;
            return null;
        }

        public Gra Delete(int id)
        {
            if (this.grySlownik.TryGetValue(id, out var gra))
            {
                this.grySlownik.Remove(id);
                return gra;
            }

            throw new InvalidOperationException("Gra nie istnieje");
        }

        public Gra Update(Gra gra)
        {
            this.grySlownik[gra.Id] = gra;
            return gra;
        }

        public IList<Gra> FindAll()
        {
            return this.grySlownik.Values.ToList();
        }
    }
}
