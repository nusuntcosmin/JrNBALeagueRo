using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    internal class Echipa : Entity<Guid>
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
    }
}
