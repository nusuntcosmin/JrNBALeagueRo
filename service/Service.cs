using JrNBALeagueRo.domain;
using JrNBALeagueRo.repository;
using JrNBALeagueRo.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.service
{
    public class Service
    {
        private IRepository<Guid, Jucator> repoJucatori;
        private IRepository<Guid, JucatorActiv> repoJucatoriActivi;
        private IRepository<Guid, Meci> repoMeciuri;
        private IRepository<Guid, Echipa> repoEchipa;
        private IRepository<Guid, Elev> repoElevi;

        private IValidator<Elev> validatorElev;
        private IValidator<JucatorActiv> validatorJucatorActiv;
        private IValidator<Echipa> validatorEchipa;

 
        public Service(IRepository<Guid, Jucator> repoJucatori, IRepository<Guid, JucatorActiv> repoJucatoriActivi, IRepository<Guid, Meci> repoMeciuri, IRepository<Guid, Echipa> repoEchipa, IRepository<Guid, Elev> repoElevi)
        {
            this.repoJucatori = repoJucatori;
            this.repoJucatoriActivi = repoJucatoriActivi;
            this.repoMeciuri = repoMeciuri;
            this.repoEchipa = repoEchipa;
            this.repoElevi = repoElevi;

            this.validatorJucatorActiv = new JucatorActivValidator();
            this.validatorElev = new ElevValidator();
            this.validatorEchipa = new EchipaValidator();
        }

        public void saveElev(String nume, String scoala)
        {
            Elev elevDeSalvat = new Elev(nume, scoala);
            validatorElev.validate(elevDeSalvat);
            repoElevi.save(elevDeSalvat);
        }
        
        public IEnumerable<Echipa> getEchipe()
        {
            return repoEchipa.findAll();
        }


        public IEnumerable<Jucator> getJucatoriForEchipa(Guid echipaGuid)
        {
            return from jucator in getJucatori()
                   where jucator.Echipa.ID.Equals(echipaGuid)
                   select jucator;
        }
        public IEnumerable<Jucator> getJucatori()
        {
            return repoJucatori.findAll();
        }

        public IEnumerable<Elev> getElevi()
        {
            return repoElevi.findAll();
        }

        public Meci findMeciById(Guid idMeci)
        {
            return repoMeciuri.findOne(idMeci);
        }

        public Echipa findEchipaByName(String numeEchipa)
        {
            List<Echipa> listaEchipe = (List<Echipa>) repoEchipa.findAll();
            IEnumerable<Echipa> foundEchipe = from echipa in listaEchipe
                              where echipa.Nume.Equals(numeEchipa)
                              select echipa;

            return foundEchipe.ElementAt(0);

        }
        public void saveJucator(String numeEchipa,Elev elev)
        { 
            Jucator jucatorDeSalvat = new Jucator(findEchipaByName(numeEchipa), elev);
            repoJucatori.save(jucatorDeSalvat);
        }

        public void saveEchipa(String numeEchipa)
        {
            Echipa e = new Echipa(numeEchipa);
            repoEchipa.save(e);
        }

        public void saveMeci(Echipa echipaGazda,Echipa echipaOaspete, DateTime dataMeci)
        {   
            repoMeciuri.save(new Meci(echipaOaspete,echipaGazda,dataMeci));
        }

        public IEnumerable<Meci> getMeciuri()
        {
            return repoMeciuri.findAll();
        }

        
        public void saveJucatorActiv(Meci meci, int nrPuncteInscrise,String tip, Jucator j)
        {
            if(!j.Echipa.ID.Equals(meci.GetEchipaOaspete.ID) && !j.Echipa.ID.Equals(meci.getEchipaGazda.ID))
            {
                throw new exceptions.ValidationException("Jucatorul nu joaca pentru niciuna din echipele meciului");
            }
            else
            {
                JucatorActiv jActiv = new JucatorActiv(meci.ID, nrPuncteInscrise, tip, j);
                repoJucatoriActivi.save(jActiv);
            }
        }







    }
}
