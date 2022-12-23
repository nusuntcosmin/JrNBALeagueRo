using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    internal class Meci : Entity<Guid>
    {
        private Echipa echipaOaspete;
        private Echipa echipaGazda;
        private DateTime dataMeci;

        public Meci(Echipa echipaOaspete, Echipa echipaGazda, DateTime dataMeci)
        {
            this.echipaOaspete = echipaOaspete;
            this.echipaGazda = echipaGazda;
            this.dataMeci = dataMeci;
            base.ID = Guid.NewGuid();
        }

        public Echipa getEchipaGazda
        {
            get { return echipaGazda; }
        }

        public Echipa GetEchipaOaspete
        {
            get { return echipaOaspete; }
        }

        public DateTime getDataMeci
        {
            get { return dataMeci; }
        }

    }
}
