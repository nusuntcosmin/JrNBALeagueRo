using JrNBALeagueRo.repository.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.repository.factory
{
    public class RepositoryFactory
    {
        private RepositoryFactory()
        {

        }

        private static RepositoryFactory instance = new RepositoryFactory();
        public static RepositoryFactory Instance { get { return instance; } }

        public static RepositoryDatabaseEchipe getRepoEchipa()
        {
            return new RepositoryDatabaseEchipe("postgres", "academic", "localhost", "parolaMea123", 5432);
        }

        public static RepositoryDatabaseElevi getRepoElevi()
        {
            return new RepositoryDatabaseElevi("postgres", "academic", "localhost", "parolaMea123", 5432);
        }

        internal static RepositoryDatabaseJucatori getRepoJucatori()
        {
            return new RepositoryDatabaseJucatori("postgres", "academic", "localhost", "parolaMea123", 5432);
        }

        internal static RepositoryDatabaseJucatoriActivi getRepoJucatoriActivi()
        {
            return new RepositoryDatabaseJucatoriActivi("postgres", "academic", "localhost", "parolaMea123", 5432);
        }

        internal static RepositoryDatabaseMeciuri getRepoMeciuri()
        {
            return new RepositoryDatabaseMeciuri("postgres", "academic", "localhost", "parolaMea123", 5432);
        }


    }
}
