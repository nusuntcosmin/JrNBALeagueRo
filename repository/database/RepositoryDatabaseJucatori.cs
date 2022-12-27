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
    internal class RepositoryDatabaseJucatori : IRepository<Guid, Jucator>
    {
        private String userID;
        private String database;
        private String host;
        private String password;
        private int port;

        public RepositoryDatabaseJucatori(string userID, string database, string host, string password, int port)
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
        public IEnumerable<Jucator> findAll()
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();


                List<Jucator> listaJucator = new List<Jucator>();
                using (con)
                {
                    const string select_jucator_sql = "SELECT jucator.guid, echipa.\"guidEchipa\", echipa.\"numeEchipa\", elev.nume, elev.scoala \n FROM jucator, echipa, elev \n WHERE jucator.guid = elev.guid AND echipa.\"guidEchipa\" = jucator.\"guidEchipa\" ;";
                    using var cmd = new NpgsqlCommand(select_jucator_sql, con);
                    using var rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        Elev elev = new Elev(rdr.GetString(3), rdr.GetString(4));
                        elev.ID = rdr.GetGuid(0);

                        Echipa echipa = new Echipa(rdr.GetString(2));
                        echipa.ID = rdr.GetGuid(1);

                        Jucator j = new Jucator(echipa, elev);

                        listaJucator.Add(j);
                    }
                }
                return listaJucator;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public Jucator findOne(Guid id)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    const string select_jucator_sql = "SELECT jucator.guid, echipa.\"guidEchipa\", echipa.\"numeEchipa\", elev.nume, elev.scoala \n FROM jucator, echipa, elev \n WHERE jucator.guid = @jucatorGuid AND jucator.guid = elev.guid AND echipa.\"guidEchipa\" = jucator.\"guidEchipa\" ;";
                    using var cmd = new NpgsqlCommand(select_jucator_sql, con);
                    using var rdr = cmd.ExecuteReader();


                    Elev elev = new Elev(rdr.GetString(3), rdr.GetString(4));
                    elev.ID = rdr.GetGuid(0);

                    Echipa echipa = new Echipa(rdr.GetString(2));
                    echipa.ID = rdr.GetGuid(1);

                    Jucator j = new Jucator(echipa, elev);

                    return j;
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public void save(Jucator entity)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    Guid guid = entity.ID;
                    Guid guidEchipa = entity.Echipa.ID;

                    String save_SQL = "INSERT INTO jucator(\"guid\", \"guidEchipa\") " +
                              "VALUES(@guidJucator,@guidEchipa) ;";

                    using var cmd = new NpgsqlCommand(save_SQL, con);

                    cmd.Parameters.AddWithValue("guidJucator", guid);
                    cmd.Parameters.AddWithValue("guidEchipa", guidEchipa);
                    

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
