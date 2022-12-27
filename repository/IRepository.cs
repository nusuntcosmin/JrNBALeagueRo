using JrNBALeagueRo.domain;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.repository
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        void save(E entity);
        E findOne(ID id);
        IEnumerable<E> findAll();
    }
}
