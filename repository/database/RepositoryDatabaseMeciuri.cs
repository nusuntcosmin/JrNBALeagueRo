using JrNBALeagueRo.domain;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.repository.database
{
    internal class RepositoryDatabaseMeciuri : IRepository<Guid, Meci>
    {
        private String userID;
        private String database;
        private String host;
        private String password;
        private int port;

        public RepositoryDatabaseMeciuri(string userID, string database, string host, string password, int port)
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
        public IEnumerable<Meci> findAll()
            {
                try
                {
                    NpgsqlConnection con = GetConnection();
                    con.Open();


                    List<Meci> listaMeci = new List<Meci>();
                    using (con)
                    {
                        const String select_SQL = "SELECT meci.\"guidMeci\", meci.\"guidEchipaGazda\", meci.\"guidEchipaOaspete\", e1.\"numeEchipa\", e2.\"numeEchipa\", meci.\"dataMeci\" \nFROM meci,echipa e1,echipa e2 \nWHERE meci.\"guidEchipaGazda\" = e1.\"guidEchipa\" AND meci.\"guidEchipaOaspete\" = e2.\"guidEchipa\" ;";

                        using var cmd = new NpgsqlCommand(select_SQL, con);
                        using NpgsqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Echipa echipaGazda = new Echipa(rdr.GetString(3));
                            echipaGazda.ID = rdr.GetGuid(1);

                            Echipa echipaOaspete = new Echipa(rdr.GetString(4));
                            echipaOaspete.ID = rdr.GetGuid(2);

                            Meci meci = new Meci(echipaOaspete, echipaGazda, rdr.GetDateTime(5));
                            meci.ID = rdr.GetGuid(0);

                            listaMeci.Add(meci);
                        }

                        return listaMeci;
                    }
                
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return null;
                }
            }

        public Meci findOne(Guid id)
        {
                NpgsqlConnection con = GetConnection();
                con.Open();
                using (con)
                {
                    const String select_SQL = "SELECT meci.\"guidMeci\", meci.\"guidEchipaGazda\", meci.\"guidEchipaOaspete\", e1.\"numeEchipa\", e2.\"numeEchipa\", meci.\"dataMeci\" \n" +
                        "FROM meci,echipa e1,echipa e2 \n" +
                        "WHERE  meci.\"guidEchipaGazda\" = e1.\"guidEchipa\" AND meci.\"guidEchipaOaspete\" = e2.\"guidEchipa\" ";
                    using var cmd = new NpgsqlCommand(select_SQL, con);

                    
                    using NpgsqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                       

                        Echipa echipaGazda = new Echipa(rdr.GetString(3));
                        echipaGazda.ID = rdr.GetGuid(1);

                        Echipa echipaOaspete = new Echipa(rdr.GetString(4));
                        echipaOaspete.ID = rdr.GetGuid(2);

                        Meci meci = new Meci(echipaOaspete, echipaGazda, rdr.GetDateTime(5));
                        meci.ID = rdr.GetGuid(0);

                        if (meci.ID.Equals(id))
                            return meci;
                        
                    }

                    throw new Exception("No row found with this ID ");
                    
                }
                
        }

        public void save(Meci entity)
        {
            try
            {
                NpgsqlConnection con = GetConnection();
                con.Open();

                using (con)
                {
                    Guid guidMeci = entity.ID;
                    DateTime date = entity.getDataMeci;
                    Guid guidEchipaGazda = entity.getEchipaGazda.ID;
                    Guid guidEchipaOaspete = entity.GetEchipaOaspete.ID;

                    String save_SQL = "INSERT INTO meci(\"guidMeci\",\"guidEchipaGazda\",\"guidEchipaOaspete\",\"dataMeci\")\n" +
                                      "VALUES(@meciGuid,@echipaGguid,@echipaOguid,@meciData)";

                    using var cmd = new NpgsqlCommand(save_SQL, con);

                    cmd.Parameters.AddWithValue("meciGuid", guidMeci);
                    cmd.Parameters.AddWithValue("echipaGguid", guidEchipaGazda);
                    cmd.Parameters.AddWithValue("echipaOguid", guidEchipaOaspete);
                    cmd.Parameters.AddWithValue("meciData",date);
                   

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
