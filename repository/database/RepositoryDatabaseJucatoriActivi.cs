using JrNBALeagueRo.domain;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.repository.database
{
    internal class RepositoryDatabaseJucatoriActivi : IRepository<Guid, JucatorActiv>
    {

        private String userID;
        private String database;
        private String host;
        private String password;
        private int port;

        public RepositoryDatabaseJucatoriActivi(string userID, string database, string host, string password, int port)
        {
            this.userID = userID;
            this.database = database;
            this.host = host;
            this.password = password;
            this.port = port;
        }

        private NpgsqlConnection GetConnection()
        {
            NpgsqlConnectionStringBuilder stringBuilder = new NpgsqlConnectionStringBuilder();
            stringBuilder.Host = host;
            stringBuilder.Port = port;
            stringBuilder.Username = userID;
            stringBuilder.Password = password;
            stringBuilder.Database = database;


            NpgsqlConnection conn = new NpgsqlConnection(@stringBuilder.ToString());


            return conn;
        }
        public IEnumerable<JucatorActiv> findAll()
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();


                List<JucatorActiv> listaJucatorActiv = new List<JucatorActiv>();
                using (con)
                {
                    const string select_jucator_sql = "SELECT jucator.guid, \"jucatorActiv\".\"nrPuncteInscrise\", \"jucatorActiv\".\"guidMeci\", echipa.\"guidEchipa\", echipa.\"numeEchipa\", elev.nume, elev.scoala, \"jucatorActiv\".tip \nFROM jucator, echipa, elev, \"jucatorActiv\" \nWHERE jucator.guid = \"jucatorActiv\".guid AND jucator.guid = elev.guid AND echipa.\"guidEchipa\" = jucator.\"guidEchipa\";";
                    using var cmd = new NpgsqlCommand(select_jucator_sql, con);
                    using var rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        Elev elev = new Elev(rdr.GetString(5), rdr.GetString(6));
                        elev.ID = rdr.GetGuid(0);

                        Echipa echipa = new Echipa(rdr.GetString(4));
                        echipa.ID = rdr.GetGuid(3);


                        Jucator j = new Jucator(echipa, elev);

                        JucatorActiv jActiv = new JucatorActiv(rdr.GetGuid(2), rdr.GetInt32(1), rdr.GetString(7), j);
                        listaJucatorActiv.Add(jActiv);

                    }
                }
                return listaJucatorActiv;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public JucatorActiv findOne(Guid id)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    const string select_jucator_sql = "SELECT jucator.guid, \"jucatorActiv\".\"nrPuncteInscrise\", \"jucatorActiv\".\"guidMeci\", echipa.\"guidEchipa\", echipa.\"numeEchipa\", elev.nume, elev.scoala, \"jucatorActiv\".tip \nFROM jucator, echipa, elev, \"jucatorActiv\" \nWHERE @jucatorActivGuid = jucator.guid AND jucator.guid = \"jucatorActiv\".guid AND jucator.guid = elev.guid AND echipa.\"guidEchipa\" = jucator.\"guidEchipa\";";
                    using var cmd = new NpgsqlCommand(select_jucator_sql, con);
                    using var rdr = cmd.ExecuteReader();
                    Elev elev = new Elev(rdr.GetString(5), rdr.GetString(6));
                    elev.ID = rdr.GetGuid(0);

                    Echipa echipa = new Echipa(rdr.GetString(4));
                    echipa.ID = rdr.GetGuid(3);

                    Jucator j = new Jucator(echipa, elev);

                    return new JucatorActiv(rdr.GetGuid(2), rdr.GetInt32(1), rdr.GetString(7), j);
                        
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public void save(JucatorActiv entity)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    Guid guid = entity.ID;
                    Guid guidMeci = entity.getIdMeci;
                    int nrPuncteInscrise = entity.getNrPuncteInscrise;
                    String tip = entity.Tip;

                    String save_SQL = "INSERT INTO \"jucatorActiv\"(\"guid\", \"guidMeci\", \"nrPuncteInscrise\", \"tip\") " +
                              "VALUES(@jucatorGuid,@meciGuid,@nrPctInscrise,CAST(@tipJ AS varchar) ) ";

                    using var cmd = new NpgsqlCommand(save_SQL, con);

                    cmd.Parameters.AddWithValue("jucatorGuid", guid);
                    cmd.Parameters.AddWithValue("meciGuid", guidMeci);
                    cmd.Parameters.AddWithValue("nrPctInscrise", nrPuncteInscrise);
                    cmd.Parameters.AddWithValue("tipJ", tip);
                    

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
        }
    }
}
