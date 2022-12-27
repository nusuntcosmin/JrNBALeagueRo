using JrNBALeagueRo.domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.repository.database
{
    public class RepositoryDatabaseEchipe : IRepository<Guid, Echipa>
    {
        private String userID;
        private String database;
        private String host;
        private String password;
        private int port;

        public RepositoryDatabaseEchipe(String userID, String database, String host, String password, int port)
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
        public IEnumerable<Echipa> findAll()
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();


                List<Echipa> listaEchipe = new List<Echipa>();
                using (con)
                {
                    const String select_SQL = "SELECT * from echipa";

                    using var cmd = new NpgsqlCommand(select_SQL, con);
                    using NpgsqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Echipa e = new Echipa(rdr.GetString(1));
                        e.ID = rdr.GetGuid(0);

                        listaEchipe.Add(e);

                    }
                }
                return listaEchipe;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public Echipa findOne(Guid id)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    const String select_one_SQL = "SELECT * FROM echipa " +
                                                  "WHERE \"guid\" = @echipaGuid ;";

                    using var cmd = new NpgsqlCommand(select_one_SQL, con);

                    cmd.Parameters.AddWithValue("echipaGuid", id);

                    using var rdr = cmd.ExecuteReader();

                    Echipa foundEchipa = new Echipa(rdr.GetString(1));
                    foundEchipa.ID = id;
                    return foundEchipa;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public void save(Echipa entity)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    Guid guid = entity.ID;
                    String nume = entity.Nume;
                    

                    String save_SQL = "INSERT INTO echipa(\"guidEchipa\", \"numeEchipa\") " +
                              "VALUES(@echipaGuid,@echipaNume) ";

                    using var cmd = new NpgsqlCommand(save_SQL, con);

                    cmd.Parameters.AddWithValue("echipaGuid", guid);
                    cmd.Parameters.AddWithValue("echipaNume", nume);
                   
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
