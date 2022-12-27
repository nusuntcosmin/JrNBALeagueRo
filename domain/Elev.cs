using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    public class Elev : Entity<Guid>
    {
        private String nume;
        private String scoala;

        public String Nume
        {
            get { return nume; }
            set { nume = value; }
        }

        public String Scoala
        {
            get { return scoala; }
            set { scoala = value; }
        }

        public Elev(string nume, string scoala)
        {
            this.nume = nume;
            this.scoala = scoala;
            base.ID = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            return obj is Elev elev &&
                   ID.Equals(elev.ID);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
