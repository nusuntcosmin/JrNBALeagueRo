using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    public class Jucator : Elev
    {

        private Echipa echipa;
        public Echipa Echipa
        {
            get
            {
                return echipa;
            }

            set
            {
                echipa = value;
            }
        }

        public Jucator(Echipa echipa, Elev elev) : base(elev.Nume,elev.Scoala)
        {   
            this.echipa = echipa;
            base.ID = elev.ID;
        }


    }
}
