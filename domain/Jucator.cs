using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    internal class Jucator : Elev
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

        public Jucator(Echipa echipa,String nume, String scoala) : base(nume,scoala)
        {
            this.echipa = echipa;
        }
    }
}
