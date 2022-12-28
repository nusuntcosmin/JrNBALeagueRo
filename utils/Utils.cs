using JrNBALeagueRo.domain;
using JrNBALeagueRo.repository.database;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace JrNBALeagueRo.utils
{
    internal class Utils
    {
        
        public static bool existaEchipa(String numeEchipa)
        {
            string[] echipe =
            {
                "Atlanta Hawks",
                "Boston Celtics",
                "Brooklyn Nets",
                "Charlotte Hornets",
                "Chicago Bulls",
                "Cleveland Cavaliers",
                "Dallas Mavericks",
                "Denver Nuggets",
                "Detroit Pistons",
                "Golden State Warriors",
                "Houston Rockets",
                "Indiana Pacers",
                "Los Angeles Clippers",
                "Los Angeles Lakers",
                "Memphis Grizzlies",
                "Miami Heat",
                "Milwaukee Bucks",
                "Minnesota Timberwolves",
                "New Orleans Pelicans",
                "New York Knicks",
                "Oklahoma City Thunder",
                "Orlando Magic",
                "Philadelphia 76ers",
                "Phoenix Suns",
                "Portland Trail Blazers",
                "Sacramento Kings",
                "San Antonio Spurs",
                "Toronto Raptors",
                "Utah Jazz",
                "Washington Wizards"
           };

            if (Array.Exists(echipe, echipa => echipa.Equals(numeEchipa)))
            {
                return true;
            }

            return false;
        }
        // adaugare date
        public static void addEchipe(ref service.Service srv)
        {
            string[] echipe =
           {
                "Atlanta Hawks",
                "Boston Celtics",
                "Brooklyn Nets",
                "Charlotte Hornets",
                "Chicago Bulls",
                "Cleveland Cavaliers",
                "Dallas Mavericks",
                "Denver Nuggets",
                "Detroit Pistons",
                "Golden State Warriors",
                "Houston Rockets",
                "Indiana Pacers",
                "Los Angeles Clippers",
                "Los Angeles Lakers",
                "Memphis Grizzlies",
                "Miami Heat",
                "Milwaukee Bucks",
                "Minnesota Timberwolves",
                "New Orleans Pelicans",
                "New York Knicks",
                "Oklahoma City Thunder",
                "Orlando Magic",
                "Philadelphia 76ers",
                "Phoenix Suns",
                "Portland Trail Blazers",
                "Sacramento Kings",
                "San Antonio Spurs",
                "Toronto Raptors",
                "Utah Jazz",
                "Washington Wizards"
           };

            foreach (string echipa in echipe)
            {
                srv.saveEchipa(echipa);
            }
        }
        public static void addElevi(ref service.Service srv)
        {
            string[] numeElevi = File.ReadAllLines(@"C:\Users\Cosmin Popa\Desktop\cursuri si altele\anul 2\sem 1\Metode avansate de programare\Lab\JrNBALeagueRo\JrNBALeagueRo\elevi.txt");
            string[] numeScoli = File.ReadAllLines(@"C:\Users\Cosmin Popa\Desktop\cursuri si altele\anul 2\sem 1\Metode avansate de programare\Lab\JrNBALeagueRo\JrNBALeagueRo\scoli.txt");

            int j = 0;
            for (int i = 0; i < 600; ++i)
            {
                srv.saveElev(numeElevi[i], numeScoli[j]);
                if ((i + 1) % 20 == 0)
                    j++;

            }



        }
        public static void addJucatori(ref service.Service srv)
        {
            List<Echipa> listaEchipe = (List<Echipa>)srv.getEchipe();
            List<Elev> listaElevi = (List<Elev>)srv.getElevi();
            for (int i = 0; i < 600; ++i)
            {
                Echipa e = listaEchipe[(i) / 20];
                Elev elev = listaElevi[i];


                if (i % 20 < 15)
                {
                    srv.saveJucator(e.Nume, elev);
                }

            }
        }
        public static void addMeciuri(ref service.Service srv) {
            List<Echipa> listaEchipe = (List<Echipa>) srv.getEchipe();

            for(int i = 0;i<15;++i)
            {
                Echipa echipaGazda = listaEchipe[i];
                Echipa echipaOaspete = listaEchipe[29 - i];
                Random rndNumberGenerator = new Random();
                int month = rndNumberGenerator.Next() % 12 + 1;
                int day = rndNumberGenerator.Next() % 28 + 1;
                DateTime dataMeci = new DateTime(2022,month,day);


                srv.saveMeci(echipaGazda, echipaOaspete, dataMeci);
                
            }
        }
        public static void addJucatoriActivi(ref service.Service srv)
        {
            List<Meci> listaMeci = (List<Meci>) srv.getMeciuri();

            foreach(Meci meci in listaMeci)
            {
                List<Jucator> listaJucatori = (List<Jucator>) srv.getJucatori();
                IEnumerable<Jucator> IEnumJucatoriEchipaGazda = from jucator in listaJucatori
                                                                where jucator.Echipa.ID == meci.getEchipaGazda.ID
                                                                select jucator;

                IEnumerable<Jucator> IEnumJucatoriEchipaOaspete = from jucator in listaJucatori
                                                                where jucator.Echipa.ID == meci.GetEchipaOaspete.ID
                                                                select jucator;

                List<Jucator> listaJucatoriEchipaGazda = IEnumJucatoriEchipaGazda.ToList();
                List<Jucator> listaJucatoriEchipaOaspete = IEnumJucatoriEchipaOaspete.ToList();
                Random rndNumberGenerator = new Random();
                for (int i = 0; i<7;++i)
                {
                    Jucator jucator = listaJucatoriEchipaGazda[i];
                    
                    int scor = rndNumberGenerator.Next() % 30 + 1;
                    String tip = "Participant";
                    srv.saveJucatorActiv(meci, scor, tip, jucator);

                }

                for(int i = 7;i<10;++i)
                {
                    Jucator jucator = listaJucatoriEchipaGazda[i];

                    String tip = "Rezerva";
                    srv.saveJucatorActiv(meci, 0, tip, jucator);
                }

                for (int i = 0; i < 7; ++i)
                {
                    Jucator jucator = listaJucatoriEchipaOaspete[i];

                    int scor = rndNumberGenerator.Next() % 30 + 1;
                    String tip = "Participant";
                    srv.saveJucatorActiv(meci, scor, tip, jucator);

                }

                for (int i = 7; i < 10; ++i)
                {
                    Jucator jucator = listaJucatoriEchipaOaspete[i];

                    String tip = "Rezerva";
                    srv.saveJucatorActiv(meci, 0, tip, jucator);
                }
            }
        }
    }
}
