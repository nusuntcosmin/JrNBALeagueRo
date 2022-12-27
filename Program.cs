using JrNBALeagueRo.repository.database;
using JrNBALeagueRo.repository.factory;
using JrNBALeagueRo.service;
namespace JrNBALeagueRo
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Service srv = new Service(RepositoryFactory.getRepoJucatori(),RepositoryFactory.getRepoJucatoriActivi(),
                                      RepositoryFactory.getRepoMeciuri(),RepositoryFactory.getRepoEchipa(),RepositoryFactory.getRepoElevi());

            //utils.Utils.addEchipe(ref srv);
            //utils.Utils.addJucatori(ref srv);
            //utils.Utils.addMeciuri(ref srv);
            //utils.Utils.addJucatoriActivi(ref srv);
            Application.Run(new AppGUI(ref srv));
           
        }
    }
}