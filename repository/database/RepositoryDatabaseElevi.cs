using JrNBALeagueRo.domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace JrNBALeagueRo.repository.database
{
    public class RepositoryDatabaseElevi : IRepository<Guid, Elev>
    {
        private String userID;
        private String database;
        private String host;
        private String password;
        private int port;

        public RepositoryDatabaseElevi(String userID,String database, String host, String password, int port)
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
   
        public IEnumerable<Elev> findAll()
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();


                List<Elev> listaElevi = new List<Elev>();
                using (con)
                {
                    const String select_SQL = "SELECT * from elev";

                    using var cmd = new NpgsqlCommand(select_SQL, con);
                    using NpgsqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Elev e = new Elev(rdr.GetString(1), rdr.GetString(2));
                        e.ID = rdr.GetGuid(0);

                        listaElevi.Add(e);

                    }
                }
                return listaElevi;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public Elev findOne(Guid id)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    const String select_one_SQL = "SELECT * FROM elev " +
                                                  "WHERE \"guid\" = @elevGuid ;";

                    using var cmd = new NpgsqlCommand(select_one_SQL, con);

                    cmd.Parameters.AddWithValue("elevGuid", id);

                    using var rdr = cmd.ExecuteReader();

                    Elev foundElev = new Elev(rdr.GetString(1), rdr.GetString(2));
                    foundElev.ID = rdr.GetGuid(0);

                    return foundElev;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public void save(Elev entity)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    Guid guid = entity.ID;
                    String nume = entity.Nume;
                    String scoala = entity.Scoala;

                    String save_SQL = "INSERT INTO elev(\"guid\", \"nume\", \"scoala\") " +
                              "VALUES(@elevGuid, @elevNume, @elevScoala) ";

                    using var cmd = new NpgsqlCommand(save_SQL, con);

                    cmd.Parameters.AddWithValue("elevGuid", guid);
                    cmd.Parameters.AddWithValue("elevNume", nume);
                    cmd.Parameters.AddWithValue("elevScoala", scoala);

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                
            }
           
        }
    }
}
