using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    internal class JucatorActiv : Jucator
    {
        private Guid idMeci;
        private int nrPuncteInscrise;
        private String tip;
           

        public JucatorActiv(Guid idMeci, int nrPuncteInscrise, string tip,Jucator jucator) : base(jucator.Echipa,jucator)
        {
            this.idMeci = idMeci;
            this.nrPuncteInscrise = nrPuncteInscrise;
            this.tip = tip;
            base.ID = jucator.ID;
            
        }

        public Guid getIdMeci
        {
            get { return idMeci; }
        }

        public int getNrPuncteInscrise
        {
            get { return nrPuncteInscrise;  }
        }

        public String Tip
        {
            get { return tip; }
            set { tip = value; }
        }
    }
}
