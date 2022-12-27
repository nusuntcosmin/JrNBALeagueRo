using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    public class Echipa : Entity<Guid>
    {
        private String nume;
        
        public String Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
            }

        }   
        public Echipa(String nume) 
        {
            base.ID = Guid.NewGuid();
            this.nume = nume;
        }

        public override bool Equals(object? obj)
        {
            return obj is Echipa echipa &&
                   ID.Equals(echipa.ID);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
